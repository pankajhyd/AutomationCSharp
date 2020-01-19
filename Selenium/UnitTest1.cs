using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System.Threading;
using System.IO;
using System.Configuration;
using Selenium.Automation_Accelarator.Utilities;

namespace Selenium
{
    [TestClass]
    public class UnitTest1
    {
        AppiumLocalService service = null;
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Window.Maximize();
            driver.Quit();

        }

        [TestMethod]
        public void AppiumTest()
        {
            string strAppActivity = "com.siri.budgetdemo.Home";
            string strAppPackage = "com.siri.budgetdemo";
            string strDeviceOS = "5.1.1";
            string strDeviceName= "e42bceae";
            string strAppiumURL = "http://localhost:4723/wd/hub";
            fnStartAppiumServer();
            //AndroidDriver<AndroidElement> driver;
            RemoteWebDriver driver;
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, strDeviceOS);
            options.AddAdditionalCapability("deviceName", strDeviceName);
            options.AddAdditionalCapability("appPackage", strAppPackage);
            options.AddAdditionalCapability("appActivity", strAppActivity);
            options.AddAdditionalCapability("–session-override", true);
            driver = new AndroidDriver<AndroidElement>(new Uri(strAppiumURL), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            Console.WriteLine("Test Appium");
            Console.WriteLine(driver.PageSource);
            driver.FindElement(By.Id("com.siri.budgetdemo:id/menu_summary")).Click();
           // driver.Close();
            driver.Quit();
            fnStopAppiumServer();
            fnStopAppiumServer();
        }

        [TestMethod]
        public void AppiumTestChrome()
        {
            Console.WriteLine(ReadConfig.fnReadTestEngineConfig("DeviceName"));
            Console.WriteLine(ReadConfig.fnReadTestEngineConfig("DeviceOSVersion"));
            Console.WriteLine(ReadConfig.fnReadTestEngineConfig("AppPackage"));
            Console.WriteLine(ReadConfig.fnReadTestEngineConfig("AppActivity"));
            Console.WriteLine(ReadConfig.fnReadTestEngineConfig("AppiumURL"));
            string strDeviceOS = "5.1.1";
            string strDeviceName = "e42bceae";
            string strAppiumURL = "http://localhost:4723/wd/hub";
            string sreChromeDriverPath = @"E:\Automation\APK_Test\chromedriver.exe";
            fnStartAppiumServer();
            //AndroidDriver<AndroidElement> driver;
            RemoteWebDriver driver;
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
            options.AddAdditionalCapability(MobileCapabilityType.BrowserName, MobileBrowserType.Chrome);
            options.AddAdditionalCapability("chromedriverExecutable", sreChromeDriverPath);
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, strDeviceOS);
            options.AddAdditionalCapability("deviceName", strDeviceName);
           // options.AddAdditionalCapability("appPackage", strAppPackage);
           // options.AddAdditionalCapability("appActivity", strAppActivity);
            options.AddAdditionalCapability("–session-override", true);
            driver = new AndroidDriver<AndroidElement>(new Uri(strAppiumURL), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            Console.WriteLine("Test Appium");
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            Thread.Sleep(10000);
            Console.WriteLine(driver.PageSource);
            By search = By.XPath(".//*[@id='container']/div/div[1]/div[1]/div[2]/div[2]/div/div[2]/a/input");
            driver.FindElement(search).SendKeys("Laptop");
            Thread.Sleep(10000);
            driver.Close();
            driver.Quit();
            fnStopAppiumServer();
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
            catch(Exception e)
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
                if(service!=null)
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
