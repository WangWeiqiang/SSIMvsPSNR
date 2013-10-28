using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ILNumerics.Data;
namespace SSIMvsPSNR
{
    public partial class MainForm : Form
    {
        const double C1=1,C2=1,C3=1;
        Task task;
        Thread uiThread = null;
        string distortionType = "blur";

        public MainForm()
        {
            InitializeComponent();
        }

        private void updateUI(PictureBox p, Chart chart)
        {
            flowLayoutPanel.Controls.Add(p);
            flowLayoutPanel.Controls.Add(chart);
        }

        private void ScanCompute()
        {

            foreach (TaskGroup g in task.TaskGroups)
            {
                PictureBox p = new PictureBox();
                p.Width=252;
                p.Height = 142;
                p.Load(g.OriginalImageFileName);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                OriginalImage.Load(g.OriginalImageFileName);
                p.Show();

                ChartArea chartArea1 = new ChartArea();
                chartArea1.Name="ChartArea1";
                Legend legend1 = new Legend();
                legend1.Name = "Legend1";
                Series series1 = new Series();
                Series series2 = new Series();
                Chart chart = new Chart();
                chart.ChartAreas.Add(chartArea1);
                chart.Legends.Add(legend1);
                
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = "PSNR";
                series1.ChartType = SeriesChartType.Line;

                series2.ChartArea = "ChartArea1";
                series2.Legend = "Legend1";
                series2.Name = "SSIM";
                series2.ChartType = SeriesChartType.Line;
                chart.Series.Add(series1);
                chart.Series.Add(series2);
                chart.Size = new System.Drawing.Size(375, 142);

                chart.Show();

                foreach (TaskItem item in g.TaskItems)
                {
                    double distortionLevel = 0;
                    bool doProcess = false;
                    switch (distortionType)
                    {
                        case "blur":
                            doProcess = (item.BlurLevel > 0 && item.JpegLevel == 0 && item.NoiseLevel == 0);
                            distortionLevel = item.BlurLevel;
                            break;
                        case "noise":
                            doProcess = (item.NoiseLevel > 0 && item.JpegLevel == 0 && item.BlurLevel == 0);
                            distortionLevel = item.NoiseLevel;
                            break;
                        case "jpeg":
                            doProcess = (item.JpegLevel > 0 && item.NoiseLevel== 0 && item.BlurLevel == 0);
                            distortionLevel = item.JpegLevel;
                            break;
                        case "blur_jpeg":
                            doProcess = (item.JpegLevel > 0 && item.BlurLevel > 0 && item.NoiseLevel == 0);
                            distortionLevel = (double)(item.JpegLevel + item.BlurLevel) / 2;
                            break;
                        case "blur_noise":
                            doProcess = (item.BlurLevel > 0 && item.NoiseLevel > 0 && item.JpegLevel == 0);
                            distortionLevel = (double)(item.BlurLevel + item.NoiseLevel) / 2;
                            break;
                    }
                    if (doProcess)
                    {
                        compressedImage.Load(item.FileName);

                        Bitmap bm = (Bitmap)OriginalImage.Image;
                        Bitmap originalBitMap = new Bitmap(OriginalImage.Image);
                        Bitmap compressedBitMap = new Bitmap(compressedImage.Image);
                        int width = OriginalImage.Image.Width;
                        int height = OriginalImage.Image.Height;

                        int modW = width % 8;
                        int modH = height % 8;
                        int newWidth = width;
                        if (modW > 0)
                        {
                            newWidth = width + (8 - modW);
                        }

                        int newHeight = height;
                        if (modH > 0)
                        {
                            newHeight = height + (8 - modH);
                        }


                        Bitmap newOrBitmap = new Bitmap(newWidth, newHeight);
                        Bitmap newPrBitmap = new Bitmap(newWidth, newHeight);
                        Graphics graphicOrImage = Graphics.FromImage(newOrBitmap);
                        Graphics graphicPrImage = Graphics.FromImage(newPrBitmap);
                        graphicOrImage.DrawImage(originalBitMap, 0, 0, width, height);
                        graphicPrImage.DrawImage(compressedBitMap, 0, 0, width, height);

                        List<Bitmap> orBlockArray = new List<Bitmap>();
                        List<Bitmap> prBlockArray = new List<Bitmap>();

                        for (int i = 0; i < newWidth / 8; i++)
                        {
                            for (int j = 0; j < newHeight / 8; j++)
                            {
                                Bitmap orBlock = new Bitmap(8, 8);
                                orBlock = Cut(newOrBitmap, i * 8, j * 8, 8, 8);
                                orBlockArray.Add(orBlock);

                                Bitmap prBlock = new Bitmap(8, 8);
                                prBlock = Cut(newPrBitmap, i * 8, j * 8, 8, 8);
                                prBlockArray.Add(prBlock);
                            }
                        }
                        //end preparing images
                        double PSNR = GetPSNR(orBlockArray, prBlockArray);
                        double SSIM = GetSSIM(orBlockArray, prBlockArray) * 100;
                        

                        chart.Series["PSNR"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(distortionLevel, PSNR));
                        chart.Series["SSIM"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(distortionLevel, SSIM));
                    }
                }
                chart.Series["PSNR"].Sort(PointSortOrder.Ascending);
                chart.Series["SSIM"].Sort(PointSortOrder.Ascending);
                
                this.Invoke(new Action<PictureBox, Chart>(this.updateUI), p, chart);
                this.Invoke(new Action(this.UpdateProcessThread));
                g.Done = true;
            }
            uiThread.Abort();

        }

