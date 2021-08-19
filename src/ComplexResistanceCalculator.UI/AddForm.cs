using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ComplexResistanceCalculator.UI
{
	public partial class AddForm : Form
	{
		public IElement Element { get; set; }
		public AddForm()
		{
			InitializeComponent();
		}
	}
}
