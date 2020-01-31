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
            return "Берлин";
        }

        public string GetCountryById(string CountryId)
        {
            return "Германия";
        }

        public Dictionary<string, string> GetInformation(string UserId, string[] Fields)
        {
            return new Dictionary<string, string>()
            {
                { "photo_max","https://image.jpg" },
                { "first_name","Евгений" },
                { "last_name","Стоялов" },
                { "country","Россия" },
                { "city","Белгород" }
            };
        }
    }
}
