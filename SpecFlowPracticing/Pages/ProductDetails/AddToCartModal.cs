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

        private readonly IWebDriver driver;
        public AddToCartModal(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); 
        }


        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        protected IWebElement ProceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@title='Continue shopping']")]
        protected IWebElement ContinueShoppingButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'layer_cart_product')]/h2")]
        protected IWebElement ModalTitle { get; set; }



        public void SuccessfullyAddedModalIsShown(string modalName)
        {
            Waiter.Wait(driver, ProceedToCheckoutButton);
            Assert.AreEqual(modalName, ModalTitle.Text);
        }

        public void ClickOnContinueShoppingButton()
        {
            ContinueShoppingButton.Click();
        }
        public CartPage ClickOnProceedToCheckoutButton()
        {
            ProceedToCheckoutButton.Click();
            return new CartPage(driver);
        }


    }
}
