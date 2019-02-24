using Framework.Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;

namespace Framework.TestCase.Common.Exceptions
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for ExceptionTranslatorTest and is intended
    ///to contain all ExceptionTranslatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExceptionTranslatorTest
    {


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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ExceptionTranslator Constructor
        ///</summary>
        [TestMethod()]
        public void ExceptionTranslatorConstructorTest()
        {
            ExceptionTranslator target = new ExceptionTranslator();
        }

        /// <summary>
        ///A test for TryToTranslate
        ///</summary>
        [TestMethod()]
        public void TryToTranslateTest()
        {
            ExceptionTranslator target = FWUtils.ExpLogUtils.ExceptionTranslator;
            Guid msgGuid = Guid.NewGuid();
            Exception exception = new Exception(msgGuid.ToString());
            string expectedMessage = StringMsgs.Exceptions.UnknownExceptionHappened;
            UserException actual;
            actual = target.TryToTranslate(exception);
            Assert.AreEqual(expectedMessage, actual.Message);
        }


    }
}
