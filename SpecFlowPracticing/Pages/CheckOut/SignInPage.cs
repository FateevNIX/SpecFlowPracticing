using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static SpecFlowPracticing.TestData.SignInPageConstants;
using SpecFlowPracticing.Utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlowPracticing.TestData;

namespace SpecFlowPracticing.Pages.CheckOut
{
   public class SignInPage
    {
        private readonly IWebDriver driver;
        private StringGenerator generator;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }      

        [FindsBy(How = How.Id, Using = "submitAccount")]
        protected IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[@class='page-subheading']")]
        protected IWebElement TableTitle { get; set; }

  
        public void PageShouldBeCreateAnAccount()
        {
            Waiter.WaitForElementIsDisplayed(driver, RegisterButton);
            Assert.AreEqual("YOUR PERSONAL INFORMATION", TableTitle.Text);
        }

        public void ClickOnRegistrationButton()
        {
            RegisterButton.Click();
        }

        public void PageShouldBeMyAccount()
        {
            IWebElement orderHistory = driver.FindElement(By.XPath("//a[@title='Orders']"));
            Waiter.WaitForElementIsDisplayed(driver, orderHistory);
            Assert.AreEqual("MY ACCOUNT", driver.FindElement(By.XPath("//h1[@class='page-heading']")).Text);
        }

        public void FillInAllRequiredFields(Table data)
        {
            dynamic testData = data.CreateDynamicInstance();
            SelectGender(testData.Gender);
            GetInputFieldById(CUSTOMER_FIRST_NAME).SendKeys(testData.FirstName);
            GetInputFieldById(CUSTOMER_LAST_NAME).SendKeys(testData.LastName);
            GetInputFieldById(EMAIL).Clear();
            GetInputFieldById(EMAIL).SendKeys(StringGenerator.RandomString());
            GetInputFieldById(PASSWORD).SendKeys(testData.Password);
            SelectOptionInDropdown(DATE_DAYS, testData.DayOfBirth.ToString());
            SelectOptionInDropdown(DATE_MONTHS, testData.MonthOfBirth.ToString());
            SelectOptionInDropdown(DATE_YEARS, testData.YearOfBirth.ToString());
            GetInputFieldById(FIRST_NAME).Clear();
            GetInputFieldById(FIRST_NAME).SendKeys(testData.AdressFirstName);
            GetInputFieldById(LAST_NAME).Clear();
            GetInputFieldById(LAST_NAME).SendKeys(testData.AdressLastName);
            GetInputFieldById(ADRESS_1).SendKeys(testData.Adress);
            GetInputFieldById(CITY).SendKeys(testData.City);
            SelectOptionInDropdown(STATE, testData.State);
            GetInputFieldById(POSTAL_CODE).SendKeys(testData.ZipCode.ToString());
            GetInputFieldById(MOBILE_PHONE).SendKeys(testData.Phone.ToString());
        }

        private void SelectGender(string gender)
        {
            if (gender == "Mr.")
                GetGenderRadioButtonByValue(MALE_GENDER).Click();
            else if(gender == "Mrs.")
                GetGenderRadioButtonByValue(FEMALE_GENDER).Click();
            else
                System.Console.WriteLine($"There is no {gender} gender.");
        }

        private void SelectOptionInDropdown(string dropdownId, string option)
        {
            GetDropdownById(dropdownId).Click();
            GetDropdownById(dropdownId).FindElement(By.XPath($"//option[@value='{option}' or contains(text(),'{option}')]")).Click();
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
