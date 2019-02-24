using UTD.Tricorder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.BusinessRule;
using System.Collections.Generic;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.TestCase
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for PaymentServiceTest and is intended
    ///to contain all PaymentServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PaymentServiceTest
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
        ///A test for PaymentService Constructor
        ///</summary>
        [TestMethod()]
        public void PaymentServiceConstructorTest()
        {
            PaymentService target = CreateNewPaymentService();
        }

        private PaymentService CreateNewPaymentService()
        {
            return (PaymentService)EntityFactory.GetEntityServiceByName(vPayment.EntityName, "");
        }


        /// <summary>
        ///A test for CreatePaymentForVisit
        ///It should create one record for one visit
        ///</summary>
        [TestMethod()]
        public void CreatePaymentForVisitTest()
        {
            PaymentService target = CreateNewPaymentService();
            Visit visit = InsertVisit(EntityEnums.VisitStatusEnum.EndSuccess, EntityEnums.PaymentStatusEnum.NotStarted);
            PaymentCreatePaymentForVisitSP p = new PaymentCreatePaymentForVisitSP();
            p.VisitID = visit.VisitID;
            p.Amount = 100;
            p.ServiceChargeAmount = 1;
            target.CreatePaymentForVisit(p);

            // Making sure that record saved in the database
            var filter = new FilterExpression(new Filter(vPayment.ColumnNames.AppEntityRecordIDValue, visit.VisitID));
            filter.AddFilter(new Filter(vPayment.ColumnNames.AppEntityID, (int)EntityEnums.PaymentEntityEnum.Visit));
            var list = target.GetByFilter(new GetByFilterParameters(filter, new SortExpression(),0, 1, null, GetSourceTypeEnum.View));
            DeleteVisit(visit.VisitID);

            Assert.AreEqual(list.Count, 1);
            foreach (vPayment payment in list)
            {
                Assert.AreEqual(payment.PaymentStatusID, (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey);
            }
        }

        private Visit InsertVisit(EntityEnums.VisitStatusEnum visitStatusEnum, EntityEnums.PaymentStatusEnum paymentStatusEnum)
        {
            return UTD.Tricorder.Service.Tests.VisitServiceTests.InsertVisit(visitStatusEnum, paymentStatusEnum);
        }

        private void DeleteVisit(long visitId)
        {
            UTD.Tricorder.Service.Tests.VisitServiceTests.DeleteVisit(visitId);
        }

        /// <summary>
        /// Happy senario:
        /// PaymentStatusID = PendingWithoutPayKey
        /// </summary>
        [TestMethod()]
        public void UpdatePayPalKeyTest()
        {
            const long testRecordID = 201;

            PaymentService target = CreateNewPaymentService();
            target.UpdatePayPalKey(testRecordID);

            Payment payment = (Payment)target.GetByID(testRecordID, new GetByIDParameters());
            int actualPaymentStatusID = payment.PaymentStatusID;
            string actualPayKey = payment.PayKey;

            //------- Reset test settings ---------//
            payment.PayKey = null;
            payment.PaymentStatusID = (int) EntityEnums.PaymentStatusEnum.PendingWithoutPayKey;
            target.Update(payment, new UpdateParameters());
            //------- Reset test settings ---------//

            Assert.AreEqual((int)EntityEnums.PaymentStatusEnum.PendingWithPayKey, actualPaymentStatusID);
            Assert.IsTrue(string.IsNullOrEmpty(actualPayKey) == false);
        }


        [TestMethod()]
        public void CompletePaymentTest()
        {
            const string testPayKey = "AP-5B6532919Y667353L";
            const long paymentId = 202;

            PaymentService target = CreateNewPaymentService();
            var payment = target.CompletePayment(paymentId);

            int actualPaymentStatusID = payment.PaymentStatusID;
            DateTime? actualPaymentDateTime = payment.CompletedDateTime;

            //------- Reset test settings ---------//
            payment.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey;
            payment.CompletedDateTime = null;
            target.Update(payment, new UpdateParameters());
            //------- Reset test settings ---------//

            Assert.AreEqual(testPayKey, payment.PayKey);
            Assert.AreEqual((int)EntityEnums.PaymentStatusEnum.Done, actualPaymentStatusID);
            Assert.IsTrue(actualPaymentDateTime != null);
        }


        // We can't have Automated testing for Refund because once refunded in PayPal
        // Can't be canceled.

        //[TestMethod()]
        //public void RefundPaymentTest()
        //{
        //    const string testPayKey = "AP-5B6532919Y667353L";
        //    const long paymentId = 202;

        //    PaymentService target = CreateNewPaymentService();
        //    var payment = target.CompletePayment(paymentId);

        //    int actualPaymentStatusID = payment.PaymentStatusID;
        //    DateTime? actualPaymentDateTime = payment.CompletedDateTime;

        //    //------- Reset test settings ---------//
        //    payment.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.Done;
        //    target.Update(payment, new UpdateParameters());
        //    //------- Reset test settings ---------//

        //    Assert.AreEqual(testPayKey, payment.PayKey);
        //    Assert.AreEqual((int)EntityEnums.PaymentStatusEnum.Done, actualPaymentStatusID);
        //    Assert.IsTrue(actualPaymentDateTime != null);
        //}




    }
}
