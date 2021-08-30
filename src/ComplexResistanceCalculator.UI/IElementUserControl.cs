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
	public partial class IElementUserControl : UserControl
	{
		/// <summary>
		/// Расположение папки с изображением элемента.
		/// </summary>
		private const string _iconPath = "../../../../icons";

		public Point Position { get; set; }

		/// <summary>
		/// Элемент цепи.
		/// </summary>
		public IElement ContainElement { get; set; }

		/// <summary>
		/// Создает экземпляр класса <see cref="Control"/>.
		/// </summary>
		/// <param name="element"> элемент цепи, который будет отображаться контролом </param>
		public IElementUserControl(IElement element)
		{
			InitializeComponent();
			
			if (element is Resistor)
			{
				BackgroundImage = Image.FromFile($"{_iconPath}/resistor.jpg");
			}
			if (element is Inductor)
			{
				BackgroundImage = Image.FromFile($"{_iconPath}/inductor.png");
			}
			if (element is Capacitor)
			{
				BackgroundImage = Image.FromFile($"{_iconPath}/capacitor.png");
			}

			ContainElement = element;
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			AddEditForm editForm = new AddEditForm(ContainElement);
			var dialogresult = editForm.ShowDialog();
			if (dialogresult != DialogResult.OK)
			{
				return;
			}
			ContainElement.ValueChanged += ChangeEventLabelColor;
			ContainElement = editForm.Element;
			ContainElement.InvokeEvent();
		}

		/// <summary>
		/// Метод для события изменение номинала элемента.
		/// </summary>
		private void ChangeEventLabelColor()
		{
			eventLabel.Text = "⨀";
			eventLabel.ForeColor = Color.Brown;
		}

		private void editButton_MouseEnter(object sender, EventArgs e)
		{
			var toolTip = new ToolTip();
			toolTip.SetToolTip(editButton, "Edit");
		}

		/// <summary>
		/// Скрытие лейбла, отвечающего за сообщение об изменении элемента внутри контрола.
		/// </summary>
		public void clearEventLabel()
		{
			eventLabel.Text = string.Empty;
			ContainElement.ValueChanged -= ChangeEventLabelColor;
		}
	}
}
