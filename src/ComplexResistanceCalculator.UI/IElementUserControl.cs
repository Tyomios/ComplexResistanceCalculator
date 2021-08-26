using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComplexResistanceCalculator.src.Model;
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
	}
}
