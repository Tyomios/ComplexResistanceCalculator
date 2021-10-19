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

		/// <summary>
		/// Цепь.
		/// </summary>
		private Circuit _circuit = new Circuit();

		private CircuitDrawer elementControlsContainer = new CircuitDrawer();

		/// <summary>
		/// Создает экземпляр класса <see cref="MainForm"/>.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			elementControlsContainer.templates = BuildTemplates();
			foreach (var template in elementControlsContainer.templates)
			{
				templatesComboBox.Items.Add(template);
			}
			circuitElementsPanel.Controls.Add(elementControlsContainer);
			elementControlsContainer.ControlAdded += ElementControlsContainerOnControlAdded; 
			_circuit.CircuitChanged += OnСircuitChanged;
		}

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

			var twoParallelTemplate = templates[0];
			twoParallelTemplate.RemoveAt(2);
			var parallelControl = (ElementControl)twoParallelTemplate[1];
			parallelControl.SetParallel = true;

			var parallelOnLeft = templates[1];
			parallelOnLeft.Add(new ElementControl());
			var parallelC = (ElementControl)parallelOnLeft[3];
			parallelC.SetParallel = true;


			return templates;
		}

		private void ElementControlsContainerOnControlAdded(object sender, ControlEventArgs e)
		{
			_currentElement = elementControlsContainer.SelectedElement;
			ShowCurrentElementInfo();
		}

		// TODO: xml+
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
			newElementUserControl.ContainElement = element;
			elementControlsContainer.Controls.Add(newElementUserControl);
			newElementUserControl.Click += UserControl_Click;
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
					foreach (ElementControl control in elementControlsContainer.Controls)
					{
						if (control.ContainElement == _currentElement)
						{
							elementControlsContainer.Controls.Remove(control);
						}
					}

					_circuit.RemoveElement(_currentElement);
                    // TODO: чтобы не забывать отнимать эти индексаторы, всегда проще обращаться к количеству элементов через Circuit. Если надо, это свойство можно сделать открытым в самом Circuit, если коллекцию элементов не хочется открывать на изменение.
					--_elementsCount;
					_currentElement = null;
					
					ShowCurrentElementInfo();
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
			elementControlsContainer.Size = circuitElementsPanel.Size;
			elementControlsContainer.Height += 10;
			elementControlsContainer.Width += 40;
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
			foreach (ElementControl control in elementControlsContainer.Controls)
			{
				control.HideEventPictureBox();
			}
			HideEventCircuitChanged();
		}

		private void templatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			elementControlsContainer.DrawTemplate((List<Control>)templatesComboBox.SelectedItem);
		}
	}
}