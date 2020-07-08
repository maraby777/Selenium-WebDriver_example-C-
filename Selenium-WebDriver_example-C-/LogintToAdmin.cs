using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_example_C_
{
    [TestFixture]
    public class LogintToAdmin
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            ////Run IE
            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            //driver = new InternetExplorerDriver(options);

            ////Run Chrome
            //ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            //options.AddArgument("start-maximized");
            //driver = new ChromeDriver(options);

            //Run FF v.49+
            //FirefoxOptions options = new FirefoxOptions();
            //options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            //driver = new FirefoxDriver(options);

            ////Run FF ESR v.45
            //FirefoxOptions options = new FirefoxOptions();
            //options.UseLegacyImplementation = true;
            //driver = new FirefoxDriver(options);

            //Run FF Nightly
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe";
            driver = new FirefoxDriver(options);


        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestMethod1()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
