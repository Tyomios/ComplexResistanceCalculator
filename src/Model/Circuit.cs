using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Электрическая цепь
	/// </summary>
	public class Circuit
	{
		/// <summary>
		/// Список элементов в цепи
		/// </summary>
		public List<IElement> Elements { get; set; } = new List<IElement>();

		/// <summary>
		/// Подсчет сопротивления в цепи
		/// </summary>
		/// <param name="frequencies"></param>
		/// <returns></returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			var allFrequenciesImpedance = new List<Complex>();
			var realPart = new List<Complex>();
			var imaginaryPart = new List<Complex>();
			foreach (var element in Elements)
			{
				if (element is Resistor)
				{
					if (realPart.Count == 0)
					{
						realPart = element.CalculateZ(frequencies);
					}
					else
					{
						var addValueRealPart = element.CalculateZ(frequencies);
						var index = 0;
						foreach (var value in addValueRealPart)
						{
							realPart[index] += value;
							++index;
						}
					}
				}
				else
				{
					if (imaginaryPart.Count == 0)
					{
						imaginaryPart = element.CalculateZ(frequencies);
					}
					else
					{
						var addValueImaginaryPart = element.CalculateZ(frequencies);
						var index = 0;
						foreach (var value in addValueImaginaryPart)
						{
							imaginaryPart[index] += value;
							++index;
						}
					}
				}
				
			}

			for (int i = 0; i < frequencies.Count; i++)
			{
				allFrequenciesImpedance.Add(new Complex(realPart[i].Real, imaginaryPart[i].Imaginary));
			}

			return allFrequenciesImpedance;
		}
	}
}
