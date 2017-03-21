using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit;
using System.Collections.Generic;
using System.Collections;
using static NUnit.Framework.Assert;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject15
{
    [TestFixture]
    public class task13waitings
    {
        private IWebDriver driver;



        [SetUp]
        public  void start()
        {
            driver = new ChromeDriver();
            
           
            driver.Url = "http://localhost/litecart/en/";


        }
        [Test]

        public void Task13b()
        {
            for (int i = 2; i < 3; i++)
            {
                FirstDuck(driver);

                //var element = driver.FindElement(By.CssSelector(".content > .quantity"));
                var element = driver.FindElement(By.XPath("//span [@class='quantity']"));
                //string elementtext = element.GetAttribute("textContent");
                int count = i + 1;
                

                IJavaScriptExecutor jse = driver as IJavaScriptExecutor;

                jse.ExecuteScript("document.querySelector(\"button[name='add_cart_product']\").click()");


       //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
         //      wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, Convert.ToString(count)));
                if (i == 2)
                {
                    //Checkout »
                    driver.FindElement(By.XPath("//a [text() [contains (., 'Checkout »')]]")).Click();
                    Remove(driver);
                }
                driver.Url = "http://localhost/litecart/en/";
            }

        }

        public static void FirstDuck (IWebDriver driver)
        {
            IWebElement firstduck = driver.FindElements(By.CssSelector(("#box-most-popular li")))[0];
            firstduck.Click();
        }

        public static void Remove(IWebDriver driver)
        {
            for (int i = 0; i < 3; i++)
            {
                IJavaScriptExecutor jse = driver as IJavaScriptExecutor;

                jse.ExecuteScript("document.querySelector(\"button[value='Remove']\").click()");
                //driver.FindElement(By.XPath("//button[contains(.,'Remove')]")).Click();
                var row3 = driver.FindElements(By.CssSelector("#order_confirmation-wrapper tbody tr"))[4];
                var row2 = driver.FindElements(By.CssSelector("#order_confirmation-wrapper tbody tr"))[3];
                var row1 = driver.FindElements(By.CssSelector("#order_confirmation-wrapper tbody tr"))[2];

                if (i == 0)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.StalenessOf(row3));
                }
                if (i == 1)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.StalenessOf(row2));
                }

                if (i == 2)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.StalenessOf(row2));
                }
            }


        }


        public static void auth(IWebDriver driver)
        {
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

