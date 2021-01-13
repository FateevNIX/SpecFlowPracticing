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
        private ProductDetailsPage productDetailsPage { get; }
        private AddToCartModal addToCartModal;
        public ProductDetailsPageSteps(IWebDriver driver)
        {
            productDetailsPage = new ProductDetailsPage(driver);
            addToCartModal = new AddToCartModal(driver);
        }

        [When(@"I select Quantity, Size, and Colour")]
        public void WhenISelectQuantitySizeAndColour(Table testData)
        {
            productDetailsPage.SelectQuantitySizeAndColour(testData);
        }

        [Then(@"Product details page is shown")]
        public void ThenProductDetailsPageIsShown()
        {
            productDetailsPage.ProductDetailsPageIsShown();
        }

        [Then(@"Product has specific (.*) and (.*)")]
        public void ThenProductHasSpecificBlouseAnd(string fullName, string price)
        {
            productDetailsPage.ProductHasNextNameAndPrice(fullName, price);
        }

        [When(@"I click on 'Add to cart' button")]
        public void WhenIClickOnButton()
        {
            productDetailsPage.ClickOnAddToCartButton();
        }

        [Then(@"""(.*)"" modal is shown")]
        public void ThenModalIsShown(string p0)
        {
            addToCartModal.successfullyAddedModalIsShown();
        }


    }
}
