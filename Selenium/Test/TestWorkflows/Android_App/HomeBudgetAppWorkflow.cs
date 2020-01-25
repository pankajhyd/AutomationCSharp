using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.TestWorkflows.Android_App
{
    public class HomeBudgetAppWorkflow:BaseClass
    {
        By summaryTab = By.Id("com.siri.budgetdemo:id/menu_summary");
        public void fnGetSummaryTab()
        {
            fnClick(summaryTab, "Summary Tab");
        }
    }
}
