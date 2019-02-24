using UTD.Tricorder.BusinessRule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using Framework.Business;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using System.Collections.Generic;
using Framework.TestCase.CommonClasses;

namespace UTD.Tricorder.TestCase
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for UserBRTest and is intended
    ///to contain all UserBRTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserBRTest
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
         
        ////You can use the following additional attributes as you write your tests:
        
        ////Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        
        ////Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        
        ////Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        
        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        
        #endregion



        private UserBR CreateNewUserBR()
        {
            return (UserBR)EntityFactory.GetEntityBusinessRuleByName(vUser.EntityName, "");
        }

        private User CreateNewUserObject()
        {
            return (User)EntityFactory.GetEntityObject(vUser.EntityName, GetSourceTypeEnum.Table);
        }


        /// <summary>
        ///A test for UserBR Constructor
        ///</summary>
        [TestMethod()]
        public void UserBRConstructorTest()
        {
            UserBR target = CreateNewUserBR();
        }


        /// <summary>
        ///A test for CheckRules
        ///</summary>
        [TestMethod()]
        public void CheckRulesTest()
        {
            UserBR target = CreateNewUserBR();
            User user = CreateNewUserObject();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            target.CheckRules(user, fnName, errors);
            Assert.IsTrue(errors.Count > 5);
        }

        /// <summary>
        ///A test for CheckRules
        ///</summary>
        [TestMethod()]
        public void CheckRulesTest2()
        {
            UserBR target = CreateNewUserBR();
            
            User user = CreateNewUserObject();
            user.Email = "validEmail@gmail.com";
            user.UserName = "validUserName";

            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            target.CheckRules(user, fnName, errors);
            Assert.IsTrue(errors.Count > 3);
        }



        /// <summary>
        ///A test for ValidateEmail
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest()
        {
            UserBR target = CreateNewUserBR(); 
            string value = "testemail@testdomain.com";
            Nullable<long> idValue = null;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert; 
            bool throwIfErrors = false; 
            bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmail
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest2()
        {
            UserBR target = CreateNewUserBR();
            string value = "testemailstringwithoutdomain";
            Nullable<long> idValue = null;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = false;
            bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for ValidateEmail
        /////</summary>
        //[TestMethod()]
        //public void ValidateEmailTest3()
        //{
        //    // validating null or empty email entering

        //    UserBR target = CreateNewUserBR();
        //    string value = "";
        //    Nullable<long> idValue = null;
        //    BusinessRuleErrorList errors = new BusinessRuleErrorList();
        //    RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
        //    bool throwIfErrors = false;
        //    bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
        //    bool expected = false;
        //    Assert.AreEqual(expected, actual);
        //}

        /// <summary>
        ///A test for ValidateEmail
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest4()
        {
            UserBR target = CreateNewUserBR();
            string value = "ایمیلدرزباندیگر@دامینزباندیگر.کام";
            Nullable<long> idValue = null;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = false;
            bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmail
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest5()
        {
            UserBR target = CreateNewUserBR();
            string value = "ValidRegisteredEmailTest@testdomain.com";
            Nullable<long> idValue = 1;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = false;
            bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmail
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest6()
        {
            UserBR target = CreateNewUserBR();
            string value = "ValidRegisteredEmailTest@testdomain.com";
            Nullable<long> idValue = 2;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = false;
            bool actual = target.ValidateEmail(value, idValue, errors, fnName, throwIfErrors);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest()
        {
            UserBR target = CreateNewUserBR(); 
            string value = null; 
            Nullable<long> idValue = null; 
            BusinessRuleErrorList errors = new BusinessRuleErrorList(); 
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert; 
            bool throwIfErrors = false; 
            bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest2()
        {
            UserBR target = CreateNewUserBR();
            string value = TestUtils.RandomUtils.RandomUserName();
            Nullable<long> idValue = null;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = false;
            bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest3()
        {
            // we want to change a user name of a registered existing id value
            UserBR target = CreateNewUserBR();
            string value = TestUtils.RandomUtils.RandomUserName();
            Nullable<long> idValue = 1;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = false;
            bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest4()
        {
            UserBR target = CreateNewUserBR();
            string value = "testExistingUserName";
            Nullable<long> idValue = null;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = false;
            try
            {
                bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
                Assert.AreNotEqual(actual, true);
            }
            catch (Exception)
            {
                Assert.AreEqual(0, errors.Count);
                // if error happened everything is fine
            }
        }

        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest5()
        {
            UserBR target = CreateNewUserBR();
            string value = "testExistingUserName";
            Nullable<long> idValue = 1;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = false;
            bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest6()
        {
            UserBR target = CreateNewUserBR();
            string value = "testExistingUserName";
            Nullable<long> idValue = 2;
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Update;
            bool throwIfErrors = true;
            try
            {
                bool actual = target.ValidateUserName(value, idValue, errors, fnName, throwIfErrors);
            }
            catch (BRException ex)
            {
                Assert.AreEqual(BusinessErrorStrings.User.UserName_DuplicateUserName, ex.RuleErrors[0].ErrorDescription);
            }
            catch (Exception)
            {
                throw;
            }
            
        }



        /// <summary>
        ///A test for ValidateUserName
        ///some valid usernames
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest7()
        {
            UserBR target = CreateNewUserBR();
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = true;

            List<string> validUserNames = new List<string>();

            validUserNames.Add("Mohammad.Ali.Ghaderi");
            validUserNames.Add("Mohammad_Ali_Ghaderi");
            validUserNames.Add("Mohammad1234");
            validUserNames.Add("Mohammad.Ali.Ghaderi");
            validUserNames.Add("testVerylongUsernameWithoutAnySpecialCharacter1234");

            for (int i = 0; i < validUserNames.Count; i++)
            {
                target.ValidateUserName(validUserNames[i], null, errors, fnName, throwIfErrors);
            }

        }



        /// <summary>
        ///A test for ValidateUserName
        ///Testing invalid values
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest8()
        {
            UserBR target = CreateNewUserBR();
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = false;

            List<string> validUserNames = new List<string>();

            //validUserNames.Add("1Mohammad.Ali.Ghaderi"); // starts with number
            validUserNames.Add("Mohammad._Ali_Ghaderi"); // has two characters ._
            validUserNames.Add("Mohammad.Ali_.Ghaderi"); // has two characters _.
            validUserNames.Add("Mohammad1234.");  // ends with .
            validUserNames.Add(".Mohammad1234");  // starts with a symbol
            validUserNames.Add("_Mohammad1234");  // starts with a symbol
            validUserNames.Add("Mohammad!Ali");  // Contains invalid symbol
            validUserNames.Add("Mohammad Ali");  // Contains invalid symbol

            for (int i = 0; i < validUserNames.Count; i++)
            {
                bool isValid = target.ValidateUserName(validUserNames[i], null, errors, fnName, throwIfErrors);
                if (isValid)
                    throw new Exception(validUserNames[i] + " shouldn't be a valid user name.");
            }

        }



        /// <summary>
        ///A test for ValidateUserName
        /// randomizing 100 samples
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest9()
        {
            UserBR target = CreateNewUserBR();
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            RuleFunctionSEnum fnName = RuleFunctionSEnum.Insert;
            bool throwIfErrors = true;

            for (int i = 0; i < 100; i++)
            {
                string userName = TestUtils.RandomUtils.RandomUserName();
                target.ValidateUserName(userName, null, errors, fnName, throwIfErrors);
            }

        }



    }
}
