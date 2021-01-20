using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SpecFlowPracticing.Pages.CheckOut
{
    public class PaymentPage
    {
        private readonly IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
