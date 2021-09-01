using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Делегат для события circuitChanged.
	/// </summary>
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

		/// <summary>
		/// Событие изменения одного и более элемента цепи.
		/// </summary>
		public event CircuitChanged circuitChanged;

		/// <summary>
		/// Метод вызова события <see cref="circuitChanged"/>.
		/// </summary>
		public void InvokeEvent()
		{
			circuitChanged?.Invoke();
		}

		/// <summary>
		/// Проверяет состояние каждого элемента в цепи.
		/// </summary>
		/// <returns>
		/// true - найден элемент с изменением данных.
		/// false - элементы в цепи не изменялись.
		/// </returns>
		public bool isCircuitChanged()
		{
			foreach (var element in Elements)
			{
				if (element.HasEventValueChanged())
				{
					return true;
				}
			}

			return false;
		}
	}
}


