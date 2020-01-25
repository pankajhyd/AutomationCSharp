using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using Selenium.Automation_Accelarator.Utilities;
using System.Threading;

namespace Selenium.Automation_Accelarator.TestEngine
{
   public class TestEngine
    {
        public RemoteWebDriver driver = null;
        AppiumLocalService service = null;
        public IWebDriver fnGetDriver(string strAppType)
        {
            if(strAppType.ToLower().StartsWith("chrome"))
            {
                ChromeOptions chromeopt = new ChromeOptions();
                chromeopt.AcceptInsecureCertificates = true;
                driver = new ChromeDriver(chromeopt);
            }
            else if(strAppType.ToLower().StartsWith("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if(strAppType.ToLower().StartsWith("androidchrome"))
            {
                fnStartAppiumServer();
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                options.AddAdditionalCapability(MobileCapabilityType.BrowserName, MobileBrowserType.Chrome);
                options.AddAdditionalCapability("chromedriverExecutable", ReadConfig.fngetChromeDriverPath().ToString());
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, ReadConfig.fnReadTestEngineConfig("DeviceOSVersion").ToString());
                options.AddAdditionalCapability("deviceName", ReadConfig.fnReadTestEngineConfig("DeviceName").ToString());
                options.AddAdditionalCapability("–session-override", true);
                driver = new AndroidDriver<AndroidElement>(new Uri(ReadConfig.fnReadTestEngineConfig("AppiumURL")), options);
                Thread.Sleep(10000);
            }
            else if (strAppType.ToLower().StartsWith("androidapp"))
            {
                fnStartAppiumServer();
                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, ReadConfig.fnReadTestEngineConfig("DeviceOSVersion"));
                options.AddAdditionalCapability("deviceName", ReadConfig.fnReadTestEngineConfig("DeviceName"));
                options.AddAdditionalCapability("–session-override", true);
                options.AddAdditionalCapability("appPackage", ReadConfig.fnReadTestEngineConfig("AppPackage"));
                options.AddAdditionalCapability("appActivity", ReadConfig.fnReadTestEngineConfig("AppActivity"));
                driver = new AndroidDriver<AndroidElement>(new Uri(ReadConfig.fnReadTestEngineConfig("AppiumURL")), options);
                Thread.Sleep(10000);
            }
            if (driver!=null)
            {
                driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10000);
                if(strAppType.ToLower().StartsWith("chrome") || strAppType.ToLower().StartsWith("firefox"))
                {
                    driver.Manage().Window.Maximize();
                }
                Console.WriteLine(strAppType.ToUpper() + " : Started Successfully");
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

        public bool fnStartAppiumServer()
        {
            bool blnStatus = true;
            try
            {
                OptionCollector args = new OptionCollector().AddArguments(GeneralOptionList.LogNoColors());
                Environment.SetEnvironmentVariable(AppiumServiceConstants.NodeBinaryPath, @"C:\Program Files\nodejs\node.exe");
                Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, @"C:\Users\admin\AppData\Roaming\npm\node_modules\appium\build\lib\main.js");
                service = new AppiumServiceBuilder().UsingPort(4723).WithArguments(args).Build();
                service.Start();
                Console.WriteLine("Appium Server Started at ==> " + service.ServiceUrl);               
            }
            catch (Exception e)
            {
                blnStatus = false;
                Console.WriteLine(e.StackTrace);
            }
            return blnStatus;
        }

        public bool fnStopAppiumServer()
        {
            bool blnStatus = true;
            try
            {
                if (service != null)
                {
                    service.Dispose();
                }
            }
            catch (Exception e)
            {
                blnStatus = false;
                Console.WriteLine(e.StackTrace);
            }
            return blnStatus;
        }


    }
}
