using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Конденсатор.
	/// </summary>
	public class Capacitor : BaseElement
	{
		/// <summary>
		/// Создает экземпляр <see cref="Capacitor"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
			Type = ConnectionType.Capacitor;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Capacitor"/>.
		/// </summary>
		public Capacitor()
		{
			Type = ConnectionType.Capacitor;
		}
		
		/// <inheritdoc cref="BaseElement.CalculateZ"/>
		public override List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var freq in frequency)
			{
				impedances.Add(new Complex(0,-1 /(2 * Math.PI * freq * Value) ));
			}

			return impedances;
		}
	}
}
