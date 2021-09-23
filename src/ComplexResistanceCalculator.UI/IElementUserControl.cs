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

		/// <summary>
		/// Подсказка для активного элемента <see cref="eventPictureBox"/>.
		/// </summary>
		private ToolTip _eventPictureBoxToolTip = new ToolTip();

		/// <summary>
		/// Создает экземпляр класса <see cref="Control"/>.
		/// </summary>
		/// <param name="element"> Элемент цепи, который будет отображаться контролом </param>
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
			ContainElement.ValueChanged += ContainElementOnValueChanged;
		}

		private void ContainElementOnValueChanged()
		{
			ActivateEventPictureBox();
		}

		/// <summary>
		/// Элемент цепи.
		/// </summary>
		public IElement ContainElement { get; set; }

		public Point Position { get; set; }

		/// <summary>
		/// Скрытие элемента контрола, отвечающего за сообщение об изменении элемента внутри контрола.
		/// </summary>
		public void HideEventPictureBox()
		{
			eventPictureBox.Visible = false;
			_eventPictureBoxToolTip.Active = false;
			ContainElement.ValueChanged -= ActivateEventPictureBox;
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			AddEditForm editForm = new AddEditForm(ContainElement);
			editForm.Icon = Icon.ExtractAssociatedIcon($"{_iconPath}/editElement.ico");
			var dialogresult = editForm.ShowDialog();
			if (dialogresult == DialogResult.OK)
			{
				ContainElement.Value = editForm.Element.Value;
				ContainElement.Name = editForm.Element.Name;
			}
		}

		/// <summary>
		/// Метод для события изменение номинала элемента.
		/// </summary>
		private void ActivateEventPictureBox()
		{
			eventPictureBox.Image = Image.FromFile($"{_iconPath}/valueChanged.png");
			eventPictureBox.Visible = true;

			_eventPictureBoxToolTip.SetToolTip(eventPictureBox, "Value was changed");
			_eventPictureBoxToolTip.Active = true;
		}

		private void editButton_MouseEnter(object sender, EventArgs e)
		{
			var toolTip = new ToolTip();
			toolTip.SetToolTip(editButton, "Edit");
		}
	}
}
