using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Резистор
	/// </summary>
	class Resistor: IElement
	{
		/// <summary>
		/// Название элемента
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номинал
		/// </summary>
		public double Value { get; set; }

		
		public Complex CalculateZ(double f)
		{
			return Value + f * 0;
		}

	}
}
