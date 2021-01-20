using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
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
        /*private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;*/

        private readonly IObjectContainer container;

        public BaseHooks(IObjectContainer container)
        {
            this.container = container;
        }

      /*  [BeforeTestRun]
        public static void InitializeReporter()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\fateev\source\repos\SpecFlowPracticing\HtmlReports.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);        
        }

        [AfterStep]
        public void InsertReportingString()
        {
            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        }

        [AfterTestRun]
        public static void TearDownReporter()
        {
            extent.Flush();
        }*/


        [BeforeScenario]
        public void RunBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            
            container.RegisterInstanceAs(driver);
            driver.Manage().Window.Maximize();

      //      scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
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
