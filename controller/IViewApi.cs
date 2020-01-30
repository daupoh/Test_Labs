using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.controller
{
    interface IViewApi
    {
        Dictionary<string, string> GetInformation(string UserId, string[] Fields);  //Получение заданной информации о пользователе с заданным ID 


        string GetCityById(string CityId);  //Перевод ID города в название


        string GetCountryById(string CountryId); //Перевод ID страны в название
       
    }
}
