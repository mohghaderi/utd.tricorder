using Framework.Common;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;
using UTD.Tricorder.TestCase;

namespace UTD.Tricorder.Service.Tests
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class VisitServiceTests
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

        private IVisitService GetNewVisitService()
        {
            return (IVisitService)
                EntityFactory.GetEntityServiceByName(vVisit.EntityName, "");
        }


        [TestMethod()]
        public void GetCurrentDoctorVisitsByDateTest()
        {
            IVisitService target = GetNewVisitService();
            long doctorId = TestEnums.User.constDoctorID;
            DateTime selectedDate = DateTime.Parse("2020-06-25 12:15:00");
            List<vVisit> visitInfo = target.GetDoctorVisitsByDate(doctorId, selectedDate);
            Assert.IsTrue(visitInfo.Count > 0, "VisitInfo.Count should be greater than 0.");
        }

        [TestMethod()]
        public void CancelVisitTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.Scheduled, EntityEnums.PaymentStatusEnum.NotStarted);
            IVisitService target = GetNewVisitService();
            target.CancelVisit(visit.VisitID);

            Visit visitAfterCancel = target.GetByIDT(visit.VisitID, new GetByIDParameters());
            int expectedVisitStatus = (int)EntityEnums.VisitStatusEnum.Cancelled;
            Assert.AreEqual(expectedVisitStatus, visitAfterCancel.VisitStatusID);

            DeleteVisit(visit.VisitID);
        }

        [TestMethod()]
        public void RescheduleVisitTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.Scheduled, EntityEnums.PaymentStatusEnum.NotStarted);
            IVisitService target = GetNewVisitService();
            long newScheduleID = 2; // it converts from 1 to 2
            target.RescheduleVisit(new VisitRescheduleVisitSP() {
                VisitID = visit.VisitID,
                NewDoctorScheduleID = newScheduleID
            });

            Visit visitAfter = target.GetByIDT(visit.VisitID, new GetByIDParameters());
            Assert.AreEqual(newScheduleID, visitAfter.DoctorScheduleID);

            DeleteVisit(visit.VisitID);
        }

        //[TestMethod()]
        //public void UpdateDoctorReportTest()
        //{
        //    TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

        //    IVisitService target = GetNewVisitService();
        //    Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.Scheduled, EntityEnums.PaymentStatusEnum.NotStarted);
        //    string newDoctorReport = "This is a test doctor report.";
        //    target.UpdateDoctorReport(visit.VisitID, newDoctorReport);

        //    Visit visitAfter = target.GetByIDT(visit.VisitID, new GetByIDParameters());
        //    Assert.AreEqual(newDoctorReport, visitAfter.DoctorReport);

        //    DeleteVisit(visit.VisitID);
        //}

        [TestMethod]
        public void GetSectionValuesSysReview()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);
            long visitID = 1;

            string expected = "{\"TestJson\":\"TestJsonValue\"}";
            IVisitService target = GetNewVisitService();
            VisitGetSectionSP p = new VisitGetSectionSP();
            p.SectionName = "SysReview";
            p.VisitID = visitID;
            string actual = target.GetSectionValues(p);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveSectionSysReview()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            IVisitService target = GetNewVisitService();
            Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.Scheduled, EntityEnums.PaymentStatusEnum.NotStarted);
            VisitSaveSectionSP p = new VisitSaveSectionSP();
            p.VisitID = visit.VisitID;
            p.SectionName = "SysReview";
            p.SectionValuesJson = "{ }";
            target.SaveSection(p);

            Visit visitAfter = target.GetByIDT(visit.VisitID, new GetByIDParameters());
            Assert.AreEqual(p.SectionValuesJson, visitAfter.DoctorSystemReviewJson);
        }

        [TestMethod]
        public void CompleteVisit_ReverseToRescheduled()
        {
            // inserts a new visit, tries to complete it first, then revert it to scheduled position again
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            IVisitService target = GetNewVisitService();
            Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.Scheduled, EntityEnums.PaymentStatusEnum.NotStarted);
            target.CompleteVisit(visit.VisitID);
            Visit visitAfter = target.GetByIDT(visit.VisitID, new GetByIDParameters());
            Assert.AreEqual(visitAfter.VisitStatusID, (int)EntityEnums.VisitStatusEnum.EndSuccess, "CompleteVisit didn't work successfully");

            target.UndoStatusToRescheduled(visit.VisitID);
            Visit visitAfter2 = target.GetByIDT(visit.VisitID, new GetByIDParameters());
            Assert.AreEqual(visitAfter2.VisitStatusID, (int)EntityEnums.VisitStatusEnum.Scheduled, "ReverseToRescheduled didn't work successfully");

            target.Delete(visitAfter2, new DeleteParameters());
        }


        /// <summary>
        /// Inserts a new visit in database
        /// </summary>
        /// <param name="visitStatusID">The visit status identifier.</param>
        /// <param name="paymentStatusID">The payment status identifier.</param>
        /// <returns></returns>
        public static Visit InsertVisit(EntityEnums.VisitStatusEnum visitStatusID, EntityEnums.PaymentStatusEnum paymentStatusID)
        {
            IVisitService visitService = (IVisitService)EntityFactory.GetEntityServiceByName(vVisit.EntityName, "");
            Visit v = new Visit();
            v.PatientUserID = TestEnums.User.constPatientUserID;
            v.DoctorScheduleID = 1; // const for service of doctor 1
            v.VisitStatusID = (int)visitStatusID;
            v.IllnessID = 0; // no specified
            //v.PaymentStatusID = (int)paymentStatusID;
            visitService.Insert(v, new InsertParameters());
            return v;
        }

        public static void DeleteVisit(long visitId)
        {
            IVisitService visitService = (IVisitService)EntityFactory.GetEntityServiceByName(vVisit.EntityName, "");
            Visit v = visitService.GetByIDT(visitId, new GetByIDParameters());
            visitService.Delete(v, new DeleteParameters()); 
        }

        

    }
}
