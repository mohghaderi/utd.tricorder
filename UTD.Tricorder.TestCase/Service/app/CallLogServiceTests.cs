using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;
using Framework.Common;
using Framework.TestCase.CommonClasses;


namespace UTD.Tricorder.Service.Tests
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class CallLogServiceTests
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
        public void VisitCallPatientTest()
        {
            long testVisitID = 201;

            var visit = VisitEN.GetService().GetByIDV(testVisitID);


            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            var target = CallLogEN.GetService();
            var actual = target.VisitCallPatient(new CallLogVisitCallPatientSP()
            {
                VisitID = testVisitID
            });

            Assert.AreEqual(visit.PatientUserID, actual.ReceiverUserID);
            Assert.AreEqual(visit.PatientFullName, actual.ReceiverFullName);

            DateTime afewSecondsAgoDate = DateTime.UtcNow.AddSeconds(-3);
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vCallLog.ColumnNames.AppEntityID, (short)EntityEnums.AppEntityEnum.Visit);
            filter.AddFilter(vCallLog.ColumnNames.EntityRecordID, testVisitID);
            filter.AddFilter(vCallLog.ColumnNames.StartDate, afewSecondsAgoDate, FilterOperatorEnum.GreaterThan);
            filter.AddFilter(vCallLog.ColumnNames.ReceiverUserID, visit.PatientUserID);

            Assert.IsTrue(target.GetCount(filter) > 0, "CallLog should be written to CallLog table");

            FilterExpression f2 = new FilterExpression();
            f2.AddFilter(vMobilePushNotification.ColumnNames.InsertDate, afewSecondsAgoDate, FilterOperatorEnum.GreaterThan);
            f2.AddFilter(vMobilePushNotification.ColumnNames.MobilePushTemplateID, (byte)EntityEnums.MobilePushTemplateType.Call_PhoneRing);

            Assert.IsTrue(MobilePushNotificationEN.GetService().GetCount(f2) > 0, "MobilePushNotification should be called");
        }

        [TestMethod()]
        public void EndCallTest()
        {
            long testVisitID = 202;

            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            var target = CallLogEN.GetService();
            var actual = target.VisitCallPatient(new CallLogVisitCallPatientSP()
            {
                VisitID = testVisitID
            });

            System.Threading.Thread.Sleep(3000);

            target.EndCall(new CallLogEndCallSP()
            {
                CallLogID = actual.CallLogID
            });

            var updatedCall = target.GetByIDV(actual.CallLogID, new GetByIDParameters());
            Assert.AreEqual((byte)EntityEnums.CallStatus.Ended, updatedCall.CallStatusID);
            Assert.IsTrue(updatedCall.DurationSeconds >= 1 && updatedCall.DurationSeconds <= 10, "DurationSeconds should be greater than one and less than 10");
            Assert.IsTrue(updatedCall.EndDate.HasValue, "EndDate should have value when call ended");
            Assert.IsTrue(Convert.ToInt32((updatedCall.EndDate.Value - updatedCall.StartDate).TotalSeconds) == updatedCall.DurationSeconds, "DurationSeconds should be contain totalseconds of the call");
        }

        [TestMethod()]
        public void AnswerCallTest()
        {
            long testVisitID = 203;

            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            var target = CallLogEN.GetService();
            var actual = target.VisitCallPatient(new CallLogVisitCallPatientSP()
            {
                VisitID = testVisitID
            });

            TestUtils.Security.SetCurrentUser(TestEnums.User.constPatientUserID);

            target.AnswerCall(new CallLogAnswerCallSP()
            {
                CallLogID = actual.CallLogID
            });

            var updatedCall = target.GetByIDV(actual.CallLogID, new GetByIDParameters());
            Assert.AreEqual((byte)EntityEnums.CallStatus.CalleeAnswered, updatedCall.CallStatusID);
        }

        [TestMethod()]
        public void DeclineCallTest()
        {
            long testVisitID = 204;

            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            var target = CallLogEN.GetService();
            var actual = target.VisitCallPatient(new CallLogVisitCallPatientSP()
            {
                VisitID = testVisitID
            });

            TestUtils.Security.SetCurrentUser(TestEnums.User.constPatientUserID);

            target.DeclineCall(new CallLogDeclineCallSP()
            {
                CallLogID = actual.CallLogID
            });

            var updatedCall = target.GetByIDV(actual.CallLogID, new GetByIDParameters());
            Assert.AreEqual((byte) EntityEnums.CallStatus.Declined, updatedCall.CallStatusID);
        }


        [TestMethod()]
        public void CancelCallTest()
        {
            long testVisitID = 204;

            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            var target = CallLogEN.GetService();
            var actual = target.VisitCallPatient(new CallLogVisitCallPatientSP()
            {
                VisitID = testVisitID
            });

            target.CancelCall(new CallLogCancelCallSP()
            {
                CallLogID = actual.CallLogID
            });

            var updatedCall = target.GetByIDV(actual.CallLogID, new GetByIDParameters());
            Assert.AreEqual((byte)EntityEnums.CallStatus.Cancelled, updatedCall.CallStatusID);
        }


    }
}
