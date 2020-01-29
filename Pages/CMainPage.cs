using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.Pages
{
    class CMainPage:ACPage
    {
        public const string DELIVERY_CITY = "//form[@class='header_box']//a[@id='current-city']",
            STREET_INPUT = "//form[@class='header_box']//input[@name='street']",
            HOUSE_INPUT = "//form[@class='header_box']//input[@name='house']",
            FIND_BUTTON = "//form[@class='header_box']//button",
            RESTAURANT = "//section[@class='list-page_catalog']/a";
         

         [FindsBy(How = How.XPath, Using = DELIVERY_CITY)]
        public IWebElement m_rDeliveryCity;

        [FindsBy(How = How.XPath, Using = STREET_INPUT)]
        public IWebElement m_rDeliveryStreet;

        [FindsBy(How = How.XPath, Using = HOUSE_INPUT)]
        public IWebElement m_rDeliveryHouse;

        [FindsBy(How = How.XPath, Using = FIND_BUTTON)]
        public IWebElement m_rFindButton;

        [FindsBy(How = How.XPath, Using = RESTAURANT)]
        public IList<IWebElement> m_aRestaurants;
     
        public CMainPage (IWebDriver rDriver,double iWaitSeconds):base(rDriver, iWaitSeconds)
        {

        }
        public override void OnPage()
        {
            m_rWait.Until(m_rDriver => m_rDeliveryCity.Text == "Белгород");
            m_rWait.Until(m_rDriver => m_rFindButton.Text.ToLower().Contains("найти рестораны"));
        }
        public void FindRestaurants(string sStreet, string sHouse)
        {
            m_rDeliveryStreet.SendKeys(sStreet);
            m_rDeliveryHouse.SendKeys(sHouse);
            m_rFindButton.Click();
            m_rWait.Until(m_rDriver => m_aRestaurants.Count>0);
        }
        
    }
}
