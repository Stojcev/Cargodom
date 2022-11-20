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

    class Registation_Looking_For_A_Transporter
    {
        
        public IWebDriver Driver;
        public WebDriverWait wait;
        public static Random random = new Random();

        public string cargodom = "http://18.156.17.83:9095/";
        public string nameInput = RandomNames(12);
        public string surnameInput= RandomNames(8);
        public string adressInput = RandomNames(6);
        public string cityInput= RandomNames(8);
        public string cityCodInput = RandomNumber(6);
        public string telephoneNumberInput= RandomNumber(9);
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
        public void CargadomRegistrationImLooking()
        {
            Driver.Navigate().GoToUrl(cargodom);

            IWebElement logo = Driver.FindElement(By.ClassName("logo-img"));

            Assert.AreEqual(cargodom, Driver.Url, "They are not the same");

            IWebElement registrationButton = Driver.FindElement(By.CssSelector("a[ui-sref='register']"));

            registrationButton.Click();


            IWebElement baramTransporter = Driver.FindElement(By.CssSelector("button[class='btn btn-blue account-type__button']"));

            baramTransporter.Click();

            string siteZaBaramTransporter = "http://18.156.17.83:9095/account-type/register-client";

            Assert.AreEqual(siteZaBaramTransporter, Driver.Url);

            IWebElement firstName = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.user.firstName']")));

            firstName.SendKeys(nameInput);

            Assert.IsNotNull(firstName);

            IWebElement lastName = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.user.lastName']")));

            lastName.SendKeys(surnameInput);

            IWebElement addres = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.address.address']")));

            addres.SendKeys(adressInput);

            IWebElement city = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.address.city']")));

            city.SendKeys(cityInput);

            IWebElement cityCod = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.address.postalCode']")));

            cityCod.SendKeys(cityCodInput);

            IWebElement country = Driver.FindElement(By.CssSelector(("span[ng-click='$select.activate()']")));

            country.Click();

            List<IWebElement> listOfCountries = Driver.FindElements(By.ClassName("ui-select-choices-row-inner")).ToList();

            listOfCountries[random.Next(0, 72)].Click();

            IWebElement telephoneNumber = Driver.FindElement(By.CssSelector(("input[ng-model='vm.clientPerson.phoneNumber']")));

            telephoneNumber.SendKeys(telephoneNumberInput);

            IWebElement email = Driver.FindElement(By.CssSelector(("#email")));

            email.SendKeys(emailInput);

            IWebElement password = Driver.FindElement(By.CssSelector(("#password")));

            password.SendKeys(randomPassword);

            IWebElement confirmPassword = Driver.FindElement(By.CssSelector(("#confirmPassword")));

            confirmPassword.SendKeys(randomPassword);

            IWebElement acceptsTermsAndConditions = Driver.FindElement(By.CssSelector(("input[ng-model='vm.acceptTerms']")));

            acceptsTermsAndConditions.Click();

            IWebElement registerButton = Driver.FindElement(By.CssSelector(("[class='btn btn-green center-block']")));

            registerButton.Click();

            IWebElement registrationButtonSucessfull = Driver.FindElement(By.CssSelector((".successful-registration__checkmark")));

            if (registrationButtonSucessfull.Displayed)
            {
                Console.WriteLine("BRAVO VIE STE TUKA I VIE STE TOJ STO SER REGISTRIRAL HA HA ");
            }

            wait.Until(Expecting.ElementIsVisible(By.ClassName("successful-registration__checkmark")));

            bool isImageDisplayed = Driver.FindElement(By.ClassName("successful-registration__checkmark")).Displayed;

            Assert.IsTrue(isImageDisplayed);

            string successfulRegistration = "http://18.156.17.83:9095/account-type/register-client/client-successful-registration";

            Assert.AreEqual(successfulRegistration, Driver.Url, "Korisnikot ne e logiran");
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

