using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
