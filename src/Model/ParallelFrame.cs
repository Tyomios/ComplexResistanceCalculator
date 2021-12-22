using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	public class ParallelFrame : BaseCircuitFrame
	{
		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты в параллельном соединении.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		private List<Complex> CalculateZ(List<double> frequencies)
		{
			var allFrequenciesImpedance = ConvertToParallel(SubSegments[0].CalculateZ(frequencies));

			for (int i = 1; i < SubSegments.Count; i++)
			{
				var elementZs = ConvertToParallel(SubSegments[i].CalculateZ(frequencies));
				for (int j = 0; j < elementZs.Count; j++)
				{
					allFrequenciesImpedance[j] += elementZs[j];
				}
			}

			return ConvertToParallel(allFrequenciesImpedance);
		}

		/// <summary>
		/// Преобразует данные последовательного соединения в рассчет импеданса параллельного соединения.
		/// </summary>
		/// <param name="values"> Значения для преобразования. </param>
		/// <returns> Данные для последовательного соединения </returns>
		private List<Complex> ConvertToParallel(List<Complex> values)
		{
			var results = new List<Complex>();
			foreach (var value in values)
			{
				results.Add(1 / value);
			}

			return results;
		}
	}
}
