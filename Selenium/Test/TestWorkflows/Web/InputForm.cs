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
using OpenQA.Selenium.Support.UI;
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
        By groupSex = By.XPath(".//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[1]");
        By groupAge = By.XPath("//*[@id='easycont']/div/div[2]/div[2]/div[2]/div[2]");
        By comboDemo = By.Id("select-demo");
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

        public void fnRadio_Buttons_Demo()
        {
            IWebElement element = driver.FindElements(pannelBody).ElementAt(1);
            IList<IWebElement> eleList = element.FindElements(By.ClassName("radio-inline"));
            Console.WriteLine("Total Radio Button Available ==> " + eleList.Count);
            for (int i=0;i<eleList.Count;i++)
            {
                Console.WriteLine("Element at " + (i + 1) +" ==> " + eleList.ElementAt(i).Text);
            }
            Console.WriteLine("Select Male");
            eleList.ElementAt(0).Click();
            Thread.Sleep(10000);
            Boolean blnStatus = eleList.ElementAt(0).FindElement(By.TagName("input")).Selected;
            if(blnStatus)
            {
                Console.WriteLine("Male is Selected");
            }
            else
            {
                Console.WriteLine("Male is not Selected");
            }
            Console.WriteLine("Select Female");
            eleList.ElementAt(1).Click();
            Boolean blnStatus1 = eleList.ElementAt(1).FindElement(By.TagName("input")).Selected;
            if (blnStatus1)
            {
                Console.WriteLine("Female is Selected");
            }
            else
            {
                Console.WriteLine("Female is not Selected");
            }
            Console.WriteLine("Group Radio Button");
            IList<IWebElement> elementGroup = driver.FindElement(groupSex).FindElements(By.ClassName("radio-inline"));
            Console.WriteLine("Total Gender Found ==> " + elementGroup.Count);
            for(int i=0;i<elementGroup.Count;i++)
            {
                Console.WriteLine("Element " + (i+1) +"  => " + elementGroup.ElementAt(i).Text);
            }
            Console.WriteLine("Select Male from gender Grpoup");
            elementGroup.ElementAt(0).Click();
            Boolean blnGroupSex = elementGroup.ElementAt(0).FindElement(By.TagName("input")).Selected;
            if (blnGroupSex)
            {
                Console.WriteLine("Male is Selected");
            }
            else
            {
                Console.WriteLine("Male is not Selected");
            }
            IList<IWebElement> eleAge = driver.FindElement(groupAge).FindElements(By.ClassName("radio-inline"));
            Console.WriteLine("Total Age Group Found ==> " + eleAge.Count);
            for(int i=0;i<eleAge.Count;i++)
            {
                Console.WriteLine("Age Goup ==> " + (i + 1) + "  ==> " +eleAge.ElementAt(i).Text);
            }
            Console.WriteLine("Select 5-15");
            eleAge.ElementAt(1).Click();
            Boolean blnStausAge = eleAge.ElementAt(1).FindElement(By.TagName("input")).Selected;
            if (blnStausAge)
            {
                Console.WriteLine("5-15 is Selected");
            }
            else
            {
                Console.WriteLine("5-15 is not Selected");
            }
            Thread.Sleep(10000);
        }

        public void fnSelect_Dropdown_List()
        {
            IWebElement element = driver.FindElement(comboDemo);
            SelectElement objSelect = new SelectElement(element);
            IList<IWebElement> eleList = objSelect.Options;
            Console.WriteLine("Total Option Found ==> " + eleList.Count);
            for(int i=0;i<eleList.Count;i++)
            {
                Console.WriteLine(eleList.ElementAt(i).Text);
            }
            Console.WriteLine("Select By Value");
            objSelect.SelectByText("Monday");
            string strText = objSelect.SelectedOption.Text;
            Console.WriteLine("Selected Option ==> " + strText);
            Console.WriteLine("Selected By Index");
            objSelect.SelectByIndex(4);
            strText = objSelect.SelectedOption.Text;
            Console.WriteLine("Selected Option ==> " + strText);
            Console.WriteLine("Selected By Value");
            objSelect.SelectByValue("Saturday");
            strText = objSelect.SelectedOption.Text;
            Console.WriteLine("Selected Option ==> " + strText);
            strText = objSelect.IsMultiple.ToString();
            Console.WriteLine("Selected Option ==> " + strText);
        }

    }
}
