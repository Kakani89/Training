using OpenQA.Selenium;
using SeleniumDemo.CommonHelpers;
using SeleniumExtras.PageObjects;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace SeleniumDemo.Pages
{
    public class PageClass1:Helper
    {
        private readonly IWebDriver driver;

        public PageClass1 (IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public IWebElement linksPageLink => driver.FindElement(By.XPath("//span[text()='Links']"));
        public ReadOnlyCollection<IWebElement> links => driver.FindElements(By.XPath("//div[@id='linkWrapper']//a"));

        public IWebElement WindowsPageLink => driver.FindElement(By.XPath("//div[text()='Alerts, Frame & Windows']"));


        // etc

        public void ClickOnPageLink()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", linksPageLink);
            linksPageLink.Click();
        }

        public bool ValidateLinks()
        {
            bool flag = false;
            foreach (var link in links)
            {
                if (link.Text.Contains("Home"))
                    continue;
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
                link.Click();
                Thread.Sleep(2000);
                var linkResponse = driver.FindElement(By.Id("linkResponse")).Text;

                if (linkResponse.Contains(link.Text))
                    flag = true;
                else { flag = false; break; }


            }
            return flag;
        }

        public void ClickOnWindowLink()
        {
            MovetoElement(driver, WindowsPageLink);
            WindowsPageLink.Click();
        }
    }
}
