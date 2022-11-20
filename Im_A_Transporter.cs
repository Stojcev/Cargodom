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

    class Im_A_Transporter
    {
        

        public IWebDriver Driver;
        public WebDriverWait wait;

        public static Random random = new Random();
        public string cargodom = "http://18.156.17.83:9095/";
        public string nameInput = RandomNames(12);
        public string surnameInput = RandomNames(8);
        public string companyNameInput = RandomNames(20);
        public string adressInput = RandomNames(6);
        public string cityInput = RandomNames(8);
        public string postalCodeInput = RandomNumber(6);
        public string taxInput = (RandomNumber(12));
        public string telephoneNumberInput = RandomNumber(9);
        public string emailInput = RandomNames(8) + RandomNumber(4) + RandomNames(2) + "+test@gmail.com";
        public string randomPassword = RandomNames(2) + RandomSpecal(2) + RandomNumber(2) + Govedo(7);

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
        public void CargodomRegistrationIMTransporter()
        {
            int randomIntemail = new Random().Next(1000);

            Driver.Navigate().GoToUrl(cargodom);

            IWebElement registrationButton = Driver.FindElement(By.CssSelector("a[ui-sref='register']"));

            registrationButton.Click();

            wait.Until(Expecting.ElementIsVisible(By.CssSelector(".logo-img")));

            bool isLogoDisplayed = Driver.FindElement(By.CssSelector(".logo-img")).Displayed;

            Assert.IsTrue(isLogoDisplayed);

            IWebElement imTransporterButton = Driver.FindElement(By.CssSelector(("button[class='btn btn-green account-type__button']")));

            imTransporterButton.Click();

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("input[ng-model='vm.providerPerson.user.firstName']")));

            bool isFirstNameDisplayed = Driver.FindElement(By.CssSelector("input[ng-model='vm.providerPerson.user.firstName']")).Displayed;

            Assert.IsTrue(isFirstNameDisplayed);

            IWebElement firstName = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.user.firstName']")));

            firstName.SendKeys(nameInput);

            Assert.That(firstName != null, "IT is not null");

            IWebElement lastName = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.user.lastName']")));

            lastName.SendKeys(surnameInput);

            Assert.IsNotNull(lastName);

            IWebElement companyname = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.providerCompany.name']")));

            companyname.SendKeys(companyNameInput);

            IWebElement address = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.providerCompany.address.address']")));

            address.SendKeys(adressInput);

            IWebElement city = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.providerCompany.address.city']")));

            city.SendKeys(cityInput);

            IWebElement postalcode = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.providerCompany.address.postalCode']")));

            postalcode.SendKeys(postalCodeInput);

            IWebElement country = Driver.FindElement(By.CssSelector(("[ng-click='$select.activate()']")));

            country.Click();

            IWebElement countryClick = Driver.FindElement(By.CssSelector(("[class='ui-select-choices-row active']")));

            countryClick.Click();

            IWebElement tax = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.providerCompany.taxNumber']")));

            tax.SendKeys(taxInput);

            IWebElement phoneNumber = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.phoneNumber']")));

            phoneNumber.SendKeys("+" + telephoneNumberInput);

            IWebElement email = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.user.email']")));

            email.SendKeys(emailInput);

            IWebElement password = Driver.FindElement(By.CssSelector(("input[ng-model='vm.providerPerson.user.password']")));

            password.SendKeys(randomPassword);

            IWebElement confirmPssword = Driver.FindElement(By.CssSelector(("#confirmPassword")));

            confirmPssword.SendKeys(randomPassword);

            IWebElement tickFiled = Driver.FindElement(By.CssSelector(("#acceptTerms")));

            tickFiled.Click();

            IWebElement registerButton = Driver.FindElement(By.CssSelector(("[class='btn btn-green center-block']")));

            registerButton.Click();

            wait.Until(Expecting.ElementIsVisible(By.ClassName("successful-registration__checkmark")));

            bool isImageDisplayed = Driver.FindElement(By.ClassName("successful-registration__checkmark")).Displayed;

            Assert.IsTrue(isImageDisplayed);

            IWebElement checketBoxRegister = Driver.FindElement(By.CssSelector((".successful-registration__checkmark")));

            if (checketBoxRegister.Displayed)
            {
                Console.WriteLine("It is displayed");
            }

            string sucessfullRegistration = "http://18.156.17.83:9095/account-type/register-provider/provider-successful-registration";

            Assert.AreEqual(sucessfullRegistration, Driver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public static string RandomNames(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsqtuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomSpecal(int lenght)
        {
            const string specal = "!@#$%^&*()_+";
            return new string(Enumerable.Repeat(specal, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Govedo(int lenght)
        {
            const string govedo = "GOVEDO";

            return new string(Enumerable.Repeat(govedo, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
