using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	public delegate void FrameChanged();
	public class BaseCircuitFrame : ICommon
	{
		public List<ICommon> subSegments { get; set; }
		public ConnectionType Type { get; set; }

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		public void AddElement(ICommon element)
		{
			subSegments.Add(element);
			//element.ValueChanged += ElementOnValueChanged;
			//CircuitChanged?.Invoke();
		}

		public BaseCircuitFrame(ConnectionType type)
		{
			Type = type;
			subSegments = new List<ICommon>();
		}

		public BaseCircuitFrame()
		{
		}

		/// <summary>
		/// Удаление элемента из цепи.
		/// </summary>
		/// <param name="element"> Удаляемый элемент </param>
		public void RemoveElement(ICommon element)
		{
			if (subSegments.Contains(element))
			{
				//element.ValueChanged -= ElementOnValueChanged;
				subSegments.Remove(element);
				//CircuitChanged?.Invoke();
			}
		}

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			
			if (this.Type != ConnectionType.Common)
			{
				return CalculateZParallel(frequencies);
			}

			var allFrequenciesImpedance = subSegments[0].CalculateZ(frequencies);
			for (int i = 1; i < subSegments.Count; i++)
			{
				var elementZs = subSegments[i].CalculateZ(frequencies);
				for (int j = 0; j < elementZs.Count; j++)
				{
					allFrequenciesImpedance[j] += elementZs[j];
				}
			}

			return allFrequenciesImpedance;

		}

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты в параллельном соединении.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		private List<Complex> CalculateZParallel(List<double> frequencies)
		{
			var allFrequenciesImpedance = ConvertToParallel(subSegments[0].CalculateZ(frequencies));

			for (int i = 1; i < subSegments.Count; i++)
			{
				var elementZs = ConvertToParallel(subSegments[i].CalculateZ(frequencies));
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

		public void ElementOnValueChanged()
		{
			frameChanged?.Invoke();
		}

		public event FrameChanged frameChanged;
	}
}
