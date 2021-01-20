
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecFlowPracticing.Utils
{
    public class Waiter
    {
        public static void WaitForElementToBecomeClickable(IWebDriver driver, IWebElement element)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForElementIsDisplayed(IWebDriver driver, IWebElement element)
        {

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ElementIsVisible(element));

        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }

        public static void WaitForElementIsNotDisplayed(IWebDriver driver, IWebElement element)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ElementIsNotVisible(element));
        }
        private static Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }
    }
}
