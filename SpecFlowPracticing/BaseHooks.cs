using BoDi;
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
    public class BaseHooks
    {
        private readonly IObjectContainer container;

        public BaseHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            
            container.RegisterInstanceAs(driver);
            driver.Manage().Window.Maximize();
           // ScenarioContext.Current.Add("currentDriver", driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
           
            IWebDriver driver = container.Resolve<IWebDriver>();
           // driver.Quit();
            driver.Close();
            driver.Dispose();
        }


    }
}
