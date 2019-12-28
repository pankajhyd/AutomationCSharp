using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Test.TestWorkflows;
using OpenQA.Selenium;
using Selenium.Automation_Accelarator.ActionEngine;
using Selenium.Automation_Accelarator.TestEngine;
using System.Threading;
namespace Selenium.Test.TestWorkflows
{
    public class InputForm : ActionEngine
    {
        By userMessage = By.Id("user-message");
        By verifyUserMsg = By.Id("display");
        By msgButton = By.XPath(".//*[@id='get-input']/button");
        By edtno1 = By.Id("sum1");
        By edtno2 = By.Id("sum2");
        By total = By.Id("displayvalue");
        By addButton = By.XPath("//*[@id='gettotal']/button");
        By checkBoxAge = By.Id("isAgeSelected");
        By ageVerify = By.Id("txtAge");
        By pannelBody = By.ClassName("panel-body");
        public void fnVerifySimpleFormDemoMessage(string strMessage)
        {
            ActionEngine.driver.FindElement(userMessage).SendKeys(strMessage);
            ActionEngine.driver.FindElement(msgButton).Click();
            string strVerifyMessage = ActionEngine.driver.FindElement(verifyUserMsg).Text;
            Console.WriteLine("Verified Message ==> " + strVerifyMessage);
        }

        public void fnVerifySimpleDemoAdd(string no1, string no2)
        {
            ActionEngine.driver.FindElement(edtno1).SendKeys(no1);
            ActionEngine.driver.FindElement(edtno2).SendKeys(no2);
            ActionEngine.driver.FindElement(addButton).Click();
            string strAddValue = ActionEngine.driver.FindElement(total).Text;
            Console.WriteLine("Answer ==> " + strAddValue);
            long intresult = long.Parse(no1) + long.Parse(no2);
            long result = long.Parse(strAddValue);
            if (intresult == result)
            {
                Console.WriteLine("Add is working fine Result ==> " + result.ToString());
            }
            else
            {
                Console.WriteLine("Add is not working fine Result ==> " + result.ToString());
            }
        }

        public void fnCheckbox_Demo()
        {
            //Verify CheckBox is not Selected
            Boolean blnStatus = driver.FindElement(checkBoxAge).Selected;
            if (blnStatus == false)
            {
                Console.WriteLine("Checkbox is not Selected");
            }
            else
            {
                Console.WriteLine("Checkbox is Selected");
            }
            driver.FindElement(checkBoxAge).Click();
            Boolean blnStatusSelected = driver.FindElement(checkBoxAge).Selected;
            if (blnStatusSelected)
            {
                Console.WriteLine("Checkbox is Selected");
            }
            else
            {
                Console.WriteLine("Checkbox is not Selected");
            }
            string strText = driver.FindElement(ageVerify).Text;
            if (strText.Contains("Success - Check box is checked"))
            {
                Console.WriteLine("Checkbox Verify Message is Displayed");
                Console.WriteLine("Message Displayed : " + strText);
            }
            else
            {
                Console.WriteLine("Checkbox is not Selected");
            }
        }
        public void fnCheckbox_DemoSelectAll()
        {
            IWebElement elePanel = driver.FindElements(pannelBody).ElementAt(2);
            IList<IWebElement> eleList = elePanel.FindElements(By.ClassName("checkbox"));
            Console.WriteLine("Total Element Found ==> " + eleList.Count);
            for(int i=0;i<eleList.Count;i++)
            {
                IWebElement element=eleList.ElementAt(i);
                Console.WriteLine("Value Present at ==> " + (i+1)+ "  ==> " + element.Text);
            }
            Console.WriteLine("Checkbox Selection");
            for(int i=0;i<eleList.Count;i++)
            {
                IWebElement element = eleList.ElementAt(i).FindElement(By.TagName("input"));
                element.Click();
                Console.WriteLine(eleList.ElementAt(i).Text + " ==> Clicked Successfully");
            }
            Thread.Sleep(10000);
            Console.WriteLine("Checkbox Un-Selection");
            for(int i=0;i<eleList.Count;i++)
            {
                if (i % 2 == 0)
                {
                    eleList.ElementAt(i).FindElement(By.TagName("input")).Click();
                    Console.WriteLine(eleList.ElementAt(i).Text + " is Un-Selected");
                }
                else
                {
                    Console.WriteLine(eleList.ElementAt(i).Text + " is Selected");
                }
            }
            Thread.Sleep(10000);
            Console.WriteLine("Checkbox Verification");
            for(int i=0;i<eleList.Count;i++)
            {
                Boolean blnStatus = eleList.ElementAt(i).FindElement(By.TagName("input")).Selected;
                if(blnStatus)
                {
                    Console.WriteLine(eleList.ElementAt(i).Text + " is Selected");
                }
                else
                {
                    Console.WriteLine(eleList.ElementAt(i).Text + " is not Selected");
                }
            }


        }
    }
}