        private void UpdateProcessThread()
        {
            Thread.Sleep(1000);

            int groupDone = 1;


            foreach (TaskGroup g in task.TaskGroups)
            {
                if (g.Done)
                    groupDone++;
            }

            this.Invoke(new Action<int>(this.UpdateProcess), groupDone);
            
        }

        private void UpdateProcess(int v)
        {
            this.progressBar.Value = v;
        }

        private void bt_Compute_Click(object sender, EventArgs e)
        {
            uiThread = new Thread(new ThreadStart(this.UpdateProcessThread));
            uiThread.IsBackground = true;
            uiThread.Start();

            Thread workThread = new Thread(new ThreadStart(this.ScanCompute));
            workThread.Start();

        }

        private double GetPSNR(List<Bitmap> x, List<Bitmap> y)
        {
            double MSE = 0;
            for (int i = 0; i < x.Count(); i++)
            {
                MSE += ComputBlockMSE(x[i], y[i]);
            }

            MSE = MSE / x.Count();

            
            double PSNR;
            if (MSE > 0)
            {
                PSNR = 20 * Math.Log10(255) - 10 * Math.Log10(MSE);
            }
            else
            {
                PSNR = 20 * Math.Log10(255);
            }
            return PSNR;
        }

        private double GetSSIM(List<Bitmap> x, List<Bitmap> y)
        {
            double SSIM = 0;
            for (int i = 0; i < x.Count(); i++)
            {
                double l = GetSSIMLuminance(x[i], y[i]);
                double c = GetSSIMContrast(x[i], y[i]);
                double s = GetSSIMStructural(x[i], y[i]);
                SSIM += (l * c * s);
            }
            SSIM = SSIM / x.Count();

            return SSIM;
        }

