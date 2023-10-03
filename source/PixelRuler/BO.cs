using System;
using System.Collections.Generic;
using System.Drawing;

namespace PixelRuler.BusinesObjects
{
	/// <summary>Locations for the Mouse Position Guide Lines.</summary>
	public class Line
	{
		public Line() { Start = Point.Empty; End = Point.Empty; }

		/// <summary>Where the Line Starts.</summary>
		public Point Start { get; set; }

		/// <summary>Where the Line Ends.</summary>
		public Point End { get; set; }
	}

	/// <summary>Datos de la Imagen y sus Puntos Asociados</summary>
	public class RulerData
	{
		public RulerData() { }
		public RulerData(string pFileName)
		{
			FileName = pFileName;
			Puntos = new List<ImagePoint>();
		}

		/// <summary>Full path to the Loaded Image File.</summary>
		public string FileName { get; set; }

		/// <summary>Color to draw all the guides and texts.</summary>
		public Color ForeColor { get; set; } = Color.Orange;

		/// <summary>Show or hide the names of the user Points over the image.</summary>
		public bool ShowLabels { get; set; } = true;

		/// <summary>Collection of Point the added on the Image.</summary>
		public List<ImagePoint> Puntos { get; set; }
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

		/// <summary>Generated Name for the Point.</summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>Where the Point is over the image</summary>
		public Point Location { get; set; } = Point.Empty;

		public override string ToString()
		{
			// AB: (0, 0)
			return String.Format("{0}: ({1}, {2})", Name, Location.X, Location.Y);
		}
	}
}
