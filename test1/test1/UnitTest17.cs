using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit;
using System.Collections.Generic;
using System.Collections;
using static NUnit.Framework.Assert;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;


namespace test1
{
    [TestFixture]
    public class task12
    {
        IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost/litecart/admin/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            auth(driver);
        }

        public void auth(IWebDriver driver)
        {
            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();
        }

        [Test]
        public void adding_goods()
        {
            driver.FindElement(By.XPath("//span[contains (., 'Catalog')]")).Click();

            General(driver);

        }

        public void General(IWebDriver driver)
        {
            var addNewGoodButton = driver.FindElement(By.XPath("//a[@href='http://localhost/litecart/admin/?category_id=0&app=catalog&doc=edit_product']"));
            addNewGoodButton.Click();

            var name = driver.FindElement(By.XPath("//input [@name='name[en]']"));
            name.SendKeys("custom_duck4");

            var code = driver.FindElement(By.XPath("//input [@name='code']"));
            code.SendKeys("1112");

            var product_groups = driver.FindElements(By.XPath("//input [@name='product_groups[]']"));
            product_groups[2].Click();


            IJavaScriptExecutor jse = driver as IJavaScriptExecutor;

            //jse.ExecuteScript("document.querySelector(\"button[type='submit'][value='Login']\").click()");

            IWebElement send_file = driver.FindElement(By.XPath("//input [@type='file'] [@name ='new_images[]']"));

            String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String strFilePath = Path.Combine(strAppPath, "Resources");
            String strFullFilename = Path.Combine(strFilePath, "image.jpg");


           send_file.SendKeys(strFullFilename);

            Infromation(driver);

            Prices(driver);
            Submit(driver);

        }

        public  static void Infromation(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains (., 'Information')]")).Click();

            var select = driver.FindElement(By.XPath("//select [@name='manufacturer_id'] [contains (., 'ACME Corp.')]"));

            var selectel1 = new SelectElement(select);

            System.Threading.Thread.Sleep(2000);
            selectel1.SelectByIndex(1);
            
           // var select2 = driver.FindElement(By.XPath("//select [@name='supplier_id'] [contains (., 'ACME Corp.')]"));

            var descr = driver.FindElement(By.XPath("//input [@name='short_description[en]']"));
            descr.SendKeys("test description");

            

        }


        public static void Prices (IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[contains (., 'Prices')]")).Click();

            var price_usd = driver.FindElement(By.XPath("//input [@name='prices[USD]']"));
            price_usd.SendKeys("100");
        }

        public static void Submit (IWebDriver driver)
        {
            var submit = driver.FindElement(By.XPath("//button [@name='save']"));

            submit.Click();
        }




        [TearDown]
        public void quit()
        {

        }

    }
}
