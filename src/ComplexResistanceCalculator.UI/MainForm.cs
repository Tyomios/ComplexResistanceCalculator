using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
		private IElement _currentElement;

		// TODO: Что за куча рассчитанных вручную точек? Почему их нельзя сверстать так, чтобы все координаты были в дизайнере?
        // TODO: Или это расположение элементов цепи на отрисовщике? Тогда они должны вычисляться программно (разве нельзя сделать X + 120 в цикле?)
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
		/// Цепь.
		/// </summary>
		private Circuit _circuit = new Circuit();

		/// <summary>
		/// Создает экземпляр класса <see cref="MainForm"/>.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			_circuit.CircuitChanged += CircuitOncircuitChanged;
		}
		// TODO: xml
        // TODO: странное название
		private void CircuitOncircuitChanged()
		{
			ChangeEventCircuitControl();
		}

		/// <summary>
		/// Отображение данных выбранного элемента.
		/// </summary>
		private void ShowCurrentElementInfo()
		{
			if (_currentElement != null)
			{
				elementNameTextBox.Text = _currentElement.Name;
				elementsValueTextBox.Text = ValueConverter.ConvertUndoPrefix(_currentElement.Value, _currentElement).ToString();
			}
		}

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		private void AddElement(IElement element)
		{
            // TODO: это что за ограничение такое? Не помню такого в ТЗ
			if (_elementsCount == 5)
			{
				MessageBox.Show("Circuit may include just 5 or less elements" +
				                "\n Remove someone element from your circuit",
								"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
            // TODO: не забывай про var +
			var addForm = new ElementForm(element);
			var dialogresult = addForm.ShowDialog();
			if (dialogresult != DialogResult.OK)
			{
				return;
			}

			var newElementUserControl = new ElementControl(element);
			circuitElementsPanel.Controls.Add(newElementUserControl);
			newElementUserControl.Click += UserControl_Click;
			newElementUserControl.Location = _userControlLocation[_elementsCount + 1];
			++_elementsCount;
			_circuit.AddElement(element);

			_currentElement = element;
			ShowCurrentElementInfo();
		}

		private void UserControl_Click(object sender, EventArgs e)
		{
			_currentElement = (sender as ElementControl).ContainElement;
			ShowCurrentElementInfo();
		}

        // TODO: странное название. "Изменить событие контрола цепи"? О_О
		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void ChangeEventCircuitControl()
		{
			calculateZbutton.BackgroundImage = Image.FromFile("../../../../icons/Start_Ch.png");
		}

        // TODO: странное название
		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void OffEventCircuitControl()
		{
			calculateZbutton.BackgroundImage = Image.FromFile("../../../../icons/Start.png");
		}

		private void AddResistorButton_Click(object sender, EventArgs e)
		{
			Resistor resistor = new Resistor();
			AddElement(resistor);
		}

		private void circuitElementsPanel_ControlAdded(object sender, ControlEventArgs e)
		{
			var addedControl = (ElementControl)circuitElementsPanel.Controls[_elementsCount];
			_currentElement = addedControl.ContainElement;
			ShowCurrentElementInfo();
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
					foreach (ElementControl control in circuitElementsPanel.Controls)
					{
						if (control.ContainElement == _currentElement)
						{
							circuitElementsPanel.Controls.Remove(control);
						}
					}

					_circuit.RemoveElement(_currentElement);
                    // TODO: чтобы не забывать отнимать эти индексаторы, всегда проще обращаться к количеству элементов через Circuit. Если надо, это свойство можно сделать открытым в самом Circuit, если коллекцию элементов не хочется открывать на изменение.
					--_elementsCount;
					_currentElement = null;
					
					ShowCurrentElementInfo();
					ControlLocation();
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
			ControlLocation();
		}

        // TODO: могу сразу сказать, что отрисовку цепи правильнее вынести в отдельный контрол. У него сделать метод Draw(Circuit) - отдельная самостоятельная задача должна решаться отдельной самостоятельной сущностью
		/// <summary>
		/// Размещает элементы цепи пропорционально размеру окна.
		/// </summary>
		private void ControlLocation()
		{
			int distance = (int)(0.17 * circuitElementsPanel.Size.Width);
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

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		/// <summary>
		/// Создает подсказку при наведении на элемент управления.
		/// </summary>
		/// <param name="control"> Элемент управления </param>
		/// <param name="toolTipText"> Текст подсказки </param>
		private void CreateButtonToolTip(Control control, string toolTipText)
		{
			var toolTip = new ToolTip();
			toolTip.SetToolTip(control, toolTipText);
		}

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		private void RemoveElementButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(RemoveElementButton, "Delete element");
		}

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		private void AddCapacitorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddCapacitorButton, "Add capacitor");
		}

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		private void AddResistorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddResistorButton, "Add resistor");
		}

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		private void AddInductorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddInductorButton, "Add inductor");
		}

        // TODO: все тултипы можно задать через дизайнер, чтобы не гадить в коде логики формы
		private void calculateZbutton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(calculateZbutton, "Calculate Z");
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
			foreach (ElementControl control in circuitElementsPanel.Controls)
			{
				control.HideEventPictureBox();
			}
			OffEventCircuitControl();
		}
	}
}
