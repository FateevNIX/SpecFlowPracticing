using OpenQA.Selenium;
using SpecFlowPracticing.Blocks.CartBlocks;
using SpecFlowPracticing.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class CartPageSteps
    {
        private CartPage CartPage { get; }
        private CartTable CartTable { get; }
        public CartPageSteps(IWebDriver driver)
        {
            CartPage = new CartPage(driver);
            CartTable = new CartTable(driver);
        }

        [Then(@"Cart page is shown")]
        public void ThenCartPageIsShown()
        {
            CartPage.CartPageIsShown();
        }

        [Then(@"It has next products with properties")]
        public void ThenItHasNextProductsWithProperties(Table productsProperties)
        {
            CartTable.CheckNameSizeColourAndTotalPriceOfProducts(productsProperties);
        }

        [Then(@"Total price of all products is '(.*)'")]
        public void ThenTotalPriceOfAllProductsIs(Decimal totalPrice)
        {
            CartTable.CheckThatSumOfAllProductsEqualsTotalPrice(totalPrice);
        }

        [When(@"I delete '(.*)' product from cart")]
        public void WhenIDeleteSecondProductFromCart(string productName)
        {
            CartTable.RemoveProductByProductName(productName);
        }

        [Then(@"Only '(.*)' product is displayed")]
        public void ThenOnlyProductIsDisplayed(string productName)
        {
            CartTable.CheckThatCartHasOnlyOneProduct(productName);
        }



    }
}
