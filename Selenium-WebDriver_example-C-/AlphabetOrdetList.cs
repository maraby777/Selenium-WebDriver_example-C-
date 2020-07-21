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
            List<string> countrieWithZone = new List<string>();
            List<string> countriesList = new List<string>();
            List<string> zoneList = new List<string>();

            LoginAsAdmin("http://localhost/litecart/admin/?app=countries&doc=countries");

            ICollection<IWebElement> rows = driver.FindElements(By.CssSelector(".row"));

            foreach (IWebElement row in rows)
            {
                List<IWebElement> cells = row.FindElements(By.TagName("td")).ToList();
                countriesList.Add(cells[4].Text);

                //create list countries with zone
                if (cells[5].Text != "0")
                {
                    countrieWithZone.Add(row.FindElement(By.TagName("a")).GetAttribute("href"));
                }
            }

            List<string> sortCountriesList = countriesList;
            sortCountriesList.Sort();
            Assert.AreEqual(sortCountriesList, countriesList);

            for (int i = 0; i < countrieWithZone.Count(); i++)
            {
                driver.Url = "" + countrieWithZone[i] + "";

                ICollection<IWebElement> zoneRows = driver.FindElements(By.CssSelector("#table-zones > tbody > tr:not(.header)"));

                foreach (IWebElement row in zoneRows)
                {
                    List<IWebElement> cells = row.FindElements(By.TagName("td")).ToList();

                    if (zoneRows.Count == 1)
                        continue;

                    zoneList.Add(cells[2].Text);

                    List<string> sortZone = zoneList;
                    sortZone.Sort();
                    Assert.AreEqual(sortZone, zoneList);
                }
            }
        }

        [Test]
        public void CheckZonesFromCountryPage()
        {
            List<string> linkList = new List<string>();
            List<string> zoneList = new List<string>();

            LoginAsAdmin("http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones");

            ICollection<IWebElement> rows = driver.FindElements(By.CssSelector(".row"));

            foreach (IWebElement row in rows)
            {
                linkList.Add(row.FindElement(By.TagName("a")).GetAttribute("href"));
            }

            for (int i = 0; i < linkList.Count(); i++)
            {
                driver.Url = "" + linkList[i] + "";
                List<IWebElement> countryZones = driver.FindElements(By.CssSelector("#table-zones tr:not(.header)")).ToList();

                for (int j = 0; j < countryZones.Count() - 1; j++ )
                {  
                    List<IWebElement> cells = countryZones[j].FindElements(By.CssSelector("td")).ToList();

                    zoneList.Add(cells[2].FindElement(By.CssSelector("[selected=selected]")).Text);

                }

                List<string> sortZone = zoneList;
                sortZone.Sort();
                Assert.AreEqual(sortZone, zoneList);

            }
        }
    }
}
