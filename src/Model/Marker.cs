using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Model
{
	//маркер
	public class Marker
	{
		public const int Size = 7;

		/// <summary>
		/// Координата X.
		/// </summary>
		public float X { get; set; }

		public float Y { get; set; }

		public Marker(float x, float y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Рисует красный квадрат для изменения расподожения / длинны стрелки
		/// </summary>
		/// <param name="gr"></param>
		public void Draw(Graphics gr)
		{
			gr.DrawRectangle(Pens.Red, X - Size / 2, Y - Size / 2, Size, Size);
		}

		/// <summary>
		/// проверяет чтобы координаты точки попали в середину.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public bool HitTest(Point p)
		{
			return Math.Abs(p.X - X) <= Size / 2 && Math.Abs(p.Y - Y) <= Size / 2;
		}

		/// <summary>
		/// Какое-то переопределение.
		/// </summary>
		/// <param name="m"></param>
		public static implicit operator PointF(Marker m)
		{
			return new PointF(m.X, m.Y);
		}

		/// <summary>
		/// меняет расположение на заданные координаты
		/// </summary>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public void Move(float dx, float dy)
		{
			X += dx;
			Y += dy;
		}
	}
}
