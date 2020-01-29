using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.Pages
{
    class CRestaurantPage:ACPage
    {
        public const string MIN_FREEDELIVERY = "//p[@class='restoran-item_big']",
            COST_PRODUCT= "//div[@class='itool2-box']//p[@class='product-item_bonus']",
            PRODUCT = "/div[contains(@class, 'col')]",
         ROW_BONUS_PRODUCT    = "//section[@id='bonus-items']/div[@class='row items']",
            ROW_PRODUCT = "//section[not(@id='bonus-items')]/div[@class='row items']",
           CART_PANE = "//div[@class='cart-pane hide']",
           CART_PANE_SUM = "//div[@class='cart-pane__sum']",
            CART_PANE_SUBMIT = "//a[contains(@class,'btn')]"; 

        [FindsBy(How = How.XPath, Using = ROW_PRODUCT)]
        public IList<IWebElement> m_aRowsProduct;

        [FindsBy(How = How.XPath, Using = ROW_BONUS_PRODUCT)]
        public IList<IWebElement> m_aRowsBonusProduct;

        public CRestaurantPage(IWebDriver rDriver, double iWaitSeconds) : base(rDriver, iWaitSeconds)
        {

        }

        public override void OnPage()
        {
        
        }
        public void CreateOrder()
        {

        }
    }
}
