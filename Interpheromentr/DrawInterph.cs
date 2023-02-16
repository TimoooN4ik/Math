using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpheromentr
{
    public partial class DrawInterph : Form
    {
        public DrawInterph()
        {
            InitializeComponent();
        }

        void drawLine(int n)
        {
            Bitmap img = new Bitmap(n, n);
            Graphics gr = Graphics.FromImage(img);
            SolidBrush s;

            for(int i = 10; i < n; i+=2)
            {
                s = new SolidBrush(Color.Black);
                if(i % 20 == 0)
                    gr.FillRectangle(s, i, 0, 1, 5);
                else if(i % 10 == 0)
                    gr.FillRectangle(s, i, 0, 1, 10);
                else
                    gr.FillRectangle(s, i, 0, 1, 2);
            }
            pictureBox2.Image = img;

            for(int i = 10; i < n; i+=2)
            {
                s = new SolidBrush(Color.Black);
                if(i % 20 == 0)
                    gr.FillRectangle(s, 0, i, 5, 1);
                else if(i % 10 == 0)
                    gr.FillRectangle(s, 0, i, 10, 1);
                else
                    gr.FillRectangle(s, 0, i, 2, 1);
            }
            pictureBox3.Image = img;
        }

        public void getData(int n, double[,] res, double Lambda)
        {
            pictureBox1.Width = n;
            pictureBox1.Height = n;

            this.Width = n + 20;
            this.Height = n + 43;
            drawLine(n);
            Bitmap img = new Bitmap(n, n);
            Graphics gr = Graphics.FromImage(img);

            SolidBrush s;
            if (Lambda >= 635)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb((int)(res[i, j] * 100), (0), (0)));
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 635 && Lambda >= 590)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb((int)(res[i, j] * 100), (int)((res[i, j] * 100) / 1.5), (0)));
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 590 && Lambda >= 565)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb((int)(res[i, j] * 100), (int)((res[i, j] * 100)), (0)));
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 565 && Lambda >= 520)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb(0, (int)((res[i, j] * 100)), (0)));
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 520 && Lambda >= 500)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb(0, (int)((res[i, j] * 100)), (int)((res[i, j] * 100) / 1.6 ) ));
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 500 && Lambda >= 450)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb(0, 0, (int)(res[i, j] * 100)) );
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            else if(Lambda < 450)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        s = new SolidBrush(Color.FromArgb((int)(res[i, j] * 100 / 1.5), 0, (int)(res[i, j] * 100)) );
                        gr.FillRectangle(s, i, j, i, j);
                    }
                }
            }
            pictureBox1.Image = img;
        }
    }
}
