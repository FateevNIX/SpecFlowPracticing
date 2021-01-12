using OpenQA.Selenium;
using SpecFlowPracticing.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class BaseSteps
    {
        private BasePage basePage { get; }
        public BaseSteps(IWebDriver driver)
        {
            basePage = new BasePage(driver);
        }

        /* public void NavigateToURL(string URL)
         {
             driver.Navigate().GoToUrl(URL);
         }*/

        [When(@"I search for the (.*)")]
        public void WhenISearchForTheproductOnAnyPage(string productName)
        {
            basePage.searchForProduct(productName);
        }
    }
}
