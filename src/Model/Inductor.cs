using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Катушка индуктивности
	/// </summary>
	public class Inductor : IElement
	{
		public string Name { get; set; }

		public double Value { get; set; }

		public List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				impedances.Add(new Complex(0, -1 / (2 * Math.PI * f * Value)) );
			}

			return impedances;
		}

		public Inductor(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}
}
