using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.contexts
{
    class CCoolerContext: DbContext
    {
        public CCoolerContext():base("DBConnection")
        {

        }
        public DbSet<CCooler> Coolers { get; set; }
    }
}
