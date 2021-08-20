
namespace ComplexResistanceCalculator.UI
{
	partial class mainForm
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
			this.firstFrequencyValueTextBox = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.circuitElementsPanel = new System.Windows.Forms.Panel();
			this.linkFrequencyLabel = new System.Windows.Forms.Label();
			this.lastFrequencyValueTextBox = new System.Windows.Forms.TextBox();
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
			this.AddResistorButton.Click += new System.EventHandler(this.AddResistorButton_Click);
			// 
			// AddInductorButton
			// 
			this.AddInductorButton.Location = new System.Drawing.Point(436, 385);
			this.AddInductorButton.Name = "AddInductorButton";
			this.AddInductorButton.Size = new System.Drawing.Size(67, 53);
			this.AddInductorButton.TabIndex = 1;
			this.AddInductorButton.Text = "Add L";
			this.AddInductorButton.UseVisualStyleBackColor = true;
			this.AddInductorButton.Click += new System.EventHandler(this.AddInductorButton_Click);
			// 
			// AddCapacitorButton
			// 
			this.AddCapacitorButton.Location = new System.Drawing.Point(552, 385);
			this.AddCapacitorButton.Name = "AddCapacitorButton";
			this.AddCapacitorButton.Size = new System.Drawing.Size(68, 53);
			this.AddCapacitorButton.TabIndex = 2;
			this.AddCapacitorButton.Text = "Add C";
			this.AddCapacitorButton.UseVisualStyleBackColor = true;
			this.AddCapacitorButton.Click += new System.EventHandler(this.AddCapacitorButton_Click);
			// 
			// ElementsNameLabel
			// 
			this.ElementsNameLabel.AutoSize = true;
			this.ElementsNameLabel.Location = new System.Drawing.Point(45, 141);
			this.ElementsNameLabel.Name = "ElementsNameLabel";
			this.ElementsNameLabel.Size = new System.Drawing.Size(49, 20);
			this.ElementsNameLabel.TabIndex = 3;
			this.ElementsNameLabel.Text = "Name";
			// 
			// ElementsValueLabel
			// 
			this.ElementsValueLabel.AutoSize = true;
			this.ElementsValueLabel.Location = new System.Drawing.Point(49, 203);
			this.ElementsValueLabel.Name = "ElementsValueLabel";
			this.ElementsValueLabel.Size = new System.Drawing.Size(45, 20);
			this.ElementsValueLabel.TabIndex = 4;
			this.ElementsValueLabel.Text = "Value";
			// 
			// ElementsFrequencyLabel
			// 
			this.ElementsFrequencyLabel.AutoSize = true;
			this.ElementsFrequencyLabel.Location = new System.Drawing.Point(214, 35);
			this.ElementsFrequencyLabel.Name = "ElementsFrequencyLabel";
			this.ElementsFrequencyLabel.Size = new System.Drawing.Size(76, 20);
			this.ElementsFrequencyLabel.TabIndex = 5;
			this.ElementsFrequencyLabel.Text = "Frequency";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(17, 164);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.Size = new System.Drawing.Size(114, 27);
			this.elementNameTextBox.TabIndex = 6;
			// 
			// elementsValueTextBox
			// 
			this.elementsValueTextBox.Location = new System.Drawing.Point(17, 226);
			this.elementsValueTextBox.Name = "elementsValueTextBox";
			this.elementsValueTextBox.Size = new System.Drawing.Size(115, 27);
			this.elementsValueTextBox.TabIndex = 7;
			// 
			// firstFrequencyValueTextBox
			// 
			this.firstFrequencyValueTextBox.Location = new System.Drawing.Point(320, 32);
			this.firstFrequencyValueTextBox.Name = "firstFrequencyValueTextBox";
			this.firstFrequencyValueTextBox.Size = new System.Drawing.Size(115, 27);
			this.firstFrequencyValueTextBox.TabIndex = 8;
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
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// circuitElementsPanel
			// 
			this.circuitElementsPanel.Location = new System.Drawing.Point(137, 65);
			this.circuitElementsPanel.Name = "circuitElementsPanel";
			this.circuitElementsPanel.Size = new System.Drawing.Size(650, 315);
			this.circuitElementsPanel.TabIndex = 11;
			this.circuitElementsPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.circuitElementsPanel_ControlAdded);
			// 
			// linkFrequencyLabel
			// 
			this.linkFrequencyLabel.AutoSize = true;
			this.linkFrequencyLabel.Location = new System.Drawing.Point(452, 35);
			this.linkFrequencyLabel.Name = "linkFrequencyLabel";
			this.linkFrequencyLabel.Size = new System.Drawing.Size(23, 20);
			this.linkFrequencyLabel.TabIndex = 12;
			this.linkFrequencyLabel.Text = "to";
			// 
			// lastFrequencyValueTextBox
			// 
			this.lastFrequencyValueTextBox.Location = new System.Drawing.Point(495, 32);
			this.lastFrequencyValueTextBox.Name = "lastFrequencyValueTextBox";
			this.lastFrequencyValueTextBox.Size = new System.Drawing.Size(125, 27);
			this.lastFrequencyValueTextBox.TabIndex = 13;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lastFrequencyValueTextBox);
			this.Controls.Add(this.linkFrequencyLabel);
			this.Controls.Add(this.circuitElementsPanel);
			this.Controls.Add(this.RemoveElementButton);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.firstFrequencyValueTextBox);
			this.Controls.Add(this.elementsValueTextBox);
			this.Controls.Add(this.elementNameTextBox);
			this.Controls.Add(this.ElementsFrequencyLabel);
			this.Controls.Add(this.ElementsValueLabel);
			this.Controls.Add(this.ElementsNameLabel);
			this.Controls.Add(this.AddCapacitorButton);
			this.Controls.Add(this.AddInductorButton);
			this.Controls.Add(this.AddResistorButton);
			this.Name = "mainForm";
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
		private System.Windows.Forms.TextBox firstFrequencyValueTextBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.TextBox elementsValueTextBox;
		private System.Windows.Forms.Panel circuitElementsPanel;
		private System.Windows.Forms.Label linkFrequencyLabel;
		private System.Windows.Forms.TextBox lastFrequencyValueTextBox;
	}
}

