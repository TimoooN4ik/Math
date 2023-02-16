using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class TC
    {
        public int id { get; set; }

        private string Adensity;
        private string Amendment;

        public string adensity
        {
            get { return Adensity; }
            set { Adensity = value; }
        }
        public string amendment
        {
            get { return Amendment; }
            set { Amendment = value; }
        }

        public TC() { }

        public TC(string Adensity, string Amendment)
        {
            this.Adensity = Adensity;
            this.Amendment = Amendment;
        }
    }
}
