using PixelRuler.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/*	SIMPLE AND EASY TOOL TO MEASURE PIXELS ON AN IMAGE
 *	Also able to store and get Points set on the image.
 *	Author:  Jhollman Chacon (Blue Mystic)  2023     */ 
namespace PixelRuler
{
	public partial class Form1 : Form
	{
		#region Public Properties

		public Image LoadedImage { get; set; } //<- Image loaded
		public RulerData ImageData { get; set; } //<- Data asociated to the loaded image

		#endregion

		#region Private Members

		private List<Line> lines = new List<Line>(); //<- Mouse Position Guide Lines
		private UserPoints UserPointsForm; //<- holds and manage the points added by the user.

		#endregion

		#region Constructors

		public Form1()
		{
			InitializeComponent(); 
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			/* INITIALIZES THE POSITION GUIDE LINES  */

			// lines[0] = Horizontal Position Guide Line
			lines.Add(new Line { Start = new Point(0,0), End = new Point(0,0) });

			// lines[1] = Vertical Position Guide Line
			lines.Add(new Line { Start = new Point(0, 0), End = new Point(0, 0) });
		}

		#endregion

		#region Methods

		/// <summary>Shows a new windows containing all the points the user had added on the loaded image.</summary>
		private void ShowPointsForm()
		{
			if (this.UserPointsForm is null || this.UserPointsForm.Visible == false)
			{
				UserPointsForm = new UserPoints(this.ImageData);
				UserPointsForm.PointsChanged += UserPointsForm_PointsChanged;
				UserPointsForm.Show();

				if (this.WindowState == FormWindowState.Normal)
				{
					UserPointsForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
				}
			}
		}

