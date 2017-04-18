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
	public class UnitTest19
	{
		IWebDriver driver;

		[SetUp]
		public void TestMethod1()
		{
			driver = new ChromeDriver();
			driver.Url = "http://localhost:8080/litecart/admin/?app=countries&doc=countries";
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

		public void verify_links_open_in_new_window()
		{
			var edit_country_button = driver.FindElement(By.XPath("//tr [@class = 'row']//a [@title = 'Edit']"));
			edit_country_button.Click();

			// remember current window 
			string main_first_window = driver.CurrentWindowHandle;

			// define all old windows
			//ICollection<string> all_old_windows = driver.WindowHandles;

			var all_links = driver.FindElements(By.XPath("//td [@id = 'content']//i [@class ='fa fa-external-link']"));

			for (int i = 0; i < all_links.Count; i++)
			{
				all_links = driver.FindElements(By.XPath("//td [@id = 'content']//i [@class ='fa fa-external-link']"));
				var separate_link = driver.FindElements(By.XPath("//td [@id = 'content']//i [@class ='fa fa-external-link']"))[i];
				separate_link.Click();

				// wait when new window appears
				//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
				//wait.Until(ThereIsNewWindow(main_first_window));

				System.Threading.Thread.Sleep(2000);

				verify_new_window(driver, main_first_window);

				return_in_main_window(driver, main_first_window);
			}


		}

		public static void verify_new_window(IWebDriver driver, string main_first_window)
		{
			// get list of windows again

			ICollection<string> all_new_windows = driver.WindowHandles;

			// define new window-id, switch in new window

			foreach (string s in all_new_windows)
			{
				if (s != main_first_window)
				{
					string new_window = s;
					driver.SwitchTo().Window(new_window);
					// close the new window
					driver.Close();
				}
			}





		}

		//public static bool ThereIsNewWindow(string main_first_window)
		//{
		//}

		public static void return_in_main_window(IWebDriver driver, string main_first_window)
		{
			driver.SwitchTo().Window(main_first_window);

			try
			{
				NUnit.Framework.Assert.AreEqual("Edit Country | My Store", driver.Title);
			}

			catch (Exception ex)
			{
				System.Diagnostics.Trace.Write(ex);
			}

		}

		



	}
}
