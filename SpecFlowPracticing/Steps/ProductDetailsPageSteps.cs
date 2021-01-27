using OpenQA.Selenium;
using SpecFlowPracticing.Blocks;
using SpecFlowPracticing.Pages;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    class ProductDetailsPageSteps
    {
        private ProductDetailsPage ProductDetailsPage { get; }
        private AddToCartModal AddToCartModal { get; }
        private BasePage BasePage { get; }
        public ProductDetailsPageSteps(IWebDriver driver)
        {

            ProductDetailsPage = new ProductDetailsPage(driver);
            AddToCartModal = new AddToCartModal(driver);
            BasePage = new BasePage(driver);
        }

        [When(@"I select Quantity, Size, and Colour")]
        public void WhenISelectQuantitySizeAndColour(Table testData)
        {
            ProductDetailsPage.SelectQuantitySizeAndColour(testData);
        }

        [When(@"I click on 'Add to cart' button")]
        public void WhenIClickOnButton()
        {
            ProductDetailsPage.ClickOnAddToCartButton();
        }

        [Then(@"Product details page is shown")]
        public void ThenProductDetailsPageIsShown()
        {
            ProductDetailsPage.ProductDetailsPageIsShown();
        }

        [Then(@"Product has specific (.*) and (.*)")]
        public void ThenProductHasSpecificBlouseAnd(string fullName, string price)
        {
            ProductDetailsPage.ProductHasNextNameAndPrice(fullName, price);
        }

        [Then(@"""(.*)"" modal is shown")]
        public void ThenModalIsShown()
        {
            AddToCartModal.SuccessfullyAddedModalIsShown();
        }
    }
}
