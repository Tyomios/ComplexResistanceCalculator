
namespace ComplexResistanceCalculator.UI
{
	partial class AddEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditForm));
			this.elementNameLabel = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.elementValueLabel = new System.Windows.Forms.Label();
			this.elementNameTextBox = new System.Windows.Forms.TextBox();
			this.elementValueTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.dimensionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// elementNameLabel
			// 
			this.elementNameLabel.AutoSize = true;
			this.elementNameLabel.Location = new System.Drawing.Point(12, 44);
			this.elementNameLabel.Name = "elementNameLabel";
			this.elementNameLabel.Size = new System.Drawing.Size(49, 20);
			this.elementNameLabel.TabIndex = 0;
			this.elementNameLabel.Text = "Name";
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(129, 166);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(68, 50);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// elementValueLabel
			// 
			this.elementValueLabel.AutoSize = true;
			this.elementValueLabel.Location = new System.Drawing.Point(12, 119);
			this.elementValueLabel.Name = "elementValueLabel";
			this.elementValueLabel.Size = new System.Drawing.Size(45, 20);
			this.elementValueLabel.TabIndex = 2;
			this.elementValueLabel.Text = "Value";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(63, 41);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.Size = new System.Drawing.Size(120, 27);
			this.elementNameTextBox.TabIndex = 4;
			// 
			// elementValueTextBox
			// 
			this.elementValueTextBox.Location = new System.Drawing.Point(63, 116);
			this.elementValueTextBox.Name = "elementValueTextBox";
			this.elementValueTextBox.Size = new System.Drawing.Size(120, 27);
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
			// dimensionLabel
			// 
			this.dimensionLabel.AutoSize = true;
			this.dimensionLabel.Location = new System.Drawing.Point(184, 119);
			this.dimensionLabel.Name = "dimensionLabel";
			this.dimensionLabel.Size = new System.Drawing.Size(13, 20);
			this.dimensionLabel.TabIndex = 7;
			this.dimensionLabel.Text = "l";
			// 
			// AddEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(212, 228);
			this.Controls.Add(this.dimensionLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.elementValueTextBox);
			this.Controls.Add(this.elementNameTextBox);
			this.Controls.Add(this.elementValueLabel);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.elementNameLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(230, 275);
			this.MinimumSize = new System.Drawing.Size(230, 275);
			this.Name = "AddEditForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label elementNameLabel;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox elementNameTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox elementValueTextBox;
		private System.Windows.Forms.Label dimensionLabel;
		private System.Windows.Forms.Label dimentionLabel;
		private System.Windows.Forms.Label elementValueLabel;
	}
}