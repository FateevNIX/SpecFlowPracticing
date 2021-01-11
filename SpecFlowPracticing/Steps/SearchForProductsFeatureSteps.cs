using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPracticing.Steps
{
    [Binding]
    public class SearchForProductsFeatureSteps : BaseSteps
    {
       
        [Given(@"I navigate to the Home page")]
        public void GivenINavigateToTheHomePage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/");
        }
        
        [When(@"I enter the (.*) into search input")]
        public void WhenIEnterTheProductNameIntoSearchInput(string productName)
        {
           driver.FindElement(By.Id("search_query_top")).SendKeys(productName);

            //все что ниже в степе, пока просто примеры работы c ScenarioContext
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

            //сохраняем в Scenario Context
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

            //Выводит тайтл самого сценария
            Console.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);

            //Выводит тип блока 
            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
        }
        
        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            driver.FindElement(By.Name("submit_search")).Click();
        }
        
        [Then(@"The search result page is shown")]
        public void ThenTheSearchResultPageIsShown()
        {
            Assert.AreEqual(driver.Title, "Search - My Store", "Title is different!");
        }
        
        [Then(@"Results contains (.*)")]
        public void ThenResultsContainsProductName(string productName)
        {
            Assert.That(driver.FindElement(By.XPath("//div[@class='product-container']//a[@class='product-name']")).Text, 
                Contains.Substring(productName), 
                $"There is no '{productName}' in first search result");
        }

        [When(@"I click on More button for first product")]
        public void WhenIClickOnButtonForFirstProduct()
        {
            driver.FindElement(By.XPath("//a[@title='View']")).Click();
        }

        [Then(@"Product details page is shown")]
        public void ThenProductDetailsPageIsShown()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(45)).Until(ExpectedConditions.ElementIsVisible((By.Id("bigpic"))));
            Assert.AreEqual(driver.FindElement(By.XPath("//h3")).Text, "DATA SHEET");
        }

        [Then(@"Product has specific (.*) and (.*)")]
        public void ThenProductHasSpecificBlouseAnd(string fullName, string price)
        {


            // dynamic expectedResults = table.CreateDynamicInstance();
            // Assert.That(driver.FindElement(By.XPath("//h1")).Text.Equals(expectedResults.Name));
            // Assert.AreEqual(driver.FindElement(By.Id("our_price_display")).Text.Replace("$", ""), expectedResults.Price.ToString());

            Assert.That(driver.FindElement(By.XPath("//h1")).Text.Equals(fullName));
                Assert.AreEqual(driver.FindElement(By.Id("our_price_display")).Text.Replace("$",""), price);
      
        }

        //можно задавать условия теста используя теги перед сценарием
        [AfterScenario("tearDown")]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
