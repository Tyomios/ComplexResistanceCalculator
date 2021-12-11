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
		public BaseElement SelectedElement;

		// TODO: RSDN +
		// TODO: Сделать свойство+
		/// <summary>
		/// Шаблоны отображения элементов.
		/// </summary>
		public List<List<Control>> Templates { get; set; }

		private List<Panel> uiFrames { get; set; }

		public List<ICommon> Frames { get; set; }

		private Point _startLocation = new Point(5, 80);

		private Graphics Graphics { get; set; }

		private Pen _pen = new Pen(Color.Black, 4);

		/// <summary>
		/// Создает экземпляр <see cref="CircuitDrawer"/>.
		/// </summary>
		public CircuitDrawer()
		{
			InitializeComponent();
		}

		// TODO: xml+
		/// <summary>
		/// Отрисовывает элементы по готовому щаблону.
		/// </summary>
		/// <param name="template"> Шаблон. </param>
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
			if (Controls.Count == 0)
			{
				return;
			}
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
				if (!CheckParallel((ElementControl)Controls[i]))
				{
					Controls[i].Location = new Point(prevLocation.X + 100, startLocation.Y);
					var prevCont = (ElementControl)Controls[i - 1];
					if (prevCont.SetNextParallel)
					{
						var xAdder = 20 * ((prevCont.Location.Y - 80) / 70 );
						Controls[i].Location = new Point(Controls[i].Location.X + xAdder, Controls[i].Location.Y);
					}
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

		/// <summary>
		/// Перестраивает контролы в нужном расположении.
		/// </summary>
		/// <param name="parallelControl"> предидущий параллельный контрол. </param>
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

		/// <summary>
		/// расстанавливает контролы три в ряд для отображения параллельных элементов.
		/// </summary>
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
			int widthAdder = 20;
			var rects = new List<Rectangle>();

			for (int i = Controls.Count - 1; i > 0; i--)
			{
				var firstPoint = Controls[i].Location + (Controls[i].BackgroundImage.Size / 2);
				var secondPoint = Controls[i - 1].Location + (Controls[i - 1].BackgroundImage.Size / 2);
				var currentCont = (ElementControl)Controls[i];
				var parallelCont = (ElementControl)Controls[i - 1];

				// соединение двух последовательных
				if (Controls[i - 1].Location.X != Controls[i].Location.X &&
				    (Math.Abs(Controls[i - 1].Location.Y - Controls[i].Location.Y) != 60 && Controls[i].Location.Y == Controls[i - 1].Location.Y))
				{
					graphics.DrawLine(pen, firstPoint, secondPoint);
				}
				// соединение последовательного с параллельным слева
				else if (Math.Abs(Controls[i - 1].Location.Y - Controls[i].Location.Y) == 60 && Controls[i].Location.X != Controls[i - 1].Location.X)
				{
					var startPoint = new Point(Controls[i].Location.X - 12, secondPoint.Y);
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
						var width = (Controls[i - 2].Location.X + Controls[i - 2].Width + 20) - Controls[i - 1].Location.X;
						var rect = new Rectangle(x, y, width, height);
						graphics.DrawRectangle(pen, rect);
						if (i + 1 <= Controls.Count - 1)
						{
							var nextControl = (ElementControl)Controls[i + 1];
							if (!nextControl.SetParallel || !nextControl.SetNextParallel)
							{
								var startPoint = new Point(Controls[i - 3].Location.X, firstPoint.Y);
								graphics.DrawLine(pen, startPoint, firstPoint);
							}
						}
					}
					else
					{
						var startPoint = new Point(parallelControl.Location.X + parallelControl.Width + 12, firstPoint.Y);
						graphics.DrawLine(pen, startPoint, firstPoint);
					}
				}
				// соединение сложного параллельного с последовательным справа
				else if (parallelCont.SetNextParallel &&
				         !currentCont.SetNextParallel && !currentCont.SetParallel)
				{
					var adder = 20 * ((parallelCont.Location.Y - 80) / 70);
					var finalPoint = new Point(parallelCont.Location.X + parallelCont.Width + adder - 12, firstPoint.Y);
					graphics.DrawLine(pen, firstPoint, finalPoint);
				}
				// соединение параллельных
				else
				{
					var currentControl = (ElementControl)Controls[i];
					if (currentControl.SetParallel && i + 1 < Controls.Count)
					{
						var nextControl = (ElementControl)Controls[i + 1];

						if (nextControl.SetNextParallel)
						{

							if (currentControl.SetParallel && nextControl.SetNextParallel)
							{
								int j = i + 1;
								var currentNextParallel = (ElementControl)Controls[j];
								var mainY = Controls[0].Location.Y;
								while (currentNextParallel.SetNextParallel || currentNextParallel.SetParallel)
								{
									j++;
									if (j >= Controls.Count)
									{
										--j;
										break;
									}

									currentNextParallel = (ElementControl)Controls[j];
									if (currentNextParallel.Location.Y == Controls[0].Location.Y)
									{
										--j;
										break;
									}
								}

								var x = Controls[i - 1].Location.X - 10;
								var y = Controls[i - 1].Location.Y + 30;
								var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
								var width = (Controls[j].Location.X + Controls[j].Width  + widthAdder) - Controls[i - 1].Location.X;
								var rect = new Rectangle(x, y, width, height);
								graphics.DrawRectangle(pen, rect);
								widthAdder += 20;

								// закрашивание лишних линий
								if (rects.Count >= 1 && CheckRects(rect, rects[rects.Count - 1]))
								{
									var fPoint = new Point(rects[rects.Count - 1].X + 2, secondPoint.Y + rect.Height);
									var secPoint = new Point(fPoint.X + rects[rects.Count - 1].Width - 4, fPoint.Y);
									var linePen = new Pen(this.BackColor, pen.Width);
									graphics.DrawLine(linePen, fPoint,secPoint);
								}
								rects.Add(rect);
								
							}
							
							
						}
						// для двух парарллельных, когда есть следующий
						else if (!nextControl.SetNextParallel && !nextControl.SetParallel)
						{
							var x = Controls[i - 1].Location.X - 10;
							var y = Controls[i - 1].Location.Y + 30;
							var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
							var width = (Controls[i - 1].Location.X + Controls[i - 1].Width + 20) - Controls[i].Location.X;
							var rect = new Rectangle(x, y, width, height);
							graphics.DrawRectangle(pen, rect);

							widthAdder += 20;
							if (rects.Count >= 1 && CheckRects(rect, rects[rects.Count - 1]))
							{
								var fPoint = new Point(rects[rects.Count - 1].X + 2, secondPoint.Y + rect.Height);
								var secPoint = new Point(fPoint.X + rects[rects.Count - 1].Width - 4, fPoint.Y);
								var linePen = new Pen(this.BackColor, pen.Width);
								graphics.DrawLine(linePen, fPoint, secPoint);
							}
							rects.Add(rect);
						}
					}
					else // для двух параллельных в конце цепи
					{
						var x = Controls[i - 1].Location.X - 10;
						var y = Controls[i - 1].Location.Y + 30;
						var height = Controls[i].Location.Y - Controls[i - 1].Location.Y;
						var width = (Controls[i - 1].Location.X + Controls[i - 1].Width + 20) - Controls[i].Location.X; 
						var rect = new Rectangle(x, y, width, height);
						graphics.DrawRectangle(pen, rect);

						if (i - 2 >= 0)
						{
							var twonextC = (ElementControl)Controls[i - 2];
							if (twonextC.SetNextParallel)
							{
								if (rects.Count >= 1 && CheckRects(rect, rects[rects.Count - 1]))
								{
									widthAdder += 20;
									var fPoint = new Point(rects[rects.Count - 1].X + 2, secondPoint.Y + rect.Height);
									var secPoint = new Point(fPoint.X + rects[rects.Count - 1].Width - 4, fPoint.Y);
									var linePen = new Pen(this.BackColor, pen.Width);
									graphics.DrawLine(linePen, fPoint, secPoint);
								}
								rects.Add(rect);
							}
						}
						
					}
						
				}
			}
			graphics.Dispose();
		}


		/// <summary>
		/// Проверка пересечения двух прямоугольников
		/// </summary>
		/// <param name="rect1"> Больший прямоугольник </param>
		/// <param name="rect2"> Меньший </param>
		/// <returns>  </returns>
		private bool CheckRects(Rectangle rect1, Rectangle rect2)
		{

			if (rect2.X < rect1.X + rect1.Width && rect2.Y < rect1.Y + rect1.Height)
			{
				return true;
			}

			return false;
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

		private void CircuitDrawer_ControlRemoved(object sender, ControlEventArgs e)
		{
			ControlLocation();
			UniteControls();
		}

		private void CircuitDrawer_SizeChanged(object sender, EventArgs e)
		{
			UniteControls();
		}

		/// <summary>
		/// Отрисовка цепи
		/// </summary>
		/// <param name="frames"> Сегменты цепи </param>
		public void Draw(List<BaseCircuitFrame> frames)
		{
			Graphics = Graphics.FromImage(BackgroundImage = Image.FromFile("../../../../icons/panelBack.png"));
			var startPosition = new Point(5, 80);
			var tempPosition = new Point(0, 0);

			foreach (var frame in frames)
			{
				if (frame.Type == ElementType.Serial)
				{
					if (tempPosition.Y != 0)
					{
						tempPosition = DrawSerialFrame(frame, tempPosition.X, tempPosition.Y);
					}
					else
					{
						tempPosition = DrawSerialFrame(frame, startPosition.X, startPosition.Y);
					}
				}
				if (frame.Type == ElementType.Parallel)
				{
					if (tempPosition.Y != 0)
					{
						tempPosition = DrawParallelFrame(frame, tempPosition.X, tempPosition.Y);
					}
					else
					{
						tempPosition = DrawParallelFrame(frame, startPosition.X, startPosition.Y);
					}
				}
			}
		}

		/// <summary>
		/// Проверка части цепи на внутренние компоненты
		/// </summary>
		/// <param name="frame"> Часть цепи </param>
		/// <returns> наличие внутренних компонентов </returns>
		private bool CheckSubSegments(ICommon frame)
		{
			if (frame.SubSegments == null)
			{
				return false;
			}

			return true;

		}

		/// <summary>
		/// Отрисовка последовательного соединения 
		/// </summary>
		/// <param name="frame"> Сегмент цепи с последовательным соединением </param>
		private Point DrawSerialFrame(ICommon frame, int x, int y)
		{
			var lastElementEnd = new Point();
			var step = 80;
			foreach (var element in frame.SubSegments)
			{
				lastElementEnd = DrawElement(element, x, y);
				x += step;
			}

			return lastElementEnd;
		}

		/// <summary>
		/// Отрисовка параллельного соединения.
		/// </summary>
		/// <param name="frame"> Сегмент цепи с параллельным соединением </param>
		private Point DrawParallelFrame(ICommon frame, int x, int y)
		{
			var lastElementEnd = new Point();
			var step = 40;
			var startLocation = new Point(x, y - 30);
			if (frame.SubSegments.Count == 1)
			{
				return new Point(DrawElement(frame.SubSegments[0], x, y).X, DrawElement(frame.SubSegments[0], x, y).Y);
			}

			foreach (var element in frame.SubSegments)
			{
				lastElementEnd = DrawElement(element, x, y);
				y += step;
			}

			var rectHeight = lastElementEnd.Y + 30 - startLocation.Y;
			var rectWidht = lastElementEnd.X - startLocation.X;

			Graphics.DrawRectangle(_pen, new Rectangle(startLocation.X, startLocation.Y, rectWidht, rectHeight));

			return lastElementEnd;
		}

		private Point DrawElement(ICommon element, int x, int y)
		{
			if (element is Resistor)
			{
				return DrawResistor(x, y);
			}
			if (element is Capacitor)
			{
				return DrawCapacitor(x, y);
			}
			if (element is Inductor)
			{
				return DrawInductor(x, y);
			}

			return new Point();
		}

		/// <summary>
		/// Отрисовка резистора
		/// </summary>
		/// <param name="x"> Координата начала соединительной линии X</param>
		/// <param name="y"> Координата начала соединительной линии Y</param>
		private Point DrawResistor(int x, int y)
		{
			var lineEnd = x + 15;
			var width = 50;
			var rightLineStart = lineEnd + width;
			Graphics.DrawLine(_pen, x, y, lineEnd, y); // соединительная ножка слева.
			Graphics.DrawRectangle(_pen, lineEnd, y - 15, 50, 30);
			Graphics.DrawLine(_pen, rightLineStart, y, rightLineStart + 15, y);

			return new Point(rightLineStart + 15, y);
		}

		/// <summary>
		/// Отрисовка конденсатора.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private Point DrawCapacitor(int x, int y)
		{
			var lineEnd = x + 35;
			var s = 10;
			var rightLineStart = lineEnd + s;
			var height = 30;
			Graphics.DrawLine(_pen, x, y, lineEnd, y); // соединительная ножка слева.
			Graphics.DrawLine(_pen, lineEnd, y + height / 2, lineEnd, y - height / 2);
			Graphics.DrawLine(_pen, lineEnd + s, y + height / 2, lineEnd + s, y - height / 2);
			Graphics.DrawLine(_pen, rightLineStart, y, rightLineStart + 35, y); // соединительная ножка справа.

			return new Point(rightLineStart + 35, y);
		}

		/// <summary>
		/// Отрисовка катушки индуктивности
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private Point DrawInductor(int x, int y)
		{
			var lineEnd = x + 20;
			var height = 15;
			var startAngle = 180;
			var sweepAngle = 179;
			var width = 15;
			var rightLineStart = lineEnd + 3 * width;

			Graphics.DrawLine(_pen, x, y, lineEnd, y); // соединительная ножка слева.
			Graphics.DrawArc(_pen, lineEnd, y - 5, width, height, startAngle, sweepAngle);
			Graphics.DrawArc(_pen, lineEnd + width, y - 5, width, height, startAngle, sweepAngle);
			Graphics.DrawArc(_pen, lineEnd + 2 * width, y - 5, width, height, startAngle, sweepAngle);
			Graphics.DrawLine(_pen, rightLineStart, y, rightLineStart + 20, y); // соединительная ножка слева.

			return new Point(rightLineStart + 20, y);
		}
	}
}
