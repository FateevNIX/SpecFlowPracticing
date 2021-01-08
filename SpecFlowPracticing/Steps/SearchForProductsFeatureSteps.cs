using NUnit.Framework;
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
            driver.Navigate().GoToUrl("http://automationpractice.com/");
        }
        
        [When(@"I enter the (.*) into search input")]
        public void WhenIEnterTheProductNameIntoSearchInput(string productName)
        {
           driver.FindElement(By.Id("search_query_top")).SendKeys(productName);
        }
        
        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            driver.FindElement(By.Name("submit_search")).Click();
        }
        
        [Then(@"The search result page is shown")]
        public void ThenTheSearchResultPageIsShown()
        {
            Assert.AreEqual(driver.Title, "Search - My Store", "Title is different!");
        }
        
        [Then(@"Results contains (.*)")]
        public void ThenResultsContainsProductName(string productName)
        {
          string actual =  driver.FindElement(By.XPath("//div[@class='product-container']//a[@class='product-name']")).Text;
            Assert.That(actual, Contains.Substring(productName), $"There is no '{productName}' in first search result");
        }

        [AfterScenario("tearDown")]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
