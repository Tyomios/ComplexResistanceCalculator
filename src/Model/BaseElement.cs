﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	public class BaseElement : ICommon
	{
		/// <summary>
		/// Номинал.
		/// </summary>
		protected double _value;

		/// <summary>
		/// Название.
		/// </summary>
		protected string _name;

		/// <summary>
		/// Подсегменты, закрытый доступ, так как у элемента не может быть элементов.
		/// </summary>
		private List<ICommon> _subSegments = null;

		/// <summary>
		/// Создает экземпляр <see cref="BaseElement"/>.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="value"> Номинал </param>
		public BaseElement(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Создает экземпляр <see cref="BaseElement"/>.
		/// </summary>
		public BaseElement()
		{
		}

		/// <summary>
		/// Тип элемента.
		/// </summary>
		public ConnectionType Type { get; set; }

		/// <summary>
		/// Подсегменты.
		/// </summary>
		public List<ICommon> subSegments { get; set; }

		/// <summary>
		/// Возвращает или задает название элемента.
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
		/// Возвращает или задает значение элемента.
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

		/// <summary>
		/// Рассчет импеданса. 
		/// </summary>
		/// <param name="frequency"> Диапазон частот </param>
		/// <returns> Значения импедансов для частот.  </returns>
		virtual public List<Complex> CalculateZ(List<double> frequency)
		{
			var impedances = new List<Complex>();
			foreach (var f in frequency)
			{
				// TODO: неправильная формула для конденсатора. Правильная формула: -1.0 / (2 * Math.PI * frequency * Value)+
				impedances.Add(new Complex(0, -1 / (2 * Math.PI * f * Value)));
			}

			return impedances;
		}

		/// <summary>
		/// Событие изменения элемента.
		/// </summary>
		public event ValueChanged ValueChanged;
	}
}
