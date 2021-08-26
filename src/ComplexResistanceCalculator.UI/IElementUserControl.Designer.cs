
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
			this.eventLabel = new System.Windows.Forms.Label();
			this.editButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// eventLabel
			// 
			this.eventLabel.AutoSize = true;
			this.eventLabel.Location = new System.Drawing.Point(9, 66);
			this.eventLabel.Name = "eventLabel";
			this.eventLabel.Size = new System.Drawing.Size(23, 20);
			this.eventLabel.TabIndex = 1;
			this.eventLabel.Text = "⨂";
			// 
			// editButton
			// 
			this.editButton.Location = new System.Drawing.Point(48, 60);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(25, 30);
			this.editButton.TabIndex = 2;
			this.editButton.Text = "e";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// IElementUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.eventLabel);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.Name = "IElementUserControl";
			this.Size = new System.Drawing.Size(80, 97);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label eventLabel;
		private System.Windows.Forms.Button editButton;
	}
}
