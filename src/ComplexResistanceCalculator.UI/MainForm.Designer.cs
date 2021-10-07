
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
			this.mainFormToolTip = new System.Windows.Forms.ToolTip(this.components);
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
			this.AddResistorButton.Location = new System.Drawing.Point(24, 160);
			this.AddResistorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddResistorButton.Name = "AddResistorButton";
			this.AddResistorButton.Size = new System.Drawing.Size(31, 26);
			this.AddResistorButton.TabIndex = 0;
			this.mainFormToolTip.SetToolTip(this.AddResistorButton, "Add resistor");
			this.AddResistorButton.UseVisualStyleBackColor = true;
			this.AddResistorButton.Click += new System.EventHandler(this.AddResistorButton_Click);
			// 
			// AddInductorButton
			// 
			this.AddInductorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddInductorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddInductorButton.BackgroundImage")));
			this.AddInductorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.AddInductorButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AddInductorButton.FlatAppearance.BorderSize = 0;
			this.AddInductorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddInductorButton.Location = new System.Drawing.Point(24, 224);
			this.AddInductorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddInductorButton.Name = "AddInductorButton";
			this.AddInductorButton.Size = new System.Drawing.Size(31, 26);
			this.AddInductorButton.TabIndex = 1;
			this.mainFormToolTip.SetToolTip(this.AddInductorButton, "Add inductor");
			this.AddInductorButton.UseVisualStyleBackColor = true;
			this.AddInductorButton.Click += new System.EventHandler(this.AddInductorButton_Click);
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
			this.AddCapacitorButton.Location = new System.Drawing.Point(24, 86);
			this.AddCapacitorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddCapacitorButton.Name = "AddCapacitorButton";
			this.AddCapacitorButton.Size = new System.Drawing.Size(31, 26);
			this.AddCapacitorButton.TabIndex = 2;
			this.mainFormToolTip.SetToolTip(this.AddCapacitorButton, "Add capacitor");
			this.AddCapacitorButton.UseVisualStyleBackColor = true;
			this.AddCapacitorButton.Click += new System.EventHandler(this.AddCapacitorButton_Click);
			// 
			// ElementsNameLabel
			// 
			this.ElementsNameLabel.AutoSize = true;
			this.ElementsNameLabel.Location = new System.Drawing.Point(86, 26);
			this.ElementsNameLabel.Name = "ElementsNameLabel";
			this.ElementsNameLabel.Size = new System.Drawing.Size(39, 15);
			this.ElementsNameLabel.TabIndex = 3;
			this.ElementsNameLabel.Text = "Name";
			// 
			// ElementsValueLabel
			// 
			this.ElementsValueLabel.AutoSize = true;
			this.ElementsValueLabel.Location = new System.Drawing.Point(257, 26);
			this.ElementsValueLabel.Name = "ElementsValueLabel";
			this.ElementsValueLabel.Size = new System.Drawing.Size(35, 15);
			this.ElementsValueLabel.TabIndex = 4;
			this.ElementsValueLabel.Text = "Value";
			// 
			// elementNameTextBox
			// 
			this.elementNameTextBox.Location = new System.Drawing.Point(134, 24);
			this.elementNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.elementNameTextBox.Name = "elementNameTextBox";
			this.elementNameTextBox.ReadOnly = true;
			this.elementNameTextBox.Size = new System.Drawing.Size(100, 23);
			this.elementNameTextBox.TabIndex = 6;
			// 
			// elementsValueTextBox
			// 
			this.elementsValueTextBox.Location = new System.Drawing.Point(302, 24);
			this.elementsValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.elementsValueTextBox.Name = "elementsValueTextBox";
			this.elementsValueTextBox.ReadOnly = true;
			this.elementsValueTextBox.Size = new System.Drawing.Size(101, 23);
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
			this.calculateZbutton.Location = new System.Drawing.Point(24, 288);
			this.calculateZbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.calculateZbutton.Name = "calculateZbutton";
			this.calculateZbutton.Size = new System.Drawing.Size(28, 24);
			this.calculateZbutton.TabIndex = 9;
			this.mainFormToolTip.SetToolTip(this.calculateZbutton, "Calculate impedance");
			this.calculateZbutton.UseVisualStyleBackColor = true;
			this.calculateZbutton.Click += new System.EventHandler(this.calculateZbutton_Click);
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveElementButton.BackgroundImage")));
			this.RemoveElementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.RemoveElementButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RemoveElementButton.FlatAppearance.BorderSize = 0;
			this.RemoveElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveElementButton.Location = new System.Drawing.Point(24, 17);
			this.RemoveElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(31, 27);
			this.RemoveElementButton.TabIndex = 10;
			this.mainFormToolTip.SetToolTip(this.RemoveElementButton, "Delete element");
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// circuitElementsPanel
			// 
			this.circuitElementsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.circuitElementsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.circuitElementsPanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.circuitElementsPanel.Location = new System.Drawing.Point(78, 49);
			this.circuitElementsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.circuitElementsPanel.Name = "circuitElementsPanel";
			this.circuitElementsPanel.Size = new System.Drawing.Size(617, 286);
			this.circuitElementsPanel.TabIndex = 11;
			this.circuitElementsPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.circuitElementsPanel_ControlAdded);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.ClientSize = new System.Drawing.Size(704, 346);
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
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(720, 385);
			this.Name = "MainForm";
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
		private System.Windows.Forms.ToolTip mainFormToolTip;
	}
}

