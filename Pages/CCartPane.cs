using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.Pages
{
    class CCartPane: ACPage
    {
        public const string
            TITLE = "//h1",
            SUBMIT_ORDER = "//div[@class='cart-form']//button",
            POSITION = "//div[@class='restoran-cart']//div[@class='product-cart row']",
            COUNT_BLOCK = "/div[contains(@class,'js-cart-calc')]/input",
            COUNT_MINUS = "/div[contains(@class,'js-cart-calc')]/button[contains(@class, 'btn--minus')]",
            COUNT_PLUS = "/div[contains(@class,'js-cart-calc')]/button[contains(@class, 'btn--plus')]",
            DELETE_BUTTON = "//button[contains(@class,'product-cart_delete')]",
            PRICE = "//p[@class='product-cart_price']",
            TOTAL = "//div[contains(@class,'cart-summary_price')]/b";

        [FindsBy(How = How.XPath, Using = TITLE)]
        public IWebElement m_rTitle;

        [FindsBy(How = How.XPath, Using = SUBMIT_ORDER)]
        public IWebElement m_rSubmitOrder;

        [FindsBy(How = How.XPath, Using = TOTAL)]
        public IWebElement m_rTotal;

        [FindsBy(How = How.XPath, Using = POSITION)]
        public IList<IWebElement> m_aPositions;

        public CCartPane(IWebDriver rDriver, double iWaitSeconds) : base(rDriver, iWaitSeconds)
        {

        }

        public override void OnPage()
        {
            m_rWait.Until(m_rDriver => m_rTitle.Text.ToLower().Contains("ваша корзина"));
            m_rWait.Until(m_rDriver => m_rSubmitOrder.Text.ToLower().Contains("заказать"));
            m_rWait.Until(m_rDriver => m_rTotal.Displayed);
            m_rWait.Until(m_rDriver => m_aPositions.Count>0);
        }
        public void ClearOrder()
        {
            for (int i = 0; i < m_aPositions.Count; i++)
            {
                IWebElement rDeleteButton = m_aPositions[i].FindElement(By.XPath(DELETE_BUTTON));
                m_rWait.Until(m_rDriver => rDeleteButton.Displayed);
                rDeleteButton.Click();
            }
        }
        public void PlusOrder(int iPosition)
        {
            if (iPosition < m_aPositions.Count)
            {
                IWebElement rCountBlock = m_aPositions[iPosition]
                    .FindElement(By.XPath("." + COUNT_BLOCK));
                int iCount = Convert.ToInt32(rCountBlock.GetAttribute("value"));
                IWebElement rPlusButton = m_aPositions[iPosition]
                    .FindElement(By.XPath("." + COUNT_PLUS));
                rPlusButton.Click();
                rCountBlock = m_aPositions[iPosition]
                   .FindElement(By.XPath("." + COUNT_BLOCK));
                iCount++;
                m_rWait.Until(m_rDriver => Convert.ToInt32(rCountBlock.GetAttribute("value")) == iCount);
            }
        }
        public void MinusOrder(int iPosition)
        {
            if (iPosition < m_aPositions.Count)
            {
                IWebElement rCountBlock = m_aPositions[iPosition]
                    .FindElement(By.XPath("." + COUNT_BLOCK));
                int iCount = Convert.ToInt32(rCountBlock.GetAttribute("value"));
                IWebElement rMinusButton = m_aPositions[iPosition]
                    .FindElement(By.XPath("." + COUNT_MINUS));
                rMinusButton.Click();
                rCountBlock = m_aPositions[iPosition]
                   .FindElement(By.XPath("." + COUNT_BLOCK));
                m_rWait.Until(m_rDriver => Convert.ToInt32(rCountBlock.GetAttribute("value")) < iCount);
            }
        }
        public void CheckTotal()
        {
            int iSum = 0;
            for (int i = 0; i < m_aPositions.Count; i++)
            {
                IWebElement rCountBlock = m_aPositions[i].FindElement(By.XPath("."+COUNT_BLOCK)),
                    rPrice = m_aPositions[i].FindElement(By.XPath("." + PRICE));
                
                iSum += Convert.ToInt32(rCountBlock.GetAttribute("value"))*
                    Convert.ToInt32(rPrice.Text.ToLower().Replace("р",""));
            }            
            m_rWait.Until(m_rDriver => m_rTotal.Text.Contains(iSum.ToString())); 
        }
    }
}
