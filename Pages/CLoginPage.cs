
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs.Pages
{
    class CLoginPage:ACPage
    {
        public const string EMAIL_INPUT = "//div[@id='view_container']//input[@type='email']",
            NEXT_EMAIL_BUTTON = "//div[@id='view_container']//div[@id='identifierNext']",
            NEXT_PASSWORD_BUTTON = "//div[@id='view_container']//div[@id='passwordNext']",
            PASSWORD_INPUT = "//div[@id='view_container']//input[@type='password']",
            WELCOME_TEXT = "//h1[@id='headingText']",
            PROFILE = "//div[@id='profileIdentifier']"
            ;
        
        [FindsBy(How =How.XPath,Using = EMAIL_INPUT)]
        public IWebElement m_rEmailInput;
        [FindsBy(How = How.XPath, Using = NEXT_EMAIL_BUTTON)]
        public IWebElement m_rNextButtonEmail;
        [FindsBy(How = How.XPath, Using = PASSWORD_INPUT)]
        public IWebElement m_rPasswordInput;
        [FindsBy(How = How.XPath, Using = NEXT_PASSWORD_BUTTON)]
        public IWebElement m_rNextButtonPassword;

        [FindsBy(How = How.XPath, Using = WELCOME_TEXT)]
        public IWebElement m_rWelcome;
        [FindsBy(How = How.XPath, Using = PROFILE)]
        public IWebElement m_rProfile;
        public CLoginPage(IWebDriver rDriver, double iWaitSeconds) :base(rDriver,iWaitSeconds)
        {
            
        }
        public CMainPage Login(string sEmail,string sPassword)
        {
            m_rWait.Until(m_rWelcome);
            m_rEmailInput.SendKeys(sEmail);
            m_rNextButtonEmail.Click();
            m_rPasswordInput.SendKeys(sPassword);
            m_rNextButtonPassword.Click();

            return new CMainPage(m_rDriver, m_rWait.Timeout.TotalSeconds);
        }
    }
}
