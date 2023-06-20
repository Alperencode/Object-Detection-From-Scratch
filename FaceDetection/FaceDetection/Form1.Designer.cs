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
            this.debug = new System.Windows.Forms.Label();
            this.debug0 = new System.Windows.Forms.Label();
            this.debug1 = new System.Windows.Forms.Label();
            this.debug2 = new System.Windows.Forms.Label();
            this.debug3 = new System.Windows.Forms.Label();
            this.picDebug = new System.Windows.Forms.PictureBox();
            this.FaceLabel = new System.Windows.Forms.Label();
            this.OriginalPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).BeginInit();
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
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(822, 710);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(50, 20);
            this.debug.TabIndex = 5;
            this.debug.Text = "label1";
            // 
            // debug0
            // 
            this.debug0.AutoSize = true;
            this.debug0.Location = new System.Drawing.Point(822, 520);
            this.debug0.Name = "debug0";
            this.debug0.Size = new System.Drawing.Size(50, 20);
            this.debug0.TabIndex = 6;
            this.debug0.Text = "label1";
            // 
            // debug1
            // 
            this.debug1.AutoSize = true;
            this.debug1.Location = new System.Drawing.Point(822, 561);
            this.debug1.Name = "debug1";
            this.debug1.Size = new System.Drawing.Size(50, 20);
            this.debug1.TabIndex = 7;
            this.debug1.Text = "label2";
            // 
            // debug2
            // 
            this.debug2.AutoSize = true;
            this.debug2.Location = new System.Drawing.Point(822, 609);
            this.debug2.Name = "debug2";
            this.debug2.Size = new System.Drawing.Size(50, 20);
            this.debug2.TabIndex = 8;
            this.debug2.Text = "label3";
            // 
            // debug3
            // 
            this.debug3.AutoSize = true;
            this.debug3.Location = new System.Drawing.Point(822, 660);
            this.debug3.Name = "debug3";
            this.debug3.Size = new System.Drawing.Size(50, 20);
            this.debug3.TabIndex = 9;
            this.debug3.Text = "label4";
            // 
            // picDebug
            // 
            this.picDebug.Location = new System.Drawing.Point(563, 531);
            this.picDebug.Name = "picDebug";
            this.picDebug.Size = new System.Drawing.Size(190, 148);
            this.picDebug.TabIndex = 10;
            this.picDebug.TabStop = false;
            // 
            // FaceLabel
            // 
            this.FaceLabel.AutoSize = true;
            this.FaceLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FaceLabel.Location = new System.Drawing.Point(610, 683);
            this.FaceLabel.Name = "FaceLabel";
            this.FaceLabel.Size = new System.Drawing.Size(101, 54);
            this.FaceLabel.TabIndex = 11;
            this.FaceLabel.Text = "Face";
            // 
            // OriginalPic
            // 
            this.OriginalPic.Location = new System.Drawing.Point(44, 24);
            this.OriginalPic.Name = "OriginalPic";
            this.OriginalPic.Size = new System.Drawing.Size(547, 472);
            this.OriginalPic.TabIndex = 12;
            this.OriginalPic.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 836);
            this.Controls.Add(this.OriginalPic);
            this.Controls.Add(this.FaceLabel);
            this.Controls.Add(this.picDebug);
            this.Controls.Add(this.debug3);
            this.Controls.Add(this.debug2);
            this.Controls.Add(this.debug1);
            this.Controls.Add(this.debug0);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.DetectedLabel);
            this.Controls.Add(this.OriginalLabel);
            this.Controls.Add(this.DetectedPic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DetectedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox DetectedPic;
        private Label OriginalLabel;
        private Label DetectedLabel;
        private Label debug;
        private Label debug0;
        private Label debug1;
        private Label debug2;
        private Label debug3;
        private PictureBox picDebug;
        private Label FaceLabel;
        private PictureBox OriginalPic;
    }
}