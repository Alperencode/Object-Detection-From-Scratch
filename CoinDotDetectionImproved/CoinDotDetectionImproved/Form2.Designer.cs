namespace CoinDotDetectionImproved
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.BSLNumeric = new System.Windows.Forms.NumericUpDown();
            this.BSLLabel = new System.Windows.Forms.Label();
            this.BlackSequenceToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.HPTLabel = new System.Windows.Forms.Label();
            this.HPTNumeric = new System.Windows.Forms.NumericUpDown();
            this.HPTToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.WPTNumeric = new System.Windows.Forms.NumericUpDown();
            this.WPTLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.WPTToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BSLNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HPTNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPTNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // BSLNumeric
            // 
            this.BSLNumeric.Location = new System.Drawing.Point(317, 46);
            this.BSLNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.BSLNumeric.Name = "BSLNumeric";
            this.BSLNumeric.Size = new System.Drawing.Size(59, 27);
            this.BSLNumeric.TabIndex = 0;
            this.BSLNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // BSLLabel
            // 
            this.BSLLabel.AutoSize = true;
            this.BSLLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BSLLabel.Location = new System.Drawing.Point(29, 41);
            this.BSLLabel.Name = "BSLLabel";
            this.BSLLabel.Size = new System.Drawing.Size(282, 32);
            this.BSLLabel.TabIndex = 1;
            this.BSLLabel.Text = "Black Sequence Length:";
            this.BSLLabel.MouseHover += new System.EventHandler(this.BlackSequenceLengthLabel_MouseHover);
            // 
            // HPTLabel
            // 
            this.HPTLabel.AutoSize = true;
            this.HPTLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HPTLabel.Location = new System.Drawing.Point(29, 101);
            this.HPTLabel.Name = "HPTLabel";
            this.HPTLabel.Size = new System.Drawing.Size(276, 32);
            this.HPTLabel.TabIndex = 2;
            this.HPTLabel.Text = "Height Pixel Tolerance:";
            this.HPTLabel.MouseHover += new System.EventHandler(this.HPTLabel_MouseHover);
            // 
            // HPTNumeric
            // 
            this.HPTNumeric.Location = new System.Drawing.Point(317, 106);
            this.HPTNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.HPTNumeric.Name = "HPTNumeric";
            this.HPTNumeric.Size = new System.Drawing.Size(59, 27);
            this.HPTNumeric.TabIndex = 3;
            this.HPTNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // WPTNumeric
            // 
            this.WPTNumeric.Location = new System.Drawing.Point(317, 173);
            this.WPTNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.WPTNumeric.Name = "WPTNumeric";
            this.WPTNumeric.Size = new System.Drawing.Size(59, 27);
            this.WPTNumeric.TabIndex = 5;
            // 
            // WPTLabel
            // 
            this.WPTLabel.AutoSize = true;
            this.WPTLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WPTLabel.Location = new System.Drawing.Point(29, 168);
            this.WPTLabel.Name = "WPTLabel";
            this.WPTLabel.Size = new System.Drawing.Size(269, 32);
            this.WPTLabel.TabIndex = 4;
            this.WPTLabel.Text = "Width Pixel Tolerance:";
            this.WPTLabel.MouseHover += new System.EventHandler(this.WPTLabel_MouseHover);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(146, 257);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(159, 61);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save and Run";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 359);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.WPTNumeric);
            this.Controls.Add(this.WPTLabel);
            this.Controls.Add(this.HPTNumeric);
            this.Controls.Add(this.HPTLabel);
            this.Controls.Add(this.BSLLabel);
            this.Controls.Add(this.BSLNumeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BSLNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HPTNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WPTNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown BSLNumeric;
        private Label BSLLabel;
        private ToolTip BlackSequenceToolTip;
        private Label HPTLabel;
        private NumericUpDown HPTNumeric;
        private ToolTip HPTToolTip;
        private NumericUpDown WPTNumeric;
        private Label WPTLabel;
        private Button SaveButton;
        private ToolTip WPTToolTip;
    }
}