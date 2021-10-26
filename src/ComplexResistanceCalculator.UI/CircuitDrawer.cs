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
		
		// TODO: xml
		public event ParallelEvent SetParallel;

		/// <summary>
		/// Шаблоны отображения элементов.
		/// </summary>
		public List<List<Control>> templates = new List<List<Control>>();

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

		public void DrawTemplate(List<Control> template)
		{
			foreach (var control in template)
			{
				Controls.Add(control);
			}
			ControlLocation();
		}

		/// <summary>
		/// Размещает элементы цепи пропорционально размеру окна.
		/// </summary>
		private void ControlLocation()
		{
			Controls[0].Location = new Point(5, 80);
			for (int i = 1; i < Controls.Count; i++)
			{
				var currentControl = (ElementControl)Controls[i]; 
				var prevLocation = Controls[i - 1].Location;

				
				if (CheckParallel((ElementControl)Controls[i])) // срабатывает на каждую итерацию
				{
					Controls[i].Location = new Point(prevLocation.X, prevLocation.Y + 70);
					Controls[i - 1].Location = new Point(Controls[i - 1].Location.X, Controls[i].Location.Y - 130);
				}
				if (!CheckParallel((ElementControl)Controls[i]) || currentControl.SetNextParallel)
				{
					Controls[i].Location = new Point(prevLocation.X + 100, prevLocation.Y);
				}
				var prevControl = (ElementControl)Controls[i - 1];
				if (prevControl.SetParallel)
				{
					SetPrevious(prevControl);
				}

				
			}
			SetThreeParallel();
			
		}

		private void SetPrevious(ElementControl parallelControl)
		{
			var i = Controls.IndexOf(parallelControl);
			var currentControl = (ElementControl)Controls[i];
			var prevLocation = Controls[0].Location;
			ElementControl lastNoTparallel = new ElementControl();

			// ищем последний параллельный
			while (currentControl.SetParallel || currentControl.SetNextParallel)
			{
				++i;
				if (i == Controls.Count)
				{
					return;
				}
				currentControl = (ElementControl)Controls[i];
			}

			// ищем последний непараллельный
			var j = 0;
			var nextControl = (ElementControl)Controls[j + 1];
			while (!nextControl.SetParallel || !nextControl.SetNextParallel)
			{
				++j;
				if (j + 1 >= Controls.Count)
				{
					j = 0;
					break;
				}
				nextControl = (ElementControl)Controls[j + 1];
			}

			lastNoTparallel = (ElementControl)Controls[j];
			var checkPrev = (ElementControl)Controls[0];
			if (j != 0)
			{
				checkPrev = (ElementControl)Controls[j - 1];
			}
			
			if (lastNoTparallel.Location.Y != checkPrev.Location.Y && !checkPrev.SetParallel && !checkPrev.SetNextParallel)
			{
				lastNoTparallel = checkPrev;
			}
			if (i - 1 >= 0)
			{
				prevLocation = Controls[i - 1].Location;
			}

			currentControl.Location = new Point(prevLocation.X + 100, lastNoTparallel.Location.Y);
			
		}

		private void SetThreeParallel()
		{
			for (int i = 1; i < Controls.Count; i++)
			{
				var prevLocation = Controls[i - 1].Location;
				if (i + 1 < Controls.Count && (CheckParallel((ElementControl)Controls[i]) &&
				                               CheckParallel((ElementControl)Controls[i + 1])))
				{
					var nextControl = (ElementControl)Controls[i + 1];

					Controls[i].Location = new Point(prevLocation.X, prevLocation.Y + 130);
					Controls[i + 1].Location = new Point(prevLocation.X, prevLocation.Y + 60);
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

			for (int i = Controls.Count - 1; i > 0; i--)
			{
				var firstPoint = Controls[i].Location + (Controls[i].BackgroundImage.Size / 2);
				var secondPoint = Controls[i - 1].Location + (Controls[i - 1].BackgroundImage.Size / 2);

				// соединение двух последовательных
				if (Controls[i - 1].Location.X != Controls[i].Location.X &&
				    (Math.Abs(Controls[i - 1].Location.Y - Controls[i].Location.Y) != 60 && Controls[i].Location.Y == Controls[i - 1].Location.Y))
				{
					graphics.DrawLine(pen, firstPoint, secondPoint);
				}
				// соединение последовательного с параллельным слева
				if (Math.Abs(Controls[i - 1].Location.Y - Controls[i].Location.Y) == 60)
				{
					var startPoint = new Point(Controls[i].Location.X, secondPoint.Y);
					graphics.DrawLine(pen, startPoint, secondPoint);
				}
				// соединение последовательного с параллельным справа
				if (i - 3 >= 0 && Controls[i].Location.Y != Controls[i - 1].Location.Y && Controls[i].Location.Y == Controls[i - 3].Location.Y 
				    && Controls[i -1].Location.X == Controls[i - 2].Location.X)
				{
					var startPoint = new Point(Controls[i - 3].Location.X, firstPoint.Y);
					graphics.DrawLine(pen, startPoint, firstPoint);
				}
				// соединение параллельных
				else
				{
					var x = Controls[i - 1].Location.X - 10;
					var y = Controls[i - 1].Location.Y + 30;
					var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
					var width = (Controls[i - 1].Location.X + Controls[i - 1].Width + 12) - Controls[i].Location.X;
					var rect = new Rectangle(x, y, width, height);
					graphics.DrawRectangle(pen, rect);
				}
			}
			graphics.Dispose();
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
