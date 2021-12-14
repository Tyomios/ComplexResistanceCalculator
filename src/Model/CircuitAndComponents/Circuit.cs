using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;
using Model;

namespace Model
{
	/// <summary>
	/// Делегат для события CircuitChanged.
	/// </summary>
	public delegate void CircuitChanged();

	/// <summary>
	/// Электрическая цепь.
	/// </summary>
	public class Circuit
	{
		/// <summary>
		/// Список элементов в цепи.
		/// </summary>
		public List<BaseCircuitFrame> Frames { get; set; } = new List<BaseCircuitFrame>();

		/// <summary>
		/// Добавление элемента в цепь.
		/// </summary>
		/// <param name="element"> Добавляемый элемент </param>
		/// <param name="frameType"> Тип последнего соединения </param>
		public void AddElement(BaseElement element, ElementType frameType, bool isNeedToCreateNewFrame)
		{
			element.ValueChanged += ElementOnValueChanged;
			CircuitChanged?.Invoke();

			if (Frames.Count == 0 || isNeedToCreateNewFrame)
			{
				Frames.Add(new BaseCircuitFrame(frameType));
				Frames[Frames.Count - 1].SubSegments.Add(element);
				return;
			}

			var lastFrame = Frames[Frames.Count - 1];

			if (!isNeedToCreateNewFrame)
			{
				var segment = FindCorrectLastSubSegment(lastFrame, frameType);
				if (segment != null)
				{
					segment.SubSegments.Add(element);
					return;
				}

				if (segment == null && lastFrame.Type != frameType)
				{
					var lastSeg = FindLastSubSegment(lastFrame);
					if (lastSeg != null)
					{
						lastSeg.SubSegments.Add(new BaseCircuitFrame(frameType));
						lastSeg.SubSegments[lastSeg.SubSegments.Count - 1].SubSegments.Add(element);
						return;
					}

					if (lastSeg == null)
					{
						for (int i = lastFrame.SubSegments.Count - 1; i >= 0; i--)
						{
							var currentElement = lastFrame.SubSegments[i];
							if (currentElement is BaseCircuitFrame)
							{
								currentElement.SubSegments.Add(new BaseCircuitFrame(frameType));
								currentElement.SubSegments[lastSeg.SubSegments.Count - 1].SubSegments.Add(element);
								return;
							}
						}
					}
				}
				lastFrame.SubSegments.Add(element);
			}
		}

		private void AddInLastSubSegment(BaseCircuitFrame subFrame, BaseElement element, ElementType type)
		{
			
		}

		/// <summary>
		/// Добавляет подсегмент в сегмент
		/// </summary>
		/// <param name="frame"> Сегмент в который добавить </param>
		/// <param name="element"> Добавляемый элемент </param>
		/// <param name="type"> Тип соединения </param>
		//private BaseCircuitFrame AddSegmentInSegment(BaseCircuitFrame frame, BaseElement element, ElementType type)
		//{
		//	for (int i = 0; i < frame.SubSegments.Count - 1; i++)
		//	{
		//		var currentE = frame.SubSegments[i];
		//		if ((currentE.Type == type && i == 0) ||
		//		    (i > 0 && currentE.Type == type && frame.SubSegments[i - 1].Type != type))
		//		{
		//			currentE.SubSegments.Add(element);
		//			return 
		//		}
		//	}
		//}


		/// <summary>
		/// Поиск подсегмента в сегменте для вставки элемента.
		/// </summary>
		/// <param name="frame"></param>
		/// <param name="connectionType"></param>
		/// <returns></returns>
		private BaseCircuitFrame FindCorrectLastSubSegment(BaseCircuitFrame frame, ElementType connectionType)
		{
			BaseCircuitFrame seg = null;
			if (frame.SubSegments.Count > 1)
			{
				for (int i = frame.SubSegments.Count - 1; i >= 0; i--)
				{
					var currentE = frame.SubSegments[i];
					if (currentE.Type == connectionType)
					{
						seg = FindCorrectLastSubSegment((BaseCircuitFrame)currentE, connectionType);
					}
				}
			}
			else if (frame.SubSegments.Count == 1)
			{
				var currentE = frame.SubSegments[0];
				if (currentE.Type == connectionType)
				{
					seg = FindCorrectLastSubSegment((BaseCircuitFrame)currentE, connectionType);
				}
			}
			

			return seg;
		}

