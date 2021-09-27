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
		/// <param name="elementType"> тип элемента </param>
		/// <returns> Возвращает значение в единицах СИ </returns>
		public static double ConvertPrefixValue(string textFormatValue, IElement elementType)
		{
            // TODO: почему на вход приходит строка? Метод должен заниматься конвертированием значений с префиксами, а не парсингом текста из контролов. Во-вторых, методы типа ConvertPrefix() и ConvertUndoPrefix() должны быть зеркальны по входным параметрам, так как выполняют противоположные задачи.
			var value = Convert.ToDouble(textFormatValue);
			
			if (elementType is Resistor)
			{
				return (value / 1000);
			}
			if (elementType is Inductor)
			{
				return (value / 1000000); // 10^6
			}
			if (elementType is Capacitor)
			{
				return (value / 1000000000000); // 10^-12
			}

			return value;
		}

		/// <summary>
		/// Преобразование результата в величину, выбранную пользователем.
		/// </summary>
		/// <param name="value"> Рассчитанное значение </param>
		/// <param name="elementType"> Тип элемента </param>
		/// <returns> Результат в величине, выбранной пользователем </returns>
		public static double ConvertUndoPrefix(double value, IElement elementType)
		{
            if (elementType is Resistor)
			{
                // TODO: чтобы не запутаться в куче нулей, надо записывать в экспоненциальной форме 1e3. Тогда и комментарии не понадобятся
				return (value * 1000);
			}
			if (elementType is Inductor)
			{
				return (value * 1000000); // 10^6
			}
			if (elementType is Capacitor)
			{
                // TODO: по комментарию должна быть -12-ая степень, а по факту просто 12-ая. Где правда?
				return (value * 1000000000000); // 10^-12
			}

			return value;
		}

		/// <summary>
		/// Для преобразования частоты в герцы.
		/// </summary>
		/// <param name="valueText"> Значение </param>
		/// <param name="prefixValue"> Выбранная пользователем величина </param>
		/// <returns> Значение частоты в герцах </returns>
		public static double ConvertPrefixFrequency(string valueText, ValuePrefix prefixValue)
		{
            // TODO: опять конвертирование строки. Неправильно!
			var value = Convert.ToDouble(valueText);
			var prefixM = 1000000;
			var prefixG = 1000000000;

            // TODO: должно упроститься после переделки перечисления
			if (prefixValue == ValuePrefix.MHz)
			{
				return (value * prefixM);
			}
			if (prefixValue == ValuePrefix.GHz)
			{
				return (value * prefixG);
			}

			return value;
		}

		/// <summary>
		/// Для преобразования частоты в пользовательскую величину.
		/// </summary>
		/// <param name="value"> Значение </param>
		/// <param name="selectedPrefix"> Величина </param>
		/// <returns> Значение в пользовательской велечине </returns>
		public static double ConvertUndoPrefixFrequency(double value, ValuePrefix selectedPrefix)
		{
            // TODO: должно упроститься после переделки перечисления
			if (selectedPrefix == ValuePrefix.MHz)
			{
				return value / 1000000;
			}
			if (selectedPrefix == ValuePrefix.GHz)
			{
				return value / 1000000000;
			}

			return value;
		}
	}
}
