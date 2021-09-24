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
	public partial class AddEditForm : Form
	{
		/// <summary>
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		/// <param name="newElement"> Элемент для внесения данных </param>
		public AddEditForm(IElement newElement)
		{
			InitializeComponent();
			Element = newElement;
			SetDimension(Element);
			elementNameTextBox.Text = Element.Name;
			elementValueTextBox.Text = ValueConverter.ConvertUndoPrefix(Element.Value, Element).ToString();
		}

		/// <summary>
		/// Добавляемый или редактируемый элемент.
		/// </summary>
		public IElement Element { get; set; }

		/// <summary>
		/// Устанавливает величину номинала элемента.
		/// </summary>
		/// <param name="element"> Элемент </param>
		private void SetDimension(IElement element)
		{
			if (element is Resistor)
			{
				dimensionLabel.Text = "mΩ";
			}
			if (element is Capacitor)
			{
				dimensionLabel.Text = "pF";
			}
			if (element is Inductor)
			{
				dimensionLabel.Text = "mcH";
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				Element.Name = elementNameTextBox.Text;
				Element.Value = ValueConverter.ConvertPrefixValue(elementValueTextBox.Text, Element) ;
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
	}
}