		private BaseCircuitFrame FindLastSubSegment(BaseCircuitFrame frame)
		{
			BaseCircuitFrame seg = null;
			if (frame.SubSegments.Count > 1)
			{
				for (int i = frame.SubSegments.Count - 1; i >= 0; i--)
				{
					var currentE = frame.SubSegments[i];
					if (currentE is BaseCircuitFrame)
					{
						seg = FindLastSubSegment((BaseCircuitFrame)currentE);
					}
				}
			}
			else if (frame.SubSegments.Count == 1)
			{
				var currentE = frame.SubSegments[0];
				if (currentE is BaseCircuitFrame)
				{
					seg = FindLastSubSegment((BaseCircuitFrame)currentE);
				}
			}


			return seg;
		}
		/// <summary>
		/// Проверяет есть ли в сегменте подсегменты
		/// </summary>
		/// <param name="frame"> Проверяемый сегмент </param>
		/// <returns> true если есть </returns>
		private bool CheckSegment(BaseCircuitFrame frame)
		{
			for (int i = 0; i < frame.SubSegments.Count - 1; i++)
			{
				var subSegment = frame.SubSegments[i];
				if (subSegment.Type == ElementType.Serial ||
				    subSegment.Type == ElementType.Parallel)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Поиск элемента по всем подсегментам в сегменте цепи.
		/// </summary>
		/// <param name="frame"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		private ICommon FindElement(BaseCircuitFrame frame, double value, ElementType type)
		{
			for(int i = 0; i < frame.SubSegments.Count - 1; i++)
			{
				var currentElement = frame.SubSegments[i];
				if (currentElement.Type == type)
				{
					var baseElement = (BaseElement)currentElement;
					if (baseElement.Value == value)
					{
						return currentElement;
					}
				}
			}

			for (int i = 0; i < frame.SubSegments.Count - 1; i++)
			{
				var currentElement = frame.SubSegments[i];
				if (currentElement.Type == ElementType.Serial ||
				    currentElement.Type == ElementType.Parallel)
				{
					 return FindElement((BaseCircuitFrame)currentElement, value, type);
				}
			}

			return null;
		}

		/// <summary>
		/// Удаление элемента и пустого сегмента. 
		/// </summary>
		/// <param name="element"> Удаляемый элемент. </param>
		public void RemoveElement(BaseElement element)
		{
			element.ValueChanged -= ElementOnValueChanged;
			for (int j = 0; j < Frames.Count; j++) 
			{
				var segment = Frames[j];
				for (int i = 0; i < segment.SubSegments.Count; i++)
				{
					if (element == segment.SubSegments[i])
					{
						segment.SubSegments.RemoveAt(i);
					}

					if (segment.SubSegments.Count == 0)
					{
						Frames.Remove(segment);
					}
				}
			}

			CircuitChanged?.Invoke();
		}

		/// <summary>
		/// Подписка на событие ValueChanged.
		/// </summary>
		private void ElementOnValueChanged()
		{
			CircuitChanged?.Invoke();
		}

		// TODO: xml+
		/// <summary>
		/// Расчет импеданса цепи.
		/// </summary>
		/// <param name="frequencies"> Частоты для расчета. </param>
		/// <returns> Список импеданса. </returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			var allFrequenciesImpedance = Frames[0].CalculateZ(frequencies);
			if (Frames.Count < 2)
			{
				return allFrequenciesImpedance;
			}
			for (int i = 1; i < Frames.Count; i++)
			{
				var result = Frames[i].CalculateZ(frequencies);
				for (int j = 0; j < frequencies.Count; j++)
				{
					allFrequenciesImpedance[j] += result[j];
				}
			}
			return allFrequenciesImpedance;
		}

		// TODO: неправильное именование
		/// <summary>
		/// Событие изменения одного и более элемента цепи.
		/// </summary>
		public event CircuitChanged CircuitChanged;
	}
}