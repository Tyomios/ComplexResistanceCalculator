using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Резистор
	/// </summary>
	public class Resistor: IElement
	{
		public string Name { get; set; }

		public double Value { get; set; }

		public List<Complex> CalculateZ(List<double> frequency)
		{
			var res = new List<Complex>();
			foreach (var f in frequency)
			{
				res.Add(new Complex(Value, 0));
			}

			return res;
		}

		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}
}
