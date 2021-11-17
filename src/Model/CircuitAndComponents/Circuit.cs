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

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		/// <param name="frameType"> Тип последнего соединения </param>
		public void AddElement(BaseElement element, ConnectionType frameType)
		{
			element.ValueChanged += ElementOnValueChanged;
			CircuitChanged?.Invoke();
			if (Frames.Count == 0 || Frames[Frames.Count - 1].Type != frameType)
			{
				Frames.Add(new BaseCircuitFrame(frameType));
				Frames[Frames.Count - 1].subSegments.Add(element);
				return;
			}

			Frames[Frames.Count - 1].subSegments.Add(element);
		}

		/// <summary>
		/// Удаление элемента и пустого сегмента. 
		/// </summary>
		/// <param name="element"> Удаляемый элемент. </param>
		public void RemoveElement(BaseElement element)
		{
			element.ValueChanged -= ElementOnValueChanged;
			for (int j = 0; j < Frames.Count; j++)
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
			CircuitChanged?.Invoke();
		}

		/// <summary>
		/// Подписка на событие ValueChanged.
		/// </summary>
		private void ElementOnValueChanged()
		{
			CircuitChanged?.Invoke();
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