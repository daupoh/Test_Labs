﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.model.contexts
{
    class CProductContext: DbContext
    {
        public CProductContext():base("DBConnection")
        {

        }
        public DbSet<CProduct> Products { get; set; }

    }
}
