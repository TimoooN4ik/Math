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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 2)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Newton.png");
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case 1:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Phizo.png");
                        break;
                    case 2:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Tv-Grin.png");
                        break;
                    default:
                        break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 2)
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\diff.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                this.Width = 977;
            }
            else
            {
                this.Width = 820;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Newton.png");
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case 1:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Phizo.png");
                        break;
                    case 2:
                        pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\Tv-Grin.png");
                        break;
                    default:
                        break;
                }
            }

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    label7.Visible = true;
                    label6.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    string s = "0,0001";
                    label7.Text = "Альфа";
                    textBox7.Text = s;
                    break;
                case 1:
                    label7.Visible = true;
                    label6.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    label7.Text = "Радиус (м)";
                    textBox7.Text = 500.ToString();
                    break;
                case 2:
                    label7.Visible = false;
                    label6.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;  //размер картинки
            double alpha, Width, Npr, R1, R2, Lambda;   //Width - размер, Npr показатель приломления
            double A, B, C, D, E, F;

            double T1, T2, J1, J2, gamma;
            
            double[,] plane;
            double[,] result;

            changePoint();

            try
            {
                Lambda = Convert.ToDouble(textBox1.Text);
                n = Convert.ToInt32(textBox2.Text);
                Width = Convert.ToDouble(textBox3.Text);
                R1 = Convert.ToDouble(textBox4.Text);
                R2 = Convert.ToDouble(textBox5.Text);

                Npr = Convert.ToDouble(textBox6.Text);
                alpha = Convert.ToDouble(textBox7.Text);

                A = Convert.ToDouble(textBox8.Text);
                B = Convert.ToDouble(textBox9.Text);
                C = Convert.ToDouble(textBox10.Text);
                D = Convert.ToDouble(textBox11.Text);
                E = Convert.ToDouble(textBox12.Text);
                F = Convert.ToDouble(textBox13.Text);

                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        plane = clinAberr(alpha, Width, Npr, n);
                        break;
                    case 1:
                        plane = spherAberr(alpha, Width, Npr, n);
                        break;
                    case 2:
                        plane = Aberr(A, B, C, D, E, F, Width, n);
                        break;
                    default:
                        plane = spherAberr(alpha, Width, Npr, n);
                        break;
                }

                T1 = 1 - R1;
                T2 = 1 - R2;
                J1 = R1;
                J2 = R2 * T1 * T1;

                result = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        gamma = ((2 * Math.PI * (plane[i, j])) / (Lambda * 0.000000001));
                        result[i, j] = J1 + J2 + 2 * Math.Sqrt(J1 * J2) * Math.Cos(gamma);
                    }
                }

                DrawInterph draw = new DrawInterph();
                draw.getData(n, result, Lambda);
                draw.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void changePoint()
        {
            textBox3.Text = textBox3.Text.Replace('.', ',');
            textBox4.Text = textBox4.Text.Replace('.', ',');
            textBox5.Text = textBox5.Text.Replace('.', ',');
            textBox6.Text = textBox6.Text.Replace('.', ',');
            textBox7.Text = textBox7.Text.Replace('.', ',');
            textBox8.Text = textBox8.Text.Replace('.', ',');
            textBox9.Text = textBox9.Text.Replace('.', ',');
            textBox10.Text = textBox10.Text.Replace('.', ',');
            textBox11.Text = textBox11.Text.Replace('.', ',');
            textBox12.Text = textBox12.Text.Replace('.', ',');
            textBox13.Text = textBox13.Text.Replace('.', ',');

            double a = Convert.ToDouble(textBox1.Text);
            double r1 = Convert.ToDouble(textBox4.Text);
            double r2 = Convert.ToDouble(textBox5.Text);
            int n = Convert.ToInt32(textBox2.Text);

            if (a > 760)
                a = 760;
            if (a < 380)
                a = 380;
            textBox1.Text = a.ToString();

            if (r1 > 1)
                r1 = 1;
            if (r1 < 0)
                r1 = 0;
            
            if (r2 > 1)
                r2 = 1;
            if (r2 < 0)
                r2 = 0;

            textBox4.Text = r1.ToString();
            textBox5.Text = r2.ToString();

            if (n < 100)
                n = 100;
            if (n > 500)
                n = 500;

            textBox2.Text = n.ToString();
        }

        double[,] clinAberr(double alpha, double wid, double Npr, int n)
        {
            double[,] plane = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    plane[i, j] = (Npr * (wid * ((double)(i) / n) * Math.Tan(alpha)));
                }
            }

            return plane;
        }

        double[,] spherAberr(double rad, double wid, double Npr, int n)
        {
            double[,] plane = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    plane[i, j] = (Npr * (Math.Sqrt((rad * rad) - Math.Pow((wid * ((double)(i) / n) - (wid / 2.0)), 2) - Math.Pow((wid * ((double)(j) / n) - (wid / 2.0)), 2))));
                }
            }

            return plane;
        }

        double[,] Aberr(double A, double B, double C, double D, double E, double F, double width, int n)
        {
            double[,] plane = new double[n, n];
            double x, y;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    x = (width * ((double)(i) / n)) - (width / 2);
                    y = (width * ((double)(j) / n)) - (width / 2);

                    plane[i, j]  = A * (Math.Pow((x * x + y * y), 2) ) + B * y * (x * x + y * y) + C * (x * x + 3 * y * y) + D * (x * x + y * y) + E * y + F * x;
                }
            }

            return plane;
        }
    }
}
