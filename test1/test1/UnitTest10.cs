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
    public class UnitTest10
    {

        IWebDriver driver;


        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            autorize(driver);
        }

        public static void autorize(IWebDriver driver)
        {
            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();
        }


        [Test]

        public void verifygeozones()

        {
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("[name = geo_zones_form] tr .row"));
            for (int i = 0; i < elements.Count; i++)
            {

                int result = String.Compare(elements[i].GetAttribute("textContent"), elements[i + 1].GetAttribute("textContent"));
                if (!comparing(result)) throw new Exception("improper sorting");

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


    

