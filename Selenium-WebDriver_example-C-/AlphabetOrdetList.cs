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
    public class AlphabetOrdetList : TestBase
    {
        [Test]
        public void CheckCountryesAndZonesAlphabetOrder()
        {
            LoginAsAdmin("http://localhost/litecart/admin/?app=countries&doc=countries");

            ICollection<IWebElement> rows = driver.FindElements(By.CssSelector(".row"));

            List<IWebElement> countrieWithZone = new List<IWebElement>();

            List<string> countrieList = new List<string>();
            List<string> zoneList = new List<string>();

            foreach (IWebElement row in rows)
            {
                List<IWebElement> cells = row.FindElements(By.TagName("td")).ToList();
                countrieList.Add(cells[4].Text);

                //create list countries with zone
                if (cells[5].Text != "0")
                {

                    countrieWithZone.Add(row);
                }
                
            }

            countrieList.Sort();
  
            foreach (IWebElement countrie in countrieWithZone)
            {
                countrie.FindElement(By.TagName("a")).Click();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                ICollection<IWebElement> zoneRows = driver.FindElements(By.CssSelector("#table-zones > tbody > tr:not(.header)"));

                foreach (IWebElement row in zoneRows)
                {
                    List<IWebElement> cells = row.FindElements(By.TagName("td")).ToList();

                    if (zoneRows.Count == 1)
                    continue;

                    zoneList.Add(cells[2].Text);

                    List<string> sortzone = zoneList;
                    sortzone.Sort();
                    Assert.AreEqual(sortzone, zoneList);

                    //back
                   driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

                }
            }
        }








            //List countrie1 = new List();

        //    foreach (IWebElement countrie in countries)
        //    {
        //        string names = countrie.FindElement(By.XPath("//td[5]//a[1]")).Text;


        //        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        //    }
        //}

        //private bool IsContactPresent()
        //{
        //    return IsElementPresent(By.Name("selected[]"));
        //}
    }
}
