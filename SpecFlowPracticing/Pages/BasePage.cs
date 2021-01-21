using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using SpecFlowPracticing.Steps;
using NUnit.Framework;

namespace SpecFlowPracticing.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "search_query_top")]
        protected IWebElement SearchInput { get; set; }

        [FindsBy(How = How.Name, Using = "submit_search")]
        protected IWebElement SubmitSearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a/span[contains(@class,'cart_quantity')]")]
        protected IWebElement QuantityOfProductsInCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        protected IWebElement ProceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@title='Continue shopping']")]
        protected IWebElement ContinueShoppingButton { get; set; }

        public SearchResultsPage SearchForProduct(string productName)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(productName);
            SubmitSearchButton.Click();
            return new SearchResultsPage(driver);
        }
        public void CartShouldHaveSpecificNumberOfProducts(string productQuantity)
        {
            Assert.AreEqual(productQuantity, QuantityOfProductsInCart.Text);
        }
        public void MouseHover(IWebElement element, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public CartPage ClickOnProceedToCheckoutButton()
        {
            ProceedToCheckoutButton.Click();
            return new CartPage(driver);
        }

        public void ClickOnContinueShoppingButton()
        {
            ContinueShoppingButton.Click();
        }
        public IWebElement GetProceedToCheckoutButton()
        {
            return ProceedToCheckoutButton;
        }
    }
}
