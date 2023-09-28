using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PixelRuler
{
	public partial class UserPoints : Form
	{
		public List<Point> Puntos { get; set; } //<- User defined points to save/export
		public event EventHandler PointsChanged = delegate { }; //<- Evento con Manejador, para evitar los Null

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

			PointsChanged?.Invoke(this.Puntos, null);
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
		private void cmdImportPoints_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog OFDialog = new OpenFileDialog()
				{
					Filter = "JSON Data|*.json;*.txt",
					FilterIndex = 0,
					DefaultExt = "json",
					AddExtension = true,
					CheckPathExists = true,
					CheckFileExists = true,
					FileName = string.Empty,
					InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
				};
				if (OFDialog.ShowDialog() == DialogResult.OK)
				{
					Puntos = DeSerialize_FromJSON<List<Point>>(OFDialog.FileName);
					RefreshDataSource();
				}
			}
			catch (Exception)
			{
				throw;
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
		private void cmdImportPoints_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Import Points..";
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

		
	}
}
