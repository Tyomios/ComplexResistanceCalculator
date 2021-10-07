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

	public partial class CircuitDrawer : Panel
	{

		public IElement SelectedElement;

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

		/// <summary>
		/// Для параллельных цепей.
		/// </summary>
		private List<Point> _circuitLavels = new List<Point>();

		/// <summary>
		/// Создает экземпляр <see cref="CircuitDrawer"/>.
		/// </summary>
		public CircuitDrawer()
		{
			InitializeComponent();
			//BackColor = Color.Azure;
		}

		/// <summary>
		/// Размещает элементы цепи пропорционально размеру окна.
		/// </summary>
		private void ControlLocation()
		{
			int distance = (int)(0.17 * this.Size.Width);
			for (int i = 2; i < _userControlLocation.Count; i++)
			{
				_userControlLocation[i] = new Point(_userControlLocation[i - 1].X + distance
					, _userControlLocation[i].Y);
			}

			for (int i = 0; i < Controls.Count; i++)
			{
				Controls[i].Location = _userControlLocation[i + 1];
			}
		}

		private void UniteControls(PaintEventArgs e)
		{
			Graphics gr = e.Graphics;
			Pen p = new Pen(Color.Blue, 5);
			for (int i = 0; i < Controls.Count - 1; i++) // возможно нужно проходить до count -1 
			{
				if (Controls[i + 1] != null)
				{
					gr.DrawLine(p, Controls[i].Location, Controls[i + 1].Location);
				}
			}
			gr.Dispose(); // освобождаем все ресурсы, связанные с отрисовкой
		}

		private void CircuitDrawer_ControlAdded(object sender, ControlEventArgs e)
		{
			var addedControl = (ElementControl)Controls[Controls.Count - 1];
			SelectedElement = addedControl.ContainElement;
			ControlLocation();
		}

		private void CircuitDrawer_SizeChanged(object sender, EventArgs e)
		{
			ControlLocation();
		}
	}
}
