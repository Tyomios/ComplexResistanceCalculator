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
	class Capacitor : IElement
	{
		public string Name { get; set; }

		public double Value { get; set; }

		public Complex CalculateZ(double f)
		{
			return (2 * Math.PI * f * Value);
		}
	}
}
