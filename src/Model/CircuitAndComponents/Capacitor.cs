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

		// TODO: xml+
		/// <inheritdoc cref="IElement.CalculateZ"/>
		public override List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				// TODO: неправильная формула для конденсатора. Правильная формула: -1.0 / (2 * Math.PI * frequency * Value)+
				impedances.Add(new Complex(0,-1 /(2 * Math.PI * f * Value) ));
			}

			return impedances;
		}
	}
}
