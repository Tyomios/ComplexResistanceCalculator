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
		/// <summary>
		/// Диапазон частот для рассчета сопротивлений.
		/// </summary>
		private List<double> Frequency { get; set; }

		/// <summary>
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		public CalculateImpedanceForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Цепь.
		/// </summary>
		public Circuit Circuit { get; set; }

		private void calculateButton_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = String.Empty;
			Frequency = GetFrequencyList();
			var impedances = Circuit.CalculateZ(Frequency);
			var frequencyIndex = 0;
			foreach (var result in impedances)
			{
				var showedResult = Math.Round(result.Real + result.Imaginary, 3);
				richTextBox1.Text += $"For{Frequency[frequencyIndex]}, \t Z = {showedResult} \n";
				++frequencyIndex;
			}
		}

		/// <summary>
		/// Создание диапазона частот по 2 значениям, введенные пользователем.
		/// </summary>
		/// <returns> Список с частотами для рассчета сопротивлений </returns>
		private List<double> GetFrequencyList()
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
	}
}
