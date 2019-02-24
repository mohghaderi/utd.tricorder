using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Service.PreRequisite;

namespace UTD.Tricorder.TestCase
{
    
    
    /// <summary>
    ///This is a test class for PersonInfoPreRequisiteTest and is intended
    ///to contain all PersonInfoPreRequisiteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonInfoPreRequisiteTest
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
        ///A test for PersonInfoPreRequisite Constructor
        ///</summary>
        [TestMethod()]
        public void PersonInfoPreRequisiteConstructorTest()
        {
            PersonInfoPreRequisite target = new PersonInfoPreRequisite();
        }

        private User UserGetUserInfo(string userName)
        {
            IUserService userService = (IUserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
            //User userInfo = (User)userService.GetByID(userID, new GetByIDParameters());
            return userService.GetByUserNameT(userName);
        }


        /// <summary>
        ///A test for Check
        ///</summary>
        [TestMethod()]
        public void CheckTest1()
        {
            PersonInfoPreRequisite target = new PersonInfoPreRequisite();
            User userInfo = UserGetUserInfo("testUserNameNeedsPersonRegistration");
            string actual = target.Check(userInfo);
            //Assert.IsTrue(actual.Contains("PersonInsert.aspx"));
            Assert.IsTrue(actual.Contains("Register/Person"));
        }



        /// <summary>
        ///A test for Check
        ///</summary>
        [TestMethod()]
        public void CheckTest2()
        {
            PersonInfoPreRequisite target = new PersonInfoPreRequisite();
            User userInfo = UserGetUserInfo("testUserNameWithoutNeedsForPersonRegistration");
            string expected = null;
            string actual = target.Check(userInfo);
            Assert.AreEqual(expected, actual);
        }

    }
}
