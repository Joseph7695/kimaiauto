//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.Text;
//using System.Threading.Tasks;

//namespace kimaiAuto
//{
//    [TestClass]
//    internal class KimaiTestClass
//    {
//        [TestMethod]
//        public void ChromeSession()
//        {
//            IWebDriver driver = new ChromeDriver();

//            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

//            var title = driver.Title;
//            Assert.AreEqual("Web form", title);

//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

//            var textBox = driver.FindElement(By.Name("my-text"));
//            var submitButton = driver.FindElement(By.TagName("button"));

//            textBox.SendKeys("Selenium");
//            submitButton.Click();

//            var message = driver.FindElement(By.Id("message"));
//            var value = message.Text;
//            Assert.AreEqual("Received!", value);

//            driver.Quit();
//        }
//    }
//}
