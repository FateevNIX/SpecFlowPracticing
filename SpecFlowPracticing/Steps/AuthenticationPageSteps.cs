using OpenQA.Selenium;
using SpecFlowPracticing.Pages.CheckOut;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class AuthenticationPageSteps
    {
        private AuthenticationPage AuthenticationPage { get; }
        public AuthenticationPageSteps(IWebDriver driver)
        {
            AuthenticationPage = new AuthenticationPage(driver);
        }
        [Then(@"Authentication page is shown")]
        public void ThenAuthenticationPageIsShown()
        {
            AuthenticationPage.PageShouldBeAuthentication();
        }


        [When(@"I enter and submit new Email")]
        public void WhenIEnterAndSubmitNewEmail()
        {
            AuthenticationPage.EnterAndSubmitNewEmail();
        }
    }
}
