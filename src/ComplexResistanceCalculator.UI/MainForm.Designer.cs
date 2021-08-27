
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.AddResistorButton = new System.Windows.Forms.Button();
			this.AddInductorButton = new System.Windows.Forms.Button();
			this.AddCapacitorButton = new System.Windows.Forms.Button();
			this.ElementsNameLabel = new System.Windows.Forms.Label();
			this.ElementsValueLabel = new System.Windows.Forms.Label();
			this.elementNameTextBox = new System.Windows.Forms.TextBox();
			this.elementsValueTextBox = new System.Windows.Forms.TextBox();
			this.calculateZbutton = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.circuitElementsPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// AddResistorButton
			// 
			this.AddResistorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddResistorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddResistorButton.BackgroundImage")));
			this.AddResistorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.AddResistorButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AddResistorButton.FlatAppearance.BorderSize = 0;
			this.AddResistorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddResistorButton.Location = new System.Drawing.Point(27, 213);
			this.AddResistorButton.Name = "AddResistorButton";
			this.AddResistorButton.Size = new System.Drawing.Size(35, 35);
			this.AddResistorButton.TabIndex = 0;
			this.AddResistorButton.UseVisualStyleBackColor = true;
			this.AddResistorButton.Click += new System.EventHandler(this.AddResistorButton_Click);
			this.AddResistorButton.MouseEnter += new System.EventHandler(this.AddResistorButton_MouseEnter);
			// 
			// AddInductorButton
			// 
			this.AddInductorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddInductorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddInductorButton.BackgroundImage")));
			this.AddInductorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.AddInductorButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AddInductorButton.FlatAppearance.BorderSize = 0;
			this.AddInductorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddInductorButton.Location = new System.Drawing.Point(27, 298);
			this.AddInductorButton.Name = "AddInductorButton";
			this.AddInductorButton.Size = new System.Drawing.Size(35, 35);
			this.AddInductorButton.TabIndex = 1;
			this.AddInductorButton.UseVisualStyleBackColor = true;
			this.AddInductorButton.Click += new System.EventHandler(this.AddInductorButton_Click);
			this.AddInductorButton.MouseEnter += new System.EventHandler(this.AddInductorButton_MouseEnter);
			// 
			// AddCapacitorButton
			// 
			this.AddCapacitorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddCapacitorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddCapacitorButton.BackgroundImage")));
			this.AddCapacitorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.AddCapacitorButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AddCapacitorButton.FlatAppearance.BorderSize = 0;
			this.AddCapacitorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.AddCapacitorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddCapacitorButton.Location = new System.Drawing.Point(27, 115);
			this.AddCapacitorButton.Name = "AddCapacitorButton";
			this.AddCapacitorButton.Size = new System.Drawing.Size(35, 35);
			this.AddCapacitorButton.TabIndex = 2;
			this.AddCapacitorButton.UseVisualStyleBackColor = true;
			this.AddCapacitorButton.Click += new System.EventHandler(this.AddCapacitorButton_Click);
			this.AddCapacitorButton.MouseEnter += new System.EventHandler(this.AddCapacitorButton_MouseEnter);
			// 
			// ElementsNameLabel
			// 
			this.ElementsNameLabel.AutoSize = true;
			this.ElementsNameLabel.Location = new System.Drawing.Point(98, 35);
			this.ElementsNameLabel.Name = "ElementsNameLabel";
			this.ElementsNameLabel.Size = new System.Drawing.Size(49, 20);
			this.ElementsNameLabel.TabIndex = 3;
			this.ElementsNameLabel.Text = "Name";
			// 
			// ElementsValueLabel
			// 
			this.ElementsValueLabel.AutoSize = true;
			this.ElementsValueLabel.Location = new System.Drawing.Point(294, 35);
			this.ElementsValueLabel.Name = "ElementsValueLabel";
			this.ElementsValueLabel.Size = new System.Drawing.Size(45, 20);
			this.ElementsValueLabel.TabIndex = 4;
			this.ElementsValueLabel.Text = "Value";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(153, 32);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.ReadOnly = true;
			this.elementNameTextBox.Size = new System.Drawing.Size(114, 27);
			this.elementNameTextBox.TabIndex = 6;
			// 
			// elementsValueTextBox
			// 
			this.elementsValueTextBox.Location = new System.Drawing.Point(345, 32);
			this.elementsValueTextBox.Name = "elementsValueTextBox";
			this.elementsValueTextBox.ReadOnly = true;
			this.elementsValueTextBox.Size = new System.Drawing.Size(115, 27);
			this.elementsValueTextBox.TabIndex = 7;
			// 
			// calculateZbutton
			// 
			this.calculateZbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.calculateZbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("calculateZbutton.BackgroundImage")));
			this.calculateZbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.calculateZbutton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.calculateZbutton.FlatAppearance.BorderSize = 0;
			this.calculateZbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.calculateZbutton.Location = new System.Drawing.Point(27, 384);
			this.calculateZbutton.Name = "calculateZbutton";
			this.calculateZbutton.Size = new System.Drawing.Size(32, 32);
			this.calculateZbutton.TabIndex = 9;
			this.calculateZbutton.UseVisualStyleBackColor = true;
			this.calculateZbutton.Click += new System.EventHandler(this.calculateZbutton_Click);
			this.calculateZbutton.MouseEnter += new System.EventHandler(this.calculateZbutton_MouseEnter);
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveElementButton.BackgroundImage")));
			this.RemoveElementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.RemoveElementButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RemoveElementButton.FlatAppearance.BorderSize = 0;
			this.RemoveElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveElementButton.Location = new System.Drawing.Point(27, 27);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(35, 36);
			this.RemoveElementButton.TabIndex = 10;
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			this.RemoveElementButton.MouseEnter += new System.EventHandler(this.RemoveElementButton_MouseEnter);
			// 
			// circuitElementsPanel
			// 
			this.circuitElementsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.circuitElementsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.circuitElementsPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.circuitElementsPanel.Location = new System.Drawing.Point(89, 65);
			this.circuitElementsPanel.Name = "circuitElementsPanel";
			this.circuitElementsPanel.Size = new System.Drawing.Size(705, 380);
			this.circuitElementsPanel.TabIndex = 11;
			this.circuitElementsPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.circuitElementsPanel_ControlAdded);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(802, 453);
			this.Controls.Add(this.circuitElementsPanel);
			this.Controls.Add(this.RemoveElementButton);
			this.Controls.Add(this.calculateZbutton);
			this.Controls.Add(this.elementsValueTextBox);
			this.Controls.Add(this.elementNameTextBox);
			this.Controls.Add(this.ElementsValueLabel);
			this.Controls.Add(this.ElementsNameLabel);
			this.Controls.Add(this.AddCapacitorButton);
			this.Controls.Add(this.AddInductorButton);
			this.Controls.Add(this.AddResistorButton);
			this.MinimumSize = new System.Drawing.Size(820, 500);
			this.Name = "mainForm";
			this.Text = "ComplexResistance Calculator";
			this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AddResistorButton;
		private System.Windows.Forms.Button AddInductorButton;
		private System.Windows.Forms.Button AddCapacitorButton;
		private System.Windows.Forms.Label ElementsNameLabel;
		private System.Windows.Forms.Label ElementsValueLabel;
		private System.Windows.Forms.TextBox elementNameTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button calculateZbutton;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.TextBox elementsValueTextBox;
		private System.Windows.Forms.Panel circuitElementsPanel;
	}
}

