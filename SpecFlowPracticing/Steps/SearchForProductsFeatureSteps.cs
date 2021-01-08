using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class SearchForProductsFeatureSteps
    {
        IWebDriver driver;
        [Given(@"I navigate to the Home page")]
        public void GivenINavigateToTheHomePage()
        {
            driver = new ChromeDriver();
            driver.Url("http://automationpractice.com/");
        }
        
        [When(@"I enter the (.*)")]
        public void WhenIEnterTheBlouse(string productName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The search result page is shown")]
        public void ThenTheSearchResultPageIsShown()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Results contains Blouse")]
        public void ThenResultsContainsBlouse()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
