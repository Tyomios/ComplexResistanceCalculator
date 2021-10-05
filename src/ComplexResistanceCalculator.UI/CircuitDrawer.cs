using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
	
    public partial class CircuitDrawer : UserControl
	{
		public List<Figure> Figures { get; set; }

		private Figure selectedFigure;

		private Point startMouseDrag;

		private Bitmap plot;

		/// <summary>
		/// Координаты расположения элементов цепи для стартового размера окна.
		/// </summary>
		private List<Point> _userControlLocation = new List<Point>()
		{
			new Point(0, 0),
			new Point(15, 80),
			new Point(135, 80),
			new Point(255, 80),
			new Point(375, 80),
			new Point(495, 80)
		};

		public CircuitDrawer()
		{
			InitializeComponent();

			plot = new Bitmap(this.Width, this.Height);
			this.BackgroundImage = plot;
			DrawResistor();
		}

		private void DrawResistor()
		{
			Graphics graphics = Graphics.FromImage(plot);
			Pen pen = new Pen(Color.Black);
			graphics.DrawRectangle(pen, _userControlLocation[1].X, _userControlLocation[1].Y, 50, 20);
			this.BackgroundImage = plot;
		}

		private void DrawInductor()
		{

		}

		private void DrawCapacitor()
		{

		}

		/// <summary>
		/// Событие отрисовки фигур.
		/// </summary>
		/// <param name="eventArgs"></param>
		protected override void OnPaint(PaintEventArgs eventArgs)
		{
			if (Figures == null) return;

			eventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;

			//рисуем фигуры
			foreach (var figure in Figures)
				eventArgs.Graphics.DrawPath(Pens.Black, figure.Path);

			//рисуем маркеры для выделенной фигуры
			if (selectedFigure != null)
			{
				foreach (var m in selectedFigure)
					m.Draw(eventArgs.Graphics);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (Figures == null) return;

			if (e.Button == MouseButtons.Left)
			{
				startMouseDrag = e.Location;

				//если кликнули на маркер - выделяем маркер
				if (selectedFigure != null)
				{
					foreach (var m in selectedFigure)
						if (m.HitTest(e.Location))
						{
							//selectedMarker = m;
							return;
						}
				}

				selectedFigure = null;
				//selectedMarker = null;

				//ищем фигуру под мышкой
				using (var pen = new Pen(Color.Black, 3))
					foreach (var f in Figures)
						if (f.Path.IsOutlineVisible(e.Location, pen))
						{
							selectedFigure = f;//выделяем фигуру
							break;
						}

				Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (e.Button == MouseButtons.Left)
			{
				var dx = e.Location.X - startMouseDrag.X;
				var dy = e.Location.Y - startMouseDrag.Y;
				startMouseDrag = e.Location;

				if (selectedFigure != null)
				{
					////if (selectedMarker != null)
					////{
					////	//двигаем маркер
					////	selectedMarker.Move(dx, dy);
					////	selectedFigure.Build();
					////}
					//else
					//{
					//	//двигаем фигуру целиком
					//	selectedFigure.Move(dx, dy);
					//}

					Invalidate(); // перерисовка
				}
			}
		}
	}
  

	/// <summary>
	/// Размещает элементы цепи пропорционально размеру окна.
	/// </summary>
	//private void ControlLocation()
	//{
	//	int distance = (int)(0.17 * this.Size.Width);
	//	for (int i = 2; i < _userControlLocation.Count; i++)
	//	{
	//		_userControlLocation[i] = new Point(_userControlLocation[i - 1].X + distance
	//			, _userControlLocation[i].Y);
	//	}

	//	for (int i = 0; i < _elementsCount; i++)
	//	{
	//		circuitElementsPanel.Controls[i].Location = _userControlLocation[i + 1];
	//	}
	//}

	/// <summary>
	/// Создает экземпляр <see cref="CircuitDrawer"/>.
	/// </summary>

}
