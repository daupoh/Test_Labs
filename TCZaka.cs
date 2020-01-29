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
    class TCZaka
    {
        IWebDriver m_rDriver;                
        CMainPage m_rMainPage;

        [SetUp]
        public void SetUp()
        {
            m_rDriver = new ChromeDriver();            
            m_rMainPage = new CMainPage(m_rDriver, 10);

            m_rDriver.Url = "https://blg.zakazaka.ru/";            
            PageFactory.InitElements(m_rDriver, m_rMainPage);
        }
        [Test, TestCaseSource("NonModalCorrectAddres")]
        public void TestFindRestaurants(string sStreet, string sHouse)
        {            
            m_rMainPage.OnPage();
            m_rMainPage.FindRestaurants(sStreet, sHouse);
        }

        [TearDown]
        public void TearDown()
        {
            m_rDriver.Quit();
            m_rDriver = null;
        }

        private object[] NonModalCorrectAddres =
        {
            new object[]
            {
                "Королева","2А"
            },
            new object[]
            {
                "Свято-Троицкий бульвар","11"
            },
        };
    }
}
