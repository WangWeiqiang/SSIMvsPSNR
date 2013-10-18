using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSIMvsPSNR
{
    public partial class Form1 : Form
    {
        const double C1=1,C2=1,C3=1;
        
        int flag = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var fileImage = openFileDialog.FileName;
            if (flag == 1)
            {
                OriginalImage.Load(fileImage);
            }
            if (flag == 2)
            {
                compressedImage.Load(fileImage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //before processing image into 8x8 blocks, need to make the width and height of images is integral multiple of 8
            //then cut the images into 8x8 blocks and save them into array.
            Bitmap bm =(Bitmap)OriginalImage.Image;
            Bitmap originalBitMap   = new Bitmap(OriginalImage.Image);
            Bitmap compressedBitMap = new Bitmap(compressedImage.Image);
            int width = OriginalImage.Image.Width;
            int height = OriginalImage.Image.Height;

            int modW = width % 8;
            int modH = height % 8;
            int newWidth=width;
            if (modW > 0)
            {
                newWidth = width + (8 - modW);
            }
            
            int newHeight=height;
            if (modH > 0)
            {
                newHeight = height + (8 - modH);
            }


            Bitmap newOrBitmap = new Bitmap(newWidth,newHeight);
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
            PSNRValue.Text = PSNR.ToString();

            double SSIM = GetSSIM(orBlockArray, prBlockArray);

            SSIMvalue.Text = SSIM.ToString();
            
        }

        private double GetPSNR(List<Bitmap> x, List<Bitmap> y)
        {
            double MSE = 0;
            for (int i = 0; i < x.Count(); i++)
            {
                MSE += ComputBlockMSE(x[i], y[i]);
            }

            MSE = MSE / x.Count();
            if (MSE == 0)
            {
                MSE = 1;
            }
            MSEValue.Text = MSE.ToString();
            double PSNR = 10 * Math.Log10((255 * 255) / MSE);
            return PSNR;
        }

        private double GetSSIM(List<Bitmap> x, List<Bitmap> y)
        {
            double SSIM = 0;
            for (int i = 0; i < x.Count(); i++)
            {
                double l = GetSSIMLuminance(x[i], y[i]);
                double c = GetSSIMContrast(x[i], y[i]);
                double s=GetSSIMStructural(x[i], y[i]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 1;
            DialogResult fileDialog = openFileDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = 2;
            DialogResult fileDialog = openFileDialog.ShowDialog();
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
            v=(2 * Math.Sqrt(xVariance * yVariance) + C2) / (xVariance + yVariance + C2);
            return v;
        }

        private double GetSSIMStructural(Bitmap x, Bitmap y)
        {
            double v = 0;
            double co = GetCovariance(x, y);
            double vx = GetVariance(x);
            double vy = GetVariance(y);
            v = co + C3 / (vx * vy + C3);
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

            return v / (bitmap.Width*bitmap.Height);
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
    }
}
