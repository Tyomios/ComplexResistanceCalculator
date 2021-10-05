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

		/// <summary>
		/// Номинал.
		/// </summary>
		private double _value;

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

		// TODO: xml+
		/// <summary>
		/// <inheritdoc cref="IElement.Name"/>
		/// </summary>
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

		// TODO: xml+
		/// <summary>
		/// <inheritdoc cref="IElement.Value"/>
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				if (_value != value)
				{
					ValueChanged?.Invoke();
				}
				_value = value;
			}
		}

		// TODO: xml - с наследованием
		/// <summary>
		/// <inheritdoc cref="IElement.CalculateZ"/>
		/// </summary>
		public List<Complex> CalculateZ(List<double> frequency)
		{
            // TODO: что за сокращения в именованиях?
			var res = new List<Complex>();
			foreach (var f in frequency)
			{
				res.Add(new Complex(Value, 0));
			}

			return res;
		}

		// TODO: xml - с наследованием
		/// <summary>
		/// <inheritdoc cref="IElement.ValueChanged"/>
		/// </summary>
		public event ValueChanged ValueChanged;
	}
}
