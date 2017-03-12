using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using NUnit.Framework;
using NUnit;
using System.Collections.Generic;
using System.Collections;
using static NUnit.Framework.Assert;
using System.Diagnostics;


namespace test1
{
    [TestFixture]
    public class UnitTest12
    {

        IWebDriver driver;


        [SetUp]
        public void setup()
        {
            driver = new InternetExplorerDriver();
            
            

            driver.Url = "http://localhost/litecart/en/";
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //autorize(driver);
        }

        //public static void autorize(IWebDriver driver)
        //{
        //    var username = driver.FindElement(By.Name("username"));
        //    username.SendKeys("admin");
        //    var password = driver.FindElement(By.Name("password"));
        //    password.SendKeys("admin");
        //    var submit = driver.FindElement(By.Name("login"));
        //    submit.Click();
        //}


        [Test]

        public void comparing_prices_internetexplorer()
        {
            IWebElement firstgood = driver.FindElement(By.CssSelector("#box-campaigns .image"));
            IWebElement duck1 = driver.FindElement(By.CssSelector("#box-campaigns .name"));
            string name1 = duck1.GetAttribute("textContent");

            var regularpricevalue1 = findordprice1(driver).GetAttribute("textContent");

            var salepricevalue1 = findsaleprice1(driver).GetAttribute("textContent");

            string ordpricecolor1 = findordprice1(driver).GetCssValue("color");

            string ordpricedecor1 = findordprice1(driver).GetCssValue("text-decoration");

            string salepriceisbold1 = findsaleprice1(driver).GetCssValue("font-weight");

            string salepriceiscolor1 = findsaleprice1(driver).GetCssValue("color");
            var salepricesize1h = findordprice1(driver).Size.Height;
            var salepricesize1w = findordprice1(driver).Size.Width;
            var ordpricesize1h = findordprice1(driver).Size.Height;
            var ordpricesize1w = findordprice1(driver).Size.Width;

            var salepricesquare1 = getsquare(salepricesize1h, salepricesize1w);
            var ordpricesquare1 = getsquare(ordpricesize1h, ordpricesize1w);



            // firstgood.Click();
            driver.Url = "http://localhost/litecart/en/rubber-ducks-c-1/subcategory-c-2/yellow-duck-p-1";

         //   new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists((By.Id(login))));
          //  IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Name("q")));
         //   IWebElement element2 = wait.Until(d => d.FindElement(By.Name("q")));

            IWebElement duck2 = driver.FindElement(By.CssSelector("#box-product .title"));
            string name2 = duck2.GetAttribute("textContent");

            var regularpricevalue2 = findordprice2(driver).GetAttribute("textContent");

            var salepricevalue2 = findsaleprice2(driver).GetAttribute("textContent");

            string ordpricecolor2 = findordprice2(driver).GetCssValue("color");
            string ordpricedecor2 = findordprice2(driver).GetCssValue("text-decoration");

            string salepriceisbold2 = findsaleprice2(driver).GetCssValue("font-weight");

            string salepriceiscolor2 = findsaleprice2(driver).GetCssValue("color");

            var salepricesize2h = findordprice2(driver).Size.Height;
            var salepricesize2w = findordprice2(driver).Size.Width;
            var ordpricesize2h = findordprice2(driver).Size.Height;
            var ordpricesize2w = findordprice2(driver).Size.Width;

            var salepricesquare2 = getsquare(salepricesize2h, salepricesize2w);
            var ordpricesquare2 = getsquare(ordpricesize2h, ordpricesize2w);



            try
            {
                AreEqual(name1, name2);
                AreEqual(regularpricevalue1, regularpricevalue2);
                AreEqual(salepricevalue1, salepricevalue2);
                AreEqual("rgba(119, 119, 119, 1)", ordpricecolor1);
                AreEqual("rgba(102, 102, 102, 1)", ordpricecolor2);
                AreEqual("line-through", ordpricedecor1);
                AreEqual("line-through", ordpricedecor2);
                AreEqual("900", salepriceisbold1);
                AreEqual("700", salepriceisbold2);
                IsTrue(salepriceiscolor1.EndsWith("0, 0, 1)"));
                IsTrue(salepriceiscolor2.EndsWith("0, 0, 1)"));
                IsTrue(salepricesquare1 >= ordpricesquare1);
                IsTrue(salepricesquare2 >= ordpricesquare2);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex);
            }



        }

        public static IWebElement findordprice1(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#box-campaigns .price-wrapper .regular-price"));
            return element;
        }

        public static IWebElement findordprice2(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector(".information .regular-price"));
            return element;
        }

        public static IWebElement findsaleprice1(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#box-campaigns .price-wrapper .campaign-price"));
            return element;
        }

        public static IWebElement findsaleprice2(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector(".price-wrapper .campaign-price"));
            return element;
        }

        public static double getsquare(double height, double width)
        {
            return (height * width);
        }




        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;

        }
    }
}




