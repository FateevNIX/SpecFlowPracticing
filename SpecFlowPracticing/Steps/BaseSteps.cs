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
    }
}
