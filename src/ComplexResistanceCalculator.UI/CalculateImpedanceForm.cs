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
		/// Создает экземпляр класса <see cref="Form"/>.
		/// </summary>
		public CalculateImpedanceForm()
		{
			InitializeComponent();
			foreach (var prefix in Enum.GetValues(typeof(ValuePrefix)))
			{
				if (prefix.ToString() == ValuePrefix.Ohm.ToString())
				{
					break;
				}

				prefixValueComboBoxFirstVal.Items.Add(prefix);
				prefixValueComboBoxLastVal.Items.Add(prefix);
				prefixStepComboBoxStep.Items.Add(prefix);
			}

			prefixValueComboBoxFirstVal.SelectedItem = ValuePrefix.Hz;
			prefixValueComboBoxLastVal.SelectedItem = ValuePrefix.Hz;
			prefixStepComboBoxStep.SelectedItem = ValuePrefix.Hz;

			resultData.Columns.Add("Frequency ");
			resultData.Columns.Add("Impedance");
			resultDataGridView.DataSource = resultData;
		}

		/// <summary>
		/// Диапазон частот для рассчета сопротивлений.
		/// </summary>
		private List<double> Frequency { get; set; }

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
				var frequencyIndex = 0;
				foreach (var result in impedances)
				{
					var showedFrequency = ValueConverter.ConvertUndoPrefixFrequency(Frequency[frequencyIndex], (ValuePrefix)prefixValue);
					var showedResult = $"{result.Real}   {Math.Round(result.Imaginary, 3)} i";
					++frequencyIndex;

					resultData.Rows.Add(new Object[] { $"{showedFrequency}", $"{showedResult}"});
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
				var firstValue = ValueConverter.ConvertPrefixFrequency(firstValueTextBox.Text, 
										(ValuePrefix)prefixValueComboBoxFirstVal.SelectedItem);

				var lastValue = ValueConverter.ConvertPrefixFrequency(lastValueTextBox.Text, 
										(ValuePrefix)prefixValueComboBoxLastVal.SelectedItem);

				var step = ValueConverter.ConvertPrefixFrequency(stepTextBox.Text, 
											(ValuePrefix)prefixStepComboBoxStep.SelectedItem);

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
