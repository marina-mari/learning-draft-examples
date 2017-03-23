//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using NUnit.Framework;
//using NUnit;
//using System.Collections.Generic;
//using System.Collections;
//using static NUnit.Framework.Assert;
//using System.Diagnostics;
//using OpenQA.Selenium.Chrome;


//namespace UnitTestProject1
//{
//    [TestFixture]
//    public class task11c
//    {
//        private IWebDriver driver;
//    }   
        

//        [SetUp]
//        public void start()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//            driver.Url = "http://localhost/litecart/en/";
            
            
//        }
//        [Test]
//        public void task11()
//        {

//            findlink_on_mainpage(driver);

//            handle_capture(driver);

//            country(driver);

//            phone(driver);

//            firstname_find(driver);

//            lastname_find(driver);

//            address1_find(driver);

//            postcode_find(driver);

//            city(driver);

//            desiredpass(driver, returnpassword(driver));

//            confirmed_password(driver, returnpassword(driver));

//            var email = send_email();
//            var password = returnpassword(driver);

//            email_field(driver, email);

//            clickSubmit(driver);

//            logout(driver);

//            login(driver, email, password);

//            logout(driver);

//        }

  
//        public static void login (IWebDriver driver, string email, string password)
//        {
//            var emailfield = driver.FindElement(By.CssSelector("[name=login_form] [name=email]"));
//            emailfield.Click();
//            emailfield.SendKeys(email);
            
            
//             var passfield = driver.FindElement(By.CssSelector("[name=login_form] [name=password]"));
//            passfield.Click();
//            passfield.SendKeys(password);

//            driver.FindElement(By.CssSelector("#box-account-login tr:nth-child(4) [name=login] [value=Login]")).Click();


//        }
//        public static string returnpassword(IWebDriver driver)
//        {
//            return "test";
//        }


//        public static void desiredpass(IWebDriver driver, string password)
//        {
//            var desiredpass = driver.FindElement(By.CssSelector("tbody tr:nth-child(8) [name=password]"));
//            desiredpass.Click();
//            desiredpass.SendKeys(password);
//        }

//        public static void confirmed_password(IWebDriver driver, string password)
//        {
//            var confirmed_password = driver.FindElement(By.CssSelector("tbody tr:nth-child(8) [name=confirmed_password]"));
//            confirmed_password.Click();
//            confirmed_password.SendKeys(password);
//        }

//        public static string send_email()
//        {
//            Random r1 = new Random();
//            string i = Convert.ToString(r1.Next(1, 1000000000));

//            Random r2 = new Random();
//            string j = Convert.ToString(r2.Next(1, 1000000000));

//            Random r3 = new Random();
//            string k = Convert.ToString(r3.Next(1, 1000000000));

//            string emailaddress = "test" + i + j + k + "@test.com";
//            return emailaddress;

//        }

//        public static void email_field(IWebDriver driver, string emailaddress)
//        {
//            var email = driver.FindElement(By.CssSelector("tbody tr:nth-child(6) [name=email]"));
//            email.Click();
//            email.SendKeys(emailaddress);

//        }

//        public static void logout(IWebDriver driver)
//        {
//            //driver.FindElement(By.CssSelector("#box-account [href=http://localhost/litecart/en/logout]")).Click();
//            driver.FindElement(By.CssSelector("a [title = Logout]")).Click();
//        }
//    }
//        public static void clickSubmit(IWebDriver driver)
//        {
//            driver.FindElement(By.XPath("//button[text() = 'Create Account']")).Click();
//        }

        

//            public static void country (IWebDriver driver)
//        {
//            //var country1 = driver.FindElement(By.CssSelector("table tr:nth-child(5) .selection "));
//            //country1.Click();
//            // var country = driver.FindElement(By.CssSelector("#select2-search__field"));
//            //country.Click();

//            // country.SendKeys("Keys.LineDown");
//            //country.SendKeys("Keys.LineDown");
//            // country.SendKeys("Keys.LineDown");
//            //country.SendKeys("Keys.Enter");

//             var countryselector = driver.FindElement(By.CssSelector(".select2-selection__arrow"));
//            countryselector.Click();
//            var US = driver.FindElement(By.XPath("//li[text() = 'United States']"));
//            US.Click();



//            // var searchbox = driver.FindElement(By.CssSelector("[type=search] [role=textbox]"));

//            //IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
//            //jse.ExecuteScript("document.querySelector(\"[type=search] [role=textbox]\").innerHTML='United States'");

//            //jse.ExecuteScript("document.querySelector(\"[type=search] [role=textbox]\").value=United States");

