using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	public delegate void CircuitChanged();
	/// <summary>
	/// Электрическая цепь.
	/// </summary>
	public class Circuit
	{
		/// <summary>
		/// Список элементов в цепи.
		/// </summary>
		public List<IElement> Elements { get; set; } = new List<IElement>();

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			try
			{
				var allFrequenciesImpedance = Elements[0].CalculateZ(frequencies);
				for (int i = 1; i < Elements.Count; i++)
				{
					var elementZs = Elements[i].CalculateZ(frequencies);
					for (int j = 0; j < elementZs.Count; j++)
					{
						allFrequenciesImpedance[j] += elementZs[j];
					}
				}

				return allFrequenciesImpedance;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			
		}

		public event CircuitChanged circuitChanged;

		public void CircuitChanged()
		{
			circuitChanged?.Invoke();
		}
	}
}


