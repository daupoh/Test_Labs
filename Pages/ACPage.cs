using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.Pages
{
    abstract class ACPage
    {
        readonly protected IWebDriver m_rDriver;
        readonly protected WebDriverWait m_rWait;
        protected ACPage(IWebDriver rDriver, double iWaitSeconds)
        {
            if (rDriver != null && iWaitSeconds > 0)
            {
                m_rDriver = rDriver;
                m_rWait = new WebDriverWait(m_rDriver, TimeSpan.FromSeconds(iWaitSeconds));
                m_rDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(iWaitSeconds);
            }
            else
            {
                throw new InvalidOperationException("");
            }
        }
        public abstract void OnPage();
    }
}
