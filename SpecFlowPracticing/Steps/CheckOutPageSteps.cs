using OpenQA.Selenium;
using SpecFlowPracticing.Pages.CheckOut;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class CheckOutPageSteps
    {
        private CheckOutPage CheckOutPage { get; }
        private SignInPage SignInPage { get; }
        public CheckOutPageSteps(IWebDriver driver)
        {
            CheckOutPage = new CheckOutPage(driver);
            SignInPage = new SignInPage(driver);
        }


        [Then(@"Registration page is shown")]
        public void ThenRegistrationPageIsShown()
        {
            SignInPage.PageShouldBeCreateAnAccount();
        }

        [When(@"I fill in all required fields")]
        public void WhenIFillInAllRequiredFields(Table table)
        {
            SignInPage.FillInAllRequiredFields(table);
        }

        [When(@"Click on Register button")]
        public void WhenClickOnRegisterButton()
        {
            SignInPage.ClickOnRegistrationButton();
        }

        [Then(@"User is succesfully registered")]
        public void ThenUserIsSuccesfullyRegistered()
        {
            SignInPage.PageShouldBeMyAccount(); ;
        }

    }
}
