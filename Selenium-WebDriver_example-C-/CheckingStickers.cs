using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_example_C_
{
    [TestFixture]
    public class CheckingStickers : TestBase
    {
        [Test]
        public void CheckingStickersOnProdukt()
        {
            LoginAsUser();

            for (int i = 0; i < driver.FindElements(By.CssSelector("li.product")).Count; i++)
            { 
                Assert.AreEqual(driver.FindElements(By.CssSelector("li.product"))
                    .ElementAt(i)
                    .FindElements(By.CssSelector("div.sticker")).Count, 1);
            }
        }
    }
}
