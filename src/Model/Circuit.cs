using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Электрическая цепь
	/// </summary>
	class Circuit
	{
		/// <summary>
		/// Список элементов в цепи
		/// </summary>
		public List<IElement> Elements { get; set; }

		/// <summary>
		/// Подсчет сопротивления в цепи
		/// </summary>
		/// <param name="frequencies"></param>
		/// <returns></returns>
		public Complex CalculateZ(List<double> frequencies)
		{
			var realPartOfZ = 0.0;
			var imaginaryPart = 0.0;
			var frequenciesIndex = 0;

			foreach (var element in Elements)
			{
				if (element is Resistor)
				{
					realPartOfZ = element.Value;
					++frequenciesIndex;
				}
				else
				{
					imaginaryPart = element.CalculateZ(frequenciesIndex).Imaginary;
					++frequenciesIndex;
				}
				
			}

			return new Complex(realPartOfZ, imaginaryPart); ;
		}
	}
}
