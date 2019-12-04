using System;
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
        [Key]
        [ForeignKey("CRecipe")]
        public int Id { get; set; }
    }
}
