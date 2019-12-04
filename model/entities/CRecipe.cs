
using System.Collections.Generic;

namespace wf_testLabs.model.entities
{
    class CRecipe
    {
        public int Id { get; set; }
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
