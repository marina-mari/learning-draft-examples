using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost/litecart/en/";
            //var username = driver.FindElement(By.Name("username"));
            //username.SendKeys("admin");
            //var password = driver.FindElement(By.Name("password"));
            //password.SendKeys("admin");
            //var submit = driver.FindElement(By.Name("login"));
            //submit.Click();

            IWebElement ordprice = driver.FindElement(By.CssSelector("#box-campaigns .price-wrapper .regular-price"));
            var ordpricecolor1 = ordprice.GetCssValue("color");
            Console.WriteLine(ordpricecolor1);
            Console.ReadKey();

            string salepriceisbold1 = findsaleprice1(driver).GetCssValue("font-weight");

            //var image = driver.FindElement(By.CssSelector("#box-campaigns .image"));

           // image.Click();

            
            //var ordprice2 = driver.FindElement(By.CssSelector(".information .regular-price"));
            //string ordpricedecor2 = ordprice2.GetCssValue("text-decoration");
            string ordpriceisbold1 = findordprice1(driver).GetCssValue("font-weight");

            Console.WriteLine(salepriceisbold1);
            Console.ReadKey();

            
            

           // Console.WriteLine(salepriceisbold1);
           // Console.ReadKey();
           // Console.WriteLine(salepriceisbold2);
           // Console.ReadKey();





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
            IWebElement element = driver.FindElement(By.CssSelector("#box-product .campaign-price"));
            return element;
        }
    }
}
