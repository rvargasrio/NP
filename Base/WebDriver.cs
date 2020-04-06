using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Base
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver == null)
                {
                    _currentWebDriver = GetChromeDriver();
                }
                return _currentWebDriver;
            }
        }


        private IWebDriver GetChromeDriver()
        {
            String pathDriver = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("test-type", "incognito", "-disable-popup-blocking", "disable-gpu", "--ignore-certificate-erros");
            chromeOptions.AddArguments("--window-size=1920,1080");
            return new ChromeDriver(pathDriver, chromeOptions);
        }
    }
}
