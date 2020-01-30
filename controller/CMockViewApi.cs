using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.controller
{
    class CMockViewApi : IViewApi
    {
        public string GetCityById(string CityId)
        {
            throw new NotImplementedException();
        }

        public string GetCountryById(string CountryId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetInformation(string UserId, string[] Fields)
        {
            throw new NotImplementedException();
        }
    }
}
