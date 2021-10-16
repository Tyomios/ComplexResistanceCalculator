using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
    // TODO: неправильное именование таких форм уже объяснял. Исправить+
	public partial class ElementForm : Form
	{
		/// <summary>
		/// Добавляемый или редактируемый элемент.
		/// </summary>
		private IElement _element;

		/// <summary>
		/// Содержит название величин для каждого типа элеметов
		/// </summary>
		private Dictionary<Type, string> _dimensions = new Dictionary<Type, string>()
		{
			[typeof(Resistor)] = "mOhm",
			[typeof(Capacitor)] ="pF",
			[typeof(Inductor)] ="nH"
		};

		/// <summary>
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		/// <param name="newElement"> Элемент для внесения данных </param>
		public ElementForm()
		{
			InitializeComponent();
			
		}

		/// <summary>
		/// Возвращает или задает элемент.
		/// </summary>
        public IElement Element
        {
	        get
	        {
		        return _element;
	        }
	        set
	        {
		        _element = value;
		        dimensionLabel.Text = _dimensions[_element.GetType()];
				elementNameTextBox.Text = _element.Name;
		        elementValueTextBox.Text = ValueConverter.ConvertUndoPrefix(_element.Value, _element).ToString();
			}
        }

		// TODO: xml
		public bool SetParallel { get; private set; }

        private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				var value = Convert.ToDouble(elementValueTextBox.Text);
				Element.Name = elementNameTextBox.Text;
				Element.Value = ValueConverter.ConvertPrefixValue(value, _element) ;
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error"
								, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void parallelCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetParallel = true;
		}
	}
}
