using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticing.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class SearchResultsPageSteps
    {
        private SearchResultsPage searchResultsPage { get; }
        public SearchResultsPageSteps(IWebDriver driver) 
        {
            searchResultsPage = new SearchResultsPage(driver);
        }

        [Then(@"The search result page is shown")]
        public void ThenTheSearchResultPageIsShown()
        {
            searchResultsPage.checkSearchResultsPageTitle();
        }

        [Then(@"Results contains (.*)")]
        public void ThenResultsContainsProductName(string productName)
        {
            Assert.That(searchResultsPage.getFirstProductName(), Contains.Substring(productName),
                $"There is no '{productName}' in first search result");
        }

        [When(@"I click on More button for first product")]
        public void WhenIClickOnMoreButtonForFirstProduct()
        {
            searchResultsPage.clickOnMoreButtonForFirstProduct();
        }
    }
}
