using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PixelRuler
{
	public partial class UserPoints : Form
	{
		public List<ImagePoint> Puntos { get; set; } //<- User defined points to save/export
		public event EventHandler PointsChanged = delegate { }; //<- Evento con Manejador, para evitar los Null

		public UserPoints()
		{
			InitializeComponent();
		}
		public UserPoints(List<ImagePoint> pPuntos)
		{
			InitializeComponent();
			Puntos = pPuntos;
		}

		private char[] caracteres = new char[26];

		private void UserPoints_Load(object sender, EventArgs e)
		{		
			//Letters used for Points names: A-Z
			for (int i = 65; i <= 90; i++)
			{
				caracteres[i - 65] = (char)i;
			}

			// Imprime los nombres para los primeros 100 índices.
			//for (int i = 0; i < 100; i++)
			//{
			//	Console.WriteLine(GenerateName(i));
			//}
		}
		private void UserPoints_Shown(object sender, EventArgs e)
		{	
		}

		#region Methods

		public void AddPoint(Point pPoint)
		{
			if (Puntos == null) Puntos = new List<ImagePoint>();	
			Puntos.Add(new ImagePoint(GenerateName(Puntos.Count), pPoint));			
			RefreshDataSource();
		}

		// Genera un nombre para un índice dado.
		private string GenerateName(int indice)
		{
			// Calcula la letra inicial del nombre.
			int letra = indice % 26;

			// Calcula el número de veces que se repite la letra.
			int repeticiones = indice / 26;

			string nombre = string.Empty; 

			if (indice < 26)
			{
				nombre = caracteres[letra].ToString();
			}
			else 
			{
				// Concatena la letra inicial y el número de repeticiones.
				nombre = string.Format("{0}{1}", caracteres[repeticiones - 1], caracteres[letra]);
			}
			return nombre;
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

		#endregion

		#region Point Editor

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem != null)
			{
				Point Sel = (Point)listBox1.SelectedItem;
				panelPointEditor.Visible = true;
				txtPosX.Value = Sel.X;
				txtPosY.Value = Sel.Y;
			}
		}
		private void EditorOK_Click(object sender, EventArgs e)
		{
			Puntos[listBox1.SelectedIndex].Location = new Point( (int)txtPosX.Value, (int)txtPosY.Value);
			panelPointEditor.Visible = false;
			RefreshDataSource();
		}

		#endregion

		#region ToolBar Buttons

		private void cmdremoveSelected_Click(object sender, EventArgs e)
		{			
			if (Puntos != null && Puntos.Count > 0)
			{
				ImagePoint Fila = (ImagePoint)listBox1.SelectedItems[0];
				Puntos.Remove(Fila);
				RefreshDataSource();
			}
		}
		private void cmdremoveSelected_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Remove Selected Point.";
		}

		private void cmdClearAll_Click(object sender, EventArgs e)
		{
			Puntos = new List<ImagePoint>();
			this.listBox1.Items.Clear();
		}
		private void cmdClearAll_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Remove All Points.";
		}

		private void cmdExport_Click(object sender, EventArgs e)
		{
			if (Puntos != null && Puntos.Count > 0)
			{
				string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(Puntos, Newtonsoft.Json.Formatting.Indented);
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
		private void cmdExport_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Export Points..";
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
					Puntos = DeSerialize_FromJSON<List<ImagePoint>>(OFDialog.FileName);
					RefreshDataSource();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void cmdImportPoints_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Import Points..";
		}

		#endregion

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
