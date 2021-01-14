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
        private SearchResultsPage SearchResultsPage { get; }
        public SearchResultsPageSteps(IWebDriver driver) 
        {
            SearchResultsPage = new SearchResultsPage(driver);
        }

        [Then(@"The search result page is shown")]
        public void ThenTheSearchResultPageIsShown()
        {
            SearchResultsPage.CheckSearchResultsPageTitle();
        }

        [Then(@"Results contains (.*)")]
        public void ThenResultsContainsProductName(string productName)
        {
            Assert.That(SearchResultsPage.GetFirstProductName(), Contains.Substring(productName),
                $"There is no '{productName}' in first search result");
        }

        [When(@"I click on More button for first product")]
        public void WhenIClickOnMoreButtonForFirstProduct()
        {
            SearchResultsPage.ClickOnMoreButtonForFirstProduct();
        }
    }
}
