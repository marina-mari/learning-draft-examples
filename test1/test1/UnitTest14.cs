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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "http://localhost/litecart/en/";



        }
        [Test]

        public void task13a()
        {
            for (int i = 0; i < 3; i++)
            {
                var firstduck = driver.FindElement(By.CssSelector("#box-most-popular img"));
                firstduck.Click();


                findselect(driver);


                IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
                System.Threading.Thread.Sleep(1000);

                jse.ExecuteScript("document.querySelector(\"button[name='add_cart_product']\").click()");
                System.Threading.Thread.Sleep(1000);

                //jse.ExecuteScript("document.querySelector(\"button[value='Add To Cart']\").click()");

                var counter = driver.FindElement(By.XPath("//span [@class='quantity']"));
                int countertext = Convert.ToInt32(counter.GetAttribute("textContent"));
               
                string scountertext = Convert.ToString(countertext);

               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

               wait.Until(ExpectedConditions.TextToBePresentInElement(counter, scountertext));


                if (i == 2)
                {
                    driver.FindElement(By.XPath("//a [contains (., 'Checkout')]")).Click();
                    System.Threading.Thread.Sleep(1000);

                    for (int j = 0; j < 3; j++)
                    {

                        Remove(driver, wait);

                    }
                }

                driver.Url = "http://localhost/litecart/en/";

            }
        }




            public static void Remove(IWebDriver driver, WebDriverWait wait)
        {
                bool isfinalpage = findfinalpage(driver);
                if (!isfinalpage)
                {
                    var row1 = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(2) "));
                    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button [contains (., 'Remove')]"))).Click();

                   // driver.FindElement(By.XPath("//button [contains (., 'Remove')]")).Click();


                    wait.Until(ExpectedConditions.StalenessOf(row1));
                }
        }

        public static bool findfinalpage (IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
                //jse.ExecuteScript("document.querySelector(\"div[id='checkout-cart-wrapper']\").click()");
                var finalpage = driver.FindElement(By.XPath("//em [contains (., 'There are no items in your cart.')]"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        

        public static void findselect (IWebDriver driver)
        {
            try
            {
                var select = driver.FindElement(By.XPath("//*[@name = 'options[Size]']"));

                var selectElemnt = new SelectElement(select);
                System.Threading.Thread.Sleep(2000);
                selectElemnt.SelectByIndex(2);

                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception e)
            {

            }
        }
        
    
        [TearDown]
        public  void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}

