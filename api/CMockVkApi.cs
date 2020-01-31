using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.api
{
    class CMockVkApi : IVkApi
    {
        public string GetCity(string CityId, string sToken)
        {
            return "{\"id\":26,\"title\":\"Белгород\"}";
        }

        public string GetCountry(string CountryId, string sToken)
        {
            return "\"country\":{\"id\":1,\"title\":\"Россия\"}";

           
        }

        public string GetToken()
        {
            return "pass123";
        }

        public string GetUsers(string UserId, string[] Fields, string sToken)
        {
            return "{\"id\":248768661,\"first_name\":\"Евгений\"," +
                "\"last_name\":\"Стоялов\"," +
                "\"city\":{\"id\":26,\"title\":\"Белгород\"}," +
                "\"country\":{\"id\":1,\"title\":\"Россия\"}," +
            "\"photo_max\":\"https:\\/\\/image.jpg\"}";
        }
    }
}
