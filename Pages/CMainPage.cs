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
            RESTAURANT = "//section[@class='list-page_catalog']/a",
            MIN_FREEDELIVERY = "//p[@class='restoran-item_big'][1]",
            COST_PRODUCT= "//div[@class='itool2-box']//p[@class='product-item_bonus']",
            PRODUCT = "/div[contains(@class, 'col')]",
         ROW_BONUS_PRODUCT    = "//section[@id='bonus-items']/div[@class='row items']",
            ROW_PRODUCT = "//section[not(@id='bonus-items')]/div[@class='row items']",
           CART_PANE = "//div[@class='cart-pane hide']",
           CART_PANE_SUM = "//div[@class='cart-pane__sum']",
            CART_PANE_SUBMIT = "//a[contains(@class,'btn')]"; 

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

        [FindsBy(How = How.XPath, Using = ROW_PRODUCT)]
        public IList<IWebElement> m_aRowsProduct;

        [FindsBy(How = How.XPath, Using = ROW_BONUS_PRODUCT)]
        public IList<IWebElement> m_aRowsBonusProduct;

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
        public void CreateOrder()
        {

        }
    }
}
