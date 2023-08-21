using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PixelRuler
{
	public partial class UserPoints : Form
	{
		public List<Point> Puntos { get; set; } //<- User defined points to save/export

		public UserPoints()
		{
			InitializeComponent();
		}
		public UserPoints(List<Point> pPuntos)
		{
			InitializeComponent();
			Puntos = pPuntos;
		}

		private void UserPoints_Load(object sender, EventArgs e)
		{

		}
		private void UserPoints_Shown(object sender, EventArgs e)
		{	
		}

		public void AddPoint(Point pPoint)
		{
			if (Puntos == null) Puntos = new List<Point>();
			Puntos.Add(pPoint);

			RefreshDataSource();
		}

		public void RefreshDataSource()
		{
			this.listBox1.Items.Clear();
			foreach (var punto in Puntos)
			{
				this.listBox1.Items.Add(punto);
			}
			this.listBox1.Refresh();
		}


		private void cmdremoveSelected_Click(object sender, EventArgs e)
		{			
			if (Puntos != null && Puntos.Count > 0)
			{
				Point Fila = (Point)listBox1.SelectedItems[0];
				Puntos.Remove(Fila);
				RefreshDataSource();
			}
		}

		private void cmdClearAll_Click(object sender, EventArgs e)
		{
			Puntos = new List<Point>();
			this.listBox1.Items.Clear();
		}

		private void cmdExport_Click(object sender, EventArgs e)
		{
			if (Puntos != null && Puntos.Count > 0)
			{
				string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Puntos);
				if (!string.IsNullOrEmpty(jsonString))
				{
					SaveFileDialog SFDialog = new SaveFileDialog()
					{
						Filter = "JSON Data|*.json",
						FilterIndex = 0,
						DefaultExt = "json",
						AddExtension = true,
						CheckPathExists = true,
						OverwritePrompt = true,
						FileName = string.Format("MyPointLocations"),
						InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
					};
					if (SFDialog.ShowDialog() == DialogResult.OK)
					{
						System.IO.File.WriteAllText(SFDialog.FileName, jsonString, System.Text.Encoding.UTF8);
					}
				}
			}
			
		}

		private void cmdremoveSelected_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Remove Selected Point.";
		}

		private void cmdClearAll_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Remove All Points.";
		}

		private void cmdExport_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Export Points..";
		}
	}
}
