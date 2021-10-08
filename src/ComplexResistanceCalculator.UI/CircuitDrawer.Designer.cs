
using System.Drawing;
using System.Windows.Forms;

namespace ComplexResistanceCalculator.UI
{
	partial class CircuitDrawer
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public SizeF AutoScaleDimensions { get; private set; }
		public AutoScaleMode AutoScaleMode { get; private set; }

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// CircuitDrawer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CircuitDrawer";
			this.Size = new System.Drawing.Size(617, 285);
			this.SizeChanged += new System.EventHandler(this.CircuitDrawer_SizeChanged);
			this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.CircuitDrawer_ControlAdded);
			this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.CircuitDrawer_ControlRemoved);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
