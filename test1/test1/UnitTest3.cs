using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using NUnit;
using NUnit.Framework;
using System.Collections.Generic;

namespace test1
{
    [TestFixture]
    public class UnitTest3
    {
       // IWebDriver ff1;
       // IWebDriver ff2;
        IWebDriver ie1;
       // IWebDriver ie2;

        [SetUp]
        public void initailize()
        {
           // ff1 = new FirefoxDriver();
           // ff2 = new FirefoxDriver();
            ie1 = new InternetExplorerDriver();
           // ie2 = new InternetExplorerDriver();
        }

        [Test]

        public void all_cookies()
        {
          //  ff1.Url = "https://www.google.com.ua/";
           // ff2.Url = "https://www.google.com.ua/";
            ie1.Url = "https://www.google.com.ua/";
          //  ie2.Url = "https://www.google.com.ua/";


           
           // ICollection<Cookie> cookies1 = ff1.Manage().Cookies.AllCookies;
          //  ICollection<Cookie> cookies2 = ff2.Manage().Cookies.AllCookies;
            ICollection<Cookie> cookies3 = ie1.Manage().Cookies.AllCookies;
          //  ICollection<Cookie> cookies4 = ie2.Manage().Cookies.AllCookies;
         //   System.Diagnostics.Debug.WriteLine(cookies1);
          //  System.Diagnostics.Debug.WriteLine(cookies2);
          //  System.Diagnostics.Debug.WriteLine(cookies3);
          //  System.Diagnostics.Debug.WriteLine(cookies4);

         //   ff1.Manage().Cookies.DeleteAllCookies();
            ie1.Manage().Cookies.DeleteAllCookies();

           // System.Diagnostics.Debug.WriteLine(cookies1);
          //  System.Diagnostics.Debug.WriteLine(cookies2);
          //  System.Diagnostics.Debug.WriteLine(cookies3);
          //  System.Diagnostics.Debug.WriteLine(cookies4);
        }

        [TearDown]
        public void close()
        {
        //    ff1.Quit();
          //  ff2.Quit();
            ie1.Quit();
            ie1 = null;
          //  ie2.Quit();
            // ff1 = null;
            // ff2 = null;

        }

    }
}
