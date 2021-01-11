using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowPracticing
{
    [Binding]
    public sealed class TestFixture : Steps.BaseSteps
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public void BeforeScenario()
        {
            //разобратся почему созданный тут драйвер не передается в StepDefinition методы
          //  driver = new ChromeDriver();
            Console.WriteLine("Понеслась");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //driver.Quit();
            Console.WriteLine("Конец");
        }

      
    }
}
