
using System.Data.Entity;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.contexts
{
    class CRecipeContext : DbContext
    {
        public CRecipeContext():base("DBConnection")
        {

        }
        public DbSet<CRecipe> Recipes { get; set; }
    }
}
