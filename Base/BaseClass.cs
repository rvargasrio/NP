using FluentAssertions;
using OpenQA.Selenium;
using System;

using System.Threading;

namespace Base
{
    public class BaseClass
    {
        readonly WebDriver driver = new WebDriver();

        public void OpenUrl(string url)
        {
            driver.Current.Navigate().GoToUrl(url);
        }

        public void SetText(By by, string text)
        {
            driver.Current.FindElement(by).SendKeys(text);
        }

        public void Click(By by)
        {
            driver.Current.FindElement(by).Click();
        }

        public String GetText(By by)
        {
            return driver.Current.FindElement(by).Text;
        }

        public void WaitElement(By by, int time)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver.Current, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void SendTabKey(By by)
        {
            driver.Current.FindElement(by).SendKeys(Keys.Tab);
        }

        public void AssertTextEquals(By by, string text)
        {
            string element = driver.Current.FindElement(by).Text;
            element.Should().Be(text);
        }

        public void AssertTextContains(By by, string text)
        {
            string element = driver.Current.FindElement(by).Text;
            element.Should().Contain(text);
        }

        public void ValidarCidadeResultadoBuscaMedicos(string text)
        {
            Thread.Sleep(3000);
            int i;
            for (i = 1; i <= 100; i++)
            {
                try
                {
                    string element = driver.Current.FindElement(By.XPath("(//p[text()=' - Tel.: '])[" + i + "]")).Text;
                    element.Should().NotContain(text);
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    return;
                }
            }
        }

        public void Dispose()
        {
            driver.Current.Close();
            driver.Current.Dispose();
        }
    }
}
