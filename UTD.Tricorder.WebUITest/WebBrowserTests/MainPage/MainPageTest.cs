using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.WebUITest.BaseClasses;

namespace UTD.Tricorder.WebUITest.WebBrowserTests.Framework
{
    [TestClass()]
    public class MainPageTests : JasmineTestPageBase
    {
        public MainPageTests()
        {
            //baseURL = "http://localhost:7255";
            this.JavaScriptTestFileName = "MainPage/mainPageTests.js";
            this.WaitingTimeSeconds = 5;
        }

        [TestMethod()]
        public void RunMainPageTests()
        {
            RunJasmineTest();
        }


    }
}
