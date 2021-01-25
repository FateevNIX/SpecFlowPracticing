using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Pages
{
    public class CartPage
    {
        private readonly IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "cart_title")]
        protected IWebElement CartTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkoutbn']")]
        protected IWebElement ProceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@title='Continue shoppingxc']")]
        protected IWebElement ContinueShoppingButton { get; set; }

        public void CartPageIsShown()
        {
            Waiter.WaitForElementIsDisplayed(driver, CartTitle);
            Assert.That(CartTitle.Text.Contains("SHOPPING-CART SUMMARY"));
        }


    }
}
