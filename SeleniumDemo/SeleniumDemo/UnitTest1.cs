using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumDemo
{
    [TestClass]
    public class UnitTest1: BaseTest
    {
      
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/documentation/");  
            Thread.Sleep(5000);
            var logo = driver.FindElement(By.Id("Layer_1")).Displayed;

            driver.Close();

        }

        [TestMethod]
        public void TextBoxFormTest()
        {          
            driver.FindElement(By.Id("userName")).SendKeys("Naveen");
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("naveen.kakani@test.com");
            driver.FindElement(By.CssSelector("#currentAddress")).SendKeys("test");
            driver.FindElement(By.Id("permanentAddress")).SendKeys("test123");
            var submitButton = driver.FindElement(By.Id("submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();
            Thread.Sleep(2000);
            var result = driver.FindElements(By.CssSelector(".border p"));
            foreach(var element in result)
            {
                Console.WriteLine(element.Text);
            }
        }

       
    }
}