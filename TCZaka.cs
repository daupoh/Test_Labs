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
        CRestaurantPage m_rRestaurantPage;
        CCartPane m_rCartPanePage;

        [SetUp]
        public void SetUp()
        {
            m_rDriver = new ChromeDriver();            
            m_rMainPage = new CMainPage(m_rDriver, 10);
            m_rRestaurantPage = new CRestaurantPage(m_rDriver, 10);
            m_rCartPanePage = new CCartPane(m_rDriver, 10);

            m_rDriver.Url = "https://blg.zakazaka.ru/";            
            PageFactory.InitElements(m_rDriver, m_rMainPage);
            PageFactory.InitElements(m_rDriver, m_rRestaurantPage);
            PageFactory.InitElements(m_rDriver, m_rCartPanePage);
        }
        [Test, TestCaseSource("NonModalCorrectAddres")]
        public void TestFindRestaurants(string sStreet, string sHouse)
        {            
            m_rMainPage.OnPage();
            m_rMainPage.FindRestaurants(sStreet, sHouse);
            m_rRestaurantPage.OnPage();
        }
        [Test]
        public void TestOrderSum()
        {
            m_rMainPage.ToRestaurantPage();
            m_rRestaurantPage.OnPage();
            m_rRestaurantPage.CreateOrder(6);
            m_rCartPanePage.OnPage();
        }
       [Test]
       public void TestCartPaneEditOrder()
        {
            m_rMainPage.ToRestaurantPage();
            m_rRestaurantPage.CreateOrder(3);
            m_rCartPanePage.OnPage();          
            m_rCartPanePage.ClearOrder();
            m_rRestaurantPage.OnPage();
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
