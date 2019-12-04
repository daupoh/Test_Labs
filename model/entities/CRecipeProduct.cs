
namespace wf_testLabs.model.entities
{
    class CRecipeProduct
    {

        public int Id { get; set; }
        public double Amount { get; set; }

        public int? RecipeId { get; set; }
        public CRecipe Recipe { get; set; }

        public int? ProductId { get; set; }
        public CProduct Product { get; set; }
       

    }
}
