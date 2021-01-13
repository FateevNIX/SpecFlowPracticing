using OpenQA.Selenium;
using SpecFlowPracticing.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
   public class CartPageSteps
    {
        private CartPage CartPage { get; }
        public CartPageSteps(IWebDriver driver)
        {
            CartPage = new CartPage(driver);
        }
    }
}
