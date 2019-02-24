using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Common.EntityObjects;
using Framework.TestCase.Common;
using Framework.TestCase.CommonClasses;
using Framework.Common;

namespace Framework.TestCase.Common.Utils
{
    [TestClass()]
    public class SecurityUtilsTests
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestUtils.Access.SetPrivateStaticField(typeof(FWUtils), "_SecurityUtils", new SecurityUtilsFake(TestEnums.User.constPatientUserID));
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
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



        [TestMethod()]
        public void FakeSetupTest()
        {
            long? l = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            Assert.AreEqual(TestEnums.User.constPatientUserID, l.Value);
        }


        ///// <summary>
        ///// Access to invalid resource should be false
        ///// </summary>
        //[TestMethod()]
        //public void HasAccessInvalidResourceTest()
        //{
        //    throw new NotImplementedException();
        //    string resourceCode = "InvalidResource";
        //    bool expected = false;
        //    bool actual = FWUtils.SecurityUtils.HasAccess(resourceCode, false);
        //    Assert.AreEqual(expected, actual);
        //}

        ///// <summary>
        ///// Access to invalid resource should throw a SecurityException
        ///// </summary>
        //[TestMethod()]
        //public void HasAccessTest2()
        //{
        //    throw new NotImplementedException();

        //    string resourceCode = "InvalidResource";
        //    bool expected = false;
        //    try
        //    {
        //        bool actual = FWUtils.SecurityUtils.HasAccess(resourceCode, false);
        //    }
        //    catch (ServiceSecurityException ex)
        //    {
        //        Assert.IsTrue(ex.Message.StartsWith(StringMsgs.Exceptions.AccessDenied_));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// Access to invalid resource should throw a SecurityException
        /// </summary>
        [TestMethod()]
        public void HasAccessValidAccessTest()
        {
            string resourceCode = "Menu";
            bool expected = true;
            bool actual = FWUtils.SecurityUtils.HasAccess(resourceCode, false);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void HasRoleInvalidRoleTest()
        {
            string roleCode = "InvalidRole";
            bool expected = false;
            bool actual = FWUtils.SecurityUtils.HasRole(roleCode);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void HasRolePatientTest()
        {
            string roleCode = EntityEnums.RoleSEnum.Patient;
            bool expected = true;
            bool actual = FWUtils.SecurityUtils.HasRole(roleCode);
            Assert.AreEqual(expected, actual);
        }



    }
}
