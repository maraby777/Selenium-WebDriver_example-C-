using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver_example_C_
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public enum BrowserEnum
        {
            CHROME,
            IE,
            FIREFOX,
            FIREFOX_49_ABOVE, //v.45
            FIREFOX_NIGHTLY,
            FIREFOX_ESR
        }

        public IWebDriver GetDriver(BrowserEnum browser)
        {
            switch (browser)
            {
                case BrowserEnum.CHROME:
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                        options.AddArgument("start-maximized");
                        driver = new ChromeDriver(options);
                    }
                    break;

                case BrowserEnum.FIREFOX:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
                        driver = new FirefoxDriver(options);
                    }
                    break;

                case BrowserEnum.IE:
                    {
                        InternetExplorerOptions options = new InternetExplorerOptions();
                        options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
                        driver = new InternetExplorerDriver(options);
                    }
                    break;

                case BrowserEnum.FIREFOX_49_ABOVE:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
                        driver = new FirefoxDriver(options);
                    }
                    break;

                case BrowserEnum.FIREFOX_NIGHTLY:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe";
                        driver = new FirefoxDriver(options);
                    }
                    break;
            }
            return driver;
        }

        [SetUp]
        public void Start()
        {
            driver = GetDriver(BrowserEnum.CHROME);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }

        public void LoginAsAdmin(string url)
        {
            driver.Url = url;
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".notice.success")));
        }

        public void LoginAsUser(string url)
        {
            driver.Url = url;
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
        }
    }
}
