using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.api
{
    interface IVkApi
    {
        string GetUsers(string UserId, string[] Fields, string sToken);
        string GetCity(string CityId, string sToken);
        string GetCountry(string CountryId,string sToken);
        string GetToken();
    }
}
