using Framework.Common;
using Framework.Common.Logging;
using Framework.Service;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common.Logging
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for LoggerTest and is intended
    ///to contain all LoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoggerTest
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
        public void WriteLogTest()
        {
            Logger target = FWUtils.ExpLogUtils.Logger;
            IAppLog logEntry = (IAppLog) EntityFactory.GetEntityObject(AppLog.EntityName, GetSourceTypeEnum.Table);
            logEntry.AppLogTypeID = -1000;
            logEntry.ExtraGuid = Guid.NewGuid();
            logEntry.ExtraDouble = TestUtils.RandomUtils.RandomDouble();
            logEntry.ExtraString1 = TestUtils.RandomUtils.RandomStringMaxLength(50, null);
            logEntry.ExtraString2 = TestUtils.RandomUtils.RandomStringMaxLength(50, null);
            bool expected = true; 
            bool actual;
            actual = target.WriteLog(logEntry);
            Assert.AreEqual(expected, actual);

            FilterExpression filter = new FilterExpression(new Filter(AppLog.ColumnNames.ExtraGuid, logEntry.ExtraGuid));
            IServiceBase logService = EntityFactory.GetEntityServiceByName(AppLog.EntityName, "");
            Assert.AreEqual(1, logService.GetCount(filter));
        }

        /// <summary>
        ///A test for Logger Constructor
        ///</summary>
        [TestMethod()]
        public void LoggerConstructorTest()
        {
            Logger target = new Logger();
        }
    }
}
