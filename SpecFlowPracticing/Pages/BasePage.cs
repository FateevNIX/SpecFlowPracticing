using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using SpecFlowPracticing.Steps;

namespace SpecFlowPracticing.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "search_query_top")]
        protected IWebElement SearchInput { get; set; }

        [FindsBy(How = How.Name, Using = "submit_search")]
        protected IWebElement SubmitButton { get; set; }

        public SearchResultsPage SearchForProduct(string productName)
        { 
            SearchInput.SendKeys(productName);
            SubmitButton.Click();
            return new SearchResultsPage(driver);
        }
        public void MouseHover(IWebElement element, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }
    }
}
