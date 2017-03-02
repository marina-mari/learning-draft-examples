using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace test1
{
    [TestFixture]
    public class UnitTest6
    {
        IWebDriver driver;

        [SetUp]

        public void start()
        {
            driver = new ChromeDriver();
        
        }

        [Test]

        public void FindElements()
        {
            driver.Url = "http://localhost/litecart/en/";
            IWebElement @class = driver.FindElement(By.ClassName("currency"));
            IWebElement @class2 = driver.FindElement(By.CssSelector(".currency"));
            //var @id driver.FindElement(By.Id("slider"));
            var @id2 = driver.FindElement(By.CssSelector("#slider"));
            //var @name = driver.FindElement(By.Name("login_form"));
            var byname = driver.FindElement(By.CssSelector("[name=password]"));
            var bycssselectortype = driver.FindElements(By.CssSelector("[type=hidden]"));
            var bycssselectorclass = driver.FindElement(By.CssSelector("[class=bottom]"));
            var bycssselectorclass2 = driver.FindElement(By.CssSelector(".bottom"));
            var test2 = driver.FindElement(By.CssSelector("[id*=rsl]"));
            var test3 = driver.FindElement(By.CssSelector("[class*=column]"));
            var test4 = driver.FindElement(By.CssSelector("[name ^=login]"));
            // find element by combination of tag "div" and class "left": looks like ("div.left")
            var test5 = driver.FindElement(By.CssSelector("div.left"));
            // find element by combunation of tag "button" and type and name
            var test6 = driver.FindElement(By.CssSelector("button[type=submit][name^=lost]"));
            //find element by combination of div tag, class "content" and tag "td" inside <div> </div>
            var test8 = driver.FindElement(By.CssSelector("button[type=submit][name^=lost]"));
            // find element by combination first element of list
            var test7 = driver.FindElement(By.CssSelector("li:first-child"));

        }

        [TearDown]
        
        public void stop()
        { 
         driver.Quit();
            driver = null;

        }


    }
}
