
namespace ComplexResistanceCalculator.UI
{
    // TODO: здесь в названии буква I лишняя - создаёт ложное понимание, что это не контрол, а интерфейс для контролов
	partial class ElementControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementControl));
			this.editButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// editButton
			// 
			this.editButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editButton.BackgroundImage")));
			this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.editButton.FlatAppearance.BorderSize = 0;
			this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editButton.Location = new System.Drawing.Point(39, 49);
			this.editButton.Margin = new System.Windows.Forms.Padding(0);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(22, 19);
			this.editButton.TabIndex = 2;
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			this.editButton.MouseEnter += new System.EventHandler(this.editButton_MouseEnter);
			// 
			// ElementControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.editButton);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
			this.Name = "ElementControl";
			this.Size = new System.Drawing.Size(70, 75);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button editButton;
	}
}
