
namespace ComplexResistanceCalculator.UI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AddResistorButton = new System.Windows.Forms.Button();
			this.AddInductorButton = new System.Windows.Forms.Button();
			this.AddCapacitorButton = new System.Windows.Forms.Button();
			this.ElementsNameLabel = new System.Windows.Forms.Label();
			this.ElementsValueLabel = new System.Windows.Forms.Label();
			this.ElementsFrequencyLabel = new System.Windows.Forms.Label();
			this.elementNameTextBox = new System.Windows.Forms.TextBox();
			this.elementsValueTextBox = new System.Windows.Forms.TextBox();
			this.elementsFrequencyTextBox = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// AddResistorButton
			// 
			this.AddResistorButton.Location = new System.Drawing.Point(309, 385);
			this.AddResistorButton.Name = "AddResistorButton";
			this.AddResistorButton.Size = new System.Drawing.Size(67, 53);
			this.AddResistorButton.TabIndex = 0;
			this.AddResistorButton.Text = "Add R";
			this.AddResistorButton.UseVisualStyleBackColor = true;
			// 
			// AddInductorButton
			// 
			this.AddInductorButton.Location = new System.Drawing.Point(436, 385);
			this.AddInductorButton.Name = "AddInductorButton";
			this.AddInductorButton.Size = new System.Drawing.Size(67, 53);
			this.AddInductorButton.TabIndex = 1;
			this.AddInductorButton.Text = "Add L";
			this.AddInductorButton.UseVisualStyleBackColor = true;
			// 
			// AddCapacitorButton
			// 
			this.AddCapacitorButton.Location = new System.Drawing.Point(552, 385);
			this.AddCapacitorButton.Name = "AddCapacitorButton";
			this.AddCapacitorButton.Size = new System.Drawing.Size(68, 53);
			this.AddCapacitorButton.TabIndex = 2;
			this.AddCapacitorButton.Text = "Add C";
			this.AddCapacitorButton.UseVisualStyleBackColor = true;
			// 
			// ElementsNameLabel
			// 
			this.ElementsNameLabel.AutoSize = true;
			this.ElementsNameLabel.Location = new System.Drawing.Point(50, 77);
			this.ElementsNameLabel.Name = "ElementsNameLabel";
			this.ElementsNameLabel.Size = new System.Drawing.Size(49, 20);
			this.ElementsNameLabel.TabIndex = 3;
			this.ElementsNameLabel.Text = "Name";
			// 
			// ElementsValueLabel
			// 
			this.ElementsValueLabel.AutoSize = true;
			this.ElementsValueLabel.Location = new System.Drawing.Point(54, 139);
			this.ElementsValueLabel.Name = "ElementsValueLabel";
			this.ElementsValueLabel.Size = new System.Drawing.Size(45, 20);
			this.ElementsValueLabel.TabIndex = 4;
			this.ElementsValueLabel.Text = "Value";
			// 
			// ElementsFrequencyLabel
			// 
			this.ElementsFrequencyLabel.AutoSize = true;
			this.ElementsFrequencyLabel.Location = new System.Drawing.Point(39, 202);
			this.ElementsFrequencyLabel.Name = "ElementsFrequencyLabel";
			this.ElementsFrequencyLabel.Size = new System.Drawing.Size(76, 20);
			this.ElementsFrequencyLabel.TabIndex = 5;
			this.ElementsFrequencyLabel.Text = "Frequency";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(22, 100);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.Size = new System.Drawing.Size(114, 27);
			this.elementNameTextBox.TabIndex = 6;
			// 
			// elementsValueTextBox
			// 
			this.elementsValueTextBox.Location = new System.Drawing.Point(22, 162);
			this.elementsValueTextBox.Name = "elementsValueTextBox";
			this.elementsValueTextBox.Size = new System.Drawing.Size(115, 27);
			this.elementsValueTextBox.TabIndex = 7;
			// 
			// elementsFrequencyTextBox
			// 
			this.elementsFrequencyTextBox.Location = new System.Drawing.Point(22, 225);
			this.elementsFrequencyTextBox.Name = "elementsFrequencyTextBox";
			this.elementsFrequencyTextBox.Size = new System.Drawing.Size(115, 27);
			this.elementsFrequencyTextBox.TabIndex = 8;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(694, 385);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(94, 53);
			this.button4.TabIndex = 9;
			this.button4.Text = "Рассчитать";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.Location = new System.Drawing.Point(23, 385);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(114, 53);
			this.RemoveElementButton.TabIndex = 10;
			this.RemoveElementButton.Text = "Remove element";
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(143, 77);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(645, 238);
			this.panel1.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.RemoveElementButton);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.elementsFrequencyTextBox);
			this.Controls.Add(this.elementsValueTextBox);
			this.Controls.Add(this.elementNameTextBox);
			this.Controls.Add(this.ElementsFrequencyLabel);
			this.Controls.Add(this.ElementsValueLabel);
			this.Controls.Add(this.ElementsNameLabel);
			this.Controls.Add(this.AddCapacitorButton);
			this.Controls.Add(this.AddInductorButton);
			this.Controls.Add(this.AddResistorButton);
			this.Name = "MainForm";
			this.Text = "ComplexResistance Calculator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AddResistorButton;
		private System.Windows.Forms.Button AddInductorButton;
		private System.Windows.Forms.Button AddCapacitorButton;
		private System.Windows.Forms.Label ElementsNameLabel;
		private System.Windows.Forms.Label ElementsValueLabel;
		private System.Windows.Forms.Label ElementsFrequencyLabel;
		private System.Windows.Forms.TextBox elementNameTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox elementsFrequencyTextBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.TextBox elementsValueTextBox;
		private System.Windows.Forms.Panel panel1;
	}
}

