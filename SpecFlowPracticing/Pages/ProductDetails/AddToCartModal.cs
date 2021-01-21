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

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'layer_cart_product')]/h2")]
        protected IWebElement ModalTitle { get; set; }

        public void SuccessfullyAddedModalIsShown()
        {
            BasePage page = new BasePage(driver);
            Waiter.WaitForElementIsDisplayed(driver, page.GetProceedToCheckoutButton());
            Assert.AreEqual("Product successfully added to your shopping cart", ModalTitle.Text);
        }
    }
}
