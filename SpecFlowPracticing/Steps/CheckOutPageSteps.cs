using OpenQA.Selenium;
using SpecFlowPracticing.Pages.CheckOut;

namespace SpecFlowPracticing.Steps
{
    public class CheckOutPageSteps
    {
        private CheckOutPage CheckOutPage { get; }
        public CheckOutPageSteps(IWebDriver driver)
        {
            CheckOutPage = new CheckOutPage(driver);
        }
    }
}
