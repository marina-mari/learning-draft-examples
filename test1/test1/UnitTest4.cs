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
    public class UnitTest4
    {
        IWebDriver ie;
        [SetUp]
        public void TestMethod1()
        {
            ie = new InternetExplorerDriver();
        }

        [Test]
        public void loginform_ie()

        {
            ie.Url = "http://localhost/litecart/admin/";
           
            var username = ie.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = ie.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = ie.FindElement(By.Name("login"));
            submit.Click();
        }
        [TearDown]
        public void stop()
        {
            ie.Quit();
            ie = null;
        }
    }
}
