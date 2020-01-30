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
            COST_PRODUCT= "//div[@class='itool2-box']//p[@class='product-item_bonus']/span",
            ADD_BUTTON = "/div[contains(@class,'product-item_row')]/button",
            ADD_BUTTON_2 = "//div[contains(@class,'itool2-box')]//button",
            PRODUCT = "//div[contains(@class,'product-item--button')]",
         ROW_BONUS_PRODUCT    = "//section[@id='bonus-items']/div[@class='row items']",
            ROW_PRODUCT = "//section[not(@id='bonus-items')]/div[@class='row items']",
           CART_PANE = "//div[@class='cart-pane hide']",
           CART_PANE_SUM = "//div[@class='cart-pane__sum']",
            CART_PANE_SUBMIT = "//a[contains(@class,'btn')]"; 

        [FindsBy(How = How.XPath, Using = ROW_PRODUCT)]
        public IList<IWebElement> m_aRowsProduct;

        [FindsBy(How = How.XPath, Using = ROW_BONUS_PRODUCT)]
        public IList<IWebElement> m_aRowsBonusProduct;

        [FindsBy(How = How.XPath, Using = CART_PANE)]
        public IWebElement m_rCartPane;

        public CRestaurantPage(IWebDriver rDriver, double iWaitSeconds) : base(rDriver, iWaitSeconds)
        {

        }

        public override void OnPage()
        {
            m_rWait.Until(m_rDriver => m_aRowsProduct.Count > 0);
            m_rWait.Until(m_rDriver => !m_rCartPane.Displayed);
        }
        public void CreateOrder(int nProducts)
        {
            int fSum = 0, iColNumber,iRowNumber;
            IWebElement rCartPaneSum, rCartPaneSubmit, rOrderButton, rCost;
            if (nProducts < m_aRowsProduct.Count * 3)
            {
                iRowNumber = nProducts / 3;
                iColNumber = nProducts % 3;
            }
            else
            {
                iRowNumber = 0;
                iColNumber = 0;
            }

            rOrderButton = GetProductAttribute(iRowNumber,iColNumber,ADD_BUTTON);
            m_rWait.Until(m_rDriver => rOrderButton.Enabled);
            rOrderButton.Click();
            rCost = GetProductAttribute(iRowNumber, iColNumber, COST_PRODUCT);
            m_rWait.Until(m_rDriver => rCost.Text!="");
            fSum += Convert.ToInt32(rCost.Text);
            m_rWait.Until(m_rDriver => m_rCartPane.Displayed);
            rCartPaneSum = m_rCartPane.FindElement(By.XPath("." + CART_PANE_SUM));
            m_rWait.Until(m_rDriver => rCartPaneSum.Text.Contains(Convert.ToString(fSum)));

            rCartPaneSubmit = m_rCartPane.FindElement(By.XPath("." + CART_PANE_SUBMIT));
            rCartPaneSubmit.Click();
        }
        private IWebElement GetProductAttribute(int iRowNumber, int iColNumber, string sAttribute)
        {
            IWebElement rElement = null;
            rElement = m_aRowsProduct[iRowNumber].FindElements(By.XPath("." + PRODUCT))[iColNumber]
                .FindElement(By.XPath("." + sAttribute));
            return rElement;
        }
       
    }
}
