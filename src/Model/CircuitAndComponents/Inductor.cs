using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Катушка индуктивности.
	/// </summary>
	public class Inductor : BaseElement
	{
		/// <summary>
		/// Создает экземпляр <see cref="Inductor"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public Inductor(string name, double value)
		{
			Name = name;
			Value = value;
			Type = ConnectionType.Inductor;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Inductor"/>.
		/// </summary>
		public Inductor()
		{
			Type = ConnectionType.Inductor;
		}

		// TODO: xml+
		/// <summary>
		/// <inheritdoc cref="IElement.CalculateZ"/>
		/// </summary>
		public override List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				// TODO: неправильная формула для катушки. Правильная формула: 2 * Math.PI * frequency * Value +
				impedances.Add(new Complex(0, (2 * Math.PI * f * Value)) );
			}

			return impedances;
		}
	}
}