//            //searchbox.SendKeys("United States");
//            //searchbox.SendKeys(Keys.Enter);

//        }
        

//        public static void findlink_on_mainpage(IWebDriver driver)
//        {
//            var link = driver.FindElement(By.CssSelector(".content table tr:nth-child(5) a"));
//            link.Click();
//        }

        

        

//        public static void firstname_find(IWebDriver driver)
//        {
//            var firstname = driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [name=firstname]"));
//            firstname.Click();
//            firstname.SendKeys("test");
//        }

//        public static void lastname_find(IWebDriver driver)
//        {
//            var lastname = driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [name=lastname]"));
//            lastname.Click();
//            lastname.SendKeys("test");
//        }

//        public static void address1_find(IWebDriver driver)
//        {
//            var address1 = driver.FindElement(By.CssSelector("tbody tr:nth-child(3) [name=address1]"));
//            address1.Click();
//            address1.SendKeys("test");
//        }
        

//             public static void postcode_find(IWebDriver driver)
//        {
//            var postcode = driver.FindElement(By.CssSelector("tbody tr:nth-child(4) [name=postcode]"));
//            postcode.Click();
//            postcode.SendKeys("04078");
//        }

//        public static void city (IWebDriver driver)
//        {
//            var city = driver.FindElement(By.CssSelector("tbody tr:nth-child(4) [name=city]"));
//            city.Click();
//            city.SendKeys("test");
//        }

//        public static void phone(IWebDriver driver)
//        {
//            var phone = driver.FindElement(By.CssSelector("tbody tr:nth-child(6) [name=phone]"));
//            phone.Click();
//            phone.SendKeys("1111");
//        }


        

//        public static void handle_capture (IWebDriver driver)
//        {
//            driver.Url = "http://localhost/litecart/admin/";

//            if (isauthrequired(driver))
//            {
//                auth(driver);
//            }

//            var settings = driver.FindElement(By.CssSelector("#box-apps-menu-wrapper li:nth-child(12)"));
//            settings.Click();
//            var securesett = driver.FindElement(By.CssSelector("[class=selected] #doc-security"));
//            securesett.Click();
//            var capturerow = driver.FindElement(By.CssSelector("[name=settings_form] tbody tr:nth-child(7) span")); 
//            if (capturerow.GetAttribute("textContent") == "True")
//            {
//                var captureedit = driver.FindElement(By.CssSelector("[name=settings_form] tbody tr:nth-child(7) [title=Edit]"));
//                captureedit.Click();
//               // var radiobutton = driver.FindElement(By.CssSelector("tbody tr:nth-child(7) label:nth-child(2)"));
//               // radiobutton.Click();



//                //if (radiobutton.Selected != true)
                    
//                //{
                    
//                    IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
//                jse.ExecuteScript("document.querySelector(\"input[type='radio'][value='0']\").click()");
//                // driver.FindElement(By.CssSelector("button [type = submit]")).Click();
//                jse.ExecuteScript("document.querySelector(\"button[type='submit'][value='Save']\").click()");
//                //jse.ExecuteScript("document.querySelector(\"input[value='0']\").click()");


//                // }


//                driver.Url = "http://localhost/litecart/en/create_account";
                
//            }
            
                    
        

//        public static void scr (IWebElement el)
//        {
//            el.Click();
//        }

        

//       public static bool isauthrequired (IWebDriver driver)
//        {
//            try
//            {
//                var loginform = driver.FindElement(By.CssSelector("#box-login-wrapper #box-login [type=submit]"));
//                return true;

//            }
            
//            catch (Exception ex)
//            {
//                System.Diagnostics.Trace.Write(ex);
//                return false;
//            }

//        }

//        public static void auth (IWebDriver driver)
//        {
//            var username = driver.FindElement(By.Name("username"));
//            username.SendKeys("admin");
//            var password = driver.FindElement(By.Name("password"));
//            password.SendKeys("admin");
//            var submit = driver.FindElement(By.Name("login"));
//            submit.Click();
//        }






//        [TearDown]
//        public void stop()
//        {
//            driver.Quit();
//            driver = null;
//        }


    





//      // public static bool iserrormsgvisible (IWebDriver driver)
//        //   {
//        //     try
//        //     {

//        //       bool iserrormsg = driver.FindElement(By.XPath("//i[contains( text(),'The email address')]")).Displayed;
//        //        return iserrormsg;
//        //   }
//        //   catch (Exception e)
//        //     {
//        //         return false;
//        //     }

//        //  }


