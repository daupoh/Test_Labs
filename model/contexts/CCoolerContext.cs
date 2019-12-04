using System.Data.Entity;
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
