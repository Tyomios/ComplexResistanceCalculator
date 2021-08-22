using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComplexResistanceCalculator.src.Model;
using Model;

namespace ComplexResistanceCalculator.UI
{
	public partial class mainForm : Form
	{
		private int _elementsCount;
		
		private IElement _currentElement;

		private List<Point> _userControlLocation = new List<Point>()
		{
			new Point(0, 0),
			new Point(15, 80), 
			new Point(135, 80),
			new Point(255, 80),
			new Point(375, 80),
			new Point(495, 80)
		};
			

		private Circuit _circuit = new Circuit();

		public mainForm()
		{
			InitializeComponent();
			
		}

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


		private void AddElement(IElement element)
		{
			if (_elementsCount == 5)
			{
				MessageBox.Show("Circuit may include just 5 or less elements" +
				                "\n Remove someone element from your circuit",
								"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			AddForm addForm = new AddForm(element);
			var dialogresult = addForm.ShowDialog();
			if (dialogresult != DialogResult.OK)
			{
				return;
			}

			IElementUserControl newElementUserControl = new IElementUserControl(element);
			circuitElementsPanel.Controls.Add(newElementUserControl);
			newElementUserControl.Click += UserControl_Click;
			// TODO: проблема с индексированием - элементы и индексы не синхронизированы
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
		}

		private void AddResistorButton_Click(object sender, EventArgs e)
		{
			Resistor resistor = new Resistor("", 0.0);
			AddElement(resistor);
		}

		private void circuitElementsPanel_ControlAdded(object sender, ControlEventArgs e)
		{
			var addedElement = (IElementUserControl)circuitElementsPanel.Controls[_elementsCount];
			elementNameTextBox.Text = addedElement.ContainElement.Name;
			elementsValueTextBox.Text = addedElement.ContainElement.Value.ToString();
		}

		private void AddInductorButton_Click(object sender, EventArgs e)
		{
			AddElement(new Inductor("L1", 0.33));
		}

		private void AddCapacitorButton_Click(object sender, EventArgs e)
		{
			AddElement(new Capacitor("C1", 1));
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
					ShowCurrentElementInfo();
					ControlLocation();
				}
			}
			else
			{
				MessageBox.Show("Select or add element");
			}
		}

		private void mainForm_SizeChanged(object sender, EventArgs e)
		{
			ControlLocation();
		}

		// Перенесу в user control
		private void elementsValueTextBox_TextChanged(object sender, EventArgs e)
		{
			var dialogresult = MessageBox.Show("Are u want to change value ?",
				"", MessageBoxButtons.YesNo);
			if (dialogresult == DialogResult.Yes)
			{
				try
				{
					_currentElement.Value = System.Convert.ToDouble(elementsValueTextBox.Text);
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

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
			
		}
	}
}
