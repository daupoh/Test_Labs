using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.model.entities
{
    class CCooler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CCoolerProduct> Products { get; set; }

        public CCooler()
        {
            Products = new List<CCoolerProduct>();
        }
    }
}
