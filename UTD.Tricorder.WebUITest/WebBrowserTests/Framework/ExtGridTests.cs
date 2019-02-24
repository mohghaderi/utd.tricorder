using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.WebUITest.BaseClasses;

namespace UTD.Tricorder.WebUITest.WebBrowserTests.Framework
{
    [TestClass()]
    public class ExtGridTests : JasmineTestPageBase
    {
        public ExtGridTests()
        {
            //baseURL = "http://localhost:7255";
            this.JavaScriptTestFileName = "Framework/ExtGridTests.js";
            this.WaitingTimeSeconds = 5;
        }

        [TestMethod()]
        public void RunExtGridTests()
        {
            RunJasmineTest();
        }


    }
}
