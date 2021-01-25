using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Blocks;
using SpecFlowPracticing.Utils;
using System.Collections;
using System.Collections.Generic;

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

        [FindsBy(How = How.XPath, Using = "//a[@title='Add to cart']")]
        protected IList<IWebElement> AddToCartButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='product-image-container']")]
        protected IList<IWebElement> ProductImages { get; set; }


        public string GetFirstProductName()
        {
            return FirstProductName.Text;
        }

        public void CheckSearchResultsPageTitle()
        {
            //wait while page is loaded
            Waiter.WaitForElementIsDisplayed(driver, BottomCompareButton);
            Assert.AreEqual(driver.Title, "Search - My Store", "Title is different!");
        }

        public ProductDetailsPage ClickOnMoreButtonForFirstProduct()
        {
            BasePage basePage = new BasePage(driver);
            Waiter.WaitForElementIsDisplayed(driver, FirstProductImage);
            //hover product to make 'More' button visible
            basePage.MouseHover(FirstProductImage, driver);

            Waiter.WaitForElementIsDisplayed(driver, MoreButtonForFirstProduct);

            MoreButtonForFirstProduct.Click();
            return new ProductDetailsPage(driver);
        }

        public void AddAllProductsToCart()
        {
            BasePage basePage = new BasePage(driver);
            AddToCartModal addToCartModal = new AddToCartModal(driver);
                for (int i = 0; i < AddToCartButtons.Count; i++)
                {
                basePage.MouseHover(ProductImages[i], driver);
                Waiter.WaitForElementIsDisplayed(driver, AddToCartButtons[i]);
                AddToCartButtons[i].Click();
                addToCartModal.SuccessfullyAddedModalIsShown();
                if(0 == 0)
                addToCartModal.ClickOnContinueShoppingButton();
                addToCartModal.ClickOnContinueShoppingButton();
            }
        }
    }
}