		/// <summary>Crea una instancia de un Objeto leyendo sus datos desde un archivo JSON.
		/// <para>Object type must have a parameterless constructor.</para></summary>
		/// <typeparam name="T">The type of object to read from the file.</typeparam>
		/// <param name="filePath">The file path to read the object instance from.</param>
		/// <returns>Returns a new instance of the object read from the Json file.</returns>
		public T DeSerialize_FromJSON<T>(string filePath) where T : new()
		{
			System.IO.TextReader reader = null;
			try
			{
				reader = new System.IO.StreamReader(filePath);
				var fileContents = reader.ReadToEnd();
				return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(fileContents);
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
		}

		private void UserPointsForm_PointsChanged(object sender, EventArgs e)
		{
			//this event occours when the points are changed by the 'UserPointsForm'
			if (sender != null) //<- Contains the Points
			{
				this.ImageData.Puntos = sender as List<ImagePoint>;
			}
		}

		#endregion

		#region Control events

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			/* SET THE POSITIONS FOR THE MOUSE GUIDE LINES  */
			if (LoadedImage != null)
			{
				this.lblLocation.Text = string.Format("X: {0}, Y: {1}", e.X, e.Y);

				// lines[0] = Horizontal Position Guide
				lines[0].Start = new Point(0, e.Y);
				lines[0].End = new Point(LoadedImage.Width - 1, e.Y);

				// lines[1] = Vertical Position Guide
				lines[1].Start = new Point(e.X, 0);
				lines[1].End = new Point(e.X, LoadedImage.Height - 1);

				pictureBox1.Invalidate(); //<- Re-paint the picture
			}
		}
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (LoadedImage != null)
			{
				//Set High Quality for Drawings:
				e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				//Visible Locations:
				var visY = Math.Abs(this.pictureBox1.Bounds.Y);
				var visX = Math.Abs(this.pictureBox1.Bounds.X);

				using (SolidBrush brush = new SolidBrush(this.ImageData.ForeColor))
				{
					using (Pen pen = new Pen(this.ImageData.ForeColor, 1.0F))
					{
						// 1. Vertical Ruler
						for (int i = 0; i < LoadedImage.Height; i += 5)
						{
							if (i % 5 == 0) // <- Minor line (3px width) each 5 pixels
							{
								e.Graphics.DrawLine(pen, new Point(visX, i), new Point(visX +3, i));																
							}
							if (i % 10 == 0) //<- Mayor Line (6px width) each 10 pixels
							{
								e.Graphics.DrawLine(pen, new Point(visX, i), new Point(visX +6, i));
							}
							if (i % 50 == 0) //<- Number text each 50 pixels
							{
								if (i > 0) //<- not enough space to write the '0' so we don't
								{
									e.Graphics.DrawString(i.ToString(), this.Font, brush, new Point(visX +7, i - 6));
								}								
							}
						}

						// 2. Horizontal Ruler						
						for (int i = 0; i < LoadedImage.Width; i++)
						{
							if (i % 5 == 0) // <- Minor line (3px width) each 5 pixels
							{								
								e.Graphics.DrawLine(pen, new Point(i, visY), new Point(i, visY + 3));
							}
							if (i % 10 == 0) //<- Mayor Line (6px width) each 10 pixels
							{
								e.Graphics.DrawLine(pen, new Point(i, visY), new Point(i, visY + 6));
							}
							if (i % 50 == 0) //<- Number text each 50 pixels
							{
								if (i > 0)
								{
									int spam = (i < 100) ? 8 : 10; //<- Horizontal span for the text, text size dependant
										spam = (i >= 1000) ? 14 : spam; //<- for 1.000px and more

									e.Graphics.DrawString(i.ToString(), this.Font, brush, new Point(i -spam, visY + 7));
								}
							}
						}

						// 3. Mouse Position Guide Lines: (Horizontal & Vertical at Mouse Position)
						foreach (var line in lines)
						{
							e.Graphics.DrawLine(pen, line.Start, line.End);
						}

						// 4. User Points:
						if (this.ImageData.Puntos != null)
						{
							foreach (var punto in this.ImageData.Puntos)
							{
								// Draws a 7x7px circle arount the point:
								e.Graphics.DrawEllipse(pen, new RectangleF(new Point(punto.Location.X -3, punto.Location.Y-3), new Size(7,7) ));

								if (this.cmdShowPointLabels.Checked)
								{
									//Draws the name over each point:
									e.Graphics.DrawString(punto.Name, this.Font, brush, new Point(punto.Location.X - 4, punto.Location.Y - 15));
								}
							}
						}
					}
				}				
			}			
		}
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			ShowPointsForm();
			UserPointsForm.AddPoint(e.Location);
		}
		
		private void cmdLoadImage_Click(object sender, EventArgs e)
		{
			/* LOADS AN IMAGE TO WORK WITH  */
			string LastPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (this.ImageData != null && !string.IsNullOrEmpty(this.ImageData.FileName))
			{
				LastPath = System.IO.Path.GetDirectoryName(this.ImageData.FileName);
			}
			OpenFileDialog OFDialog = new OpenFileDialog()
			{
				Filter = "Supported Files|*.png;*.jpg;*.bmp;*.json|JSON Data|*.json",
				FilterIndex = 0,
				DefaultExt = "png",
				AddExtension = true,
				CheckPathExists = true,
				CheckFileExists = true,
				InitialDirectory = LastPath
			};

			if (OFDialog.ShowDialog() == DialogResult.OK)
			{
				// If the opened file is a json, it gets deserialized
				// if it is an image, then it gets loaded
				string Ext = System.IO.Path.GetExtension(OFDialog.FileName); //<- File Extension
				ImageData = (Ext.ToLower() == ".json") ?
					DeSerialize_FromJSON<RulerData>(OFDialog.FileName) :
					new RulerData(OFDialog.FileName);

				if (ImageData.Puntos != null && ImageData.Puntos.Count > 0)
				{
					ShowPointsForm();
				}

				this.cmdShowPointLabels.Checked = ImageData.ShowLabels;
				this.LoadedImage = Image.FromFile(ImageData.FileName);
				this.cmdForeColor.BackColor = ImageData.ForeColor;
				
				this.pictureBox1.Image = LoadedImage;
				this.panel1.AutoScroll = true;

				string file_name = System.IO.Path.GetFileName(ImageData.FileName); //<- Nombre del Archivo con Extension (Sin Ruta)

				lblImageSize.Text = string.Format("Image: ({0:n0}x{1:n0} px)", LoadedImage.Width, LoadedImage.Height);
				this.Text = string.Format("Image Pixel Ruler [{0}]", file_name);
			}
		}
		private void cmdForeColor_Click(object sender, EventArgs e)
		{
			/* CHANGE THE COLOR TO DRAW STUFF  */
			ColorDialog Dialog = new ColorDialog()
			{
				AnyColor = true,
				FullOpen = true,
				AllowFullOpen = true,
				Color = this.ImageData.ForeColor
			};

			if (Dialog.ShowDialog() == DialogResult.OK)
			{
				this.ImageData.ForeColor = Dialog.Color;
				this.cmdForeColor.BackColor = Dialog.Color;
				this.pictureBox1.Refresh();

				if (this.UserPointsForm != null || this.UserPointsForm.Visible != false)
				{
					this.UserPointsForm.ForeColor = Dialog.Color;
				}
			}
		}

		#endregion
	}
}
