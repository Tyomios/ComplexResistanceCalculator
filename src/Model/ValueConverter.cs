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
        // TODO: каждый тип данных должен быть в своём файле
		// TODO: в префиксах дикая смесь префиксов и единиц измерений. Не надо их смешивать. Либо чисто префиксы kilo, Mega, Giga и т.д., либо для каждой единицы измерения своё перечисление. Правильнее - первый вариант
		// TODO: элементам перечисления можно присвоить целое значение. Присвой каждому элементу значение его степени и используй в коде как Pow(value, (int)ValuePrefix)
		Mega = 6,
		Giga = 9,
		mili = -3,
		nano = -9,
		piko = -12
	}

	// TODO: xml
	// TODO: каждый тип данных должен быть в своём файле
	public enum FreqPrefixValue
	{
		Hz = 1, // проверить результаты привожу к double 
		MGz = 6,
		GHz = 9
	}

	/// <summary>
	/// Сервисный класс для конвертирования значений в разные форматы величин.
	/// </summary>
	public static class ValueConverter
	{
		// TODO: xml
		// TODO: RSDN
		private static Dictionary<Type, int> pows = new Dictionary<Type, int>()
		{
			[typeof(Resistor)] = (int)ValuePrefix.mili,
			[typeof(Inductor)] = (int)ValuePrefix.nano,
			[typeof(Capacitor)] = (int)ValuePrefix.piko
		};

		/// <summary>
		/// Преобразует значение в единицы СИ.
		/// </summary>
		/// <param name="textFormatValue"> значение </param>
		/// <param name="elementType"> тип элемента </param>
		/// <returns> Возвращает значение в единицах СИ </returns>
		public static double ConvertPrefixValue(double value, IElement elementType)
		{
            // TODO: почему на вход приходит строка? Метод должен заниматься конвертированием значений с префиксами, а не парсингом текста из контролов.+
            // Во-вторых, методы типа ConvertPrefix() и ConvertUndoPrefix()
            // должны быть зеркальны по входным параметрам, так как выполняют противоположные задачи.+

            var pow = Math.Pow(10, pows[elementType.GetType()]);

            return value * pow;
		}

		/// <summary>
		/// Преобразование результата в величину, выбранную пользователем.
		/// </summary>
		/// <param name="value"> Рассчитанное значение </param>
		/// <param name="elementType"> Тип элемента </param>
		/// <returns> Результат в величине, выбранной пользователем </returns>
		public static double ConvertUndoPrefix(double value, IElement elementType)
		{
			var pow = Math.Pow(10, pows[elementType.GetType()]);

			return value / pow;
		}

		/// <summary>
		/// Для преобразования частоты в герцы.
		/// </summary>
		/// <param name="valueText"> Значение </param>
		/// <param name="prefixValue"> Выбранная пользователем величина </param>
		/// <returns> Значение частоты в герцах </returns>
		public static double ConvertPrefixFrequency(double value, FreqPrefixValue prefixValue)
		{
			// TODO: должно упроститься после переделки перечисления+
			var pow = Math.Pow(10, (double)prefixValue);
			return value * pow;
		}

		/// <summary>
		/// Для преобразования частоты в пользовательскую величину.
		/// </summary>
		/// <param name="value"> Значение </param>
		/// <param name="selectedPrefix"> Величина </param>
		/// <returns> Значение в пользовательской велечине </returns>
		public static double ConvertUndoPrefixFrequency(double value, FreqPrefixValue selectedPrefix)
		{
			// TODO: должно упроститься после переделки перечисления+
			var pow = Math.Pow(10, (double)selectedPrefix);
			return value / pow;
		}
	}
}
