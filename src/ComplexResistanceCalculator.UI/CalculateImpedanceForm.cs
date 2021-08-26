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

		public Circuit Circuit { get; set; }

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
			var frequencyIndex = 0;
			foreach (var result in impedances)
			{
				var showedResult = Math.Round(result.Real + result.Imaginary, 3);
				richTextBox1.Text += $"For{Frequency[frequencyIndex]}, \t Z = {showedResult} \n";
				++frequencyIndex;
			}
		}
	}
}
