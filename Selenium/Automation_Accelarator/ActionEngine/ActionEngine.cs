using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Automation_Accelarator.TestEngine;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace Selenium.Automation_Accelarator.ActionEngine
{
    public class ActionEngine:TestEngine.TestEngine
    {
        public static IWebDriver driver = null;
        public void fnOpenURL(String strAppType,String strURL)
        {
            ActionEngine.driver= fnGetDriver(strAppType);
            ActionEngine.driver.Navigate().GoToUrl(strURL);
            Console.WriteLine("URL ==> " + strURL + "  Open Successfully");
        }

        public void fnOpenApp(String strAppType)
        {
            ActionEngine.driver = fnGetDriver(strAppType);          
        }

        public bool fnClick(By loc,string strLocatorName)
        {
            bool blnStatus = true;
            try
            {
                ActionEngine.driver.FindElement(loc).Click();
                Console.WriteLine("Click Sucessfully Done on " + strLocatorName + " using locator ==> "+ loc.ToString());
            }
            catch(Exception e)
            {
                blnStatus = false;
                Console.WriteLine("Unable to Click on " + strLocatorName + " using locator ==> " + loc.ToString());
                Console.WriteLine(e.StackTrace);
            }
            return blnStatus;
        }
    }
}
