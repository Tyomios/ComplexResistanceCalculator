using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace Model
{
	/// <summary>
	/// Фигура, сформированная маркерами
	/// </summary>
	public abstract class Figure : List<Marker>
	{
		public GraphicsPath Path { get; private set; }
		public abstract void Build();

		public Figure()
		{
			Path = new GraphicsPath();
		}

		/// <summary>
		/// изменение расположения фигуры - каждый маркер перемещается на dx dy
		/// </summary>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public void Move(float dx, float dy)
		{
			foreach (var m in this)
				m.Move(dx, dy);

			Build();
		}
	}
}
