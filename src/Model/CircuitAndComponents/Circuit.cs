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
		public List<IElement> Elements { get; set; } = new List<IElement>();

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		public void AddElement(IElement element)
		{
            // TODO: не стоит ли проверять, что элемент уже добавлен в коллекцию?
			Elements.Add(element);
			element.ValueChanged += ElementOnValueChanged;
			CircuitChanged?.Invoke();
		}

		/// <summary>
		/// Удаление элемента из цепи.
		/// </summary>
		/// <param name="element"> Удаляемый элемент </param>
		public void RemoveElement(IElement element)
		{
			if (Elements.Contains(element))
			{
				element.ValueChanged -= ElementOnValueChanged;
				Elements.Remove(element);
				CircuitChanged?.Invoke();
			}
		}

		/// <summary>
		/// Подписка на событие ValueChanged.
		/// </summary>
		private void ElementOnValueChanged()
		{
			CircuitChanged?.Invoke();
		}

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
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

		/// <summary>
		/// Расчет импеданса в цепи для каждого значения частоты в параллельном соединении.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZParallel(List<double> frequencies)
		{
			var allFrequenciesImpedance = ConvertToParallel(Elements[0].CalculateZ(frequencies));
			
			for (int i = 1; i < Elements.Count; i++)
			{
				var elementZs = ConvertToParallel(Elements[i].CalculateZ(frequencies));
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
		// TODO: неправильное именование
		/// <summary>
		/// Событие изменения одного и более элемента цепи.
		/// </summary>
		public event CircuitChanged CircuitChanged;
	}
}