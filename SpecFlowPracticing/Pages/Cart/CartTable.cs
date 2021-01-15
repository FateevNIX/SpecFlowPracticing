using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPracticing.Blocks.CartBlocks
{
    [Binding]
    public class CartTable
    {
        private readonly IWebDriver driver;
        public CartTable(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//td[@class='cart_unit']/span/span")]
        protected IList<IWebElement> UnitPrices { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[contains(@class,'cart_item')]")]
        protected IList<IWebElement> TableRows { get; set; }


        public void CheckThatSumOfAllProductsEqualsTotalPrice(Decimal expectedTotalPrice)
        {
            //without numberFormatinfo while parsing decimal method throws System.FormatException "Input string was not in a correct format."
            var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
            decimal actualTotalPrice = 0;
            for (int i = 0; i < UnitPrices.Count; i++)
            {
                actualTotalPrice +=  Decimal.Parse(UnitPrices[i].Text.Replace("$", ""), numberFormatInfo);
            }

            Assert.AreEqual(expectedTotalPrice, actualTotalPrice, $"Expected sum is {expectedTotalPrice}, but was {actualTotalPrice}");
        }

        public void RemoveProductByProductName(string productName)
        {
            ClickOnDeleteButtonForProduct(productName);
            Waiter.WaitForElementIsNotDisplayed(driver, GetTableRowByProductName(productName));
        }

        public void CheckThatCartHasOnlyOneProduct(string productName)
        {
            Assert.AreEqual(TableRows.Count, 1);
            Assert.AreEqual(productName, GetProductName(productName), "Product name was not " + productName);
        }

        public void CheckNameSizeColourAndTotalPriceOfProducts(Table table)
        {
            IEnumerable<dynamic> productsData = table.CreateDynamicSet();
            foreach (var data in productsData)
            {
                Assert.AreEqual(data.ProductName, GetProductName(data.ProductName), "Product name was not " + data.ProductName);
                Assert.That(GetColourAndSize(data.ProductName).Contains("Color : " + data.Colour), "Colour doesn't contain " + data.Colour);
                Assert.That(GetColourAndSize(data.ProductName).Contains("Size : " + data.Size), "Size doesn't contain " + data.Size);
                Assert.AreEqual(data.Quantity.ToString(), GetQuantityOfProduct(data.ProductName), "Quantity of product was not " + data.Quantity);
                Assert.AreEqual(data.TotalPrice, GetTotalPrice(data.ProductName), "Total price was not " + data.TotalPrice);

                /* Console.WriteLine(GetProductName(data.ProductName));
                 Console.WriteLine(GetColourAndSize(data.ProductName));
                 Console.WriteLine(GetQuantityOfProduct(data.ProductName));
                 Console.WriteLine(GetTotalPrice(data.ProductName));*/

            }
        }
        private IWebElement GetTableRowByProductName(string productName)
        {
            return driver.FindElement(By.XPath($"//td[@class='cart_description']//a[text()='{productName}']//ancestor::tr"));
        }

        private string GetProductName(string productName)
        {
            return GetTableRowByProductName(productName).FindElement(By.XPath(".//td[@class='cart_description']/p/a")).Text;
        }

        private string GetColourAndSize(string productName)
        {
            return GetTableRowByProductName(productName).FindElement(By.XPath(".//td[@class='cart_description']//small/a")).Text;
        }

        private string GetQuantityOfProduct(string productName)
        {
            return GetTableRowByProductName(productName).FindElement(By.XPath(".//td[contains(@class,'cart_quantity')]/input[@type='text']")).GetAttribute("value");
        }
        private string GetTotalPrice(string productName)
        {
            return GetTableRowByProductName(productName).FindElement(By.XPath(".//td[contains(@class,'cart_total')]/span")).Text.Replace(" ", "");
        }
        private void ClickOnDeleteButtonForProduct(string productName)
        {
            GetTableRowByProductName(productName).FindElement(By.XPath(".//td[contains(@class,'cart_delete')]//i")).Click();
        }

    }
}
