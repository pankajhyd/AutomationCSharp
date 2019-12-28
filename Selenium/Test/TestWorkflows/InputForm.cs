using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Test.TestWorkflows;
using OpenQA.Selenium;
using Selenium.Automation_Accelarator.ActionEngine;
using Selenium.Automation_Accelarator.TestEngine;

namespace Selenium.Test.TestWorkflows
{
   public class InputForm:ActionEngine
   {
        By userMessage = By.Id("user-message");
        By verifyUserMsg = By.Id("display");
        By msgButton = By.XPath(".//*[@id='get-input']/button");
        By edtno1 = By.Id("sum1");
        By edtno2 = By.Id("sum2");
        By total = By.Id("displayvalue");
        By addButton = By.XPath("//*[@id='gettotal']/button");

        public void fnVerifySimpleFormDemoMessage(string strMessage)
        {
            ActionEngine.driver.FindElement(userMessage).SendKeys(strMessage);
            ActionEngine.driver.FindElement(msgButton).Click();
            string strVerifyMessage = ActionEngine.driver.FindElement(verifyUserMsg).Text;
            Console.WriteLine("Verified Message ==> " + strVerifyMessage);
        }

        public void fnVerifySimpleDemoAdd(string no1,string no2)
        {
            ActionEngine.driver.FindElement(edtno1).SendKeys(no1);
            ActionEngine.driver.FindElement(edtno2).SendKeys(no2);
            ActionEngine.driver.FindElement(addButton).Click();
            string strAddValue = ActionEngine.driver.FindElement(total).Text;
            Console.WriteLine("Answer ==> " + strAddValue);
            long intresult= long.Parse(no1) + long.Parse(no2);
            long result = long.Parse(strAddValue);
            if(intresult==result)
            {
                Console.WriteLine("Add is working fine Result ==> " + result.ToString());
            }
            else
            {
                Console.WriteLine("Add is not working fine Result ==> " + result.ToString());
            }
        }

   }
}
