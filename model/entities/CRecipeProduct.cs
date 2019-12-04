﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
