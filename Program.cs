using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AUTOMATION.FirstAutomation
{
    public class Program
    {
        public IWebDriver driver;
        public IWebElement _SearchBox;
        public IWebElement _twitterLink => driver.FindElement(By.XPath("//div/a[@href='https://twitter.com/BijayOCT25']"));
        public IWebElement _loginbtn => driver.FindElement(By.XPath("//div/a[@href='/login']"));
        public IWebElement _userName => driver.FindElement(By.XPath("//div/input[@name='text']"));
        public IWebElement _nextbtn => driver.FindElement(By.XPath("//div//span[text()='Next']"));
        public IWebElement _password => driver.FindElement(By.XPath("//div/input[@name='password']"));
        public IWebElement  _finalLogin => driver.FindElement(By.XPath("//div//div[@role='button']//span[text()='Log in']"));

        [SetUp]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            _SearchBox = driver.FindElement(By.Name("q"));
           
        }

        [SetUp]
        [Test]
        public void FirstTest()
        {
            _SearchBox.Click();
            _SearchBox.SendKeys("Bijay Uprety");
            _SearchBox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            ScrollDownTest();
            _twitterLink.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
             _loginbtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _userName.SendKeys("bijayuprety17@gmail.com");
            _nextbtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _password.SendKeys("Eyh6rrQM7YjU.Ac");
            _finalLogin.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        // [Test, Order(2)]
        // public void SecondTest()
        // {
        //     _loginbtn.Click();
        //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //     _userName.SendKeys("bijayuprety17@yahoo.com");
        //     _nextbtn.Click();
        //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //     _password.SendKeys("Eyh6rrQM7YjU.Ac");
        //     _finalLogin.Click();
        //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        // }


        [TearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }

         public void ScrollDownTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
