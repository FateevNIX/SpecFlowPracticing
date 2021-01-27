using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.TestData;
using SpecFlowPracticing.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Pages.CheckOut
{
    public class AuthenticationPage
    {
        private readonly IWebDriver driver;

        public AuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email_create")]
        protected IWebElement EmailAdressInput { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        protected IWebElement CreateAnAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading']")]
        protected IWebElement AuthenticationTitle { get; set; }

        public SignInPage EnterAndSubmitNewEmail()
        {
            EmailAdressInput.SendKeys(StringGenerator.RandomString());
            CreateAnAccountButton.Click();
            return new SignInPage(driver);
        }
        public void PageShouldBeAuthentication()
        {
            Waiter.WaitForElementIsDisplayed(driver, AuthenticationTitle);
            Assert.AreEqual("AUTHENTICATION", AuthenticationTitle.Text);
        }
    }
}
