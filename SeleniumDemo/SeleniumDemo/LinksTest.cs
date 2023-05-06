using OpenQA.Selenium;
using SeleniumDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    [TestClass]
    public class LinksTest:BaseTest
    {
        [TestMethod]
        public void VerifyLinks()
        {

            var page1 = new PageClass1(driver);
            var page2 = new PageClass2(driver);
            page1.ClickOnPageLink();
            var linkDisplay = page2.ValidateLinks();
            Assert.IsTrue(linkDisplay,"Link Value should display under Link text");
           
           
        }

        [TestMethod]
        public void WindowsTests()
        {
            var page1 = new PageClass1(driver);
            page1.ClickOnWindowLink();
            var windowPage = new DemoWindowspage(driver);
            windowPage.ClickOnBrowserWindows();
            var currentWindow = driver.CurrentWindowHandle;
            windowPage.ClickOnNewTab();
            var allWindows = driver.WindowHandles;

            foreach(var windowHandle in allWindows)
            {
                if(windowHandle==currentWindow) continue;
                driver.SwitchTo().Window(windowHandle);break;
            }

            string text= windowPage.NewTabElementText();
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
            windowPage.ClickOnNewTab();

        }
    }
}
