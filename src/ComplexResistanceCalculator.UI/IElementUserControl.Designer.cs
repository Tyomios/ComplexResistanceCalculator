
namespace ComplexResistanceCalculator.UI
{
	partial class IElementUserControl
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.valueChangedlabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// valueChangedlabel
			// 
			this.valueChangedlabel.AutoSize = true;
			this.valueChangedlabel.Location = new System.Drawing.Point(9, 66);
			this.valueChangedlabel.Name = "valueChangedlabel";
			this.valueChangedlabel.Size = new System.Drawing.Size(23, 20);
			this.valueChangedlabel.TabIndex = 1;
			this.valueChangedlabel.Text = "⨂";
			// 
			// IElementUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.valueChangedlabel);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.Name = "IElementUserControl";
			this.Size = new System.Drawing.Size(80, 97);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label valueChangedlabel;
	}
}
