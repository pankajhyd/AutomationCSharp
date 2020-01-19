using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Automation_Accelarator.Utilities
{
    public class ReadConfig
    {
        public static string fnReadTestEngineConfig(string strConfig)
        {
            var strValue = "";
            try
            {
                var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                var file = Path.Combine(projectFolder, @"Automation_Accelarator\Config\TestConfig.config");
                ExeConfigurationFileMap customConfigFileMap = new ExeConfigurationFileMap();
                customConfigFileMap.ExeConfigFilename = file;
                Configuration customConfig = ConfigurationManager.OpenMappedExeConfiguration(customConfigFileMap, ConfigurationUserLevel.None);
                KeyValueConfigurationCollection confCollection = customConfig.AppSettings.Settings;
                strValue = confCollection[strConfig].Value;

            }
            catch(Exception e) { Console.WriteLine(e.StackTrace); }
            return strValue;
        }

        public static string fngetChromeDriverPath()
        {
            var strValue = "";
            try
            {
                var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                strValue = Path.Combine(projectFolder, @"Automation_Accelarator\Config\Lib\chromedriver.exe");
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            return strValue;
        }
    }
}
