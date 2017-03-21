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


namespace UnitTestProject1
{
    [TestFixture]
    public class task13
    {
        private IWebDriver driver;



        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://localhost/litecart/en/";



        }
        [Test]

        public void task13a()
        {
            for (int i = 0; i < 3; i++)
            {
                var firstduck = driver.FindElement(By.CssSelector("#box-most-popular img"));
                firstduck.Click();
                IJavaScriptExecutor jse = driver as IJavaScriptExecutor;

                jse.ExecuteScript("document.querySelector(\"button[name='add_cart_product']\").click()");

                //jse.ExecuteScript("document.querySelector(\"button[value='Add To Cart']\").click()");
                
                var counter = driver.FindElement(By.XPath("//span [@class='quantity']"));
                int countertext = Convert.ToInt32(counter.GetAttribute("textContent"));
                countertext = countertext + 1;
                string scountertext = Convert.ToString(countertext);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(ExpectedConditions.TextToBePresentInElementValue(counter, scountertext));
                driver.Url = "http ://localhost/litecart/en/";

                if (i == 2)
                {
                    for (int j = 0; j < 3; i++)
                    {
                        Remove(driver, wait);
                    }

                }

            }
        }

            public static void Remove(IWebDriver driver, WebDriverWait wait)
        {
            driver.FindElement(By.XPath("//a [contains (., 'Checkout')]")).Click();

            driver.FindElement(By.XPath("//button [contains (., 'Remove')]")).Click();

            var ammount = driver.FindElements(By.CssSelector("#order_confirmation-wrapper .footer td strong:nth-child(2)"))[1];

            wait.Until(ExpectedConditions.StalenessOf(ammount));

        
        }

        
    
        [TearDown]
        public  void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}