        private Bitmap Cut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null) { return null; }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h) { return null; } if (StartX + iWidth > w) { iWidth = w - StartX; }
            if (StartY + iHeight > h) { iHeight = h - StartY; } try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut); g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose(); 
                return bmpOut;
            }
            catch { return null; }
        }

        private double GetLuminanceByColor(Color color)
        {
            return 0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B;
        }

        private double ComputBlockMSE(Bitmap x,Bitmap y)
        {
            double MSE = 0;
            double xLuminance = GetAvgLuminance(x);
            double yLuminance = GetAvgLuminance(y);

            MSE = (xLuminance - yLuminance)*(xLuminance - yLuminance);
            return MSE;
        }

        private double GetSSIMLuminance(Bitmap x, Bitmap y)
        {
            double v = 0;

            double xLuminance = GetAvgLuminance(x);
            double yLuminance = GetAvgLuminance(y);

            v = (2 * xLuminance * yLuminance+C1) / (xLuminance * xLuminance + yLuminance * yLuminance+C1);

            return v;
        }

        private double GetSSIMContrast(Bitmap x, Bitmap y)
        {
            double v = 0;
            double xVariance=GetVariance(x);
            double yVariance=GetVariance(y);
            v = (2 * xVariance * yVariance + C2) / (xVariance * xVariance + yVariance * yVariance + C2);
            return v;
        }

        private double GetSSIMStructural(Bitmap x, Bitmap y)
        {
            double v = 0;
            double co = GetCovariance(x, y);
            double vx = GetVariance(x);
            double vy = GetVariance(y);
            v = (co + C3) / (vx * vy + C3);
            return v;
        }

        //Get average luminance value of image
        private double GetAvgLuminance(Bitmap bitmap){
            double avgLuminance = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    avgLuminance +=(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
                }
            }

            return avgLuminance / (bitmap.Width*bitmap.Height);
        }

        //Get variance value of image, before sqrt
        private double GetVariance(Bitmap bitmap)
        {
            //每个像素点的灰度值减去图像平均灰度值的平方和除以总的像素个数
            double v = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    try
                    {
                        Color or_color = bitmap.GetPixel(i, j);
                        double or_luminance = 0.2126 * or_color.R + 0.7152 * or_color.G + 0.0722 * or_color.B;

                        v += or_luminance;
                    }
                    finally
                    {
                    }
                }
            }
            double avgV = v / 64;
            v = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    try
                    {
                        Color or_color = bitmap.GetPixel(i, j);
                        double or_luminance = 0.2126 * or_color.R + 0.7152 * or_color.G + 0.0722 * or_color.B;
                        v += (or_luminance - avgV) * (or_luminance - avgV);
                    }
                    finally
                    {
                    }
                }
            }

            return Math.Sqrt(v / (bitmap.Width * bitmap.Height));
        }

        
        //Get covariance value of image1 and image2
        private double GetCovariance(Bitmap x, Bitmap y)
        {
            //每个像素点的灰度值减去图像平均灰度值的平方和除以总的像素个数
            double v = 0;

            for (int i = 0; i < x.Width; i++)
            {
                for (int j = 0; j < x.Height; j++)
                {
                    try
                    {
                        Color or_color = x.GetPixel(i, j);
                        double or_luminance = 0.2126 * or_color.R + 0.7152 * or_color.G + 0.0722 * or_color.B;

                        v += or_luminance;
                    }
                    finally
                    {
                    }
                }
            }
            double x_avgV = v / (x.Width*x.Height);

            v = 0;
            for (int i = 0; i < y.Width; i++)
            {
                for (int j = 0; j < y.Height; j++)
                {
                    try
                    {
                        Color or_color = y.GetPixel(i, j);
                        double or_luminance = 0.2126 * or_color.R + 0.7152 * or_color.G + 0.0722 * or_color.B;

                        v += or_luminance;
                    }
                    finally
                    {
                    }
                }
            }
            double y_avgV = v / (x.Width * x.Height);



            v = 0;
            for (int i = 0; i < x.Width; i++)
            {
                for (int j = 0; j < x.Height; j++)
                {
                    try
                    {
                        Color x_color = x.GetPixel(i, j);
                        double x_luminance = 0.2126 * x_color.R + 0.7152 * x_color.G + 0.0722 * x_color.B;

                        Color y_color = y.GetPixel(i, j);
                        double y_luminance = 0.2126 * y_color.R + 0.7152 * y_color.G + 0.0722 * y_color.B;

                        v += (x_luminance - x_avgV) * (y_luminance - y_avgV);
                    }
                    finally
                    {
                    }
                }
            }

            return v/(x.Height*x.Width);
        }

        private void btBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                task = new Task();
                task.TaskGroups = new List<TaskGroup>();

                this.folderName.Text = folderBrowserDialog.SelectedPath;
                string[] files=Directory.GetFiles(this.folderName.Text);
                ILNumerics.ILMatFile x = new ILNumerics.ILMatFile("D:\\NTU Course\\Multiple Media Management\\To_Release\\Part 2\\Imagelists.mat");
                
                
                foreach (var file in files)
                {
                    var imgfilename = file.Replace(this.folderName.Text+"\\", "").Replace(".bmp", "");
                    if (imgfilename.IndexOf("_") < 0)
                    {
                        TaskGroup g = new TaskGroup();
                        g.GroupName = imgfilename;
                        g.OriginalImageFileName = file;
                        g.TaskItems = new List<TaskItem>();
                        task.TaskGroups.Add(g);
                    }
                    else
                    {
                        string[] processfilename = imgfilename.Split('_');

                        foreach (var g in task.TaskGroups)
                        {
                            if (g.GroupName == processfilename[0])
                            {
                                TaskItem item = new TaskItem();
                                item.FileName = file;
                                if (processfilename[1].IndexOf("blur") >= 0)
                                {
                                    item.BlurLevel = int.Parse(processfilename[1].Replace("blur", ""));
                                }
                                if (processfilename[1].IndexOf("jpeg") >= 0)
                                {
                                    item.JpegLevel = int.Parse(processfilename[1].Replace("jpeg", ""));
                                }
                                if (processfilename[1].IndexOf("noise") >= 0)
                                {
                                    item.NoiseLevel = int.Parse(processfilename[1].Replace("noise", ""));
                                }

                                if (processfilename.Length > 2)
                                {
                                    if (processfilename[2].IndexOf("blur") >= 0)
                                    {
                                        item.BlurLevel = int.Parse(processfilename[2].Replace("blur", ""));
                                    }
                                    if (processfilename[2].IndexOf("jpeg") >= 0)
                                    {
                                        item.JpegLevel = int.Parse(processfilename[2].Replace("jpeg", ""));
                                    }
                                    if (processfilename[2].IndexOf("noise") >= 0)
                                    {
                                        item.NoiseLevel = int.Parse(processfilename[2].Replace("noise", ""));
                                    }
                                }

                                g.TaskItems.Add(item);
                            }
                        }
                    }
                }

                int taskcount=task.TaskGroups.Count();
                if (taskcount > 0)
                {
                    progressBar.Maximum = taskcount;
                    bt_Compute.Enabled = true;
                }

            }
        }

        private void radioButton_Blur_CheckedChanged(object sender, EventArgs e)
        {
            distortionType = "blur";
            ResetProcess();
        }

        private void radioButton_Noise_CheckedChanged(object sender, EventArgs e)
        {
            distortionType = "noise";
            ResetProcess();
        }

        private void radioButton_Jpeg_CheckedChanged(object sender, EventArgs e)
        {
            distortionType = "jpeg";
            ResetProcess();
        }

        private void radioButton_Blur_Noise_CheckedChanged(object sender, EventArgs e)
        {
            distortionType = "blur_noise";
            ResetProcess();
        }

        private void radioButton_Blur_Jpeg_CheckedChanged(object sender, EventArgs e)
        {
            distortionType = "blur_jpeg";
            ResetProcess();
        }

        private void ResetProcess()
        {
            if (task != null)
            {
                foreach (TaskGroup g in task.TaskGroups)
                {
                    g.Done = false;
                }
            }
        }
    }
}
