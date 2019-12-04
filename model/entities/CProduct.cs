using System.Collections.Generic;

namespace wf_testLabs.model.entities
{
    class CProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public ICollection<CRecipeProduct> Recipes { get; set; }

        public CProduct ()
        {
            Recipes = new List<CRecipeProduct>();
        }

    }
}
