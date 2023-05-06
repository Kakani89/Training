using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    public class BaseTest
    {
        public IWebDriver driver;
        [TestInitialize]
        public void InitialiazeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            Thread.Sleep(15000);
        }
        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }

       
    }
}
