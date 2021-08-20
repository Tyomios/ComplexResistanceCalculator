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
			new Point(),
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
			IElementUserControl newElementUserControl = new IElementUserControl(element);
			circuitElementsPanel.Controls.Add(newElementUserControl);
			newElementUserControl.Click += UserControl_Click;
			// TODO: проблема с индексированием - элементы и индексы не синхронизированы
			newElementUserControl.Location = _userControlLocation[_elementsCount];
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
			Resistor resistor = new Resistor("R1", 4);
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
			}
		}
	}
}
