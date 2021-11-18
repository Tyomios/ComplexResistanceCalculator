using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	// TODO: вынести перечисление в отдельный файл.
	// TODO: Подписать перечисления используя xml. Оставил пример.
	/// <summary>
	/// Тип сегмента - соединение цепи или элемент.
	/// </summary>
	public enum ConnectionType
	{
		/// <summary>
		/// Параллельное соединение
		/// </summary>
		Parallel,
		Common,				// Последовательное соединение
		Resistor,			// Резистор
		Capacitor,			// Конденсатор
		Inductor			// Катушка индуктивности
	}

	/// <summary>
	/// Общий для соединений и элементов интерфейс.
	/// </summary>
	public interface ICommon
	{
		/// <summary>
		/// Тип обьекта.
		/// </summary>
		public ConnectionType Type { get; set; }

		/// <summary>
		/// Подсегменты обьекта (для соединений).
		/// </summary>
		List<ICommon> subSegments { get; set; }

		// TODO: переименовать frequency -> frequencies. Так везде+
		/// <summary>
		/// Расчет импеданса
		/// </summary>
		/// <param name="frequencies"> Диапазон частот для расчета </param>
		/// <returns> Значения импеданса для каждой частоты </returns>
		abstract List<Complex> CalculateZ(List<double> frequencies);
	}
}
