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
		public Image LoadedImage { get; set; } //<- Image loaded
		public Color ForeColorEx { get; set; } = Color.Orange; //<- Color to draw rulers, guides and text.
		public List<ImagePoint> Puntos { get; set; } //<- User defined points to save/export

		private List<Line> lines = new List<Line>(); //<- Mouse Position Guide Lines
		private UserPoints UserPointsForm; //<- holds and manage the points added by the user.
		private string OpenImagePath = string.Empty; //<- Full path of the opened image


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

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			/* SET THE POSITIONS FOR THE MOUSE POSITION GUIDE LINES  */
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
				//e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
				//e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				//e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				//e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				//Visible Locations:
				var visY = Math.Abs(this.pictureBox1.Bounds.Y);
				var visX = Math.Abs(this.pictureBox1.Bounds.X);

				using (SolidBrush brush = new SolidBrush(ForeColorEx))
				{
					using (Pen pen = new Pen(ForeColorEx, 1.0F))
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
								if (i > 0) //<- no space to write the '0'
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
						if (Puntos != null)
						{
							foreach (var punto in Puntos)
							{
								// Draws a 7x7px circle arount the point:
								e.Graphics.DrawEllipse(pen, new RectangleF(new Point(punto.Location.X -3, punto.Location.Y-3), new Size(7,7)));
							}
						}
					}
				}				
			}			
		}
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (Puntos is null)
			{
				Puntos = new List<ImagePoint>();
				UserPointsForm = new UserPoints(Puntos);
				UserPointsForm.PointsChanged += UserPointsForm_PointsChanged;
				UserPointsForm.Show();
			}
			UserPointsForm.AddPoint(e.Location);
		}

		private void UserPointsForm_PointsChanged(object sender, EventArgs e)
		{
			//this event occours when the points are changed by the 'UserPointsForm'
			if (sender != null) //<- Contains the Points
			{
				Puntos = sender as List<ImagePoint>;
			}
		}

		private void cmdLoadImage_Click(object sender, EventArgs e)
		{
			/* LOADS AN IMAGE TO WORK WITH  */
			string LastPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (!string.IsNullOrEmpty(this.OpenImagePath))
			{
				LastPath = System.IO.Path.GetDirectoryName(this.OpenImagePath);
			}
			OpenFileDialog OFDialog = new OpenFileDialog()
			{
				Filter = "Supported Images|*.png;*.jpg;*.bmp",
				FilterIndex = 0,
				DefaultExt = "png",
				AddExtension = true,
				CheckPathExists = true,
				CheckFileExists = true,
				InitialDirectory = LastPath
			};

			if (OFDialog.ShowDialog() == DialogResult.OK)
			{
				this.OpenImagePath = OFDialog.FileName;
				this.LoadedImage = Image.FromFile(OFDialog.FileName);
				this.pictureBox1.Image = LoadedImage;
				this.panel1.AutoScroll = true;

				string file_name = System.IO.Path.GetFileName(OFDialog.FileName); //<- Nombre del Archivo con Extension (Sin Ruta)

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
				Color = ForeColorEx
			};

			if (Dialog.ShowDialog() == DialogResult.OK)
			{
				this.ForeColorEx = Dialog.Color;
				this.cmdForeColor.BackColor = Dialog.Color;
				this.pictureBox1.Refresh();
			}
		}
	}

	/// <summary>Locations for theMouse Position Guide Lines.</summary>
	public class Line
	{
		public Point Start { get; set; }
		public Point End { get; set; }
	}

	/// <summary>Point set on the image by the User</summary>
	public class ImagePoint
	{
		public ImagePoint() { }
		public ImagePoint(string pName, Point pLocation) 
		{
			Name = pName;
			Location = pLocation;
		}

		public string Name { get; set; } = string.Empty;
		public Point Location { get; set; } = Point.Empty;

		public override string ToString()
		{
			return String.Format("{0}: (X:{1}, Y:{2})", Name, Location.X, Location.Y);
		}
	}
}
