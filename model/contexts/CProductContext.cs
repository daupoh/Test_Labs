
using System.Data.Entity;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.contexts
{
    class CProductContext: DbContext
    {
        public CProductContext():base("DBConnection")
        {

        }
        public DbSet<CProduct> Products { get; set; }

    }
}
