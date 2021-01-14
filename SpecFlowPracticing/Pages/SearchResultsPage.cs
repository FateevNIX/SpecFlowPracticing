using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Pages
{
    public class SearchResultsPage
    {

        private readonly IWebDriver driver;
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='product-container']//a[@class='product-name']")]
        protected IWebElement FirstProductName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='product-image-container']")]
        protected IWebElement FirstProductImage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='View']")]
        protected IWebElement MoreButtonForFirstProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'bottom-pagination')]//form[@method='post']")]
        protected IWebElement BottomCompareButton { get; set; }
        
        public string GetFirstProductName()
        {
            return FirstProductName.Text;
        }

        public void CheckSearchResultsPageTitle()
        {
            //wait while page is loaded
            Waiter.Wait(driver, BottomCompareButton);
            Assert.AreEqual(driver.Title, "Search - My Store", "Title is different!");
        }

        public ProductDetailsPage ClickOnMoreButtonForFirstProduct()
        {          
            BasePage basePage = new BasePage(driver);
            Waiter.Wait(driver, FirstProductImage);
            //hover product to make 'More' button visible
            basePage.MouseHover(FirstProductImage, driver);

            Waiter.Wait(driver, MoreButtonForFirstProduct);

            MoreButtonForFirstProduct.Click();
            return new ProductDetailsPage(driver);
        }
    }
}
