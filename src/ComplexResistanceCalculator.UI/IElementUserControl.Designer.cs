﻿
namespace ComplexResistanceCalculator.UI
{
    // TODO: здесь в названии буква I лишняя - создаёт ложное понимание, что это не контрол, а интерфейс для контролов
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IElementUserControl));
			this.editButton = new System.Windows.Forms.Button();
			this.eventPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// editButton
			// 
			this.editButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editButton.BackgroundImage")));
			this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.editButton.FlatAppearance.BorderSize = 0;
			this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editButton.Location = new System.Drawing.Point(45, 65);
			this.editButton.Margin = new System.Windows.Forms.Padding(0);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(25, 25);
			this.editButton.TabIndex = 2;
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			this.editButton.MouseEnter += new System.EventHandler(this.editButton_MouseEnter);
			// 
			// eventPictureBox
			// 
			this.eventPictureBox.Location = new System.Drawing.Point(10, 65);
			this.eventPictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.eventPictureBox.Name = "eventPictureBox";
			this.eventPictureBox.Size = new System.Drawing.Size(25, 25);
			this.eventPictureBox.TabIndex = 3;
			this.eventPictureBox.TabStop = false;
			// 
			// IElementUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.eventPictureBox);
			this.Controls.Add(this.editButton);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.Name = "IElementUserControl";
			this.Size = new System.Drawing.Size(80, 100);
			((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.PictureBox eventPictureBox;
	}
}
