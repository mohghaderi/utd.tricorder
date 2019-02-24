using Framework.Business;
using Framework.Common;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.TestCase.Service.app;

namespace UTD.Tricorder.TestCase.BusinessRule.app
{
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for DoctorSchedule
    ///</summary>
    [TestClass()]
    public class DoctorScheduleBRTest
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

        [TestMethod()]
        public void InsertTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            // happy scenario insert without any problem
            var doctorSchedule = DoctorScheduleServiceTest.CreateNewDoctorSchedule();
            DoctorScheduleBR doctorScheduleBR = (DoctorScheduleBR)EntityFactory.GetEntityBusinessRuleByName(vDoctorSchedule.EntityName, "");
            BusinessRuleErrorList errorsList = new BusinessRuleErrorList();
            doctorScheduleBR.CheckRules(doctorSchedule, RuleFunctionSEnum.Insert, errorsList);
            Assert.AreEqual(0, errorsList.Count);
        }

        [TestMethod()]
        public void InsertDuplicateTest()
        {
            string existingDateTimeInDatabase = "2020-06-25 12:15:00.000";
            var doctorSchedule = DoctorScheduleServiceTest.CreateNewDoctorSchedule();
            doctorSchedule.SlotUnixEpoch = DateTimeEpoch.ConvertDateToSecondsEpoch(DateTime.Parse(existingDateTimeInDatabase));
            DoctorScheduleBR doctorScheduleBR = (DoctorScheduleBR)EntityFactory.GetEntityBusinessRuleByName(vDoctorSchedule.EntityName, "");
            BusinessRuleErrorList errorsList = new BusinessRuleErrorList();
            doctorScheduleBR.CheckRules(doctorSchedule, RuleFunctionSEnum.Insert, errorsList);
            if (errorsList.Count > 0)
                Assert.AreEqual(BusinessErrorStrings.DoctorSchedule.TimeAllocatedBefore, errorsList[0].ErrorDescription);
            Assert.AreEqual(1, errorsList.Count);
        }






    }
}
