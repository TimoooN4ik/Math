using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lisaju
{
    public partial class Form1 : Form
    {
        int c = 0;
        double dt = 0.1;

        private Thread cpuThread;

        int n = 100;
        double[] x = new double[100];
        double[] y = new double[100];

        bool stop = false;

        public Form1()
        {
            InitializeComponent();

            cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters)); //создание потока
            cpuThread.IsBackground = true; //задает(может возвращать) значение, показывающее, является ли поток фоновым.
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cpuThread.Start();
        }
        private void getPerformanceCounters()
        {
            while (!stop)
            {
                this.BeginInvoke((MethodInvoker)delegate { UpdateCpuChart(); });
                Thread.Sleep(250);
            }
        }
        private void UpdateCpuChart()
        {
            chart1.Series[0].Points.Clear();

            for (int i = 0; i < n; i++)
            {
                x[i] = Math.Sin(2 * dt * i * c);
                y[i] = Math.Cos(dt * i * c);
            }

            for (int i = 0; i < n; i++)
                chart1.Series[0].Points.AddXY(x[i], y[i]);
            c++;
            if (c > 1000000)
                c = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop = !stop;
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
