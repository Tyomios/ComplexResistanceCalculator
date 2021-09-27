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
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		public void AddElement(IElement element)
		{
            // TODO: не стоит ли проверять, что элемент уже добавлен в коллекцию?
			Elements.Add(element);
			element.ValueChanged += ElementOnValueChanged;
			circuitChanged?.Invoke();
		}

		/// <summary>
		/// Удаление элемента из цепи.
		/// </summary>
		/// <param name="element"> Удаляемый элемент </param>
		public void RemoveElement(IElement element)
		{
			element.ValueChanged -= ElementOnValueChanged;
			Elements.Remove(element);
			if (Elements.Count > 0)
			{
                // TODO: а если элементов стало 0, разве это не изменение цепи?
				circuitChanged?.Invoke();
			}
            // TODO: не стоит ли проверять наличие элемента в списке элементов?
		}

		/// <summary>
		/// Подписка на событие ValueChanged.
		/// </summary>
		private void ElementOnValueChanged()
		{
			circuitChanged?.Invoke();
		}

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
				// TODO: если ты тут же кидаешь исключение, то зачем его вообще ловить?
                // TODO: в итоге, ты наверх выкидываешь более обобщенное исключение типа Exception, теряя полезную информацию о конкретном типе исключения для того, кто будет обрабатывать исключение.
				throw new Exception(e.Message);
			}
			
		}

        // TODO: неправильное именование
		/// <summary>
		/// Событие изменения одного и более элемента цепи.
		/// </summary>
		public event CircuitChanged circuitChanged;
	}
}