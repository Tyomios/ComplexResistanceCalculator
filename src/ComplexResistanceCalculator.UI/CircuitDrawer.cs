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
				var startLocation = Controls[0].Location;
				
				if (CheckParallel((ElementControl)Controls[i])) // срабатывает на каждую итерацию
				{
					Controls[i].Location = new Point(prevLocation.X, prevLocation.Y + 70);
					Controls[i - 1].Location = new Point(Controls[i - 1].Location.X, Controls[i].Location.Y - 130);
				}
				if (!CheckParallel((ElementControl)Controls[i])/* || currentControl.SetNextParallel*/)
				{
					Controls[i].Location = new Point(prevLocation.X + 100, startLocation.Y);
				}
				if (currentControl.SetNextParallel)
				{
					currentControl.Location = new Point(prevLocation.X + 100, prevLocation.Y);
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
				else if (Math.Abs(Controls[i - 1].Location.Y - Controls[i].Location.Y) == 60 && Controls[i].Location.X != Controls[i - 1].Location.X)
				{
					var startPoint = new Point(Controls[i].Location.X, secondPoint.Y);
					graphics.DrawLine(pen, startPoint, secondPoint);
				}
				// соединение последовательного с параллельным справа и соединение 3х парраллельных
				else if (i - 3 >= 0 && Controls[i].Location.Y != Controls[i - 1].Location.Y && Controls[i].Location.Y == Controls[i - 3].Location.Y 
				    && Controls[i -1].Location.X == Controls[i - 2].Location.X)
				{
					var currentControl = (ElementControl)Controls[i];
					var parallelControl = (ElementControl)Controls[i - 1];
					if (currentControl.SetParallel && parallelControl.SetParallel)
					{
						var x = Controls[i - 2].Location.X - 10;
						var y = Controls[i - 2].Location.Y + 30;
						var height = Controls[i - 1].Location.Y - Controls[i - 2].Location.Y;
						var width = (Controls[i - 2].Location.X + Controls[i - 2].Width + 12) - Controls[i - 1].Location.X;
						var rect = new Rectangle(x, y, width, height);
						graphics.DrawRectangle(pen, rect);
					}
					else
					{
						var startPoint = new Point(Controls[i - 3].Location.X, firstPoint.Y);
						graphics.DrawLine(pen, startPoint, firstPoint);
					}
				}
				// соединение параллельных (здесь улучшить для нескольких)
				else
				{
					var currentControl = (ElementControl)Controls[i];
					if (currentControl.SetParallel && i + 1 < Controls.Count)
					{
						var parallelControl = (ElementControl)Controls[i + 1];
						if (parallelControl.SetNextParallel)
						{
							for (int k = i; k < Controls.Count - 1; k++)
							{

								if (currentControl.SetParallel && parallelControl.SetNextParallel)
								{
									int j = k + 1;
									var currentNextParallel = (ElementControl)Controls[j];
									while (currentNextParallel.SetNextParallel)
									{
										j++;
										if (j >= Controls.Count)
										{
											--j;
											break;
										}

										currentNextParallel = (ElementControl)Controls[j];
										if (!currentNextParallel.SetNextParallel)
										{
											--j;
											break;
										}
									}

									var x = Controls[k - 1].Location.X - 10;// элемент перед параллельным
									var y = Controls[k - 1].Location.Y + 30;
									var height = Controls[k].Location.Y - Controls[k - 1].Location.Y;
									var width = (Controls[j].Location.X + Controls[j].Width + 20) - Controls[k - 1].Location.X;
									var rect = new Rectangle(x, y, width, height);
									graphics.DrawRectangle(pen, rect);
								}
							}
						

						}
					}
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
			}
			graphics.Dispose();
		}

		private void UniteInRectangle(Graphics graphics, Pen pen)
		{
			for (int i = 0; i < Controls.Count - 1; i++)
			{
				var currentControl = (ElementControl)Controls[i];
				ElementControl nextControl = (ElementControl)Controls[i + 1];
				
				if (currentControl.SetParallel && nextControl.SetNextParallel)
				{
					int j = i + 1;
					var currentNextParallel = (ElementControl)Controls[j];
					while (currentNextParallel.SetNextParallel)
					{
						++j;
						if (j >= Controls.Count)
						{
							--j;
							break;
						}
						currentNextParallel = (ElementControl)Controls[j];
					}
					var x = Controls[i - 1].Location.X - 10; // элемент перед параллельным
					var y = Controls[i - 1].Location.Y + 30;
					var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
					var width = Controls[j].Location.X - Controls[i - 1].Location.X + 5; //крайний справа - элемент перед параллельным + разница
					var rect = new Rectangle(x, y, width, height);
					graphics.DrawRectangle(pen, rect);
				}
				
			}
			//graphics.Dispose(); //если включить будет странная ошибка с параметром в основном цикле UniteControls
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="line"></param>
		/// <param name="listIndex"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public List<List<IElement>> GetLineParts(List<IElement> line, int listIndex = 0, int y = 80)
		{
			var result = new List<List<IElement>>();
			result.Add(line);
			for (int i = 0; i < Controls.Count; i++)
			{
				var currentControl = (ElementControl)Controls[i];
				if (currentControl.Location.Y == y)
				{
					result[listIndex].Add(currentControl.ContainElement);
				}
				else
				{
					++listIndex;
					result.Add(GetLineParts(new List<IElement>(), listIndex, currentControl.Location.Y)[0]); // спорный момент ?????
				}
			}

			return result;
		}

		public List<List<IElement>> GetParallelParts(List<IElement> line, int x, int listIndex = 0)
		{
			var result = new List<List<IElement>>();
			result.Add(line);
			for (int i = 0; i < Controls.Count; i++)
			{
				var currentControl = (ElementControl)Controls[i];
				if (currentControl.Location.Y == x)
				{
					result[listIndex].Add(currentControl.ContainElement);
				}
				else
				{
					++listIndex;
					result.Add(GetLineParts(new List<IElement>(), listIndex, currentControl.Location.Y)[0]); // спорный момент ?????
				}
			}

			return result;
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
