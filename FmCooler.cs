using System;
using System.Windows.Forms;
using wf_testLabs.model.contexts;
using wf_testLabs.model.entities;

namespace wf_testLabs
{
    public partial class FmCooler : Form
    {
        public FmCooler()
        {
            InitializeComponent();
            using (CProductContext rProductContext = new CProductContext())
            {
                int i = 2;
                CProduct rPotato = new CProduct {Name = "Картофель", Type = i+4};

                rProductContext.Products.Add(rPotato);
                rProductContext.SaveChanges();
                var aProducts = rProductContext.Products;
                Console.WriteLine("Список объектов:");
                foreach (CProduct rProduct in aProducts)
                {
                    Console.WriteLine("{0}.{1} ", rProduct.Id, rProduct.Name);
                }
            }
        }
    }
}
