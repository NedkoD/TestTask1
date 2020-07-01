using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TelerikLoginTestTask
{
    [TestFixture]
    public class TelerikLoginTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void TestMethod1()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.telerik.com/login/v2/telerik");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();

        }

        [Test]
        public void LoginTelerik()
        {
            //accept the user agreement
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();

            //send username and password
            driver.FindElement(By.Id("username")).SendKeys("nedkoedno@mail.bg");
            driver.FindElement(By.Id("password")).SendKeys("tralala");

            var loginButton = wait.Until((w) => { return w.FindElement(By.Id("GeneralContent_C048_ctl00_ctl00_LoginButton")); });
            loginButton.Click();

            //check if the  page is loaded
            var usernameField = wait.Until((w) => { return w.FindElement(By.XPath("//h3[@class='e2e-nickname u-wbba']")); });

            Assert.AreEqual("Nedko", usernameField.Text);


        }

        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
