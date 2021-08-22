
namespace ComplexResistanceCalculator.UI
{
	partial class CalculateImpedanceForm
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.firstValueTextBox = new System.Windows.Forms.TextBox();
			this.fromLabel = new System.Windows.Forms.Label();
			this.toLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.stepLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.lastValueTextBox = new System.Windows.Forms.TextBox();
			this.stepTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(363, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(425, 283);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// firstValueTextBox
			// 
			this.firstValueTextBox.Location = new System.Drawing.Point(70, 80);
			this.firstValueTextBox.Name = "firstValueTextBox";
			this.firstValueTextBox.Size = new System.Drawing.Size(238, 27);
			this.firstValueTextBox.TabIndex = 1;
			// 
			// fromLabel
			// 
			this.fromLabel.AutoSize = true;
			this.fromLabel.Location = new System.Drawing.Point(12, 80);
			this.fromLabel.Name = "fromLabel";
			this.fromLabel.Size = new System.Drawing.Size(46, 20);
			this.fromLabel.TabIndex = 4;
			this.fromLabel.Text = "From:";
			// 
			// toLabel
			// 
			this.toLabel.AutoSize = true;
			this.toLabel.Location = new System.Drawing.Point(12, 119);
			this.toLabel.Name = "toLabel";
			this.toLabel.Size = new System.Drawing.Size(28, 20);
			this.toLabel.TabIndex = 5;
			this.toLabel.Text = "To:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-324, -75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Enter frequency range";
			// 
			// stepLabel
			// 
			this.stepLabel.AutoSize = true;
			this.stepLabel.Location = new System.Drawing.Point(12, 159);
			this.stepLabel.Name = "stepLabel";
			this.stepLabel.Size = new System.Drawing.Size(42, 20);
			this.stepLabel.TabIndex = 7;
			this.stepLabel.Text = "Step:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(134, 262);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 29);
			this.button1.TabIndex = 8;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// lastValueTextBox
			// 
			this.lastValueTextBox.Location = new System.Drawing.Point(70, 119);
			this.lastValueTextBox.Name = "lastValueTextBox";
			this.lastValueTextBox.Size = new System.Drawing.Size(238, 27);
			this.lastValueTextBox.TabIndex = 9;
			// 
			// stepTextBox
			// 
			this.stepTextBox.Location = new System.Drawing.Point(70, 156);
			this.stepTextBox.Name = "stepTextBox";
			this.stepTextBox.Size = new System.Drawing.Size(125, 27);
			this.stepTextBox.TabIndex = 10;
			// 
			// CalculateImpedanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 303);
			this.Controls.Add(this.stepTextBox);
			this.Controls.Add(this.lastValueTextBox);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.stepLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toLabel);
			this.Controls.Add(this.fromLabel);
			this.Controls.Add(this.firstValueTextBox);
			this.Controls.Add(this.richTextBox1);
			this.Name = "CalculateImpedanceForm";
			this.Text = "CalculateImpedanceForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label enterFrequencyRangeLabel;
		private System.Windows.Forms.Label enterLabel;
		private System.Windows.Forms.TextBox firstValueTextBox;
		private System.Windows.Forms.Label fromLabel;
		private System.Windows.Forms.Label toLabel;
		private System.Windows.Forms.Button calculateButton;
		private System.Windows.Forms.TextBox lastValueTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label stepLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox stepTextBox;
	}
}