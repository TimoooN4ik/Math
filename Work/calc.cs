using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class calc
    {
        public int id { get; set; }

        private double K, a, b, c;

        public double k
        {
            get { return K; }
            set { K = value; }
        }
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public calc() { }

        public calc(double K, double a, double b, double c)
        {
            this.K = K;
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
