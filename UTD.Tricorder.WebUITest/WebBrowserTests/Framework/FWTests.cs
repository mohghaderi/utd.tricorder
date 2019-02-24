using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.WebUITest.BaseClasses;

namespace UTD.Tricorder.TestCase.WebBrowserTests.Framework
{
    [TestClass()]
    public class FWTests : JasmineTestPageBase
    {

        public FWTests()
        {
            //baseURL = "http://localhost:7255";
            this.JavaScriptTestFileName = "Framework/fwTests.js";
            this.WaitingTimeSeconds = 5;
        }

        [TestMethod()]
        public void RunFWTests()
        {
            RunJasmineTest();
        }


    }
}
