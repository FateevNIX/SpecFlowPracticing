
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecFlowPracticing.Utils
{
    public class Waiter
    {
        public static void Wait(IWebDriver driver, IWebElement element)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromMinutes(1);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
