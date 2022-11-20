using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using Expecting = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargodom
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    class Login
    {
        public IWebDriver Driver;
        public WebDriverWait wait;
        public static Random random = new Random();
        public string cargodom = "http://18.156.17.83:9095/";
        public string email = "a.stojcev@hotmail.com";
        public string user_password = "Aleksandar123";

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
        }

        [Parallelizable(ParallelScope.Self)]
        [Test]
        public void Login_Function()
        {
            Driver.Navigate().GoToUrl(cargodom);

            IWebElement loginButton = Driver.FindElement(By.CssSelector(("#login")));

            loginButton.Click();

            IWebElement username = Driver.FindElement(By.CssSelector(("#username")));

            username.SendKeys(email);

            IWebElement password = Driver.FindElement(By.CssSelector(("#password")));

            password.SendKeys(user_password);

            IWebElement singIn = Driver.FindElement(By.CssSelector(("[type='submit']")));

            singIn.Click();

            Assert.AreEqual(cargodom, Driver.Url, "They are not the same");

            List<IWebElement> listOfRequests = Driver.FindElements(By.CssSelector(("[class='tabular-data__item']"))).ToList();

            listOfRequests.First().TagName.Contains("Request Number 5");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
