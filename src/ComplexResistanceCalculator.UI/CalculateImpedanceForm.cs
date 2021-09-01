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
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		public CalculateImpedanceForm()
		{
			InitializeComponent();
			foreach (var prefix in Enum.GetValues(typeof(ValuePrefix)))
			{
				prefixValueComboBoxFirstVal.Items.Add(prefix);
				prefixValueComboBoxLastVal.Items.Add(prefix);
				prefixStepComboBoxStep.Items.Add(prefix);
			}

			prefixValueComboBoxFirstVal.SelectedItem = ValuePrefix.Hz;
			prefixValueComboBoxLastVal.SelectedItem = ValuePrefix.Hz;
			prefixStepComboBoxStep.SelectedItem = ValuePrefix.Hz;
		}

		/// <summary>
		/// Диапазон частот для рассчета сопротивлений.
		/// </summary>
		private List<double> Frequency { get; set; }

		/// <summary>
		/// Цепь.
		/// </summary>
		public Circuit Circuit { get; set; }

		private void calculateButton_Click(object sender, EventArgs e)
		{
			resultTextBox.Text = string.Empty;
			Frequency = GetFrequencyList();
			try
			{
				var impedances = Circuit.CalculateZ(Frequency);
				var frequencyIndex = 0;
				foreach (var result in impedances)
				{
					var showedFrequency = ConvertUndoPrefix(Frequency[frequencyIndex]);
					var showedResult = Math.Round(result.Real + result.Imaginary, 3);
					resultTextBox.Text += $"For {showedFrequency} {prefixValueComboBoxFirstVal.SelectedItem}," +
					                      $" \t Z = {showedResult} \n";
					++frequencyIndex;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				throw;
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
				var firstValue = ConvertPrefixValue(firstValueTextBox.Text, prefixValueComboBoxFirstVal);
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

		/// <summary>
		/// Преобразование результата в величину, выбранную пользователем.
		/// </summary>
		/// <param name="value"> Рассчитанное значение </param>
		/// <returns> Результат в величине, выбранной пользователем </returns>
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
	}
}
