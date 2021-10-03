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
    // TODO: проверить на грамошибки+
	public partial class CalculateImpedanceForm : Form
	{
		/// <summary>
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		public CalculateImpedanceForm()
		{
			InitializeComponent();
			foreach (var prefix in Enum.GetValues(typeof(FreqPrefixValue)))
			{
				prefixValueComboBoxFirstVal.Items.Add(prefix);
				prefixValueComboBoxLastVal.Items.Add(prefix);
				prefixStepComboBoxStep.Items.Add(prefix);
			}

			prefixValueComboBoxFirstVal.SelectedItem = FreqPrefixValue.Hz;
			prefixValueComboBoxLastVal.SelectedItem = FreqPrefixValue.Hz;
			prefixStepComboBoxStep.SelectedItem = FreqPrefixValue.Hz;
			// TODO: в название строки стоит добавлять единицы измерений. Почему их не добавить сразу?+
			resultData.Columns.Add("Frequency Hz");
			resultData.Columns.Add("Impedance");
			resultDataGridView.DataSource = resultData;
		}

		/// <summary>
		/// Диапазон частот для расчета сопротивлений.
		/// </summary>
		private List<double> Frequency { get; set; }

		/// <summary>
		/// Таблица результатов расчета импеданса для каждой частоты.
		/// </summary>
		private DataTable resultData = new DataTable();

		/// <summary>
		/// Цепь.
		/// </summary>
		public Circuit Circuit { get; set; }

		private void calculateButton_Click(object sender, EventArgs e)
		{
			var prefixValue = prefixValueComboBoxFirstVal.SelectedItem;
			resultData.Clear();
			resultData.Columns[0].ColumnName = $"Frequency ({prefixValue})";
			Frequency = GetFrequencyList();

			try
			{
				
				var impedances = Circuit.CalculateZ(Frequency);

				for (int index = 0; index < impedances.Count; index++)
				{
					var result = impedances[index];
					var showedFrequency = ValueConverter.ConvertUndoPrefixFrequency(Frequency[index], (FreqPrefixValue)prefixValue);
					var showedResult = $"{result.Real}   {CompressResult(Math.Round(result.Imaginary, 3))} i";
					var test = result.ToString();
					resultData.Rows.Add(new Object[] { $"{showedFrequency}", $"{showedResult}" });
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				throw;
			}
			
		}
        // TODO: xml +
		/// <summary>
		/// Приводит мнимое значение результата к более удобному для восприятия виду.
		/// </summary>
		/// <param name="result"> Мнимая часть </param>
		/// <returns> Удобный для восприятия результат </returns>
		private string CompressResult(double result)
		{
			var symbol = "";
			if (result > 0)
			{
				symbol = "+";
			}

			if (result < 0)
			{
				symbol = "-";
			}
			var textResult = result.ToString();
			if (textResult.Length > 7)
			{
				return $"{textResult.Substring(0, 4)} e+ {textResult.Length - 4}";
			}

			return symbol + textResult;
		}

		/// <summary>
		/// Создание диапазона частот по 2 значениям, введенных пользователем.
		/// </summary>
		/// <returns> Список с частотами для рассчета сопротивлений </returns>
		private List<double> GetFrequencyList()
		{
			List<double> frequency = new List<double>();
			try
			{
				var firstTextBoxValue = Convert.ToDouble(firstValueTextBox.Text);
				var lastTextBoxValue = Convert.ToDouble(lastValueTextBox.Text);
				var stepTextBoxValue = Convert.ToDouble(stepTextBox.Text);

				var firstValue = ValueConverter.ConvertPrefixFrequency(firstTextBoxValue, 
										(FreqPrefixValue)prefixValueComboBoxFirstVal.SelectedItem);

				var lastValue = ValueConverter.ConvertPrefixFrequency(lastTextBoxValue, 
										(FreqPrefixValue)prefixValueComboBoxLastVal.SelectedItem);

				var step = ValueConverter.ConvertPrefixFrequency(stepTextBoxValue, 
											(FreqPrefixValue)prefixStepComboBoxStep.SelectedItem);

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
