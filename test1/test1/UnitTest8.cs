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
    public class UnitTest8
    {
        IWebDriver driver;
        
        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://localhost/litecart/en/";
        }

        [Test]
        public void findStickers()
        {
            IList<IWebElement> ducks = driver.FindElements(By.CssSelector(".image-wrapper"));

            for (int i = 0; i < ducks.Count; i++)
            {
                 var duck = driver.FindElements(By.CssSelector(".image-wrapper"))[i];

                 var sticker = duck.FindElements(By.CssSelector("[class *= sticker]"));

                if (sticker.Count != 1)
                {
                    throw new Exception("stickers count differs from 1"); 
                }
                
            }

          

        }

       


        [TearDown]
        public void stop()
        {

        }
    }
}
