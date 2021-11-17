using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Тип сегмента - соединение цепи или элемент.
	/// </summary>
	public enum ConnectionType
	{
		Parallel,			// Параллельное соединение
		ContinueParallel,   //
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

		/// <summary>
		/// Расчет импеданса
		/// </summary>
		/// <param name="frequency"> Диапазон частот для расчета </param>
		/// <returns> Значения импеданса для каждой частоты </returns>
		abstract List<Complex> CalculateZ(List<double> frequency);
	}
}
