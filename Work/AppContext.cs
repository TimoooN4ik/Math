using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Work
{
    class AppContext : DbContext
    {
        public DbSet<calc> calcs { get; set; }
        public DbSet<FHC> FHCs { get; set; }
        public DbSet<TC> TCs { get; set; }

        public AppContext() : base("DC") { }
    }
}
