using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium.Automation_Accelarator.TestEngine
{
   public class TestEngine
    {
        public IWebDriver driver = null;
        public IWebDriver fnOpenBrowser(string strBrowserName)
        {
            if(strBrowserName.ToLower().Contains("chrome"))
            {
                ChromeOptions chromeopt = new ChromeOptions();
                chromeopt.AcceptInsecureCertificates = true;
                driver = new ChromeDriver(chromeopt);
            }
            else if(strBrowserName.ToLower().Contains("firefox"))
            {
                driver = new FirefoxDriver();
            }
            if(driver!=null)
            {
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10000);
                driver.Manage().Window.Maximize();
                Console.WriteLine(strBrowserName.ToUpper() + " : Browser Started Successfully");
            }
            return driver;
        }
        public void fnCloseBrowser()
        {
            if(driver!=null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
