using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Model
{
	/// <summary>
	/// Резистор.
	/// </summary>
	public class Resistor: BaseElement
	{
		
		/// <summary>
		/// Создает экземпляр <see cref="Resistor"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
			Type = ConnectionType.Resistor;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Resistor"/>.
		/// </summary>
		public Resistor()
		{
			Type = ConnectionType.Resistor;
		}

		// TODO: xml - с наследованием
		/// <summary>
		/// <inheritdoc cref="IElement.CalculateZ"/>
		/// </summary>
		public override List<Complex> CalculateZ(List<double> frequency)
		{
            // TODO: что за сокращения в именованиях?
			var res = new List<Complex>();
			foreach (var f in frequency)
			{
				res.Add(new Complex(Value, 0));
			}

			return res;
		}
	}
}
