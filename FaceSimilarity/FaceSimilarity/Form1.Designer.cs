namespace FaceDetection
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
            this.DetectedPic = new System.Windows.Forms.PictureBox();
            this.OriginalLabel = new System.Windows.Forms.Label();
            this.DetectedLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.OriginalPic = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPic)).BeginInit();
            this.SuspendLayout();
            // 
            // DetectedPic
            // 
            this.DetectedPic.Location = new System.Drawing.Point(744, 24);
            this.DetectedPic.Name = "DetectedPic";
            this.DetectedPic.Size = new System.Drawing.Size(547, 472);
            this.DetectedPic.TabIndex = 2;
            this.DetectedPic.TabStop = false;
            // 
            // OriginalLabel
            // 
            this.OriginalLabel.AutoSize = true;
            this.OriginalLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OriginalLabel.Location = new System.Drawing.Point(189, 506);
            this.OriginalLabel.Name = "OriginalLabel";
            this.OriginalLabel.Size = new System.Drawing.Size(164, 54);
            this.OriginalLabel.TabIndex = 0;
            this.OriginalLabel.Text = "Original";
            // 
            // DetectedLabel
            // 
            this.DetectedLabel.AutoSize = true;
            this.DetectedLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetectedLabel.Location = new System.Drawing.Point(963, 499);
            this.DetectedLabel.Name = "DetectedLabel";
            this.DetectedLabel.Size = new System.Drawing.Size(184, 54);
            this.DetectedLabel.TabIndex = 4;
            this.DetectedLabel.Text = "Detected";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreLabel.Location = new System.Drawing.Point(575, 568);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(185, 54);
            this.ScoreLabel.TabIndex = 11;
            this.ScoreLabel.Text = "Similarity";
            // 
            // OriginalPic
            // 
            this.OriginalPic.Location = new System.Drawing.Point(44, 24);
            this.OriginalPic.Name = "OriginalPic";
            this.OriginalPic.Size = new System.Drawing.Size(547, 472);
            this.OriginalPic.TabIndex = 12;
            this.OriginalPic.TabStop = false;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.score.Location = new System.Drawing.Point(588, 622);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(39, 54);
            this.score.TabIndex = 13;
            this.score.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 836);
            this.Controls.Add(this.score);
            this.Controls.Add(this.OriginalPic);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.DetectedLabel);
            this.Controls.Add(this.OriginalLabel);
            this.Controls.Add(this.DetectedPic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DetectedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox DetectedPic;
        private Label OriginalLabel;
        private Label DetectedLabel;
        private Label ScoreLabel;
        private PictureBox OriginalPic;
        private Label score;
    }
}