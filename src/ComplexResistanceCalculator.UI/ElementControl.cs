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
	public partial class ElementControl : UserControl
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
		public ElementControl(IElement element)
		{
			InitializeComponent();
			// TODO: а если элемент null?
			// TODO: вообще, входные аргументы в конструкторы контролов нежелательны, так как мешают размещать контролы через дизайнер форм и могут быть созданы только программно.
			// TODO: вынести в словарь связь типа элемента с именем файла, а здесь обращаться к словарю и сократить вызов до одной строчки.
            if (element is Resistor)
			{
                // TODO: почему резистор jpg, а остальные png. Качество картинок не должно отличаться.
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

        // TODO: ты кладешь элемент в свойство, но если кто-то его изменит снаружи? Не должны ли здесь меняться подписки на элемент?
		/// <summary>
		/// Элемент цепи.
		/// </summary>
		public IElement ContainElement { get; set; }

        // TODO: xml
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
			ElementForm editForm = new ElementForm();
			editForm.Element = ContainElement;
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
