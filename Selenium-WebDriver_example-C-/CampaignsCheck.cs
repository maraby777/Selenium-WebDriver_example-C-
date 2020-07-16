using System;
using System.Collections;
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
    public class CampaignsCheck : TestBase
    {
        [Test]
        public void CheckNameItemInCampaigns()
        {
            LoginAsUser("http://localhost/litecart/en/");

            List<IWebElement> items = driver.FindElements(By.CssSelector("#box-campaigns > div > ul > li")).ToList();
            if (items != null)
            {
                string oldItemName = items[0].FindElement(By.CssSelector("#box-campaigns [title='Yellow Duck'] .name")).Text ;
                string oldRegularePrice = items[0].FindElement(By.CssSelector("#box-campaigns .regular-price")).Text;
                string oldCampaignPrice = items[0].FindElement(By.CssSelector("#box-campaigns .campaign-price")).Text;

                //Go to item page
                items[0].FindElement(By.CssSelector("#box-campaigns [title='Yellow Duck'] .name")).Click();

                string newItemName = driver.FindElement(By.CssSelector("#box-product .title")).Text;
                string newRegularePrice = driver.FindElement(By.CssSelector(".regular-price")).Text;
                string newCampaignPrice = driver.FindElement(By.CssSelector(".campaign-price")).Text;

                Assert.AreEqual(oldItemName, newItemName);
                Assert.AreEqual(oldRegularePrice, newRegularePrice);
                Assert.AreEqual(oldCampaignPrice, newCampaignPrice);

            }
        

        }
    }
}
