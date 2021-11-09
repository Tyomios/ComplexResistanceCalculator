using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// Тип соединения узла
	/// </summary>
	public enum NodeType
	{
		Parallel,
		ContinueParallel,
		Common
	}

	class CircuitNode
	{
		private IElement _data;

		public CircuitNode _parentCircuitNode;

		public NodeType type;

		public CircuitNode parallelChild;

		public CircuitNode continueParallelChild;

		public CircuitNode commonChild;

		public CircuitNode()
		{

		}

		public IElement Data
		{
			get => _data;
			set
			{
				_data = value;
			}

		}
	}
}
