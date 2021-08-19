using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model
{
	/// <summary>
	/// Интерфейс элементов
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Название
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		double Value { get; set; }

		/// <summary>
		/// Рассчет реактивного сопротивления
		/// </summary>
		/// <param name="frequency"> Диапазон частот </param>
		/// <returns> Возвращает сопротивление для каждой частоты из диапазона </returns>
		abstract List<Complex> CalculateZ(List<double> frequency);

		//event void ValueChanged(object f, object k);
	}
}
