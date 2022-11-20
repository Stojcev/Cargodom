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

    class Flow_Cargodom_Functionalities
    {
        public IWebDriver Driver;
        public WebDriverWait wait;

        public static Random random = new Random();

        public string cargodom = "http://18.156.17.83:9095/";

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
        public void FinalHomework()
        {
            string email_imLookingForTransporter_user = "a.stojcev@hotmail.com";
            string password_imLookingForTransporte_user = "Aleksandar123";

            string email_UserForTransporter = "stojcev.a@hotmail.com";
            string password_UserForTrasnposrter = "Brainster1";

            Driver.Navigate().GoToUrl(cargodom);

            IWebElement logInButton = Driver.FindElement(By.CssSelector("a[id='login']"));
            logInButton.Click();

            IWebElement username = Driver.FindElement(By.CssSelector("#username"));

            username.SendKeys(email_imLookingForTransporter_user);

            IWebElement password = Driver.FindElement(By.CssSelector("#password"));

            password.SendKeys(password_imLookingForTransporte_user);

            IWebElement singIn = Driver.FindElement(By.CssSelector("[type='submit']"));
            singIn.Click();

            IWebElement createRequest = Driver.FindElement(By.CssSelector("a[ui-sref='client-create-request']"));
            createRequest.Click();

            IWebElement title = Driver.FindElement(By.CssSelector("input[ng-model='vm.request.title']"));
            title.SendKeys("Dolen Ves");

            IWebElement catrogy = Driver.FindElement(By.CssSelector("select[ng-model='vm.request.categoryType']"));
            catrogy.Click();

            wait.Until(Expecting.ElementToBeClickable(By.CssSelector("select>option[value='COMBE']")));
            IWebElement categoryCombe = Driver.FindElement(By.CssSelector("select>option[value='COMBE']"));
            categoryCombe.Click();

            List<IWebElement> pickUpDelivery = Driver.FindElements(By.CssSelector("input[ng-model='vm.mustPutSomething']")).ToList();
            IWebElement pickUp = pickUpDelivery[0];
            pickUp.Click();
            pickUp.SendKeys(RandomSpecalAdress(2));

            List<IWebElement> pickUpTable = Driver.FindElements(By.CssSelector("div[class='pac-item']")).ToList();

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("div[class='pac-item']")));
            pickUpTable.First().Click();

            IWebElement delivery = pickUpDelivery[1];
            wait.Until(Expecting.ElementIsVisible(By.CssSelector("input[ng-model='vm.mustPutSomething']")));
            delivery.Click();
            delivery.SendKeys(RandomSpecalAdress(2));

            List<IWebElement> deliveryTable = Driver.FindElements(By.CssSelector("div[class='pac-item']")).ToList();
            wait.Until(Expecting.ElementIsVisible(By.CssSelector("div[class='pac-item']")));
            deliveryTable.First().Click();

            IWebElement checkBoxPickUpDate = Driver.FindElement(By.CssSelector("input[ng-model='vm.setPickUpDate']"));
            checkBoxPickUpDate.Click();

            IWebElement earlierPickUpDate = Driver.FindElement(By.CssSelector("input[ng-click='vm.openEarliestPickUpDatePicker()']"));
            earlierPickUpDate.SendKeys("22.04.2023");

            IWebElement latestPickUpDate = Driver.FindElement(By.CssSelector("input[ng-click='vm.openLatestPickUpDatePicker()']"));
            latestPickUpDate.SendKeys("05.05.2023");

            IWebElement checkBoxDeliveryDate = Driver.FindElement(By.CssSelector("input[ng-model='vm.setDeliveryDate']"));
            checkBoxDeliveryDate.Click();

            IWebElement earliestDelivery = Driver.FindElement(By.CssSelector("input[ng-click='vm.openEarliestDeliveryDatePicker()']"));
            earliestDelivery.SendKeys("16.05.2023");

            IWebElement latestDelivery = Driver.FindElement(By.CssSelector("input[ng-click='vm.openLatestDeliveryDatePicker()']"));
            latestDelivery.SendKeys("16.05.2023");

            IWebElement shipmentWeight = Driver.FindElement(By.CssSelector("input[ng-model='vm.request.shipmentWeight']"));
            shipmentWeight.SendKeys("500");

            IWebElement shipmentVolume = Driver.FindElement(By.CssSelector("input[ng-model='vm.request.shipmentVolume']"));
            shipmentVolume.SendKeys("50");

            IWebElement drescription = Driver.FindElement(By.CssSelector("textarea[ng-model='vm.request.description']"));
            drescription.SendKeys("No description needed, we are all going to nee ves");

            List<IWebElement> chechedBox = Driver.FindElements(By.CssSelector("input[ng-model='checked']")).ToList();

            IWebElement normalCheckedBox = chechedBox[0];
            normalCheckedBox.Click();

            IWebElement cashOnPickUpBox = chechedBox[2];
            cashOnPickUpBox.Click();

            IWebElement submitRequestButton = Driver.FindElement(By.CssSelector("input[class='btn btn-green center-block']"));
            submitRequestButton.Click();


            bool activeRequest = Driver.FindElement(By.CssSelector("span[class='request--outcome__success']")).Displayed;
            Assert.IsTrue(activeRequest);

            List<IWebElement> nameDolenVes = Driver.FindElements(By.CssSelector("div[class='tabular-data__item-body']")).ToList();

            IWebElement dolenVes = nameDolenVes[0];

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("a[ui-sref='client-request-details({id: request.id})']")));

            dolenVes.Text.Contains("Dolen Ves");

            List<IWebElement> logOut = Driver.FindElements(By.CssSelector("a[id='logout2']")).ToList();
            IWebElement logOutButoon = logOut[0];
            logOutButoon.Click();

            IWebElement logInButtonTransporter = Driver.FindElement(By.CssSelector(("a[id='login']")));
            logInButtonTransporter.Click();

            IWebElement usernameTransporter = Driver.FindElement(By.CssSelector(("#username")));
            usernameTransporter.SendKeys(email_UserForTransporter);

            IWebElement passwordTransporter = Driver.FindElement(By.CssSelector("#password"));
            passwordTransporter.SendKeys(password_UserForTrasnposrter);

            IWebElement singInTransporter = Driver.FindElement(By.CssSelector("[type='submit']"));
            singInTransporter.Click();

            List<IWebElement> activeRequests = Driver.FindElements(By.CssSelector("tr[ng-repeat='request in vm.requests | filter:cargo']")).ToList();

            IWebElement myActiveRequest = activeRequests[0];

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("td[class='table-body__cell column1']")));

            IWebElement myRequestTitle = myActiveRequest.FindElement(By.CssSelector("td[class='table-body__cell column1']"));

            string requestName = "Dolen Ves";

            Assert.AreEqual(requestName, myRequestTitle.Text, "Ne treba da ne se tocni.");

            List<IWebElement> requestClicks = Driver.FindElements(By.CssSelector("a[ui-sref='provider-request-details({id: request.id})']")).ToList();

            IWebElement myRequestClick = requestClicks[0];

            myRequestClick.Click();

            IWebElement createOffer = Driver.FindElement(By.CssSelector("button[class='details-panel__make-offer-btn']"));

            createOffer.Click();

            IWebElement cacheOnPickUp = Driver.FindElement(By.CssSelector("input[ng-model='paymentType.price']"));

            cacheOnPickUp.Click();
            cacheOnPickUp.SendKeys("10");

            List<IWebElement> fileds = Driver.FindElements(By.CssSelector("div[class='form-group']")).ToList();

            IWebElement pickUpTime = Driver.FindElement(By.CssSelector("input[ng-model='vm.pickUpTime']"));

            pickUpTime.SendKeys("24.04.2023 00:00");


            IWebElement deliveryTime = Driver.FindElement(By.CssSelector("input[ng-model='vm.deliveryTime']"));

            deliveryTime.SendKeys("26.04.2023 00:00");


            IWebElement offerValidUntil = Driver.FindElement(By.CssSelector("input[ng-model='vm.expirationDate']"));

            offerValidUntil.SendKeys("30.04.2023 02:00");


            IWebElement insurance = fileds[3];
            insurance.FindElement(By.CssSelector("option[value='750000']")).Click();

            IWebElement messageToClinet = Driver.FindElement(By.CssSelector("textarea[rows='9']"));

            messageToClinet.SendKeys("This is the best offer your going to get in a long time buddy \n So dont be sily take it!");

            IWebElement subbmitOffer = Driver.FindElement(By.CssSelector("button[class='make-offer__btn-create']"));

            subbmitOffer.Click();

            IWebElement conffirmOffer = Driver.FindElement(By.CssSelector("button[ng-click='vm.saveOffer()']"));

            conffirmOffer.Click();

            List<IWebElement> offerActive = Driver.FindElements(By.CssSelector("span[class='flex-table__offers-state-text']")).ToList();

            IWebElement myActiveOffer = offerActive[0];

            string activeOfferText = "Активен";

            Assert.AreEqual(activeOfferText, myActiveOffer.Text);

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("#logout2")));
            IWebElement logOutTransporter = Driver.FindElement(By.CssSelector("#logout2"));
            logOutTransporter.Click();


            IWebElement logInButtonUser = Driver.FindElement(By.CssSelector(("a[id='login']")));
            logInButtonUser.Click();

            IWebElement usernameUser = Driver.FindElement(By.CssSelector(("#username")));
            usernameUser.SendKeys(email_imLookingForTransporter_user);

            IWebElement passwordUser = Driver.FindElement(By.CssSelector("#password"));
            passwordUser.SendKeys(password_imLookingForTransporte_user);

            IWebElement singInUser = Driver.FindElement(By.CssSelector("[type='submit']"));
            singInUser.Click();

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("span[translate='provider.myRequests']")));
            IWebElement myRequest1 = Driver.FindElement(By.CssSelector("span[translate='provider.myRequests']"));
            myRequest1.Click();

            List<IWebElement> acceptetOffers = Driver.FindElements(By.CssSelector("tr[ng-repeat='request in vm.requests | filter:cargo']")).ToList();

            IWebElement myAcceptedOffer = acceptetOffers[0];

            List<IWebElement> myAcceptedOfferClick = myAcceptedOffer.FindElements(By.CssSelector("a[ui-sref='client-request-details({id: request.id})']")).ToList();

            myAcceptedOfferClick.First().Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement tableBody = Driver.FindElement(By.ClassName("table-body"));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", tableBody);

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("a[class='flex-table__expander-btn']")));
            IWebElement moreButton = Driver.FindElement(By.CssSelector("a[class='flex-table__expander-btn']"));

            moreButton.Click();

            IWebElement offerClick = Driver.FindElement(By.CssSelector("input[id='offer0']"));

            offerClick.Click();

            IWebElement acceptOffer = Driver.FindElement(By.CssSelector("input[ng-disabled='!offersSet.acceptedOffer']"));

            acceptOffer.Click();


            List<IWebElement> myFinishedRequestButtons = Driver.FindElements(By.CssSelector("a[class='tabs-wrapper__item-anchor']")).ToList();
            IWebElement myFinishedAcceptedRequests = myFinishedRequestButtons[1];
            myFinishedAcceptedRequests.Click();

            List<IWebElement> confirmAcceptedOffer = Driver.FindElements(By.CssSelector("tr[class='table-body__row']")).ToList();
            IWebElement myConfirmedAcceptedOffer = confirmAcceptedOffer[0];

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("a[ui-sref='client-request-details({id: request.id})']")));

            myConfirmedAcceptedOffer.Text.Contains("Dolen Ves");

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("#logout2")));
            IWebElement logOutFinal = Driver.FindElement(By.CssSelector("#logout2"));
            logOutFinal.Click();

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("#login")));
            IWebElement loginCheck = Driver.FindElement(By.CssSelector("#login"));

            string youAreNotLogInUrl = "http://18.156.17.83:9095/";
            Assert.AreEqual(youAreNotLogInUrl, Driver.Url, "he is not log in ");
            if (loginCheck.Displayed)
            {
                Console.WriteLine("The final project flow is done :) ");
            }

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();

        }

        public static string RandomSpecalAdress(int lenght)
        {
            const string specal = "ALsTcOhR";
            return new string(Enumerable.Repeat(specal, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
