using PixelRuler.BusinesObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PixelRuler
{
	public partial class UserPoints : Form
	{
		#region Public Properties

		public string FileName { get; set; } //<- Full path of the loaded image file.
		public RulerData ImageData { get; set; } //<- Data asociated to the loaded image
		public List<ImagePoint> Puntos { get; set; } //<- User defined points to save/export
		public event EventHandler PointsChanged = delegate { }; //<- Event triggers whenever the Points are changed.

		public UserPoints()
		{
			InitializeComponent();
			Puntos = new List<ImagePoint>();
		}
		public UserPoints(RulerData pImageData)
		{
			InitializeComponent();
			ImageData = pImageData;
			Puntos = ImageData.Puntos;
		}

		#endregion

		#region Constructors

		private void UserPoints_Load(object sender, EventArgs e)
		{
			// Imprime los nombres para los primeros 1000 índices.
			//for (int i = 1; i <= 1000; i++)
			//{
			//	string column_name = GenerateColumnName(i);
			//	Console.WriteLine(string.Format("{0:n0} - {1} | {2}", i, column_name, NumberFromColumn(column_name) ));
			//}
		}
		private void UserPoints_Shown(object sender, EventArgs e)
		{
			RefreshDataSource();
		}

		#endregion

		#region Methods

		/// <summary>Adds a new Point to the collection.</summary>
		/// <param name="pPoint">Point to be added.</param>
		public void AddPoint(Point pPoint)
		{
			if (Puntos == null) Puntos = new List<ImagePoint>();	
			Puntos.Add(new ImagePoint(GenerateColumnName(Puntos.Count +1), pPoint));			
			RefreshDataSource();
		}

		/// <summary>Shows the Collection of Point in a ListBox.</summary>
		public void RefreshDataSource()
		{
			if (Puntos != null && Puntos.Count > 0)
			{
				this.listBox1.Items.Clear();
				foreach (var punto in Puntos)
				{
					this.listBox1.Items.Add(punto);
				}
				this.listBox1.Refresh();
			}

			PointsChanged?.Invoke(this.Puntos, null);
		}

		/// <summary>Generates Excel style Column names based on an index number.</summary>
		/// <param name="column">Number of the column to name, idex start with 1.</param>
		/// <returns>A-Z, AA-AZ, BA-BZ,..ZA-ZZ, AAA-AAZ,..ABA-ABZ,..AZA-AZZ,..</returns>
		private string GenerateColumnName(int column)
		{			
			if (column == 0) return ""; /* THIS IS A RECURSIVE METHOD */

			int currentLetterNumber = (column - 1) % 26;
			char currentLetter = (char)(currentLetterNumber + 65);

			return GenerateColumnName((column - (currentLetterNumber + 1)) / 26) + currentLetter;
		}

		/// <summary>Returns the Excel style Column index for a named column.</summary>
		/// <param name="column">Column Name: A-Z, AA-AZ, BA-BZ,..ZA-ZZ,..</param>
		/// <returns>1 based index of the column.</returns>
		private int NumberFromColumn(string column)
		{
			int retVal = 0;
			string col = column.ToUpper();
			for (int iChar = col.Length - 1; iChar >= 0; iChar--)
			{
				char colPiece = col[iChar];
				int colNum = colPiece - 64;
				retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
			}
			return retVal;
		}

		/// <summary>Crea una instancia de un Objeto leyendo sus datos desde un archivo JSON.
		/// <para>Object type must have a parameterless constructor.</para></summary>
		/// <typeparam name="T">The type of object to read from the file.</typeparam>
		/// <param name="filePath">The file path to read the object instance from.</param>
		/// <returns>Returns a new instance of the object read from the Json file.</returns>
		private T DeSerialize_FromJSON<T>(string filePath) where T : new()
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

		#endregion

		#region Point Editor

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			/* Allowes to edit the selected point location  */
			if (listBox1.SelectedItem != null)
			{
				ImagePoint Sel = (ImagePoint)listBox1.SelectedItem;
				panelPointEditor.Visible = true;

				lbPointName.Text = string.Format("Point {0}:", Sel.Name);
				txtPosX.Value = Sel.Location.X;
				txtPosY.Value = Sel.Location.Y;
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
				ImageData.Puntos = this.Puntos;

				string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ImageData, Newtonsoft.Json.Formatting.Indented);
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
		{ /*
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
			}*/
		}
		private void cmdImportPoints_MouseMove(object sender, MouseEventArgs e)
		{
			this.lblDescription.Text = "Import Points..";
		}

		#endregion		
	}
}
