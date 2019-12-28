using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Automation_Accelarator.ActionEngine;
using Selenium.Automation_Accelarator.TestEngine;
using Selenium.Test.TestWorkflows;
using System.Threading;

namespace Selenium.Test.TestScripts
{
    [TestClass]
    public class InputForms:ActionEngine
    {
        string strBrowser = "firefox";
        [TestMethod]
         public void Simple_Form_Demo()
        {
            string strURL = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            fnOpenURL(strBrowser, strURL);
            BaseClass.inputform.fnVerifySimpleFormDemoMessage("Sreyash");
            BaseClass.inputform.fnVerifySimpleDemoAdd("5", "8");
            fnCloseBrowser();
        }
        [TestMethod]
        public void Checkbox_Demo()
        {
        }
        [TestMethod]
        public void Radio_Buttons_Demo()
        {
        }
        [TestMethod]
        public void Select_Dropdown_List()
        {
        }
        [TestMethod]
        public void Input_Form_Submit()
        {
        }
        [TestMethod]
        public void Ajax_Form_Submit()
        {
        }
        [TestMethod]
        public void JQuery_Select_Dropdown()
        {
        }

    }
}
