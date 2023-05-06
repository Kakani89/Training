using OpenQA.Selenium;
using SeleniumDemo.CommonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Pages
{
    public class DemoWindowspage : Helper
    {
        private readonly IWebDriver driver;

        public DemoWindowspage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public IWebElement windowPageLink => driver.FindElement(By.XPath("//span[text()='Browser Windows']"));
        public IWebElement NewTab => driver.FindElement(By.Id("tabButton"));
        public IWebElement NewTabElement => driver.FindElement(By.Id("sampleHeading"));

        public void ClickOnBrowserWindows()
        {
            MovetoElement(driver, windowPageLink);
            windowPageLink.Click();
        }
        public void ClickOnNewTab()
        {
            NewTab.Click();
        }

        public string NewTabElementText()
        {
            return NewTabElement.Text;
        }
    }
}
