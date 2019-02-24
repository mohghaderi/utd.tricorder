using Framework.Common;
using Framework.Common.Logging;
using Framework.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common.Logging
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for ExceptionLoggerTest and is intended
    ///to contain all ExceptionLoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExceptionLoggerTest
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
        ///A test for WriteLog
        ///</summary>
        [TestMethod()]
        public void LogErrorTest()
        {
            ExceptionLogger target = FWUtils.ExpLogUtils.ExceptionLogger;

            Guid msgGuid = Guid.NewGuid();
            Exception exception = new Exception(msgGuid.ToString()); 

            bool expected = true;
            bool actual;
            actual = target.LogError(exception, "");
            Assert.AreEqual(expected, actual);

            FilterExpression filter = new FilterExpression(new Filter(AppExceptionLog.ColumnNames.Message, msgGuid.ToString()));
            IServiceBase logService = EntityFactory.GetEntityServiceByName(AppExceptionLog.EntityName, "");
            Assert.AreEqual(1, logService.GetCount(filter));
        }

        /// <summary>
        ///A test for ExceptionLogger Constructor
        ///</summary>
        [TestMethod()]
        public void ExceptionLoggerConstructorTest()
        {
            ExceptionLogger target = new ExceptionLogger();
        }
    }
}
