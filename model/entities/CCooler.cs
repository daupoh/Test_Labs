
using System.Collections.Generic;

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
