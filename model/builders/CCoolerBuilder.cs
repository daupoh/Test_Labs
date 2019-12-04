using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.model.entities;

namespace wf_testLabs.model.builders
{
    class CCoolerBuilder
    {
        public CCooler Build()
        {
            CCooler rCooler = new CCooler();

            return rCooler;
        }
        public CCoolerBuilder WithName(string sName)
        {
            return this;
        }
     
    }
}
