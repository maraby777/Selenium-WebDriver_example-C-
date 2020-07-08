using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_example_C_
{
    [TestFixture]
    public class LeftMenu : TestBase
    {
        [Test]
        public void CheckingTitleInLeftMenu()
        {
            LoginAsAdmin();

            By mainElements = By.CssSelector("ul#box-apps-menu > li");
            By subElements = By.CssSelector("ul#box-apps-menu ul.docs a");
            for (int i = 0; i < driver.FindElements(mainElements).Count(); i++)
            {
                IWebElement item = driver.FindElements(mainElements).ElementAt(i);
                item.Click();
                HeaderPresent();

                if (driver.FindElements(subElements).Count > 0)
                {
                    for (int j = 0; j < driver.FindElements(subElements).Count; j++)
                    {
                        IWebElement subitem = driver.FindElements(subElements).ElementAt(j);
                        HeaderPresent();
                    }

                }

                void HeaderPresent()
                {
                    By header = By.CssSelector("#content > h1");
                    wait.Until(ExpectedConditions.ElementIsVisible(header));
                    Assert.Greater(driver.FindElement(header).Text.Length, 0);
                }
            }
        }
    }
}
