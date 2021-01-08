using SpecFlowPracticing.Steps;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPracticing
{
    [Binding]
    public class SimpleFeatureSteps
    {
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            Console.WriteLine(number);
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            Console.WriteLine(number);
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("Two numbers are added!");
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if (result == 121)
                Console.WriteLine("The test is passed");
            else
            {
                Console.WriteLine("Test is failed!");
                throw new Exception ("Value is different!");
            }
        }

        [Given(@"I navigate to the home page")]
        public void GivenINavigateToTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I typed ""(.*)"" into search field")]
        public void WhenITypedIntoSearchField(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Product is displayed among others")]
        public void ThenProductIsDisplayedAmongOthers(Table table)
        {
          ProductDetails product = table.CreateInstance<ProductDetails>();
        }

    }
}
