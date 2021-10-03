using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComplexResistanceCalculator.UI
{
	public partial class CircuitDrawer : UserControl
	{
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

			for (int i = 0; i < _elementsCount; i++)
			{
				circuitElementsPanel.Controls[i].Location = _userControlLocation[i + 1];
			}
		}

		/// <summary>
		/// Создает экземпляр <see cref="CircuitDrawer"/>.
		/// </summary>
		public CircuitDrawer()
		{
			InitializeComponent();
		}
	}
}
