using System;
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
		/// <param name="f"> Частота </param>
		/// <returns> Возвращает сопротивление </returns>
		abstract Complex CalculateZ(double f);

		//event void ValueChanged(object f, object k);
	}
}
