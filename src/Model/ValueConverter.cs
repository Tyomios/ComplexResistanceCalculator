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
		Mega = (int)1E6,
		Giga = (int)1E9,
		mili = (int)1E-3,
		nano = (int)1E-9,
		piko = (int)1E-12
	}

	public enum FreqPrefixValue
	{
		Hz = 1, // проверить результаты привожу к double 
		MGz = (int)1E6,
		GHz = (int)1E9
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
		public static double ConvertPrefixValue(double value, IElement elementType)
		{
            // TODO: почему на вход приходит строка? Метод должен заниматься конвертированием значений с префиксами, а не парсингом текста из контролов.
            // Во-вторых, методы типа ConvertPrefix() и ConvertUndoPrefix()
            // должны быть зеркальны по входным параметрам, так как выполняют противоположные задачи.+

            if (elementType is Resistor)
            {
	            var pow = Math.Exp((double)ValuePrefix.mili);
				var res = Math.Pow(value, pow);
				return Math.Round(res, MidpointRounding.ToEven);
            }
			if (elementType is Inductor)
			{
				var pow = Math.Exp((double)ValuePrefix.nano);
				return Math.Pow(value, pow);
			}
			if (elementType is Capacitor)
			{
				//var pow = Math.Exp((double)ValuePrefix.piko);
				return Math.Pow(value, (int)ValuePrefix.piko);
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
	            // TODO: чтобы не запутаться в куче нулей, надо записывать в экспоненциальной форме 1e3. Тогда и комментарии не понадобятся+
	            var pow = Math.Exp(-(double)ValuePrefix.mili);
				return (value * 1e3);
			}
			if (elementType is Inductor)
			{
				return (value * 1e9);
			}
			if (elementType is Capacitor)
			{
                // TODO: по комментарию должна быть -12-ая степень, а по факту просто 12-ая. Где правда?+
				return (value * (int)ValuePrefix.piko); 
			}

			return value;
		}

		/// <summary>
		/// Для преобразования частоты в герцы.
		/// </summary>
		/// <param name="valueText"> Значение </param>
		/// <param name="prefixValue"> Выбранная пользователем величина </param>
		/// <returns> Значение частоты в герцах </returns>
		public static double ConvertPrefixFrequency(double value, FreqPrefixValue prefixValue)
		{
			// TODO: должно упроститься после переделки перечисления
			return (value * Math.Exp((double)prefixValue));
		}

		/// <summary>
		/// Для преобразования частоты в пользовательскую величину.
		/// </summary>
		/// <param name="value"> Значение </param>
		/// <param name="selectedPrefix"> Величина </param>
		/// <returns> Значение в пользовательской велечине </returns>
		public static double ConvertUndoPrefixFrequency(double value, FreqPrefixValue selectedPrefix)
		{
			// TODO: должно упроститься после переделки перечисления
			return (value * Math.Exp(-(double)selectedPrefix));
		}
	}
}
