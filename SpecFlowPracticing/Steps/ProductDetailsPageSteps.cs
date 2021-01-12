using OpenQA.Selenium;
using SpecFlowPracticing.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    class ProductDetailsPageSteps
    {
        private ProductDetailsPage productDetailsPage { get; }
        public ProductDetailsPageSteps(IWebDriver driver)
        {
            productDetailsPage = new ProductDetailsPage(driver);
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
    }
}
