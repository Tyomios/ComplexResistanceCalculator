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
	public class Resistor: IElement
	{
		/// <summary>
		/// Название.
		/// </summary>
		private string _name;
		public string Name
		{
			get => _name;
			set
			{
				if (value.Length > 10)
				{
					throw new ArgumentException("Resistor's name might be shorter, " +
					                            "then 10 symbols");
				}
				_name = value;
			}
		}

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

		/// <summary>
		/// Создает экземпляр <see cref="Resistor"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Resistor"/>.
		/// </summary>
		public Resistor()
		{
			
		}
	}
}
