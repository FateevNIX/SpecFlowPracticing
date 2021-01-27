using OpenQA.Selenium;
using SpecFlowPracticing.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class BaseSteps
    {
        private BasePage BasePage { get; }
        public BaseSteps(IWebDriver driver)
        {
            BasePage = new BasePage(driver);
        }

        /* public void NavigateToURL(string URL)
         {
             driver.Navigate().GoToUrl(URL);
         }*/

        [When(@"I search for the (.*)")]
        public void WhenISearchForTheproductOnAnyPage(string productName)
        {
            BasePage.SearchForProduct(productName);
        }

        [When(@"I click 'Continue shopping' button")]
        public void WhenIClickContinueButton()
        {
            BasePage.ClickOnContinueShoppingButton();
        }

        [When(@"I click 'Proceed to checkout' button")]
        public void WhenIClickproceedToCheckoutButton()
        {
            BasePage.ClickOnProceedToCheckoutButton();
        }

        [When(@"I click on 'Sign in' button")]
        public void WhenIClickOnButton()
        {
            BasePage.ClickOnSignInButton();
        }

    }
}
