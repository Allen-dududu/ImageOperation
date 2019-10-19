using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Linq;
using AForge.Imaging;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using AForge;
using System.Reflection;
using Newtonsoft.Json;

namespace point_operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                histForm histoGram = new histForm(curBitmap);
                histoGram.ShowDialog();
                histoGram.Close();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            opnDlg.Title = "打开图像文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                curFileName = opnDlg.FileName;
                try
                {
                    curBitmap = (Bitmap)System.Drawing.Image.FromFile(curFileName);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (curBitmap != null)
            {
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }


        private void stretch_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {

                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height*3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                
                byte a = 255, b = 0;
                double p;

                for (int i = 0; i < bytes; i++)
                {
                    if (a > grayValues[i])
                    {
                        a = grayValues[i];
                    }
                    if (b < grayValues[i])
                    {
                        b = grayValues[i];
                    }
                }
                p = 255.0 / (b - a);

                for (int i = 0; i < bytes; i++)
                {
                    grayValues[i] = (byte)(p * (grayValues[i] - a) + 0.5);
                }

                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpData);

                Invalidate();
            }
        }

        private void equalization_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height * 3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                byte temp;
                int[] countPixel = new int[256];
                int[] tempArray = new int[256];
                //Array.Clear(tempArray, 0, 256);
                byte[] pixelMap = new byte[256];
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    countPixel[temp]++;
                }

                for (int i = 0; i < 256; i++)
                {
                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + countPixel[i];
                    }
                    else
                    {
                        tempArray[0] = countPixel[0];
                    }
                    
                    pixelMap[i] = (byte)(255.0 * tempArray[i] / bytes + 0.5);
                }
                
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    grayValues[i] = pixelMap[temp];
                }
                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpData);

                Invalidate();
            }
        }

       
        private void Button1_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                int width = curBitmap.Width;
                int height = curBitmap.Height;
                var bmp2 = new Bitmap(width, height);

                Color c;
                int[] Laplacian = { -1, -1, -1, -1, 8, -1, -1, -1, -1 };//拉普拉斯锐化模板  
                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int r = 0, g = 0, b = 0;
                        int Index = 0;
                        //两个for循环刚好将拉普拉斯锐化模板数组完全遍历  
                        for (int col = -1; col <= 1; col++)
                            for (int row = -1; row <= 1; row++)
                            {
                                //获取bmp1的各个点的像素值       
                                c = curBitmap.GetPixel(x + row, y + col);
                                r += c.R * Laplacian[Index];
                                g += c.G * Laplacian[Index];
                                b += c.B * Laplacian[Index];
                                Index++;
                            }
                        //要注意的是，运算后如果出现了大于255或者小于0的点，称为溢出，  
                        //溢出点的处理通常是截断，即大于255时，令其等于255；小于0时，取其绝对值。  
                        //处理颜色值溢出  
                        r = r > 255 ? 255 : r;
                        r = r < 0 ? 0 : r;
                        g = g > 255 ? 255 : g;
                        g = g < 0 ? 0 : g;
                        b = b > 255 ? 255 : b;
                        b = b < 0 ? 0 : b;

                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;
                        //将bmp2的各个像素点进行赋值  
                        bmp2.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = bmp2;


                Invalidate();
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(curBitmap != null)
            {
                int width = curBitmap.Width;
                int height = curBitmap.Height;
                var bmp2 = new Bitmap(width, height);
                int[] gaosi = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                Color c = new Color();
                for(int x = 1; x < curBitmap.Width -1; x++)
                {
                    for(int y = 1;y < curBitmap.Height -1; y++)
                    {
                       
                        
                        List<int> zhong = new List<int>(); ;
                        for(var gx = -1; gx <= 1; gx++)
                        {
                            for(int gy = -1; gy <= 1; gy++)
                            {
                                c = curBitmap.GetPixel(x + gx, y + gy);
                                int r = c.R;
                                zhong.Add(r);
                                
                                
                            }
                        }
                        var z = zhong.OrderBy(i => i);
                       var s = z.ToArray();
                        //r = r / 9;
                        //g = g / 9;
                        //b = b / 9;
                        //处理颜色值溢出  
                        //r = r > 255 ? 255 : r;
                        //r = r < 0 ? 0 : r;
                        //g = g > 255 ? 255 : g;
                        //g = g < 0 ? 0 : g;
                        //b = b > 255 ? 255 : b;
                        //b = b < 0 ? 0 : b;
                        bmp2.SetPixel(x, y, Color.FromArgb(s[5], s[5], s[5]));
                    }
                }
                curBitmap = bmp2;
                Invalidate();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            int width = curBitmap.Width;
            int height = curBitmap.Height;
            var bmp2 = new Bitmap(width, height);
            Random r = new Random();
            Color c;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    if ((x + y) % 5 == 0)
                    {
                        int Index = 0;
                        Index = r.Next(0, 255);
                        bmp2.SetPixel(x , y , Color.FromArgb(Index, Index, Index));
                        continue;
                    }

                    c = curBitmap.GetPixel(x, y);
                    //将bmp2的各个像素点进行赋值  
                    bmp2.SetPixel(x , y ,c);
                }
            }
            curBitmap = bmp2;
            Invalidate();
        }
        public Bitmap orignal8 = null;
        private void Button4_Click(object sender, EventArgs e)
        {
            
            //var bit8 = new Bitmap(curBitmap.Width, curBitmap.Height, PixelFormat.Format8bppIndexed);
            var bit8 = Tool.RgbToGrayScale(curBitmap);
            orignal8 = bit8;
            ComplexImage complexImage = ComplexImage.FromBitmap(bit8);
            // 进行正向傅立叶变换，即将图像从空间域向频率域转换
            complexImage.ForwardFourierTransform();
     
            curBitmap = complexImage.ToBitmap();
            Invalidate();
        }
        private void FFTfilter(object sender, EventArgs e)
        {
            ComplexImage complexImage = ComplexImage.FromBitmap(orignal8);
            complexImage.ForwardFourierTransform();
            //通过频率范围创建过滤器
            AForge.Imaging.ComplexFilters.FrequencyFilter filter = new AForge.Imaging.ComplexFilters.FrequencyFilter(new IntRange(10, 100));
            // 频率过滤
            filter.Apply(complexImage);
            //逆向频率域操作
            complexImage.BackwardFourierTransform();
            curBitmap = complexImage.ToBitmap();
            Invalidate();
        }
        //修复残缺文字
        private void FixWorld(object sender, EventArgs e)
        {


            int width = curBitmap.Width;
            int height = curBitmap.Height;
            int[] pointer = new int[] { 0, 1, 0, 1, 1, 1, 0, 1,0 };
            
            for(var w = 0; w < width; w++)
            {
                for(int h = 0; h < height; h++)
                {
                    var bit = curBitmap.GetPixel(w, h);
                    //之前要进行图像黑白处理
                    //弱智二值化
                    if (bit.R >=127)
                    {
                        curBitmap.SetPixel(w, h,  Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        curBitmap.SetPixel(w, h, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height * 3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                curBitmap.UnlockBits(bmpData);
            }

            var bmp2 = Tool.CloneJson(curBitmap);
          
            for (var w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    var bit = curBitmap.GetPixel(w, h);
                    if (bit.R == 0)
                    {
                        int index = 0;
                        for (int x = -1; x < 2; x++)
                        {
                            for (int y = -1; y < 2; y++)
                            {
                                if(pointer[index] ==1)
                                bmp2.SetPixel(w + x, h + y, Color.FromArgb(0, 0, 0));

                                index++;
                            }
                        }

                    }


                }
            }
            //Rectangle rect1 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
            //System.Drawing.Imaging.BitmapData bmpData1 = bmp2.LockBits(rect1, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp2.PixelFormat);
            //IntPtr ptr1 = bmpData1.Scan0;
            //int bytes1 = curBitmap.Width * curBitmap.Height * 3;
            //byte[] grayValues1 = new byte[bytes1];
            //System.Runtime.InteropServices.Marshal.Copy(ptr1, grayValues1, 0, bytes1);
            curBitmap = bmp2;
            Invalidate();
        }
   
    
        private void changetoWBimg(object sender, EventArgs e)
        {
            int width = curBitmap.Width;
            int height = curBitmap.Height;
            var bmp2 = new Bitmap(width, height);

            Color c;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    c = curBitmap.GetPixel(x, y);//获取像素  
                    int value = (c.R + c.G + c.B) / 3;
                    bmp2.SetPixel(x, y, Color.FromArgb(value, value, value));//设置像素  
                }
            }
            curBitmap = bmp2;
            Invalidate();
        }

    }
}