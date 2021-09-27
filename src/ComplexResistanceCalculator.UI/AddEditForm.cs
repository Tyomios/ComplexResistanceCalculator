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
    // TODO: неправильное именование таких форм уже объяснял. Исправить
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

        // TODO: ты оставляешь снаружи возможность присвоения другого элемента. Оно нужно? А если нужно, не должно ли что-то пересчитаться в интерфейсе?
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
            // TODO: вынести в словарь связь типа элемента и текста, сократить кучу ифов в одну строку
			if (element is Resistor)
			{
                // TODO: омега - это более специфичное обозначение. Просто Ohm
				dimensionLabel.Text = "mΩ";
			}
			if (element is Capacitor)
			{
				dimensionLabel.Text = "pF";
			}
			if (element is Inductor)
			{
                // TODO: mcH - это что-такое? милисантиГенри? должны быть наноГенри - нГн (1e-9)
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
