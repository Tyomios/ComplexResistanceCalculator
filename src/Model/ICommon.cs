using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	// TODO: вынести перечисление в отдельный файл.
	// TODO: Подписать перечисления используя xml. Оставил пример.+
	/// <summary>
	/// Тип сегмента - соединение цепи или элемент.
	/// </summary>
	public enum ElementType
	{
		/// <summary>
		/// Параллельное соединение
		/// </summary>
		Parallel,
		
		/// <summary>
		/// Последовательное соединение
		/// </summary>
		Serial,
		
		/// <summary>
		/// Резистор
		/// </summary>
		Resistor,
		
		/// <summary>
		/// Конденсатор
		/// </summary>
		Capacitor,
		
		/// <summary>
		/// Катушка индуктивности
		/// </summary>
		Inductor			
	}

	/// <summary>
	/// Общий для соединений и элементов интерфейс.
	/// </summary>
	public interface ICommon
	{
		/// <summary>
		/// Тип обьекта.
		/// </summary>
		public ElementType Type { get; set; }

		/// <summary>
		/// Подсегменты обьекта (для соединений).
		/// </summary>
		List<ICommon> SubSegments { get; set; }

		// TODO: переименовать frequency -> frequencies. Так везде+
		/// <summary>
		/// Расчет импеданса
		/// </summary>
		/// <param name="frequencies"> Диапазон частот для расчета </param>
		/// <returns> Значения импеданса для каждой частоты </returns>
		abstract List<Complex> CalculateZ(List<double> frequencies);
	}
}
