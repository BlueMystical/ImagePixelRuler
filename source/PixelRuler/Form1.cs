using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PixelRuler
{
	public partial class Form1 : Form
	{
		public Image LoadedImage { get; set; }
		public Color ForeColorEx { get; set; } = Color.Orange;
		public List<Point> Puntos { get; set; } //<- User defined points to save/export

		private List<Line> lines = new List<Line>(); // Position Guides

		private UserPoints UserPointsForm;

		public Form1()
		{
			InitializeComponent(); 
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// lines[0] = Horizontal Position Guide
			lines.Add(new Line { Start = new Point(0,0), End = new Point(0,0) });

			// lines[1] = Vertical Position Guide
			lines.Add(new Line { Start = new Point(0, 0), End = new Point(0, 0) });
		}

		private void cmdLoadImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFDialog = new OpenFileDialog()
			{
				Filter = "Supported Images|*.png;*.jpg;*.bmp",
				FilterIndex = 0,
				DefaultExt = "png",
				AddExtension = true,
				CheckPathExists = true,
				CheckFileExists = true,
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
			};

			if (OFDialog.ShowDialog() == DialogResult.OK)
			{
				System.IO.FileInfo file = new System.IO.FileInfo(OFDialog.FileName);
				LoadedImage = Image.FromFile(OFDialog.FileName);
				this.pictureBox1.Image = LoadedImage;
				this.panel1.AutoScroll = true;

				lblImageSize.Text = string.Format("Size: {0:n0} x {1:n0}px", LoadedImage.Width, LoadedImage.Height);
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (LoadedImage != null)
			{
				this.lblLocation.Text = string.Format("Pos X: {0}, Y: {1}", e.X, e.Y);

				// lines[0] = Horizontal Position Guide
				lines[0].Start = new Point(0, e.Y);
				lines[0].End = new Point(LoadedImage.Width - 1, e.Y);

				// lines[1] = Vertical Position Guide
				lines[1].Start = new Point(e.X, 0);
				lines[1].End = new Point(e.X, LoadedImage.Height - 1);

				pictureBox1.Invalidate();
			}
		}
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			if (LoadedImage != null)
			{
				using (SolidBrush brush = new SolidBrush(ForeColorEx))
				{
					using (Pen pen = new Pen(ForeColorEx, 1.0F))
					{
						// 1. Vertical Ruler
						for (int i = 0; i < LoadedImage.Height; i += 5)
						{
							if (i % 5 == 0) // <- Minor line each 5 pixels
							{
								e.Graphics.DrawLine(pen, new Point(0, i), new Point(3, i));
							}
							if (i % 10 == 0) //<- Mayor Line each 10 pixels
							{
								e.Graphics.DrawLine(pen, new Point(0, i), new Point(6, i));
							}
							if (i % 50 == 0) //<- Number text each 50 pixels
							{
								e.Graphics.DrawString(i.ToString(), this.Font, brush, new Point(7, i - 6));
							}
						}

						// 2. Horizontal Ruler
						for (int i = 0; i < LoadedImage.Width; i++)
						{
							if (i % 5 == 0) // <- Minor line each 5 pixels
							{
								e.Graphics.DrawLine(pen, new Point(i, 0), new Point(i, 3));
							}
							if (i % 10 == 0) //<- Mayor Line each 10 pixels
							{
								e.Graphics.DrawLine(pen, new Point(i, 0), new Point(i, 6));
							}
							if (i % 50 == 0) //<- Number text each 50 pixels
							{
								e.Graphics.DrawString(i.ToString(), this.Font, brush, new Point(i, 7));
							}
						}

						// Position Guides:
						foreach (var line in lines)
						{
							e.Graphics.DrawLine(pen, line.Start, line.End);
						}
					}
				}				
			}			
		}
		private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (Puntos == null)
			{
				Puntos = new List<Point>();
				UserPointsForm = new UserPoints(Puntos);
				UserPointsForm.Show();
			}
			UserPointsForm.AddPoint(e.Location);
		}

		private void cmdForeColor_Click(object sender, EventArgs e)
		{
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

	class Line
	{
		public Point Start { get; set; }
		public Point End { get; set; }
	}
}
