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
        private BasePage BasePage { get; }
        public SearchResultsPageSteps(IWebDriver driver) 
        {
            SearchResultsPage = new SearchResultsPage(driver);
            BasePage = new BasePage(driver);
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

        [When(@"I add all available items to cart")]
        public void WhenIAddAllAvailableItemsToCart()
        {
            SearchResultsPage.AddAllProductsToCart();
        }

        [Then(@"Product cart should have '(.*)' products")]
        public void ThenProductCartShouldHaveProducts(string quantityOfProducts)
        {
            BasePage.CartShouldHaveSpecificNumberOfProducts(quantityOfProducts);
        }


    }
}
