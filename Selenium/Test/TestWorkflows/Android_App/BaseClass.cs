using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Automation_Accelarator.ActionEngine;
using Selenium.Test.TestWorkflows.Android_App;
using OpenQA.Selenium;
namespace Selenium.Test.TestWorkflows.Android_App
{
    public class BaseClass:ActionEngine
    {
         public static HomeBudgetAppWorkflow homeBudgetApp = new HomeBudgetAppWorkflow();
    }
}
