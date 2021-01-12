using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

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


        public void ProductDetailsPageIsShown()
        {
            //   new WebDriverWait(driver, TimeSpan.FromSeconds(45)).Until(ExpectedConditions.ElementIsVisible((By.Id("bigpic"))));
            Assert.AreEqual(DataSheetText.Text, "DATA SHEET");
        }

        public void ProductHasNextNameAndPrice(string fullName, string price)
        {
            // dynamic expectedResults = table.CreateDynamicInstance();
            // Assert.That(driver.FindElement(By.XPath("//h1")).Text.Equals(expectedResults.Name));
            // Assert.AreEqual(driver.FindElement(By.Id("our_price_display")).Text.Replace("$", ""), expectedResults.Price.ToString());

            Assert.AreEqual(ProductName.Text, fullName, $"Name is not equal to {fullName}");
            Assert.AreEqual(ProductPrice.Text.Replace("$", ""), price, $"Price is not equal to {price}");

        }


    }
}
