using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Test.TestWorkflows;
using OpenQA.Selenium;

namespace Selenium.Test.TestWorkflows
{
   public class InputForm:BaseClass
   {
        By userMessage = By.Id("user-message");
        By verifyUserMsg = By.Id("display");
        By msgButton = By.XPath("//*[@id='get - input']/button");


        public void fnVerifySimpleFormDemoMessage(string strMessage)
        {
            driver.FindElement(userMessage).SendKeys(strMessage);
            driver.FindElement(msgButton).Click();
            string strVerifyMessage = driver.FindElement(verifyUserMsg).Text;
            Console.WriteLine("Verified Message ==> " + strVerifyMessage);
        }


   }
}
