using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Pages
{
    public class SearchResultsPage
    {

        private IWebDriver driver;
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


        public string getFirstProductName()
        {
            return FirstProductName.Text;
        }

        public void checkSearchResultsPageTitle()
        {
            Assert.AreEqual(driver.Title, "Search - My Store", "Title is different!");
        }

        public ProductDetailsPage clickOnMoreButtonForFirstProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //hover product to make 'More' button visible
            BasePage basePage = new BasePage(driver);
            basePage.MouseHover(FirstProductImage, driver);

            MoreButtonForFirstProduct.Click();
            return new ProductDetailsPage(driver);
        }
    }
}
