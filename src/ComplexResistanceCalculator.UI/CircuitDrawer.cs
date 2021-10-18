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
	public delegate void ParallelEvent();
	public partial class CircuitDrawer : Panel
	{
		/// <summary>
		/// Элемент, содержащийся в выбранном контроле.
		/// </summary>
		public IElement SelectedElement;

		public event ParallelEvent SetParallel;

		/// <summary>
		/// Шаблоны отображения элементов.
		/// </summary>
		public List<ElementControl> templates = new List<ElementControl>();

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
				if (CheckParallel((ElementControl)Controls[i]))
				{
					Controls[i].Location = new Point(prevLocation.X, prevLocation.Y + 70);
					Controls[i - 1].Location = new Point(Controls[i - 1].Location.X, Controls[i].Location.Y - 130);
				}
				else
				{
					Controls[i].Location = new Point(prevLocation.X + 100, prevLocation.Y);
				}
			}
		}

		/// <summary>
		/// Проверяет нужно ли ставить контрол параллельно.
		/// </summary>
		/// <param name="control"> Проверяемый контрол </param>
		/// <returns>
		///	@retval true -нужно
		/// @retval false - не нужно
		/// </returns>
		private bool CheckParallel(ElementControl control)
		{
			if (control.SetParallel)
			{
				return true;
			}

			return false;
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
					if (Controls[i + 1].Location.X != Controls[i].Location.X)
					{
						graphics.DrawLine(pen, firstPoint, secondPoint);
					}
					else // нуждается в правке
					{
						var x = Controls[i].Location.X - 5;
						var y = Controls[i].Location.Y;
						var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
						var width = (Controls[i - 1].Location.X + Controls[i - 1].Width + 5) - Controls[i].Location.X;
						var rect = new Rectangle(x, y, width, height);
						graphics.DrawRectangle(pen, rect);
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

			if (addedControl.Location.X > this.Width)
			{
				Width += 90;
			}
		}

		public List<ElementControl> GetLineParts()
		{
			var lineParts = new List<ElementControl>();
			foreach (ElementControl control in Controls)
			{
				if (!control.SetParallel)
				{
					lineParts.Add(control);
				}
			}

			return lineParts;
		}

		public List<ElementControl> GetParallelParts()
		{
			var lineParts = new List<ElementControl>();
			foreach (ElementControl control in Controls)
			{
				if (control.SetParallel)
				{
					lineParts.Add(control);
				}
			}

			return lineParts;
		}

		private void CircuitDrawer_ControlRemoved(object sender, ControlEventArgs e)
		{
			ControlLocation();
			UniteControls();
		}

		private void CircuitDrawer_SizeChanged(object sender, EventArgs e)
		{
			UniteControls();
		}
	}
}
