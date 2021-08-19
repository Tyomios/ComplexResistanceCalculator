using System;
using System.Collections.Generic;
using System.Numerics;
using ComplexResistanceCalculator.src.Model;

namespace Model
{
	public class ComplexFormatter : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
				return this;
			else
				return null;
		}

		public string Format(string format, object arg,
			IFormatProvider provider)
		{
			if (arg is Complex)
			{
				Complex c1 = (Complex)arg;
				// Check if the format string has a precision specifier.
				int precision;
				string fmtString = String.Empty;
				if (format.Length > 1)
				{
					try
					{
						precision = Int32.Parse(format.Substring(1));
					}
					catch (FormatException)
					{
						precision = 0;
					}
					fmtString = "N" + precision.ToString();
				}
				if (format.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase))
					return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "i";
				else if (format.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase))
					return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "j";
				else
					return c1.ToString(format, provider);
			}
			else
			{
				if (arg is IFormattable)
					return ((IFormattable)arg).ToString(format, provider);
				else if (arg != null)
					return arg.ToString();
				else
					return String.Empty;
			}
		}
	}
    class Program
	{
		static void Main(string[] args)
		{
			List<double> f = new List<double>()
			{
				1.0, 1.4, 1.7
			};

			var r = new Resistor("R1", 45);
			var c = new Capacitor("c1", 22);
			var l = new Inductor("L1", 11);

			var circuit = new Circuit();
			circuit.Elements.Add(r);
			circuit.Elements.Add(c);
			circuit.Elements.Add(l);

			var test = circuit.CalculateZ(f);

			foreach (var res in test)
			{
				Console.WriteLine(String.Format(new ComplexFormatter(), "{0:I0}", res));
			}

			Console.ReadLine();
		}
	}
}
