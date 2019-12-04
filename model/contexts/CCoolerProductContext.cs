using System.Data.Entity;
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
