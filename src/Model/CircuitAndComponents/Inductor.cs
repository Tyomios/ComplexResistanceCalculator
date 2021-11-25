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
			Type = ElementType.Inductor;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Inductor"/>.
		/// </summary>
		public Inductor()
		{
			Type = ElementType.Inductor;
		}
		
		/// <summary>
		/// <inheritdoc cref="BaseElement.CalculateZ"/>
		/// </summary>
		public override List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				impedances.Add(new Complex(0, (2 * Math.PI * f * Value)) );
			}

			return impedances;
		}
	}
}
