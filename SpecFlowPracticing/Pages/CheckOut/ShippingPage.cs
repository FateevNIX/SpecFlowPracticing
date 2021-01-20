using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Pages.CheckOut
{
   public class ShippingPage
    {
        private readonly IWebDriver driver;

        public ShippingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
