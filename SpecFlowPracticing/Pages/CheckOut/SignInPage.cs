using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticing.TestData;
using SpecFlowPracticing.Utils;

namespace SpecFlowPracticing.Pages.CheckOut
{
    class SignInPage
    {
        SignInPageConstants constant;
        private readonly IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email_create")]
        protected IWebElement EmailAdressInput { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        protected IWebElement CreateAnAccountButton { get; set; }

        public void EnterAndSubmitNewEmail(string email)
        {
            EmailAdressInput.SendKeys(email);
            CreateAnAccountButton.Click();
            Waiter.WaitForElementIsDisplayed(driver, GetInputFieldById(constant.CUSTOMER_FIRST_NAME));
        }

        private void SelectGender(string gender)
        {
            if (gender == "Mr.")
                GetGenderRadioButtonByValue(constant.MALE_GENDER).Click();
            else if(gender == "Mrs.")
                GetGenderRadioButtonByValue(constant.FEMALE_GENDER).Click();
            else
                System.Console.WriteLine($"There is no {gender} gender.");
        }

        private void SelectOptionInDateOfBirthDropdown(string dropdownId, string option)
        {
            GetDropdownById(dropdownId).Click();
            GetDropdownById(dropdownId).FindElement(By.XPath($"//option[@value='{option}']")).Click();
        }

        private IWebElement GetDropdownById(string dropdownId)
        {
            return driver.FindElement(By.Id($"{dropdownId}"));
        }


        private IWebElement GetInputFieldById(string fieldId)
        {
            return driver.FindElement(By.Id($"{fieldId}"));
        }

        private IWebElement GetGenderRadioButtonByValue(string genderValue)
        {
            return driver.FindElement(By.XPath($"//input[@name='id_gender' and @value='{genderValue}']"));
        }
    }
}
