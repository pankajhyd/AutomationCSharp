using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Automation_Accelarator.ActionEngine;
using Selenium.Test.TestWorkflows.Android_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Test.TestScripts.Android_App
{
    [TestClass]
    public class HomeBudgetApp : BaseClass
    {
        [TestMethod]
        public void HomeBudgetAppTest()
        {
            string strAppType = "androidapp";
            fnOpenApp(strAppType);
            homeBudgetApp.fnGetSummaryTab();

        }
    }
}
