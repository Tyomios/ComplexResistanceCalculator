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
	public partial class mainForm : Form
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

		public mainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Отображение данных выбранного элемента.
		/// </summary>
		private void ShowCurrentElementInfo()
		{
			if (_currentElement == null)
			{
				elementNameTextBox.Text = "";
				elementsValueTextBox.Text = "";
				return;
			}
			elementNameTextBox.Text = _currentElement.Name;
			elementsValueTextBox.Text = _currentElement.Value.ToString();
		}

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		private void AddElement(IElement element)
		{
			if (_elementsCount == 5)
			{
				MessageBox.Show("Circuit may include just 5 or less elements" +
				                "\n Remove someone element from your circuit",
								"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			AddEditForm addForm = new AddEditForm(element);
			var dialogresult = addForm.ShowDialog();
			if (dialogresult != DialogResult.OK)
			{
				return;
			}

			IElementUserControl newElementUserControl = new IElementUserControl(element);
			circuitElementsPanel.Controls.Add(newElementUserControl);
			newElementUserControl.Click += UserControl_Click;
			newElementUserControl.Location = _userControlLocation[_elementsCount + 1];
			++_elementsCount;
			_circuit.Elements.Add(element);

			_currentElement = element;
			ShowCurrentElementInfo();
		}

		private void UserControl_Click(object sender, EventArgs e)
		{
			_currentElement = (sender as IElementUserControl).ContainElement;
			ShowCurrentElementInfo();
			CheckCircuitChanged();
			//_circuit.InvokeEvent();
		}

		/// <summary>
		/// Вызов события изменение цепи
		/// </summary>
		/// TODO: перенести в бизнес-логику
		private void CheckCircuitChanged()
		{
			foreach (IElementUserControl control in circuitElementsPanel.Controls)
			{
				if (control.ContainElement.HasEventValueChanged())
				{
					_circuit.circuitChanged += ChangeEventCircuitLabel;
					return;
				}
			}

			_circuit.circuitChanged -= ChangeEventCircuitLabel;
			_circuit.circuitChanged += OffEventCircuitLabel;
		}

		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void ChangeEventCircuitLabel()
		{
			eventCircuitChangedLabel.Text = "Circuit changed";
			eventCircuitChangedLabel.ForeColor = Color.Brown;
		}

		/// <summary>
		/// Метод для события изменение цепи.
		/// </summary>
		private void OffEventCircuitLabel()
		{
			eventCircuitChangedLabel.Text = string.Empty;
		}

		private void AddResistorButton_Click(object sender, EventArgs e)
		{
			Resistor resistor = new Resistor();
			AddElement(resistor);
		}

		private void circuitElementsPanel_ControlAdded(object sender, ControlEventArgs e)
		{
			var addedControl = (IElementUserControl)circuitElementsPanel.Controls[_elementsCount];
			_currentElement = addedControl.ContainElement;
			ShowCurrentElementInfo();
			// событие изменения цепи
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
				var result = MessageBox.Show($"Delete element {_currentElement.Name} ?", "?", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					foreach (IElementUserControl control in circuitElementsPanel.Controls)
					{
						if (control.ContainElement == _currentElement)
						{
							circuitElementsPanel.Controls.Remove(control);
						}
					}

					_circuit.Elements.Remove(_currentElement);
					--_elementsCount;
					_currentElement = null;
					ShowCurrentElementInfo();
					ControlLocation();
					// событие изменения цепи
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
		private void RemoveElementButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(RemoveElementButton, "Delete element");
		}

		private void AddCapacitorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddCapacitorButton, "Add capacitor");
		}

		private void AddResistorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddResistorButton, "Add resistor");
		}

		private void AddInductorButton_MouseEnter(object sender, EventArgs e)
		{
			CreateButtonToolTip(AddInductorButton, "Add inductor");
		}

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
			CalculateImpedanceForm calculateImpedance = new CalculateImpedanceForm();
			calculateImpedance.Circuit = _circuit;
			calculateImpedance.ShowDialog();
			foreach (IElementUserControl control in circuitElementsPanel.Controls)
			{
				control.clearEventLabel();
			}
			CheckCircuitChanged();
			_circuit.InvokeEvent();
		}

		private void circuitElementsPanel_MouseEnter(object sender, EventArgs e)
		{
			CheckCircuitChanged();
			_circuit.InvokeEvent();
		}
	}
}
