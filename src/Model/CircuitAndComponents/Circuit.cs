using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Делегат для события CircuitChanged.
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
		public List<BaseCircuitFrame> Frames { get; set; } = new List<BaseCircuitFrame>();

		public bool CheckNewElement(BaseElement element, bool isParallel)
		{
			if (isParallel && Frames[GetFramesCount() - 1].Type == ConnectionType.Parallel)
			{
				return true;
			}

			if (!isParallel && Frames[GetFramesCount() - 1].Type == ConnectionType.Common)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Удаление элемента и пустого сегмента. 
		/// </summary>
		/// <param name="element"> Удаляемый элемент. </param>
		public void RemoveElement(BaseElement element)
		{
			for(int j = 0; j < Frames.Count; j++)
			{
				var segment = Frames[j];
				for (int i = 0; i < segment.subSegments.Count; i++)
				{
					if (element == segment.subSegments[i])
					{
						segment.subSegments.RemoveAt(i);
					}

					if (segment.subSegments.Count == 0)
					{
						Frames.Remove(segment);
					}
				}
			}
		}

		/// <summary>
		/// Подписка на событие ValueChanged.
		/// </summary>
		private void ElementOnValueChanged()
		{
			CircuitChanged?.Invoke();
		}

		public int GetFramesCount() => Frames.Count;

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			var allFrequenciesImpedance = Frames[0].CalculateZ(frequencies);
			for (int i = 1; i < Frames.Count; i++)
			{
				var elementZs = Frames[i].CalculateZ(frequencies);
				for (int j = 0; j < elementZs.Count; j++)
				{
					allFrequenciesImpedance[j] += elementZs[j];
				}
			}

			return allFrequenciesImpedance;

		}

		public List<Complex> G(List<double> frequencies)
		{
			var allFrequenciesImpedance = Frames[0].CalculateZ(frequencies);
			if (Frames.Count < 2)
			{
				return allFrequenciesImpedance;
			}
			for (int i = 1; i < Frames.Count; i++)
			{
				var result = Frames[i].CalculateZ(frequencies);
				for (int j = 0; j < frequencies.Count; j++)
				{
					allFrequenciesImpedance[j] += result[j];
				}
			}
			return allFrequenciesImpedance;
		}

		// TODO: неправильное именование
		/// <summary>
		/// Событие изменения одного и более элемента цепи.
		/// </summary>
		public event CircuitChanged CircuitChanged;
	}
}