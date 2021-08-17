using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Катушка индуктивности
	/// </summary>
	class Inductor : IElement
	{
		public string Name { get; set; }

		public double Value { get; set; }

		public Complex CalculateZ(double f)
		{
			return -1 / (2 * Math.PI * f * Value);
		}
	}
}
