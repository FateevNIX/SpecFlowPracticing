using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using SpecFlowPracticing.Utils;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlowPracticing.Blocks;

namespace SpecFlowPracticing.Pages
{
    public class ProductDetailsPage
    {
        private IWebDriver driver;
        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h3")]
        protected IWebElement DataSheetText { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1")]
        protected IWebElement ProductName { get; set; }

        [FindsBy(How = How.Id, Using = "our_price_display")]
        protected IWebElement ProductPrice { get; set; }

        [FindsBy(How = How.Id, Using = "quantity_wanted")]
        protected IWebElement quantityInput { get; set; }

        [FindsBy(How = How.Id, Using = "our_price_display")]
        protected IWebElement sizeDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "Submit")]
        protected IWebElement addToCartButton { get; set; }



        public void ProductDetailsPageIsShown()
        {
            Assert.AreEqual(DataSheetText.Text, "DATA SHEET");
        }

        public void ProductHasNextNameAndPrice(string fullName, string price)
        {
            Assert.AreEqual(ProductName.Text, fullName, $"Name is not equal to {fullName}");
            Assert.AreEqual(ProductPrice.Text.Replace("$", ""), price, $"Price is not equal to {price}");
        }

        private void SelectOptionInDropdown(string optionName)
        {
            sizeDropdown.Click();
            IWebElement option = driver.FindElement(By.XPath($"//option[@title='{optionName}']"));
            Waiter.wait(driver, option);
            option.Click();
        }

        private void SelectProductColour(string colourName)
        {
            driver.FindElement(By.XPath($"//a[@name='{colourName}']")).Click();
        }

        public void SelectQuantitySizeAndColour(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();

            quantityInput.Clear();
            quantityInput.SendKeys(testData.Quantity.ToString());
            SelectOptionInDropdown(testData.Size.ToString());
            SelectProductColour(testData.Colour.ToString());
        }

        public void ClickOnAddToCartButton()
        {
            addToCartButton.Click();
          //  return new AddToCartModal(driver);
        }


    }
}
