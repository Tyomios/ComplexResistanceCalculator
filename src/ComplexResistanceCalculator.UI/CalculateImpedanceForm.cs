using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
	public partial class CalculateImpedanceForm : Form
	{
		private List<double> Frequency { get; set; }

		public Circuit Circuit { get;
			set; }

		private List<double> GetFrequencyFromTextBox()
		{
			List<double> frequency = new List<double>();
			try
			{
				var firstValue = System.Convert.ToDouble(firstValueTextBox.Text);
				var lastValue = System.Convert.ToDouble(lastValueTextBox.Text);
				var step = System.Convert.ToDouble(stepTextBox.Text);
				
				while (firstValue != lastValue)
				{
					if (firstValue > lastValue)
					{
						frequency.Add(lastValue);
						return frequency;
					}
					frequency.Add(firstValue);
					firstValue += step;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			return frequency;
		}
		public CalculateImpedanceForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = String.Empty;
			Frequency = GetFrequencyFromTextBox();
			var impedances = Circuit.CalculateZ(Frequency);
			foreach (var result in impedances)
			{
				richTextBox1.Text += $"{result.Real + result.Imaginary}\n";
			}
		}
	}
}
