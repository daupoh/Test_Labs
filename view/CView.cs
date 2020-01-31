using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.controller;

namespace wf_testLabs.view
{
    class CView:IView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }       
        public string ImageLocation { get; set; } 
        IViewApi m_rViewApi;
        Dictionary<string, string> _Response;
        public CView(string sAppId)
        {
            m_rViewApi = new CViewApi(sAppId);
        }
        public CView(IViewApi rViewApi)
        {
            m_rViewApi = rViewApi;
        }

        public string[] GetFields()
        {
            string[] aFields = new string[4];
            aFields[0] = Name;
            aFields[1] = Surname;
            aFields[2] = City;
            aFields[3] = Country;  

            return aFields;
        }

        public void GetInformation(string _UserId)
        {
            try
            {
                string[] Params = { "city", "country", "photo_max" };
                _Response = m_rViewApi.GetInformation (_UserId, Params);
                if (_Response != null)
                {
                    ImageLocation = _Response["photo_max"];
                    Name = _Response["first_name"];
                    Surname = _Response["last_name"];
                    Country = m_rViewApi.GetCountryById(_Response["country"]);
                    City = m_rViewApi.GetCityById(_Response["city"]);
                }
            }
            catch
            {

            }
        }
    }
}
