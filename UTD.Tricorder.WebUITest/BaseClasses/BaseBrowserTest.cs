using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTD.Tricorder.WebUITest.BaseClasses
{
    public class SeleniumBrowserTestBase
    {
        protected static IWebDriver driver;
        protected bool acceptNextAlert = true;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public SeleniumBrowserTestBase()
        {
            this.baseURL = "http://localhost:7255";
        }



        [TestInitialize()]
        public void SetupTest()
        {
            if (driver == null)
                InitializeBrowserDriver();
            //baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        private void InitializeBrowserDriver()
        {
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
        }

        [TestCleanup()]
        public void TeardownTest()
        {
            try
            {
                // we don't want to close browser as there might be several other test cases to use the browser
                //driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        protected bool IsElementPresent(By by)
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

        protected bool IsAlertPresent()
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

        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
