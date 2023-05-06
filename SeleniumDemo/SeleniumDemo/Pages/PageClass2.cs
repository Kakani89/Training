using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Pages
{
    public class PageClass2
    {
        private readonly IWebDriver driver;

        public PageClass2(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public ReadOnlyCollection<IWebElement> links => driver.FindElements(By.XPath("//div[@id='linkWrapper']//a"));


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
    }
}
