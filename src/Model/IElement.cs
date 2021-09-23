using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace Model
{
	public delegate void ValueChanged();

	/// <summary>
	/// Интерфейс элементов.
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Возвращает или задает название элемента.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Возвращает или задает значение элемента.
		/// </summary>
		double Value { get; set; }

		/// <summary>
		/// Рассчет реактивного сопротивления.
		/// </summary>
		/// <param name="frequency"> Диапазон частот </param>
		/// <returns> Возвращает сопротивление для каждой частоты из диапазона </returns>
		abstract List<Complex> CalculateZ(List<double> frequency);

		/// <summary>
		/// Событие изменения данных элемента.
		/// </summary>
		public event ValueChanged ValueChanged;
	}
}
