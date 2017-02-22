using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace UnitTestProject1
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void FirstTest()
        {
            driver.Url = "http://google.com";
           
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}
