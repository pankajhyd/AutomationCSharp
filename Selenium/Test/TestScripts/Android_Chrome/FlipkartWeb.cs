using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Automation_Accelarator.ActionEngine;

namespace Selenium.Test.TestScripts.Android_Chrome
{
    [TestClass]
    public class FlipkartWeb : ActionEngine
    {
        [TestMethod]
        public void fnFlipKart()
        {
            string strBrowser = "androidchrome";
            string strURL = "https://www.flipkart.com/";            
            fnOpenURL(strBrowser, strURL);

        }
    }
}
