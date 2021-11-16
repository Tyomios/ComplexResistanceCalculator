using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Тип сегмента - соединение цепи или элемент.
	/// </summary>
	public enum ConnectionType
	{
		Parallel,
		ContinueParallel,
		Common,

	}

	public interface ICommon
	{
		public ConnectionType Type { get; set; }

		List<ICommon> subSegments { get; set; }

		abstract List<Complex> CalculateZ(List<double> frequency);
	}
}
