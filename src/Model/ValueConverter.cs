using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// Величина значения.
	/// </summary>
	public enum ValuePrefix
	{
		Hz,
		MHz,
		GHz,
		Ohm,
		mOhm,
		H,
		mcH,
		F,
		pF
	}

	/// <summary>
	/// Сервисный класс для конвертирования значений в разные форматы величин.
	/// </summary>
	public static class ValueConverter
	{
		/// <summary>
		/// Преобразует значение в единицы СИ.
		/// </summary>
		/// <param name="textFormatValue"> значение </param>
		/// <param name="prefixValue"> пользовательская единица измерения </param>
		/// <returns> Возвращает значение в единицах СИ </returns>
		public static double ConvertPrefixValue(string textFormatValue, ValuePrefix prefixValue)
		{
			var value = Convert.ToDouble(textFormatValue);
			var prefixM = 1000000;
			var prefixG = 1000000000;

			if (prefixValue == ValuePrefix.MHz)
			{
				return (value * prefixM);
			}
			if (prefixValue == ValuePrefix.GHz)
			{
				return (value * prefixG);
			}
			if (prefixValue == ValuePrefix.mOhm)
			{
				return (value / 1000);
			}
			if (prefixValue == ValuePrefix.mcH)
			{
				return (value / 1000000);
			}
			if (prefixValue == ValuePrefix.pF)
			{
				return (value / 1000000000000);
			}

			return value;
		}

		/// <summary>
		/// Преобразование результата в величину, выбранную пользователем.
		/// </summary>
		/// <param name="value"> Рассчитанное значение </param>
		/// <returns> Результат в величине, выбранной пользователем </returns>
		public static double ConvertUndoPrefix(double value, ValuePrefix selectedPrefix)
		{
			if (selectedPrefix == ValuePrefix.MHz)
			{
				return value / 1000000;
			}
			if (selectedPrefix == ValuePrefix.GHz)
			{
				return value / 1000000000;
			}
			if (selectedPrefix == ValuePrefix.mOhm)
			{
				return (value * 1000);
			}
			if (selectedPrefix == ValuePrefix.mcH)
			{
				return (value * 1000000);
			}
			if (selectedPrefix == ValuePrefix.pF)
			{
				return (value * 1000000000000);
			}

			return value;
		}
	}
}
