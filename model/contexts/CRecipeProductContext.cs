
using System.Data.Entity;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.contexts
{
    class CRecipeProductContext: DbContext
    {
        public CRecipeProductContext() : base("DBConnection")
        {

        }
        public DbSet<CRecipeProduct> RecipeProducts { get; set; }
    }
}
