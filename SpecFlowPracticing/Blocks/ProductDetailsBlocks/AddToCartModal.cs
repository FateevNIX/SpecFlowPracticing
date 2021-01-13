using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Pages;
using SpecFlowPracticing.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Blocks
{
    [Binding]
    public class AddToCartModal
    {
        private IWebDriver driver;
        public AddToCartModal(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); 
        }

        [FindsBy(How = How.XPath, Using = ".//a[@title= 'Proceed to checkout']")]
        protected IWebElement proceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@title= 'Continue shopping']")]
        protected IWebElement continueShoppingButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@id='layer_cart']//div[contains(@class,'layer_cart_product')]/h2")]
        protected IWebElement modalTitle { get; set; }

        public void successfullyAddedModalIsShown()
        {
            Waiter.wait(driver, proceedToCheckoutButton);
            Assert.AreEqual(modalTitle.Text, "Product successfully added to your shopping cart");
        }
    }
}
