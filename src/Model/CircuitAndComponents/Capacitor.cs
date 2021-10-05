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
	public class Capacitor : IElement
	{
		/// <summary>
		/// Номинал.
		/// </summary>
		private double _value;

		/// <summary>
		/// Название.
		/// </summary>
		private string _name;

		/// <summary>
		/// Создает экземпляр <see cref="Capacitor"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Capacitor"/>.
		/// </summary>
		public Capacitor()
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
					throw new ArgumentException("Capacitor's name might be shorter, " +
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

		// TODO: xml+
		/// <inheritdoc cref="IElement.CalculateZ"/>

		public List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				impedances.Add(new Complex(0, 2 * Math.PI * f * Value));
			}

			return impedances;
		}

		// TODO: xml+
		/// <inheritdoc cref="IElement.CalculateZ"/>
		public event ValueChanged ValueChanged;
	}
    // TODO: реализации классов дублируются больше чем на половину. Подумай, как можно избавиться от дублирования
}
