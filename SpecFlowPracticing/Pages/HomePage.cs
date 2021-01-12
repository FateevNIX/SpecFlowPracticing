using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowPracticing.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
      
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

      //  public HomePage(IWebDriver driver) : base(driver)  {}

        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

    }
}
