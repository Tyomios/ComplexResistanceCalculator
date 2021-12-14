using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Количество элементов в цепи.
		/// </summary>
		private int _elementsCount;

		/// <summary>
		/// Выбранный пользователем элемент цепи.
		/// </summary>
		private BaseElement _currentElement;

		/// <summary>
		/// Цепь.
		/// </summary>
		private Circuit _circuit = new Circuit();

		// TODO: xml+
		// TODO: RSDN+
		/// <summary>
		/// Элемент, отвечающий за отрисовку цепи.
		/// </summary>
		private CircuitDrawer _elementControlsContainer = new CircuitDrawer();

		/// <summary>
		/// Создает экземпляр класса <see cref="MainForm"/>.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			_elementControlsContainer.Templates = BuildTemplates();
			
			circuitElementsPanel.Controls.Add(_elementControlsContainer);
			_elementControlsContainer.ControlAdded += ElementControlsContainerOnControlAdded; 
			_circuit.CircuitChanged += OnСircuitChanged;

			_elements.Columns.Add("Name");
			_elements.Columns.Add("Value");
			ElementsDataGridView.DataSource = _elements;

			//_elementControlsContainer.Draw(TestCircuit().Frames);
		}

		private DataTable _elements = new DataTable();

		/// <summary>
		/// создает цепь с сегментом, имеющим несколько вложенных подсегментов
		/// </summary>
		/// <returns> цепь с сегментом, имеющим несколько вложенных подсегментов </returns>
		private Circuit TestCircuit()
		{
			var circuit = new Circuit();
			var segment = new BaseCircuitFrame(ElementType.Parallel);
			segment.SubSegments.Add(new Resistor("1", 3));

			var fSub = new BaseCircuitFrame(ElementType.Serial);
			fSub.SubSegments.Add(new Inductor("2", 3));
			fSub.SubSegments.Add(new Inductor("3", 3));
			segment.SubSegments.Add(fSub);
			segment.SubSegments.Add(new Resistor("4", 4));
			segment.SubSegments.Add(new Resistor("5", 5));

			var sSub = new BaseCircuitFrame(ElementType.Serial);
			sSub.SubSegments.Add(new Inductor("6", 6));

			var ssSub = new BaseCircuitFrame(ElementType.Parallel);
			ssSub.SubSegments.Add(new Capacitor("7", 7));
			ssSub.SubSegments.Add(new Capacitor("8", 8));
			sSub.SubSegments.Add(ssSub);
			segment.SubSegments.Add(sSub);

			circuit.Frames.Add(segment);
			return circuit;
		}

		/// <summary>
		/// Построение шаблонов
		/// </summary>
		/// <returns> Список контролов для отрисовки шаблона. </returns>
		private List<List<Control>> BuildTemplates()
		{
			var templates = new List<List<Control>>();
			for (int i = 0; i <= 4; i++)
			{
				templates.Add(new List<Control>()
				{
					new ElementControl(),
					new ElementControl(),
					new ElementControl(),
				});
			}

			// Первый шаблон - два параллельных резистора
			var twoParallelTemplate = templates[0];
			twoParallelTemplate.RemoveAt(2);
			var parallelControl = (ElementControl)twoParallelTemplate[1];
			parallelControl.SetParallel = true;

			// Второй шаблон - два последовательных и два параллельных.
			var parallelOnLeft = templates[1];
			parallelOnLeft.Add(new ElementControl());
			var parallelC = (ElementControl)parallelOnLeft[3];
			parallelC.SetParallel = true;

			// Третий шаблон - два параллельных в центре
			var parallelInCenter = templates[2];
			parallelInCenter.Add(new ElementControl());
			var parallel = (ElementControl)parallelInCenter[2];
			parallel.SetParallel = true;

			// Четвертый шаблон - три в параллельном.
			var threeInParallel = templates[3];
			var firstParallel = (ElementControl)threeInParallel[1];
			var secondParallel = (ElementControl)threeInParallel[2];
			firstParallel.SetParallel = true;
			secondParallel.SetParallel = true;


			return templates;
		}

		private void ElementControlsContainerOnControlAdded(object sender, ControlEventArgs e)
		{
			_currentElement = _elementControlsContainer.SelectedElement;
			//UpdateElementsInfo();
		}
		
        // TODO: странное название+
		/// <summary>
		/// Сообщает об изменении цепи.
		/// </summary>
		private void OnСircuitChanged()
		{
			ShowEventCircuitChanged();
		}

		/// <summary>
		/// Отображение данных выбранного элемента.
		/// </summary>
		private void UpdateElementsInfo(BaseCircuitFrame frame)
		{
			foreach (var element in frame.SubSegments)
			{
				if (!ElementIsFrame(element))
				{
					_elements.Rows.Add(new Object[] { $"{GetElementName((BaseElement)element)}",
						$"{ValueConverter.ConvertUndoPrefix(GetElementValue((BaseElement)element), (BaseElement)element)}" });
				}
				else
				{
					UpdateElementsInfo((BaseCircuitFrame)element);
				}

			}
		}

		private bool ElementIsFrame(ICommon element)
		{
			if (element.Type == ElementType.Serial
			    || element.Type == ElementType.Parallel)
			{
				return true;
			}

			return false;
		}

		private string GetElementName(BaseElement element) => element.Name;

		private double GetElementValue(BaseElement element) => element.Value;

			/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		private void AddElement(BaseElement element)
		{
            // TODO: это что за ограничение такое? Не помню такого в ТЗ+
            // TODO: не забывай про var +
			var addForm = new ElementForm();
			addForm.Element = element;
			var dialogresult = addForm.ShowDialog();
			if (dialogresult != DialogResult.OK)
			{
				return;
			}

			var newElementUserControl = new ElementControl();
			newElementUserControl.SetParallel = addForm.SetParallel;
			//if (!addForm.CreateNewSegment  /*_circuit.Frames[_circuit.Frames.Count - 1].Type != GetFrameType(newElementUserControl)*/)
			//{
			//	_circuit.AddSegmentInSegment(new BaseCircuitFrame(GetFrameType(newElementUserControl)));
			//}
			++_elementsCount;

			_circuit.AddElement(element, GetFrameType(newElementUserControl), addForm.CreateNewSegment);

			_currentElement = element;

			_elements.Clear();
			foreach (var frame in _circuit.Frames)
			{
				UpdateElementsInfo(frame);
			}

			_elementControlsContainer.Draw(_circuit.Frames);
		}

		/// <summary>
		/// Определяет подходящий тип сегмента для добавляемого элемента.
		/// </summary>
		/// <param name="control"> Контрол, содержащий элемент </param>
		/// <returns> Тип сегмента для элемента. </returns>
		private ElementType GetFrameType(ElementControl control)
		{
			return control.SetParallel ? ElementType.Parallel : ElementType.Serial;
		}


        // TODO: странное название. "Изменить событие контрола цепи"? О_О+
		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void ShowEventCircuitChanged()
		{
			if (_elementsCount == 0)
			{
				return;
			}
			calculateZbutton.BackgroundImage = Image.FromFile("../../../../icons/Start_Ch.png");
		}

        // TODO: странное название+
		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void HideEventCircuitChanged()
		{
			calculateZbutton.BackgroundImage = Image.FromFile("../../../../icons/Start.png");
		}

		private void AddResistorButton_Click(object sender, EventArgs e)
		{
			AddElement(new Resistor());
		}

		private void AddInductorButton_Click(object sender, EventArgs e)
		{
			AddElement(new Inductor());
		}

		private void AddCapacitorButton_Click(object sender, EventArgs e)
		{
			AddElement(new Capacitor());
		}

		private void RemoveElementButton_Click(object sender, EventArgs e)
		{
			if (_currentElement != null)
			{
				var result = MessageBox.Show($"Delete element {_currentElement.Name} ?",
													"", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					foreach (ElementControl control in _elementControlsContainer.Controls)
					{
						if (control.ContainElement == _currentElement)
						{
							_elementControlsContainer.Controls.Remove(control);
						}
					}

					_circuit.RemoveElement(_currentElement);
					--_elementsCount;
					_currentElement = null;
					
					//UpdateElementsInfo();
				}
			}
			else
			{
				MessageBox.Show("Select or add element", "Warning",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void mainForm_SizeChanged(object sender, EventArgs e)
		{
			_elementControlsContainer.Size = circuitElementsPanel.Size;
			_elementControlsContainer.Height += 10;
			_elementControlsContainer.Width += 40;
			_elementControlsContainer.Draw(_circuit.Frames);
		}


		private void calculateZbutton_Click(object sender, EventArgs e)
		{
			if (_elementsCount == 0)
			{
				MessageBox.Show("Add element in circuit", "Warning", 
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			CalculateImpedanceForm calculateImpedanceForm = new CalculateImpedanceForm();
			calculateImpedanceForm.Circuit = _circuit;
			calculateImpedanceForm.ShowDialog();
			foreach (ElementControl control in _elementControlsContainer.Controls)
			{
				control.HideEventPictureBox();
			}
			HideEventCircuitChanged();
		}
	}
}