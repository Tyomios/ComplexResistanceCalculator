
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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.valueChangedlabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(80, 60);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// valueChangedlabel
			// 
			this.valueChangedlabel.AutoSize = true;
			this.valueChangedlabel.Location = new System.Drawing.Point(25, 73);
			this.valueChangedlabel.Name = "valueChangedlabel";
			this.valueChangedlabel.Size = new System.Drawing.Size(50, 20);
			this.valueChangedlabel.TabIndex = 1;
			this.valueChangedlabel.Text = "label1";
			// 
			// IElementUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.valueChangedlabel);
			this.Controls.Add(this.pictureBox);
			this.Name = "IElementUserControl";
			this.Size = new System.Drawing.Size(100, 100);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label valueChangedlabel;
	}
}
