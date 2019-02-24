using Framework.Common;
using Framework.Common.Exceptions;
using Framework.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common.Exceptions
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for ExceptionHandlerTest and is intended
    ///to contain all ExceptionHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExceptionHandlerTest
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
        ///A test for ExceptionHandler Constructor
        ///</summary>
        [TestMethod()]
        public void ExceptionHandlerConstructorTest()
        {
            ExceptionHandler target = new ExceptionHandler();
        }

        /// <summary>
        ///A test for HandleException
        ///</summary>
        [TestMethod()]
        public void HandleExceptionTest()
        {
            // exception should be converted to UserException
            ExceptionHandler target = FWUtils.ExpLogUtils.ExceptionHandler; 
            Guid msgGuid = Guid.NewGuid();
            Exception exception = new Exception(msgGuid.ToString()); 
            string policyName = PolicyName.GlobalPolicy; 
            bool expected = true; 
            bool actual;
            actual = target.HandleException(ref exception, policyName);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(exception is UserException);

            // handled exception should be logged
            IServiceBase service = EntityFactory.GetEntityServiceByName(AppExceptionLog.EntityName, "");
            FilterExpression filter = new FilterExpression(new Filter(AppExceptionLog.ColumnNames.Message, msgGuid.ToString()));
            Assert.AreEqual(1, service.GetCount(filter));
        }

        /// <summary>
        ///A test for HandleException
        ///</summary>
        [TestMethod()]
        public void HandleExceptionTest2()
        {
            // User Exception shouldn't change at all
            ExceptionHandler target = FWUtils.ExpLogUtils.ExceptionHandler;
            Guid msgGuid = Guid.NewGuid();
            Exception exception = new UserException(msgGuid.ToString());
            int hashCode = exception.GetHashCode();
            string policyName = PolicyName.GlobalPolicy;
            bool expected = true;
            bool actual;
            actual = target.HandleException(ref exception, policyName);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(exception is UserException);
            Assert.AreEqual(hashCode, exception.GetHashCode());

            // user exception shouldn't be logged
            IServiceBase service = EntityFactory.GetEntityServiceByName(AppExceptionLog.EntityName, "");
            FilterExpression filter = new FilterExpression(new Filter(AppExceptionLog.ColumnNames.Message, msgGuid.ToString()));
            Assert.AreEqual(0, service.GetCount(filter));
        }


    }
}
