using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace mydraft
{

    class Program
    {

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=edit_country&country_code=CA";
            var username = driver.FindElement(By.Name("username"));
            username.SendKeys("admin");
            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("admin");
            var submit = driver.FindElement(By.Name("login"));
            submit.Click();

            IList<IWebElement> internalrows = driver.FindElements(By.CssSelector("#table-zones td:nth-child(3) [name=zones[1][name]]"));

            for (int j = 0; j < internalrows.Count; j++)
            {
                Console.WriteLine(internalrows[j].GetAttribute("textContent"));
                Console.WriteLine(internalrows[j + 1].GetAttribute("textContent"));
                Console.ReadKey();
                int result = String.Compare(internalrows[j].GetAttribute("textContent"), internalrows[j + 1].GetAttribute("textContent"));
                if (result > 0) throw new Exception("improper sorting");



            }

        }
    }
}
