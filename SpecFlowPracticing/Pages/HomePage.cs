using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.Utils;

namespace SpecFlowPracticing.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
      
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@class='homeslider-container']/a[@title='sample-2']")]
        protected IWebElement SecondSliderAdvertise { get; set; }

        //  public HomePage(IWebDriver driver) : base(driver)  {}

        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        //hardcode for one particular xPath
        public void WaitForSecondAdvertismentToAppear()
        {
            Waiter.WaitForElementIsDisplayed(driver, SecondSliderAdvertise);
        }

        //universal method for all similar elements
        private IWebElement GetAdvertisementByNumber(string numberOfAdvertisment)
        {
            return driver.FindElement(By.XPath($"//li[@class='homeslider-container']/a[@title='sample-{numberOfAdvertisment}']"));
        }

        public void WaitForSpecificAdvertisementToAppear(string numberOfAdvertisment)
        {
            Waiter.WaitForElementIsDisplayed(driver, GetAdvertisementByNumber(numberOfAdvertisment));
        }

    }
}
