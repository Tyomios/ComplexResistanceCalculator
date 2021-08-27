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
		/// Величина частоты.
		/// </summary>
		private enum ValuePrefix
		{
			Hz,
			MHz,
			GHz
		}

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
			foreach (var prefix in Enum.GetValues(typeof(ValuePrefix)))
			{
				prefixValueComboBox1.Items.Add(prefix);
				prefixValueComboBox2.Items.Add(prefix);
				prefixStepComboBox3.Items.Add(prefix);
			}

			prefixValueComboBox1.SelectedItem = ValuePrefix.Hz;
			prefixValueComboBox2.SelectedItem = ValuePrefix.Hz;
			prefixStepComboBox3.SelectedItem = ValuePrefix.Hz;
		}

		/// <summary>
		/// Цепь.
		/// </summary>
		public Circuit Circuit { get; set; }

		private void calculateButton_Click(object sender, EventArgs e)
		{
			resultTextBox.Text = string.Empty;
			Frequency = GetFrequencyList();
			var impedances = Circuit.CalculateZ(Frequency);
			var frequencyIndex = 0;
			foreach (var result in impedances)
			{
				var showedFrequency = ConvertUndoPrefix(Frequency[frequencyIndex]);
				var showedResult = Math.Round(result.Real + result.Imaginary, 3);
				resultTextBox.Text += $"For {showedFrequency} {prefixValueComboBox1.SelectedItem}," +
				                     $" \t Z = {showedResult} \n";
				++frequencyIndex;
			}
		}

		/// <summary>
		/// Получение значения в герцах.
		/// </summary>
		/// <param name="textFormatValue"> Введенное пользователем значение </param>
		/// <param name="prefixKeeper"> Контрол, отвечающий за величину </param>
		/// <returns></returns>
		private double ConvertPrefixValue(string textFormatValue, ComboBox prefixKeeper)
		{
			var value = Convert.ToDouble(textFormatValue);
			var selectedPrefix = (ValuePrefix)prefixKeeper.SelectedItem;
			var prefixM = 1000000;
			var prefixG = 1000000000;

			if (selectedPrefix == ValuePrefix.MHz)
			{
				  return (value * prefixM);
			}
			if (selectedPrefix == ValuePrefix.GHz)
			{
				return (value * prefixG);
			}

			return value;
		}

		private double ConvertUndoPrefix(double value)
		{
			if ((ValuePrefix)prefixValueComboBox2.SelectedItem == ValuePrefix.MHz)
			{
				return value / 1000000;
			}
			if ((ValuePrefix)prefixValueComboBox2.SelectedItem == ValuePrefix.GHz)
			{
				return value / 1000000000;
			}

			return value;
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
				var firstValue = ConvertPrefixValue(firstValueTextBox.Text, prefixValueComboBox1);
				var lastValue = ConvertPrefixValue(lastValueTextBox.Text, prefixValueComboBox2);
				var step = ConvertPrefixValue(stepTextBox.Text, prefixStepComboBox3);

				if (firstValue > lastValue)
				{
					MessageBox.Show("Last value from range can't be less, than first one.", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				while (firstValue <= lastValue)
				{
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
