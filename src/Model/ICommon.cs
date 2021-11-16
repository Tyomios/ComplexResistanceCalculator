using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Model
{
	/// <summary>
	/// Тип соединения узла
	/// </summary>
	public enum ConnectionType
	{
		Parallel,
		ContinueParallel,
		Common
	}

	public interface ICommon
	{
		public ConnectionType Type { get; set; }

		abstract List<Complex> CalculateZ(List<double> frequency);


	}
}
