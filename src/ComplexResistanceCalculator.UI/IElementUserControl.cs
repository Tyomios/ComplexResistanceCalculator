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
		private const string _iconPath = "../../../../icons";

		public Point Position { get; set; }
		public IElement ContainElement { get; set; }
		public IElementUserControl(IElement element)
		{
			InitializeComponent();
			

			if (element is Resistor)
			{
				pictureBox.Image = Image.FromFile($"{_iconPath}/resistor.jpg");
			}
			if (element is Inductor)
			{
				pictureBox.Image = Image.FromFile($"{_iconPath}/inductor.png");
			}
			if (element is Capacitor)
			{
				pictureBox.Image = Image.FromFile($"{_iconPath}/capacitor.png");
			}

			ContainElement = element;
		}

		private void IElementUserControl_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox_Click(object sender, EventArgs e)
		{
			MessageBox.Show("d");
		}
	}
}
