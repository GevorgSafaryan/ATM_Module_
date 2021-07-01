using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Implementation.WebDriver
{
    public class Configuration
    {
        public static string GetConfigs(string configKey, string defaultValue)
        {
            return ConfigurationManager.AppSettings[configKey] ?? defaultValue;
        }

        public static string Browser => GetConfigs("browser", "Chrome");
        public static string URL => GetConfigs("url", "https://mail.ru/");
    }
}
