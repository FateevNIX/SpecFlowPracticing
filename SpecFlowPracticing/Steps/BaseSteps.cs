using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowPracticing.Steps
{
    public class BaseSteps
    {
       public IWebDriver driver = new ChromeDriver();
    }
}
