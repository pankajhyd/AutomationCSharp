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
        public void fnOpenURL(String strBrowser,String strURL)
        {
            fnOpenBrowser(strBrowser);
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl(strURL);
        }
    }
}
