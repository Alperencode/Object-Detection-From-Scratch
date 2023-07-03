namespace CoinDotDetection
{
    partial class Form1
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
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.originalImageLabel = new System.Windows.Forms.Label();
            this.coin1PictureBox = new System.Windows.Forms.PictureBox();
            this.coin2PictureBox = new System.Windows.Forms.PictureBox();
            this.coin1Label = new System.Windows.Forms.Label();
            this.coin2Label = new System.Windows.Forms.Label();
            this.CoinWithDotPictureBox = new System.Windows.Forms.PictureBox();
            this.CoinWithDotLabel = new System.Windows.Forms.Label();
            this.CoinComparePictureBox = new System.Windows.Forms.PictureBox();
            this.CoinCompareLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.BSWLabel = new System.Windows.Forms.Label();
            this.BSHLabel = new System.Windows.Forms.Label();
            this.pixelToleranceLabel = new System.Windows.Forms.Label();
            this.BSWTrackbar = new System.Windows.Forms.TrackBar();
            this.BSHTrackbar = new System.Windows.Forms.TrackBar();
            this.pixelToleranceInput = new System.Windows.Forms.NumericUpDown();
            this.BSWTrackbarLabel = new System.Windows.Forms.Label();
            this.BSHTrackbarLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.BScanLabel = new System.Windows.Forms.Label();
            this.BackgroundScanInput = new System.Windows.Forms.NumericUpDown();
            this.detectLabel = new System.Windows.Forms.Label();
            this.BSTrackbarLabel = new System.Windows.Forms.Label();
            this.BSTrackbar = new System.Windows.Forms.TrackBar();
            this.BSLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinWithDotPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinComparePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSWTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSHTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelToleranceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundScanInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Location = new System.Drawing.Point(58, 98);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(292, 216);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // originalImageLabel
            // 
            this.originalImageLabel.AutoSize = true;
            this.originalImageLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.originalImageLabel.Location = new System.Drawing.Point(58, 327);
            this.originalImageLabel.Name = "originalImageLabel";
            this.originalImageLabel.Size = new System.Drawing.Size(285, 54);
            this.originalImageLabel.TabIndex = 1;
            this.originalImageLabel.Text = "Original Image";
            // 
            // coin1PictureBox
            // 
            this.coin1PictureBox.Location = new System.Drawing.Point(467, 98);
            this.coin1PictureBox.Name = "coin1PictureBox";
            this.coin1PictureBox.Size = new System.Drawing.Size(292, 216);
            this.coin1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin1PictureBox.TabIndex = 2;
            this.coin1PictureBox.TabStop = false;
            // 
            // coin2PictureBox
            // 
            this.coin2PictureBox.Location = new System.Drawing.Point(861, 98);
            this.coin2PictureBox.Name = "coin2PictureBox";
            this.coin2PictureBox.Size = new System.Drawing.Size(292, 216);
            this.coin2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin2PictureBox.TabIndex = 3;
            this.coin2PictureBox.TabStop = false;
            // 
            // coin1Label
            // 
            this.coin1Label.AutoSize = true;
            this.coin1Label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.coin1Label.Location = new System.Drawing.Point(539, 327);
            this.coin1Label.Name = "coin1Label";
            this.coin1Label.Size = new System.Drawing.Size(137, 54);
            this.coin1Label.TabIndex = 4;
            this.coin1Label.Text = "Coin 1";
            // 
            // coin2Label
            // 
            this.coin2Label.AutoSize = true;
            this.coin2Label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.coin2Label.Location = new System.Drawing.Point(962, 327);
            this.coin2Label.Name = "coin2Label";
            this.coin2Label.Size = new System.Drawing.Size(137, 54);
            this.coin2Label.TabIndex = 5;
            this.coin2Label.Text = "Coin 2";
            // 
            // CoinWithDotPictureBox
            // 
            this.CoinWithDotPictureBox.Location = new System.Drawing.Point(51, 468);
            this.CoinWithDotPictureBox.Name = "CoinWithDotPictureBox";
            this.CoinWithDotPictureBox.Size = new System.Drawing.Size(292, 216);
            this.CoinWithDotPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CoinWithDotPictureBox.TabIndex = 6;
            this.CoinWithDotPictureBox.TabStop = false;
            // 
            // CoinWithDotLabel
            // 
            this.CoinWithDotLabel.AutoSize = true;
            this.CoinWithDotLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CoinWithDotLabel.Location = new System.Drawing.Point(51, 710);
            this.CoinWithDotLabel.Name = "CoinWithDotLabel";
            this.CoinWithDotLabel.Size = new System.Drawing.Size(275, 54);
            this.CoinWithDotLabel.TabIndex = 7;
            this.CoinWithDotLabel.Text = "Coin With Dot";
            // 
            // CoinComparePictureBox
            // 
            this.CoinComparePictureBox.Location = new System.Drawing.Point(419, 441);
            this.CoinComparePictureBox.Name = "CoinComparePictureBox";
            this.CoinComparePictureBox.Size = new System.Drawing.Size(499, 303);
            this.CoinComparePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CoinComparePictureBox.TabIndex = 8;
            this.CoinComparePictureBox.TabStop = false;
            // 
            // CoinCompareLabel
            // 
            this.CoinCompareLabel.AutoSize = true;
            this.CoinCompareLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CoinCompareLabel.Location = new System.Drawing.Point(514, 758);
            this.CoinCompareLabel.Name = "CoinCompareLabel";
            this.CoinCompareLabel.Size = new System.Drawing.Size(276, 54);
            this.CoinCompareLabel.TabIndex = 9;
            this.CoinCompareLabel.Text = "Coin Compare";
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.settingsLabel.Location = new System.Drawing.Point(1115, 408);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(148, 46);
            this.settingsLabel.TabIndex = 10;
            this.settingsLabel.Text = "Settings:";
            // 
            // BSWLabel
            // 
            this.BSWLabel.AutoSize = true;
            this.BSWLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BSWLabel.Location = new System.Drawing.Point(1048, 565);
            this.BSWLabel.Name = "BSWLabel";
            this.BSWLabel.Size = new System.Drawing.Size(293, 28);
            this.BSWLabel.TabIndex = 11;
            this.BSWLabel.Text = "Background Similarity for Witdh";
            // 
            // BSHLabel
            // 
            this.BSHLabel.AutoSize = true;
            this.BSHLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BSHLabel.Location = new System.Drawing.Point(1043, 668);
            this.BSHLabel.Name = "BSHLabel";
            this.BSHLabel.Size = new System.Drawing.Size(298, 28);
            this.BSHLabel.TabIndex = 12;
            this.BSHLabel.Text = "Background Similarity for Height";
            // 
            // pixelToleranceLabel
            // 
            this.pixelToleranceLabel.AutoSize = true;
            this.pixelToleranceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pixelToleranceLabel.Location = new System.Drawing.Point(1043, 765);
            this.pixelToleranceLabel.Name = "pixelToleranceLabel";
            this.pixelToleranceLabel.Size = new System.Drawing.Size(148, 28);
            this.pixelToleranceLabel.TabIndex = 13;
            this.pixelToleranceLabel.Text = "Pixel Tolerance :";
            // 
            // BSWTrackbar
            // 
            this.BSWTrackbar.Location = new System.Drawing.Point(1133, 609);
            this.BSWTrackbar.Maximum = 150;
            this.BSWTrackbar.Minimum = 1;
            this.BSWTrackbar.Name = "BSWTrackbar";
            this.BSWTrackbar.Size = new System.Drawing.Size(130, 56);
            this.BSWTrackbar.TabIndex = 14;
            this.BSWTrackbar.Value = 25;
            this.BSWTrackbar.Scroll += new System.EventHandler(this.BSWTrackbar_Scroll);
            // 
            // BSHTrackbar
            // 
            this.BSHTrackbar.Location = new System.Drawing.Point(1133, 706);
            this.BSHTrackbar.Maximum = 150;
            this.BSHTrackbar.Minimum = 1;
            this.BSHTrackbar.Name = "BSHTrackbar";
            this.BSHTrackbar.Size = new System.Drawing.Size(130, 56);
            this.BSHTrackbar.TabIndex = 17;
            this.BSHTrackbar.Value = 50;
            this.BSHTrackbar.Scroll += new System.EventHandler(this.BSHTrackbar_Scroll);
            // 
            // pixelToleranceInput
            // 
            this.pixelToleranceInput.Location = new System.Drawing.Point(1255, 766);
            this.pixelToleranceInput.Name = "pixelToleranceInput";
            this.pixelToleranceInput.Size = new System.Drawing.Size(60, 27);
            this.pixelToleranceInput.TabIndex = 18;
            this.pixelToleranceInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BSWTrackbarLabel
            // 
            this.BSWTrackbarLabel.AutoSize = true;
            this.BSWTrackbarLabel.Location = new System.Drawing.Point(1269, 609);
            this.BSWTrackbarLabel.Name = "BSWTrackbarLabel";
            this.BSWTrackbarLabel.Size = new System.Drawing.Size(25, 20);
            this.BSWTrackbarLabel.TabIndex = 19;
            this.BSWTrackbarLabel.Text = "25";
            // 
            // BSHTrackbarLabel
            // 
            this.BSHTrackbarLabel.AutoSize = true;
            this.BSHTrackbarLabel.Location = new System.Drawing.Point(1269, 706);
            this.BSHTrackbarLabel.Name = "BSHTrackbarLabel";
            this.BSHTrackbarLabel.Size = new System.Drawing.Size(25, 20);
            this.BSHTrackbarLabel.TabIndex = 20;
            this.BSHTrackbarLabel.Text = "50";
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(1222, 173);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(145, 74);
            this.runButton.TabIndex = 21;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // BScanLabel
            // 
            this.BScanLabel.AutoSize = true;
            this.BScanLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BScanLabel.Location = new System.Drawing.Point(1043, 810);
            this.BScanLabel.Name = "BScanLabel";
            this.BScanLabel.Size = new System.Drawing.Size(193, 28);
            this.BScanLabel.TabIndex = 22;
            this.BScanLabel.Text = "Background Scan % :";
            // 
            // BackgroundScanInput
            // 
            this.BackgroundScanInput.Location = new System.Drawing.Point(1255, 809);
            this.BackgroundScanInput.Name = "BackgroundScanInput";
            this.BackgroundScanInput.Size = new System.Drawing.Size(60, 27);
            this.BackgroundScanInput.TabIndex = 23;
            this.BackgroundScanInput.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // detectLabel
            // 
            this.detectLabel.AutoSize = true;
            this.detectLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.detectLabel.ForeColor = System.Drawing.Color.Green;
            this.detectLabel.Location = new System.Drawing.Point(586, 20);
            this.detectLabel.Name = "detectLabel";
            this.detectLabel.Size = new System.Drawing.Size(308, 54);
            this.detectLabel.TabIndex = 24;
            this.detectLabel.Text = "Coins Detected";
            // 
            // BSTrackbarLabel
            // 
            this.BSTrackbarLabel.AutoSize = true;
            this.BSTrackbarLabel.Location = new System.Drawing.Point(1254, 506);
            this.BSTrackbarLabel.Name = "BSTrackbarLabel";
            this.BSTrackbarLabel.Size = new System.Drawing.Size(33, 20);
            this.BSTrackbarLabel.TabIndex = 27;
            this.BSTrackbarLabel.Text = "150";
            // 
            // BSTrackbar
            // 
            this.BSTrackbar.Location = new System.Drawing.Point(1118, 506);
            this.BSTrackbar.Maximum = 200;
            this.BSTrackbar.Minimum = 1;
            this.BSTrackbar.Name = "BSTrackbar";
            this.BSTrackbar.Size = new System.Drawing.Size(130, 56);
            this.BSTrackbar.TabIndex = 26;
            this.BSTrackbar.Value = 150;
            this.BSTrackbar.Scroll += new System.EventHandler(this.BSTrackbar_Scroll);
            // 
            // BSLabel
            // 
            this.BSLabel.AutoSize = true;
            this.BSLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BSLabel.Location = new System.Drawing.Point(1090, 465);
            this.BSLabel.Name = "BSLabel";
            this.BSLabel.Size = new System.Drawing.Size(204, 28);
            this.BSLabel.TabIndex = 25;
            this.BSLabel.Text = "Background Similarity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 860);
            this.Controls.Add(this.BSTrackbarLabel);
            this.Controls.Add(this.BSTrackbar);
            this.Controls.Add(this.BSLabel);
            this.Controls.Add(this.detectLabel);
            this.Controls.Add(this.BackgroundScanInput);
            this.Controls.Add(this.BScanLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.BSHTrackbarLabel);
            this.Controls.Add(this.BSWTrackbarLabel);
            this.Controls.Add(this.pixelToleranceInput);
            this.Controls.Add(this.BSHTrackbar);
            this.Controls.Add(this.BSWTrackbar);
            this.Controls.Add(this.pixelToleranceLabel);
            this.Controls.Add(this.BSHLabel);
            this.Controls.Add(this.BSWLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.CoinCompareLabel);
            this.Controls.Add(this.CoinComparePictureBox);
            this.Controls.Add(this.CoinWithDotLabel);
            this.Controls.Add(this.CoinWithDotPictureBox);
            this.Controls.Add(this.coin2Label);
            this.Controls.Add(this.coin1Label);
            this.Controls.Add(this.coin2PictureBox);
            this.Controls.Add(this.coin1PictureBox);
            this.Controls.Add(this.originalImageLabel);
            this.Controls.Add(this.originalPictureBox);
            this.Name = "Form1";
            this.Text = "Coin Dot Detection";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinWithDotPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinComparePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSWTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSHTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelToleranceInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundScanInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox originalPictureBox;
        private Label originalImageLabel;
        private PictureBox coin1PictureBox;
        private PictureBox coin2PictureBox;
        private Label coin1Label;
        private Label coin2Label;
        private PictureBox CoinWithDotPictureBox;
        private Label CoinWithDotLabel;
        private PictureBox CoinComparePictureBox;
        private Label CoinCompareLabel;
        public Label settingsLabel;
        private Label BSWLabel;
        private Label BSHLabel;
        private Label pixelToleranceLabel;
        public TrackBar BSWTrackbar;
        public TrackBar BSHTrackbar;
        public NumericUpDown pixelToleranceInput;
        private Label BSWTrackbarLabel;
        private Label BSHTrackbarLabel;
        private Button runButton;
        private Label BScanLabel;
        public NumericUpDown BackgroundScanInput;
        public Label detectLabel;
        private Label BSTrackbarLabel;
        public TrackBar BSTrackbar;
        private Label BSLabel;
    }
}