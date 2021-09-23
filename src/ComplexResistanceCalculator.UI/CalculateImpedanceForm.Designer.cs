
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.firstValueTextBox = new System.Windows.Forms.TextBox();
			this.fromLabel = new System.Windows.Forms.Label();
			this.toLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.stepLabel = new System.Windows.Forms.Label();
			this.calculateButton = new System.Windows.Forms.Button();
			this.lastValueTextBox = new System.Windows.Forms.TextBox();
			this.stepTextBox = new System.Windows.Forms.TextBox();
			this.welcomingLabel = new System.Windows.Forms.Label();
			this.prefixValueComboBoxFirstVal = new System.Windows.Forms.ComboBox();
			this.prefixValueComboBoxLastVal = new System.Windows.Forms.ComboBox();
			this.prefixStepComboBoxStep = new System.Windows.Forms.ComboBox();
			this.resultDataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// firstValueTextBox
			// 
			this.firstValueTextBox.Location = new System.Drawing.Point(61, 60);
			this.firstValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.firstValueTextBox.Name = "firstValueTextBox";
			this.firstValueTextBox.Size = new System.Drawing.Size(169, 23);
			this.firstValueTextBox.TabIndex = 1;
			// 
			// fromLabel
			// 
			this.fromLabel.AutoSize = true;
			this.fromLabel.Location = new System.Drawing.Point(10, 60);
			this.fromLabel.Name = "fromLabel";
			this.fromLabel.Size = new System.Drawing.Size(38, 15);
			this.fromLabel.TabIndex = 4;
			this.fromLabel.Text = "From:";
			// 
			// toLabel
			// 
			this.toLabel.AutoSize = true;
			this.toLabel.Location = new System.Drawing.Point(10, 89);
			this.toLabel.Name = "toLabel";
			this.toLabel.Size = new System.Drawing.Size(22, 15);
			this.toLabel.TabIndex = 5;
			this.toLabel.Text = "To:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-284, -56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Enter frequency range";
			// 
			// stepLabel
			// 
			this.stepLabel.AutoSize = true;
			this.stepLabel.Location = new System.Drawing.Point(10, 119);
			this.stepLabel.Name = "stepLabel";
			this.stepLabel.Size = new System.Drawing.Size(33, 15);
			this.stepLabel.TabIndex = 7;
			this.stepLabel.Text = "Step:";
			// 
			// calculateButton
			// 
			this.calculateButton.Location = new System.Drawing.Point(117, 196);
			this.calculateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.calculateButton.Name = "calculateButton";
			this.calculateButton.Size = new System.Drawing.Size(83, 22);
			this.calculateButton.TabIndex = 8;
			this.calculateButton.Text = "Calculate";
			this.calculateButton.UseVisualStyleBackColor = true;
			this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
			// 
			// lastValueTextBox
			// 
			this.lastValueTextBox.Location = new System.Drawing.Point(61, 89);
			this.lastValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lastValueTextBox.Name = "lastValueTextBox";
			this.lastValueTextBox.Size = new System.Drawing.Size(169, 23);
			this.lastValueTextBox.TabIndex = 9;
			// 
			// stepTextBox
			// 
			this.stepTextBox.Location = new System.Drawing.Point(61, 117);
			this.stepTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.stepTextBox.Name = "stepTextBox";
			this.stepTextBox.Size = new System.Drawing.Size(112, 23);
			this.stepTextBox.TabIndex = 10;
			// 
			// welcomingLabel
			// 
			this.welcomingLabel.AutoSize = true;
			this.welcomingLabel.Location = new System.Drawing.Point(95, 32);
			this.welcomingLabel.Name = "welcomingLabel";
			this.welcomingLabel.Size = new System.Drawing.Size(123, 15);
			this.welcomingLabel.TabIndex = 11;
			this.welcomingLabel.Text = "Enter frequency range";
			// 
			// prefixValueComboBoxFirstVal
			// 
			this.prefixValueComboBoxFirstVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.prefixValueComboBoxFirstVal.FormattingEnabled = true;
			this.prefixValueComboBoxFirstVal.Location = new System.Drawing.Point(233, 60);
			this.prefixValueComboBoxFirstVal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.prefixValueComboBoxFirstVal.Name = "prefixValueComboBoxFirstVal";
			this.prefixValueComboBoxFirstVal.Size = new System.Drawing.Size(53, 23);
			this.prefixValueComboBoxFirstVal.TabIndex = 12;
			// 
			// prefixValueComboBoxLastVal
			// 
			this.prefixValueComboBoxLastVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.prefixValueComboBoxLastVal.FormattingEnabled = true;
			this.prefixValueComboBoxLastVal.Location = new System.Drawing.Point(233, 89);
			this.prefixValueComboBoxLastVal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.prefixValueComboBoxLastVal.Name = "prefixValueComboBoxLastVal";
			this.prefixValueComboBoxLastVal.Size = new System.Drawing.Size(53, 23);
			this.prefixValueComboBoxLastVal.TabIndex = 13;
			// 
			// prefixStepComboBoxStep
			// 
			this.prefixStepComboBoxStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.prefixStepComboBoxStep.FormattingEnabled = true;
			this.prefixStepComboBoxStep.Location = new System.Drawing.Point(178, 116);
			this.prefixStepComboBoxStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.prefixStepComboBoxStep.Name = "prefixStepComboBoxStep";
			this.prefixStepComboBoxStep.Size = new System.Drawing.Size(53, 23);
			this.prefixStepComboBoxStep.TabIndex = 14;
			// 
			// resultDataGridView
			// 
			this.resultDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.resultDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.resultDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.resultDataGridView.Location = new System.Drawing.Point(292, 12);
			this.resultDataGridView.Name = "resultDataGridView";
			this.resultDataGridView.ReadOnly = true;
			this.resultDataGridView.RowTemplate.Height = 25;
			this.resultDataGridView.Size = new System.Drawing.Size(400, 209);
			this.resultDataGridView.TabIndex = 15;
			// 
			// CalculateImpedanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 233);
			this.Controls.Add(this.resultDataGridView);
			this.Controls.Add(this.prefixStepComboBoxStep);
			this.Controls.Add(this.prefixValueComboBoxLastVal);
			this.Controls.Add(this.prefixValueComboBoxFirstVal);
			this.Controls.Add(this.welcomingLabel);
			this.Controls.Add(this.stepTextBox);
			this.Controls.Add(this.lastValueTextBox);
			this.Controls.Add(this.calculateButton);
			this.Controls.Add(this.stepLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toLabel);
			this.Controls.Add(this.fromLabel);
			this.Controls.Add(this.firstValueTextBox);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(720, 272);
			this.MinimumSize = new System.Drawing.Size(720, 272);
			this.Name = "CalculateImpedanceForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Calculate impedance";
			((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
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
		private System.Windows.Forms.Label welcomingLabel;
		private System.Windows.Forms.ComboBox prefixValueComboBoxFirstVal;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox prefixValueComboBox2;
		private System.Windows.Forms.ComboBox prefixStepComboBox3;
		private System.Windows.Forms.ComboBox prefixValueComboBoxLastVal;
		private System.Windows.Forms.ComboBox prefixStepComboBoxStep;
		private System.Windows.Forms.DataGridView resultDataGridView;
	}
}