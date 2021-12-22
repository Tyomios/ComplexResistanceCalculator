using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Базовый класс сегментов цепи.
	/// </summary>
	public class BaseCircuitFrame : ICommon
	{
		/// <summary>
		/// Возвращает или задает список элементов соединения.
		/// </summary>
		public List<ICommon> SubSegments { get; set; }

		/// <summary>
		/// Возвращает или задает тип соединения.
		/// </summary>
		public ElementType Type { get; set; }

		/// <summary>
		/// Создает экземпляр класса <see cref="BaseCircuitFrame"/>
		/// </summary>
		/// <param name="type"> Тип соединения </param>
		public BaseCircuitFrame(ElementType type)
		{
			Type = type;
			SubSegments = new List<ICommon>();
		}

		/// <summary>
		/// Создает экземпляр класса <see cref="BaseCircuitFrame"/>
		/// </summary>
		public BaseCircuitFrame()
		{
		}

		/// <summary>
		/// Выбирает какой метод расчета применить для участка цепи.
		/// </summary>
		/// <param name="frequencies"> Список частот </param>
		/// <returns> Список комплексных сопротивлений </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			var allFrequenciesImpedance = SubSegments[0].CalculateZ(frequencies);
			for (int i = 1; i < SubSegments.Count; i++)
			{
				var elementZs = SubSegments[i].CalculateZ(frequencies);
				for (int j = 0; j < elementZs.Count; j++)
				{
					allFrequenciesImpedance[j] += elementZs[j];
				}
			}

			return allFrequenciesImpedance;
		}
	}
}
