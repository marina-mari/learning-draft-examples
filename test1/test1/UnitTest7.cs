using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace test1
{
    [TestFixture]
    public class UnitTest7
    {
        IWebDriver driver;
        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
           // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }

        [Test]
        public void task7()
        {
            driver.Url = "http://localhost/litecart/admin/";
            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();
            var ul = driver.FindElement(By.CssSelector("#box-apps-menu"));
            IList<IWebElement> li = ul.FindElements(By.CssSelector("#app-"));

            for (int i = 0; i < li.Count; i++)
            {
                ul = driver.FindElement(By.CssSelector("#box-apps-menu"));

                IWebElement liParent = ul.FindElements(By.CssSelector("#app-"))[i];
                liParent.Click();

                ul = driver.FindElement(By.CssSelector("#box-apps-menu"));
                liParent = ul.FindElements(By.CssSelector("#app-"))[i];

                
                IList<IWebElement> liInners = liParent.FindElements(By.CssSelector("li"));
                for (int j = 0; j < liInners.Count; j++)
                {
                    var currentChild = liParent.FindElements(By.CssSelector("li"))[j];

                    currentChild.Click();

                    ul = driver.FindElement(By.CssSelector("#box-apps-menu"));
                    liParent = ul.FindElements(By.CssSelector("#app-"))[i];
                }


            }
        }

        public bool IsHeadElementPresent()
        {
            try
            {
                var h1 = driver.FindElement(By.CssSelector("h1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no such element");
                return false;

            }
        }


        [TearDown]

        public void stop()

        {
            driver.Quit();
            driver = null;
        }

    }
}

