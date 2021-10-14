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
		/// <summary>
		/// Элемент, содержащийся в выбранном контроле.
		/// </summary>
		public IElement SelectedElement;

		/// <summary>
		/// Для параллельных цепей.
		/// </summary>
		private List<Point> _circuitLevels = new List<Point>();

		/// <summary>
		/// Создает экземпляр <see cref="CircuitDrawer"/>.
		/// </summary>
		public CircuitDrawer()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Размещает элементы цепи пропорционально размеру окна.
		/// </summary>
		private void ControlLocation()
		{
			int distance = (int)(0.17 * this.Size.Width);
			Controls[0].Location = new Point(5, 80);
			var height = Controls[0].Height + 20;
			for (int i = 1; i < Controls.Count; i++)
			{
				var prevLocation = Controls[i - 1].Location;
				
				if (i % 5 == 0)
				{
					height += 80;
					Controls[i].Location = new Point(5, height);

					prevLocation = Controls[i].Location;
				}
				else
				{
					Controls[i].Location = new Point(prevLocation.X + distance, prevLocation.Y);
				}
			}
		}

		/// <summary>
		/// Создает линию между контролами.
		/// </summary>
		private void UniteControls()
		{
			var graphics = Graphics.FromImage(BackgroundImage = Image.FromFile("../../../../icons/panelBack.png"));
			var pen = new Pen(Color.Black, 4);
			graphics.Clear(Color.White);

			for (int i = 0; i < Controls.Count - 1; i++)
			{
				if (Controls[i + 1] != null)
				{
					var firstPoint = Controls[i].Location + (Controls[i].BackgroundImage.Size / 2);
					var secondPoint = Controls[i + 1].Location + (Controls[i + 1].BackgroundImage.Size / 2);
					if (Controls[i + 1].Location.Y == Controls[i].Location.Y)
					{
						graphics.DrawLine(pen, firstPoint, secondPoint);
					}
					if (i % 5 == 0)
					{
						if (i + 5 < Controls.Count)
						{
							firstPoint = Controls[i].Location + (Controls[i].BackgroundImage.Size / 2);
							secondPoint = Controls[i + 5].Location + (Controls[i + 5].BackgroundImage.Size / 2);
							graphics.DrawLine(pen, firstPoint, secondPoint);
						}
						else
						{
							continue;
						}
						
					}
					if (Controls[i + 1].Location.Y != Controls[i].Location.Y && i + 5 < Controls.Count) // работает неправильно
					{
						if (i + 5 < Controls.Count && Controls[i].Location.X == Controls[i + 5].Location.X)
						{
							firstPoint = Controls[i].Location + (Controls[i].BackgroundImage.Size / 2);
							secondPoint = Controls[i + 5].Location + (Controls[i + 5].BackgroundImage.Size / 2);
							graphics.DrawLine(pen, firstPoint, secondPoint);
						}
					}
				}
			}
			graphics.Dispose(); //освобождаем все ресурсы, связанные с отрисовкой
		}

		private void CircuitDrawer_ControlAdded(object sender, ControlEventArgs e)
		{
			var addedControl = (ElementControl)Controls[Controls.Count - 1];
			SelectedElement = addedControl.ContainElement;
			ControlLocation();
			if (Controls.Count > 1)
			{
				UniteControls();
			}
		}

		private void CircuitDrawer_ControlRemoved(object sender, ControlEventArgs e)
		{
			ControlLocation();
			UniteControls();
		}

		private void CircuitDrawer_SizeChanged(object sender, EventArgs e)
		{
			ControlLocation();
			UniteControls();
		}
	}
}
