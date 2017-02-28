using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit;
using NUnit.Framework;

namespace test1
{
    [TestFixture]
    public class UnitTest5
    {
        IWebDriver driver;
        
        

        [SetUp]
        public void TestMethod1()
        {
            
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            
        }

        [Test]
        public void OldMethodForFF()

        {
            driver.Url = "http://localhost/litecart/admin/";

            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}