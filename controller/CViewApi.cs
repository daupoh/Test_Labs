using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.api;
using wf_testLabs.controller;
using xNet;

namespace wf_testLabs
{
    class CViewApi: IViewApi
    {   
        private string _Token;  //Токен, использующийся при запросах
        IVkApi m_rVkApi;

        public CViewApi(string sAppId)
        {            
            m_rVkApi = new CVkApi(sAppId);
            _Token = m_rVkApi.GetToken();
        }
        public CViewApi(CVkApi rVkApi)
        {
            m_rVkApi = rVkApi;
            _Token = m_rVkApi.GetToken();
        }

        public Dictionary<string, string> GetInformation(string UserId, string[] Fields)  //Получение заданной информации о пользователе с заданным ID 
        {            
            Dictionary<string, string> Dict = JsonConvert.
                DeserializeObject<Dictionary<string, string>>(m_rVkApi.GetUsers(UserId, Fields, _Token));
            return Dict;
        }

        public string GetCityById(string CityId)  //Перевод ID города в название
        {
            Dictionary<string, string> Dict = JsonConvert.
                DeserializeObject<Dictionary<string, string>>(m_rVkApi.GetCity(CityId, _Token));
            return Dict["name"];
        }

        public string GetCountryById(string CountryId)  //Перевод ID страны в название
        {           
            Dictionary<string, string> Dict = JsonConvert
                .DeserializeObject<Dictionary<string, string>>(m_rVkApi.GetCountry(CountryId, _Token));
            return Dict["name"];
        }
    }
}
