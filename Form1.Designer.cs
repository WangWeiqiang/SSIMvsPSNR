namespace SSIMvsPSNR
{
    partial class MainForm
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
            this.bt_Compute = new System.Windows.Forms.Button();
            this.compressedImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelFolder = new System.Windows.Forms.Label();
            this.folderName = new System.Windows.Forms.TextBox();
            this.btBrowseFolder = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Blur_Jpeg = new System.Windows.Forms.RadioButton();
            this.radioButton_Blur_Noise = new System.Windows.Forms.RadioButton();
            this.radioButton_Jpeg = new System.Windows.Forms.RadioButton();
            this.radioButton_Noise = new System.Windows.Forms.RadioButton();
            this.radioButton_Blur = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedImage)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // bt_Compute
            // 
            this.bt_Compute.Enabled = false;
            this.bt_Compute.Location = new System.Drawing.Point(725, 588);
            this.bt_Compute.Name = "bt_Compute";
            this.bt_Compute.Size = new System.Drawing.Size(95, 23);
            this.bt_Compute.TabIndex = 3;
            this.bt_Compute.Text = "Compute";
            this.bt_Compute.UseVisualStyleBackColor = true;
            this.bt_Compute.Click += new System.EventHandler(this.bt_Compute_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Processed Image";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(12, 392);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(39, 13);
            this.labelFolder.TabIndex = 20;
            this.labelFolder.Text = "Folder:";
            // 
            // folderName
            // 
            this.folderName.Location = new System.Drawing.Point(57, 389);
            this.folderName.Name = "folderName";
            this.folderName.Size = new System.Drawing.Size(662, 20);
            this.folderName.TabIndex = 21;
            // 
            // btBrowseFolder
            // 
            this.btBrowseFolder.Location = new System.Drawing.Point(725, 389);
            this.btBrowseFolder.Name = "btBrowseFolder";
            this.btBrowseFolder.Size = new System.Drawing.Size(95, 23);
            this.btBrowseFolder.TabIndex = 22;
            this.btBrowseFolder.Text = "Browse";
            this.btBrowseFolder.UseVisualStyleBackColor = true;
            this.btBrowseFolder.Click += new System.EventHandler(this.btBrowseFolder_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(57, 414);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(662, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Status:";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(57, 443);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(662, 168);
            this.flowLayoutPanel.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Blur_Jpeg);
            this.groupBox1.Controls.Add(this.radioButton_Blur_Noise);
            this.groupBox1.Controls.Add(this.radioButton_Jpeg);
            this.groupBox1.Controls.Add(this.radioButton_Noise);
            this.groupBox1.Controls.Add(this.radioButton_Blur);
            this.groupBox1.Location = new System.Drawing.Point(725, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 164);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distortion";
            // 
            // radioButton_Blur_Jpeg
            // 
            this.radioButton_Blur_Jpeg.AutoSize = true;
            this.radioButton_Blur_Jpeg.Location = new System.Drawing.Point(7, 131);
            this.radioButton_Blur_Jpeg.Name = "radioButton_Blur_Jpeg";
            this.radioButton_Blur_Jpeg.Size = new System.Drawing.Size(72, 17);
            this.radioButton_Blur_Jpeg.TabIndex = 4;
            this.radioButton_Blur_Jpeg.Text = "Blur+Jpeg";
            this.radioButton_Blur_Jpeg.UseVisualStyleBackColor = true;
            this.radioButton_Blur_Jpeg.CheckedChanged += new System.EventHandler(this.radioButton_Blur_Jpeg_CheckedChanged);
            // 
            // radioButton_Blur_Noise
            // 
            this.radioButton_Blur_Noise.AutoSize = true;
            this.radioButton_Blur_Noise.Location = new System.Drawing.Point(7, 103);
            this.radioButton_Blur_Noise.Name = "radioButton_Blur_Noise";
            this.radioButton_Blur_Noise.Size = new System.Drawing.Size(76, 17);
            this.radioButton_Blur_Noise.TabIndex = 3;
            this.radioButton_Blur_Noise.Text = "Blur+Noise";
            this.radioButton_Blur_Noise.UseVisualStyleBackColor = true;
            this.radioButton_Blur_Noise.CheckedChanged += new System.EventHandler(this.radioButton_Blur_Noise_CheckedChanged);
            // 
            // radioButton_Jpeg
            // 
            this.radioButton_Jpeg.AutoSize = true;
            this.radioButton_Jpeg.Location = new System.Drawing.Point(7, 75);
            this.radioButton_Jpeg.Name = "radioButton_Jpeg";
            this.radioButton_Jpeg.Size = new System.Drawing.Size(48, 17);
            this.radioButton_Jpeg.TabIndex = 2;
            this.radioButton_Jpeg.Text = "Jpeg";
            this.radioButton_Jpeg.UseVisualStyleBackColor = true;
            this.radioButton_Jpeg.CheckedChanged += new System.EventHandler(this.radioButton_Jpeg_CheckedChanged);
            // 
            // radioButton_Noise
            // 
            this.radioButton_Noise.AutoSize = true;
            this.radioButton_Noise.Location = new System.Drawing.Point(7, 47);
            this.radioButton_Noise.Name = "radioButton_Noise";
            this.radioButton_Noise.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Noise.TabIndex = 1;
            this.radioButton_Noise.Text = "Noise";
            this.radioButton_Noise.UseVisualStyleBackColor = true;
            this.radioButton_Noise.CheckedChanged += new System.EventHandler(this.radioButton_Noise_CheckedChanged);
            // 
            // radioButton_Blur
            // 
            this.radioButton_Blur.AutoSize = true;
            this.radioButton_Blur.Checked = true;
            this.radioButton_Blur.Location = new System.Drawing.Point(7, 19);
            this.radioButton_Blur.Name = "radioButton_Blur";
            this.radioButton_Blur.Size = new System.Drawing.Size(43, 17);
            this.radioButton_Blur.TabIndex = 0;
            this.radioButton_Blur.TabStop = true;
            this.radioButton_Blur.Text = "Blur";
            this.radioButton_Blur.UseVisualStyleBackColor = true;
            this.radioButton_Blur.CheckedChanged += new System.EventHandler(this.radioButton_Blur_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 623);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btBrowseFolder);
            this.Controls.Add(this.folderName);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.compressedImage);
            this.Controls.Add(this.bt_Compute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OriginalImage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 650);
            this.MinimumSize = new System.Drawing.Size(840, 650);
            this.Name = "MainForm";
            this.Text = "SSIM vs PSNR";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compressedImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Compute;
        private System.Windows.Forms.PictureBox compressedImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox folderName;
        private System.Windows.Forms.Button btBrowseFolder;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Blur_Jpeg;
        private System.Windows.Forms.RadioButton radioButton_Blur_Noise;
        private System.Windows.Forms.RadioButton radioButton_Jpeg;
        private System.Windows.Forms.RadioButton radioButton_Noise;
        private System.Windows.Forms.RadioButton radioButton_Blur;
    }
}

