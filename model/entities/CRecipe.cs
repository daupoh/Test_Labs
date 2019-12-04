using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.model.entities
{
    class CRecipe
    {
        public string Name { get; set; }
        public ICollection<CRecipeProduct> RecipeProducts { get; set; }
        public string Descriptions { get; set; }
        public int Time { get; set; }

        public CRecipe()
        {
            RecipeProducts = new List<CRecipeProduct>();
        }
    }
}
