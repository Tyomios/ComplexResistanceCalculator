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
		// TODO: Лучше использовать относительные пути или вынести все картинки в Resources.resx
		/// <summary>
		/// Расположение папки с изображением элемента.
		/// </summary>
		private const string _iconPath = "../../../../icons";

		/// <summary>
		/// Подсказка для активного элемента <see cref="eventPictureBox"/>.
		/// </summary>
		private ToolTip _eventPictureBoxToolTip = new ToolTip();

		/// <summary>
		/// Содержимый элемент цепи.
		/// </summary>
		private IElement _containElement;

		// TODO: RSDN
		/// <summary>
		/// Содержит изображения элемента.
		/// </summary>
		private Dictionary<Type, Image> elementPictures = new Dictionary<Type, Image>()
		{
			[typeof(Resistor)] = Image.FromFile($"{_iconPath}/newResistor.png"),
			[typeof(Capacitor)] = Image.FromFile($"{_iconPath}/newCapacitor.png"),
			[typeof(Inductor)] = Image.FromFile($"{_iconPath}/newInductor.png")
		};

		// TODO: xml
		// TODO: RSDN
		private Dictionary<Type, Image> updateElementPictures = new Dictionary<Type, Image>()
		{
			[typeof(Resistor)] = Image.FromFile($"{_iconPath}/newEventResistorIcon1.png"),
			[typeof(Capacitor)] = Image.FromFile($"{_iconPath}/newEventCapacitorIcon1.png"),
			[typeof(Inductor)] = Image.FromFile($"{_iconPath}/newEventInductorIcon1.png")
		};

		/// <summary>
		/// Создает экземпляр класса <see cref="Control"/>.
		/// </summary>
		public ElementControl()
		{
			InitializeComponent();
			// TODO: а если элемент null?+
			// TODO: вообще, входные аргументы в конструкторы контролов нежелательны, так как мешают размещать контролы через дизайнер форм и могут быть созданы только программно.+
			// TODO: вынести в словарь связь типа элемента с именем файла, а здесь обращаться к словарю и сократить вызов до одной строчки.+
			if (_containElement == null)
			{
				ContainElement = new Resistor(); // для отрисовки шаблонов.
			}
		}
		
		private void ContainElementOnValueChanged()
		{
			ActivateEventPictureBox();
		}

		/// <summary>
		/// Возвращает или задает хранящийся элемент.
		/// </summary>
		public IElement ContainElement
		{
			get => _containElement;
			set
			{
				_containElement = value;
				_containElement.ValueChanged += ContainElementOnValueChanged;
				BackgroundImage = elementPictures[value.GetType()];
			}
		}

        // TODO: xml
		public bool SetParallel { get; set; }

		public bool SetNextParallel { get; set; }

		/// <summary>
		/// Скрытие элемента контрола, отвечающего за сообщение об изменении элемента внутри контрола.
		/// </summary>
		public void HideEventPictureBox()
		{
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
			BackgroundImage = updateElementPictures[_containElement.GetType()];
		}
		
		private void editButton_MouseEnter(object sender, EventArgs e)
		{
			var toolTip = new ToolTip();
			toolTip.SetToolTip(editButton, "Edit");
		}
	}
}
