using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf_testLabs.Pages;

namespace wf_testLabs
{
    [TestFixture]
    class TCGoogleMail
    {
        IWebDriver m_rDriver;        
        CLoginPage m_rLoginPage;        

        [SetUp]
        public void SetUp()
        {
            m_rDriver = new ChromeDriver();
            m_rLoginPage = new CLoginPage(m_rDriver,10);
            
            m_rDriver.Url = "https://mail.google.com/";
            PageFactory.InitElements(m_rDriver, m_rLoginPage);
        }
        [Test]
        public void SimpleTest()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            m_rDriver.Quit();
            m_rDriver = null;
        }
    }
}
