using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Test.TestWorkflows;
using System.Threading;

namespace Selenium.Test.TestScripts
{
    [TestClass]
    public class InputForms:BaseClass
    {
        string strBrowser = "chrome";
        [TestMethod]
         public void Simple_Form_Demo()
        {
            string strURL = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            fnOpenURL(strBrowser, strURL);
            Thread.Sleep(10000);
            inputform.fnVerifySimpleFormDemoMessage("Sreyash");
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
