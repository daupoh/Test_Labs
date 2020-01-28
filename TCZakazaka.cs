using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_testLabs
{
    [TestFixture]
    class TCZakazaka
    {
        IWebDriver rDriver;
        WebDriverWait rWait;

        [SetUp]
        public void SetUp()
        {
            rDriver = new ChromeDriver();
            rWait = new WebDriverWait(rDriver, TimeSpan.FromSeconds(10));
               
        }
        [Test]
        public void SimpleTest()
        {
            rDriver.Url = "https://www.google.ru/";
            IWebElement rElement = rDriver.FindElement(By.Name("q"));
            rElement.SendKeys("send some keys");
            rElement.Submit();
            rElement = rDriver.FindElement(By.Id("resultStats"));
        }

        [TearDown]
        public void TearDown()
        {
            rDriver.Quit();
            rDriver = null;
        }
    }
}
