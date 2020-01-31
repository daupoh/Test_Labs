using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace wf_testLabs.api
{
    class CVkApi : IVkApi
    {
        string AppId { get; set; }
        private const string __VKAPIURL = "https://api.vk.com/method/";  //Ссылка для запросов
        public CVkApi(string sAppId)
        {
            AppId = sAppId;
        }

        public string GetCity(string CityId, string sToken)
        {
            HttpRequest GetCityById = new HttpRequest();
            GetCityById.AddUrlParam("city_ids", CityId);
            GetCityById.AddUrlParam("access_token", sToken);
            GetCityById.AddUrlParam("v", "5.52");
            string Result = GetCityById.Get(__VKAPIURL + "database.getCitiesById").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            return Result;
        }

        public string GetCountry(string CountryId, string sToken)
        {
            HttpRequest GetCountryById = new HttpRequest();
            GetCountryById.AddUrlParam("country_ids", CountryId);
            GetCountryById.AddUrlParam("access_token", sToken);
            GetCountryById.AddUrlParam("v", "5.52");
            string Result = GetCountryById.Get(__VKAPIURL + "database.getCountriesById").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            return Result;
        }

        public string GetToken()
        {
            string sToken="";
            IWebDriver rDriver = new ChromeDriver();
            rDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            rDriver.Url = "https://oauth.vk.com/authorize?client_id=" + AppId
               + "&display=page&redirect_uri=" +
               "https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.52";
            string sButtonAccesXpath = "//button[contains(@class,'button_indent')]",
                sWarningXPath = "//b[.='не копируйте']";
            //rDriver.FindElement(By.XPath(sButtonAccesXpath));
            rDriver.FindElement(By.XPath(sWarningXPath));
            char[] Symbols = { '=', '&' };
            string[] URL = rDriver.Url.ToString().Split(Symbols);           
            sToken = URL[1];           
            rDriver.Quit();
            rDriver = null;
            return sToken;

        }

        public string GetUsers(string UserId, string[] Fields, string sToken)
        {
            HttpRequest GetInformation = new HttpRequest();
            GetInformation.AddUrlParam("user_ids", UserId);
            GetInformation.AddUrlParam("access_token", sToken);
            GetInformation.AddUrlParam("v", "5.52");
            string Params = "";
            foreach (string i in Fields)
            {
                Params += i + ",";
            }
            Params = Params.Remove(Params.Length - 1);
            GetInformation.AddUrlParam("fields", Params);
            string Result = GetInformation.Get(__VKAPIURL + "users.get").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            return Result;
        }
    }
}
