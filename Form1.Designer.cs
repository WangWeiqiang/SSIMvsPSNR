namespace SSIMvsPSNR
{
    partial class Form1
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
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.compressedImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PSNRValue = new System.Windows.Forms.Label();
            this.SSIMvalue = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MSEValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalImage
            // 
            this.OriginalImage.BackColor = System.Drawing.Color.White;
            this.OriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImage.Location = new System.Drawing.Point(12, 23);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(400, 350);
            this.OriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.OriginalImage.TabIndex = 0;
            this.OriginalImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Compute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // compressedImage
            // 
            this.compressedImage.BackColor = System.Drawing.Color.White;
            this.compressedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compressedImage.Location = new System.Drawing.Point(420, 23);
            this.compressedImage.Name = "compressedImage";
            this.compressedImage.Size = new System.Drawing.Size(400, 350);
            this.compressedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.compressedImage.TabIndex = 4;
            this.compressedImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "PSNR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "SSIM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Processed Image";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files|*.jpg;*.bmp;*.png";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // PSNRValue
            // 
            this.PSNRValue.AutoSize = true;
            this.PSNRValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PSNRValue.ForeColor = System.Drawing.Color.Red;
            this.PSNRValue.Location = new System.Drawing.Point(186, 469);
            this.PSNRValue.Name = "PSNRValue";
            this.PSNRValue.Size = new System.Drawing.Size(0, 13);
            this.PSNRValue.TabIndex = 14;
            // 
            // SSIMvalue
            // 
            this.SSIMvalue.AutoSize = true;
            this.SSIMvalue.ForeColor = System.Drawing.Color.Red;
            this.SSIMvalue.Location = new System.Drawing.Point(397, 448);
            this.SSIMvalue.Name = "SSIMvalue";
            this.SSIMvalue.Size = new System.Drawing.Size(0, 13);
            this.SSIMvalue.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Load Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(418, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Load Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "MSE:";
            // 
            // MSEValue
            // 
            this.MSEValue.AutoSize = true;
            this.MSEValue.Location = new System.Drawing.Point(187, 453);
            this.MSEValue.Name = "MSEValue";
            this.MSEValue.Size = new System.Drawing.Size(0, 13);
            this.MSEValue.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.MSEValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SSIMvalue);
            this.Controls.Add(this.PSNRValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.compressedImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OriginalImage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 530);
            this.MinimumSize = new System.Drawing.Size(840, 530);
            this.Name = "Form1";
            this.Text = "SSIM vs PSNR";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox compressedImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label PSNRValue;
        private System.Windows.Forms.Label SSIMvalue;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MSEValue;
    }
}

