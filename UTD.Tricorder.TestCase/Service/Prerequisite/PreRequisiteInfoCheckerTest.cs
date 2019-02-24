using UTD.Tricorder.Service.PreRequisite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.TestCase
{
    
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for PreRequisiteInfoCheckerTest and is intended
    ///to contain all PreRequisiteInfoCheckerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PreRequisiteInfoCheckerTest
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
        ///A test for PreRequisiteInfoChecker Constructor
        ///</summary>
        [TestMethod()]
        public void PreRequisiteInfoCheckerConstructorTest()
        {
            PreRequisiteInfoChecker target = new PreRequisiteInfoChecker();
        }

        /// <summary>
        ///A test for CheckAndReturnNextForm
        ///</summary>
        [TestMethod()]
        public void CheckAndReturnNextFormTest()
        {
            // Pre Requisite for someone who needs Person Registration
            PreRequisiteInfoChecker target = new PreRequisiteInfoChecker();
            long userID = 1; // testUserNameNeedsPersonRegistration
            //string expected = "~/Pages/PersonInsert.aspx?Entity="
            //                    + vPerson.EntityName
            //                    + "&AdditionalDataKey="
            //                    + Person.AdditionalData_Register
            //                    + "&MasterRecordID=&MasterEntity=User&MasterAdditionalDataKey=&ParentIDInTree=";

            string expected = "Register/Person";

            string actual;
            actual = target.CheckAndReturnNextForm(userID);
            Assert.AreEqual(expected, actual);
        }


    }
}
