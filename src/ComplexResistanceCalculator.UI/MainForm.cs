using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
	public partial class MainForm : Form
	{
		private int _elementsCount;

		private IElement _currentElement;
		public MainForm()
		{
			InitializeComponent();
			_elementsCount = 0;

		}
	}
}
