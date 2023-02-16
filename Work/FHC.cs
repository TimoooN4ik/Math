using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class FHC
    {
        public int id { get; set; }

        private double B0, B1, B2, B3, B4;

        public double b0
        {
            get { return B0; }
            set { B0 = value; }
        }
        public double b1
        {
            get { return B1; }
            set { B1 = value; }
        }
        public double b2
        {
            get { return B2; }
            set { B2 = value; }
        }
        public double b3
        {
            get { return B3; }
            set { B3 = value; }
        }
        public double b4
        {
            get { return B4; }
            set { B4 = value; }
        }

        public FHC() { }

        public FHC(double B0, double B1, double B2, double B3, double B4)
        {
            this.B0 = B0;
            this.B1 = B1;
            this.B2 = B2;
            this.B3 = B3;
            this.B4 = B4;
        }
    }
}
