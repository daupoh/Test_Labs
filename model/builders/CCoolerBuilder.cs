﻿
using wf_testLabs.model.entities;

namespace wf_testLabs.model.builders
{
    class CCoolerBuilder
    {
        int i;

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
