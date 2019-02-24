using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.TestCase.WebBrowserTests;

namespace UTD.Tricorder.WebUITest.BaseClasses
{

    /// <summary>
    /// Base page for Jasmine test suite
    /// </summary>
    public abstract class JasmineTestPageBase : SeleniumBrowserTestBase
    {

        /// <summary>
        /// Gets the name of the java script test file.
        /// </summary>
        /// <value>
        /// The name of the java script test file.
        /// </value>
        public string JavaScriptTestFileName { get; set; }

        private int waitingTimeSeconds = 6;

        /// <summary>
        /// Gets or sets the waiting time seconds.
        /// </summary>
        /// <value>
        /// The waiting time seconds.
        /// </value>
        public int WaitingTimeSeconds 
        { 
            get { return waitingTimeSeconds; } 
            set { waitingTimeSeconds = value; } 
        }


        public void RunJasmineTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/TestCases/JSTest.aspx?TestCase=" + this.JavaScriptTestFileName);


            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("FrameworkTest.getQueryString();");

            for (int second = 0; ; second++)
            {
                if (second >= this.waitingTimeSeconds * 10) Assert.Fail("timeout");
                try
                {
                    var element = driver.FindElement(By.CssSelector("span.duration"));
                    if (element != null)
                    {
                        var duration = element.Text;
                        if (duration.Contains("finished in"))
                            break;
                    }
                }
                catch (Exception)
                { }
                System.Threading.Thread.Sleep(100);
            }

            //x specs, 0 failures
            string results = "";
            try
            {
                results = driver.FindElement(By.CssSelector("span.bar.passed")).Text;
            }
            catch(NoSuchElementException) // test probably failed
            {
                results = driver.FindElement(By.CssSelector("span.bar.failed")).Text;
                throw new Exception("Test failed: " + results);
            }
            Assert.AreEqual(results.Contains("0 failures"), true);
        }

    }
}
