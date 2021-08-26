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
	public partial class AddForm : Form
	{
		/// <summary>
		/// Добавляемый элемент.
		/// </summary>
		public IElement Element { get; set; }

		/// <summary>
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		/// <param name="newElement"> Элемент для внесения данных </param>
		public AddForm(IElement newElement)
		{
			InitializeComponent();
			Element = newElement;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			try
			{
				Element.Name = elementNameTextBox.Text;
				Element.Value = Convert.ToDouble(elementValueTextBox.Text);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
