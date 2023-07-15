namespace UnsafePointer
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
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.picture1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // picture2
            // 
            this.picture2.Location = new System.Drawing.Point(433, 66);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(337, 302);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture2.TabIndex = 0;
            this.picture2.TabStop = false;
            // 
            // picture1
            // 
            this.picture1.Location = new System.Drawing.Point(30, 63);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(337, 302);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture1.TabIndex = 1;
            this.picture1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.picture2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picture2;
        private PictureBox picture1;
    }
}