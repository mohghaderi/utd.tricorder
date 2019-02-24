using UTD.Tricorder.Service.PreRequisite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using Framework.Common;

namespace UTD.Tricorder.TestCase
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for UserApprovedPreRequisiteTest and is intended
    ///to contain all UserApprovedPreRequisiteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserApprovedPreRequisiteTest
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
        ///A test for UserApprovedPreRequisite Constructor
        ///</summary>
        [TestMethod()]
        public void UserApprovedPreRequisiteConstructorTest()
        {
            UserApprovedPreRequisite target = new UserApprovedPreRequisite();
        }


        private User UserGetUserInfo(string userName)
        {
            IUserService userService = (IUserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
            //User userInfo = (User)userService.GetByID(userID, new GetByIDParameters());
            return userService.GetByUserNameT(userName);
        }


        ///// <summary>
        /////A test for Check
        /////</summary>
        //[TestMethod()]
        //public void CheckTestNeedsApproval()
        //{
        //    UserApprovedPreRequisite target = new UserApprovedPreRequisite(); // TODO: Initialize to an appropriate value
        //    User userInfo = UserGetUserInfo("testUserNameNeedsApproval");
        //    string expected = UserApprovedPreRequisite.urlApprovalNeeded;
        //    string actual = target.Check(userInfo);
        //    Assert.AreEqual(expected, actual);
        //}

        /// <summary>
        ///A test for Check
        ///</summary>
        [TestMethod()]
        public void CheckTestApproved()
        {
            UserApprovedPreRequisite target = new UserApprovedPreRequisite(); // TODO: Initialize to an appropriate value
            User userInfo = UserGetUserInfo("testUserNameApproved");
            string expected = null;
            string actual = target.Check(userInfo);
            Assert.AreEqual(expected, actual);
        }



    }
}
