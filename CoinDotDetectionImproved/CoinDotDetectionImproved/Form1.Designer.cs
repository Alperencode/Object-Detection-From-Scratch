namespace CoinDotDetectionImproved
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
            this.Picture1 = new System.Windows.Forms.PictureBox();
            this.Picture2 = new System.Windows.Forms.PictureBox();
            this.Coin1Picture = new System.Windows.Forms.PictureBox();
            this.Coin2Picture = new System.Windows.Forms.PictureBox();
            this.CoinWithDotPicture = new System.Windows.Forms.PictureBox();
            this.BWImageLabel = new System.Windows.Forms.Label();
            this.DetectionImageLabel = new System.Windows.Forms.Label();
            this.Coin1ImageLabel = new System.Windows.Forms.Label();
            this.Coin2ImageLabel = new System.Windows.Forms.Label();
            this.CoinWithDotLabel = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetectLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinWithDotPicture)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Picture1
            // 
            this.Picture1.Location = new System.Drawing.Point(47, 28);
            this.Picture1.Name = "Picture1";
            this.Picture1.Size = new System.Drawing.Size(546, 405);
            this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture1.TabIndex = 0;
            this.Picture1.TabStop = false;
            // 
            // Picture2
            // 
            this.Picture2.Location = new System.Drawing.Point(702, 28);
            this.Picture2.Name = "Picture2";
            this.Picture2.Size = new System.Drawing.Size(514, 405);
            this.Picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture2.TabIndex = 1;
            this.Picture2.TabStop = false;
            // 
            // Coin1Picture
            // 
            this.Coin1Picture.Location = new System.Drawing.Point(47, 514);
            this.Coin1Picture.Name = "Coin1Picture";
            this.Coin1Picture.Size = new System.Drawing.Size(224, 199);
            this.Coin1Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Coin1Picture.TabIndex = 2;
            this.Coin1Picture.TabStop = false;
            // 
            // Coin2Picture
            // 
            this.Coin2Picture.Location = new System.Drawing.Point(369, 514);
            this.Coin2Picture.Name = "Coin2Picture";
            this.Coin2Picture.Size = new System.Drawing.Size(224, 199);
            this.Coin2Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Coin2Picture.TabIndex = 3;
            this.Coin2Picture.TabStop = false;
            // 
            // CoinWithDotPicture
            // 
            this.CoinWithDotPicture.Location = new System.Drawing.Point(811, 514);
            this.CoinWithDotPicture.Name = "CoinWithDotPicture";
            this.CoinWithDotPicture.Size = new System.Drawing.Size(309, 199);
            this.CoinWithDotPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CoinWithDotPicture.TabIndex = 4;
            this.CoinWithDotPicture.TabStop = false;
            // 
            // BWImageLabel
            // 
            this.BWImageLabel.AutoSize = true;
            this.BWImageLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BWImageLabel.Location = new System.Drawing.Point(162, 447);
            this.BWImageLabel.Name = "BWImageLabel";
            this.BWImageLabel.Size = new System.Drawing.Size(321, 38);
            this.BWImageLabel.TabIndex = 5;
            this.BWImageLabel.Text = "Black and White Image";
            // 
            // DetectionImageLabel
            // 
            this.DetectionImageLabel.AutoSize = true;
            this.DetectionImageLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DetectionImageLabel.Location = new System.Drawing.Point(851, 447);
            this.DetectionImageLabel.Name = "DetectionImageLabel";
            this.DetectionImageLabel.Size = new System.Drawing.Size(235, 38);
            this.DetectionImageLabel.TabIndex = 6;
            this.DetectionImageLabel.Text = "Detection Image";
            // 
            // Coin1ImageLabel
            // 
            this.Coin1ImageLabel.AutoSize = true;
            this.Coin1ImageLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Coin1ImageLabel.Location = new System.Drawing.Point(62, 728);
            this.Coin1ImageLabel.Name = "Coin1ImageLabel";
            this.Coin1ImageLabel.Size = new System.Drawing.Size(190, 38);
            this.Coin1ImageLabel.TabIndex = 7;
            this.Coin1ImageLabel.Text = "Coin 1 Image";
            // 
            // Coin2ImageLabel
            // 
            this.Coin2ImageLabel.AutoSize = true;
            this.Coin2ImageLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Coin2ImageLabel.Location = new System.Drawing.Point(386, 728);
            this.Coin2ImageLabel.Name = "Coin2ImageLabel";
            this.Coin2ImageLabel.Size = new System.Drawing.Size(190, 38);
            this.Coin2ImageLabel.TabIndex = 8;
            this.Coin2ImageLabel.Text = "Coin 2 Image";
            // 
            // CoinWithDotLabel
            // 
            this.CoinWithDotLabel.AutoSize = true;
            this.CoinWithDotLabel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CoinWithDotLabel.Location = new System.Drawing.Point(869, 728);
            this.CoinWithDotLabel.Name = "CoinWithDotLabel";
            this.CoinWithDotLabel.Size = new System.Drawing.Size(205, 38);
            this.CoinWithDotLabel.TabIndex = 9;
            this.CoinWithDotLabel.Text = "Coin With Dot";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectImageToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1273, 28);
            this.menuStrip2.TabIndex = 11;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.selectImageToolStripMenuItem.Text = "Select Image";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // DetectLabel
            // 
            this.DetectLabel.AutoSize = true;
            this.DetectLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DetectLabel.ForeColor = System.Drawing.Color.Green;
            this.DetectLabel.Location = new System.Drawing.Point(473, 809);
            this.DetectLabel.Name = "DetectLabel";
            this.DetectLabel.Size = new System.Drawing.Size(308, 54);
            this.DetectLabel.TabIndex = 12;
            this.DetectLabel.Text = "Coins Detected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 872);
            this.Controls.Add(this.DetectLabel);
            this.Controls.Add(this.CoinWithDotLabel);
            this.Controls.Add(this.Coin2ImageLabel);
            this.Controls.Add(this.Coin1ImageLabel);
            this.Controls.Add(this.DetectionImageLabel);
            this.Controls.Add(this.BWImageLabel);
            this.Controls.Add(this.CoinWithDotPicture);
            this.Controls.Add(this.Coin2Picture);
            this.Controls.Add(this.Coin1Picture);
            this.Controls.Add(this.Picture2);
            this.Controls.Add(this.Picture1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Coin Dot Detection Improved";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Coin2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinWithDotPicture)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Picture1;
        private PictureBox Picture2;
        private PictureBox Coin1Picture;
        private PictureBox Coin2Picture;
        private PictureBox CoinWithDotPicture;
        private Label BWImageLabel;
        private Label DetectionImageLabel;
        private Label Coin1ImageLabel;
        private Label Coin2ImageLabel;
        private Label CoinWithDotLabel;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem selectImageToolStripMenuItem;
        private Label DetectLabel;
    }
}