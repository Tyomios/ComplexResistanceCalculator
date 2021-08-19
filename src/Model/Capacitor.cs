using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Model;

namespace ComplexResistanceCalculator.src.Model
{
	/// <summary>
	/// Конденсатор
	/// </summary>
	public class Capacitor : IElement
	{
		public string Name { get; set; }

		public double Value { get; set; }

		public List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				impedances.Add(new Complex(0, 2 * Math.PI * f * Value));
			}

			return impedances;
		}

		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}
}
