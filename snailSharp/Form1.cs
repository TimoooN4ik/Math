using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snailSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int c = 4;
        double l = 8;
        void draw(int c, double l)
        {
            double a = 4, p = 0, R = 0, x = 0, y = 0;
            for (double i = 0; i <= 360; i += 0.25)
            {
                R = l + a * Math.Cos(i);
                x = R * Math.Cos(i);
                y = R * Math.Sin(i);

                if(c < 5 && c > -1)
                    chart1.Series[c].Points.AddXY(x, y);//(i, p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            double a = 0.5, p = 0, R = 0, x = 0, y = 0, L = 0;

            try
            {
                a = Convert.ToDouble(textBox1.Text);
                L = Convert.ToDouble(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (double i = 0; i <= 360; i += 0.25)
            {
                R = L + a * Math.Cos(i);
                x = R * Math.Cos(i);
                y = R * Math.Sin(i);

                //if (c < 5 && c > -1)
                    chart1.Series[0].Points.AddXY(x, y);//(i, p);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
            /*for (int l = 8, c = 0; l >= 0; l -= 2, c++)
            {
                draw(c, l);
            }*/

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (l < 0 || c < 0)
            {
                c = 4;
                l = 8;
                timer1.Enabled = false;
                return;
            }
            draw(c, l);
            c--;
            l -= 2;
        }
    }
}
