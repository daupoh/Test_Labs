using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.contexts
{
    class CCoolerProductContext : DbContext
    {
        public CCoolerProductContext():base("DBConnection")
        {

        }
        public DbSet<CCoolerProduct> CoolerProducts { get; set; }
    }
}
