using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowPracticing.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private HomePage homePage { get; }
        public HomePageSteps(IWebDriver driver)// : base(driver)
        {
            homePage = new HomePage(driver);
        }

        [Given(@"I navigate to the Home page")]
        public void GivenINavigateToTheHomePage()
        {
           homePage.NavigateToURL("http://automationpractice.com/");
        }

        /*[When(@"I enter the (.*) into search input")]
        public void WhenIEnterTheProductNameIntoSearchInput(string productName)
        {
           driver.FindElement(By.Id("search_query_top")).SendKeys(productName);

            //below is just examples of work of ScenarioContext
            ScenarioContext.Current["InfoForNextStep"] = "Step 2 passed";
            Console.WriteLine(ScenarioContext.Current["InfoForNextStep"].ToString());

            List<ProductDetails> products = new List<ProductDetails>()
            {
                new ProductDetails()
                {
                    Name = "Blouse",
                    Price = 100,
                    Quantity = 2,
                    Size = "M"
                 },
                 new ProductDetails()
                {
                    Name = "Dress",
                    Price = 500,
                    Quantity = 4,
                    Size = "L"
                 }
            };

            //saving in Scenario Context
            ScenarioContext.Current.Add("Products", products);

            //Достаем значение из Scenario Context
            var producList = ScenarioContext.Current.Get<IEnumerable<ProductDetails>>("Products");
            foreach (ProductDetails product in producList)
            {
                Console.WriteLine("Product Name is: " + product.Name);
                Console.WriteLine("Product Price is: " + product.Price);
                Console.WriteLine("Product Quantity is: " + product.Quantity);
                Console.WriteLine("Product Size is: " + product.Size);
            }

            //var productDetails = tab

            //get title of the scenario
            Console.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);

            //shows block type
            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
        }*/
       
       /* 

        

        [AfterScenario("tearDown")]
        public void TearDown()
        {
            driver.Quit();
        }*/

    }
}
