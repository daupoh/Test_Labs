using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wf_testLabs.model.contexts;

namespace wf_testLabs
{
    public partial class FmCooler : Form
    {
        public FmCooler()
        {
            InitializeComponent();
            using (CProductContext rProductContext = new CProductContext())
            {
                CProduct rPotato = new CProduct {Name = "Картофель", Type = 2, Amount = 3 };

                rProductContext.Products.Add(rPotato);
                rProductContext.SaveChanges();
                var aProducts = rProductContext.Products;
                Console.WriteLine("Список объектов:");
                foreach (CProduct rProduct in aProducts)
                {
                    Console.WriteLine("{0}.{1} - {2}", rProduct.Id, rProduct.Name, rProduct.Amount);
                }
            }
        }
    }
}
