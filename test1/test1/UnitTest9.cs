using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit;
using System.Collections.Generic;
using System.Collections;

namespace test1
{
    [TestFixture]
    public class UnitTest9
    {

        IWebDriver driver;
        

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();
        }

        [Test]

        public void verifysorting ()

        {
            
            IList<IWebElement> countries = driver.FindElements(By.CssSelector("tr.row td:nth-child(5)"));

            for (int i = 0; i < countries.Count-1; i++)
            {
                
                int result = String.Compare(countries[i].GetAttribute("textContent"), countries[i+1].GetAttribute("textContent"));
                if (!comparing(result)) throw new Exception("improper sorting");
                
             }
          
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("[name=countries_form] .row "));


            for (int i = 0; i < rows.Count; i++)
            {
                IWebElement zone = rows[i].FindElement(By.CssSelector("td:nth-child(6)"));


                if (zone.GetAttribute("textContent") != "0")
                {

                    IWebElement link = rows[i].FindElement(By.CssSelector("td:nth-child(5) a"));

                    link.Click();
                    IList<IWebElement> internalrows = driver.FindElements(By.CssSelector("#table-zones td:nth-child(3)"));

                    for (int j = 0; j < internalrows.Count - 1; j++)
                    {
                       

                        int result2 = String.Compare(internalrows[j].GetAttribute("textContent"), internalrows[j + 1].GetAttribute("textContent"));

                        if (!comparing(result2)) throw new Exception("improper sorting");

                            

                        driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

                    }
                }

            }


            }
        public static bool comparing(int result)
        {
            if (result > 0) return false;
            else return true;
        }

  
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;

        }
    

    }
}
