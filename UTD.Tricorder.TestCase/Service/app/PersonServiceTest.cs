using UTD.Tricorder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.BusinessRule;
using System.Collections.Generic;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.TestCase
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for PersonServiceTest and is intended
    ///to contain all PersonServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonServiceTest
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
        ///A test for PersonService Constructor
        ///</summary>
        [TestMethod()]
        public void PersonServiceConstructorTest()
        {
            PersonService target = CreateNewPersonService();
        }

        private PersonService CreateNewPersonService()
        {
            return (PersonService)EntityFactory.GetEntityServiceByName(vPerson.EntityName, "");
        }


        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void InsertPerson()
        {
            PersonService target = CreateNewPersonService();
            User user = GetUserByUserName("testUserNameNeedsPersonRegistration");
            //delete if exists to prevent previous clean up problem
            Person oldP = (Person) target.GetByID(user.UserID, new GetByIDParameters());
            if (oldP != null)
                target.Delete(oldP, new DeleteParameters());

            // inserting new person
            Person newPerson = new Person();
            newPerson.PersonID = user.UserID;
            newPerson.Birthday = DateTime.UtcNow;
            newPerson.GenderTypeID = (int)EntityEnums.GenderTypeEnum.Female;
            newPerson.USStateID = "TX";
            target.Insert(newPerson, new InsertParameters());
            // clean up
            target.Delete(newPerson, new DeleteParameters());
            IUserService service = (IUserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
            User newUser = GetUserByUserName("testUserNameNeedsPersonRegistration");
            newUser.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration;
            service.Update(newUser, new UpdateParameters());
        }

        private User GetUserByUserName(string userName)
        {
            IUserService service = (IUserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
            return service.GetByUserNameT(userName);
        }


    }
}
