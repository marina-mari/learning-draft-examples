using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
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
	public class UnitTest20
	{

		EventFiringWebDriver driver;
		[SetUp]
		public void Start()
		{
			driver = new EventFiringWebDriver( new ChromeDriver());
			//driver.FindingElement += Driver_FindingElement;
			driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
			driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + "element is found");
			driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);
			driver.Url = "http://localhost:8080/litecart/admin/?app=catalog&doc=catalog&category_id=1";
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			auth(driver);
		}

		//
		//private void Driver_FindingElement(object sender, FindElementEventArgs e)
		//{
		//	Console.WriteLine(e.FindMethod);
		//}

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
		public void VerifyBrowserLogs()
		{
			var AllDucks = driver.FindElements(By.XPath("//*[@class='dataTable']//td/a[contains (., 'Duck')]"));

			for (int i =0; i <AllDucks.Count; i++)
			{
				driver.Url = "http://localhost:8080/litecart/admin/?app=catalog&doc=catalog&category_id=1";
				System.Threading.Thread.Sleep(2000);
				AllDucks = driver.FindElements(By.XPath("//*[@class='dataTable']//td/a[contains (., 'Duck')]"));
				AllDucks[i].Click();
				driver.GetScreenshot().SaveAsFile("C:\\Resources\\screen", ScreenshotImageFormat.Png);

				//String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
				//Console.WriteLine(strAppPath);
				//String strFilePath = Path.Combine(strAppPath, "Resources");
				//Console.WriteLine(strFilePath);
				//String strFullFilename = Path.Combine(strFilePath, "screen.png");
				//Console.WriteLine(strFullFilename);
				Console.WriteLine(driver.Manage().Logs.AvailableLogTypes);
				Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
				System.Diagnostics.Trace.Write(driver.Manage().Logs.GetLog("browser"));

				
				
			}
		}


		[TearDown]
		public void Stop()
		{
			driver.Quit();
			driver = null;
		}
	}
}
