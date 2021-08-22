
namespace ComplexResistanceCalculator.UI
{
	partial class AddForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.elementNameTextBox = new System.Windows.Forms.TextBox();
			this.elementValueTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(129, 166);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(68, 50);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Value";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(72, 41);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.Size = new System.Drawing.Size(125, 27);
			this.elementNameTextBox.TabIndex = 4;
			// 
			// elementValueTextBox
			// 
			this.elementValueTextBox.Location = new System.Drawing.Point(72, 116);
			this.elementValueTextBox.Name = "elementValueTextBox";
			this.elementValueTextBox.Size = new System.Drawing.Size(125, 27);
			this.elementValueTextBox.TabIndex = 5;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(12, 166);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(68, 50);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// AddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(212, 228);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.elementValueTextBox);
			this.Controls.Add(this.elementNameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.label1);
			this.MaximumSize = new System.Drawing.Size(230, 275);
			this.MinimumSize = new System.Drawing.Size(230, 275);
			this.Name = "AddForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox elementNameTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox elementValueTextBox;
	}
}