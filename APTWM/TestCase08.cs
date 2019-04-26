using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class TestCase08
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheCase08Test()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Jan");
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Kowalski");
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("16-12-2000");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            try
            {
                Assert.AreEqual("Jan Kowalski zostal zakwalifikowany do kategorii Dorosly", driver.FindElement(By.Id("returnSt")).Text);
            }
            catch (Exception e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//body")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
