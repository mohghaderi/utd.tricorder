using Framework.Common;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Service.NotificationSystem;
using UTD.Tricorder.TestCase;


namespace UTD.Tricorder.Common.Tests
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class NotificationSenderAgentTests
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

        static NotificationSenderAgent agent;


        ////You can use the following additional attributes as you write your tests:

        ////Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            agent = new NotificationSenderAgent();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            agent.Dispose();
        }

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



        //[TestMethod()]
        //public void DoActionTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DoActionTest1()
        //{
        //    Assert.Fail();
        //}




        [TestMethod()]
        public void GetPendingNotificationListTest()
        {
            List<vNotification> list = NotificationSenderAgent.GetPendingNotificationList();
            foreach (vNotification item in list)
            {
                bool checkSMS = true;
                if (item.IsEmail)
                {
                    if (item.EmailNotificationStatusID != (int)EntityEnums.NotificationStatusEnum.Pending)
                    {
                        Assert.Fail("EmailNotificationStatusID should be pending for GetPendingNotificationList function");
                    }
                    else
                        checkSMS = false;
                }
                if (checkSMS) // if it was not email pending check SMS status
                {
                    if (item.SMSNotificationStatusID != (int)EntityEnums.NotificationStatusEnum.Pending
                        && item.IsSMS)
                    {
                        Assert.Fail("SMSNotificationStatusID should be pending for GetPendingNotificationList function");
                    }
                }

            }
        }

        [TestMethod()]
        public void SendNotificationTest()
        {
            Notification notification = CreateNewNotification((short)EntityEnums.NotificationTemplateEnum.TestNotification);
            notification.IsSMS = true;
            notification.IsMobilePushMessage = true;

            INotificationService service = (INotificationService)
                    EntityFactory.GetEntityServiceByName(vNotification.EntityName, "");
            service.Insert(notification, new InsertParameters());
            vNotification nSaved = (vNotification)service.GetByID(notification.NotificationID, new GetByIDParameters(GetSourceTypeEnum.View));

            NotificationSenderAgent.SendNotification(nSaved);

            // Check that log inserted for all notifications (no error happened anywhere)
            IAppLogService logService = (IAppLogService)
                EntityFactory.GetEntityServiceByName(AppLog.EntityName, "");
            FilterExpression filter = new FilterExpression(new Filter(AppLog.ColumnNames.ExtraBigInt, nSaved.NotificationID));
            FilterExpression f2 = new FilterExpression();
            f2.AddFilter(new Filter(AppLog.ColumnNames.AppLogTypeID, (int)EntityEnums.AppLogType.Notify_Email));
            f2.AddFilter(new Filter(AppLog.ColumnNames.AppLogTypeID, (int)EntityEnums.AppLogType.Notify_MobilePush));
            f2.AddFilter(new Filter(AppLog.ColumnNames.AppLogTypeID, (int)EntityEnums.AppLogType.Notify_SMS));
            f2.LogicalOperator = FilterLogicalOperatorEnum.OR;
            filter.AndMerge(f2);

            long logCount = logService.GetCount(filter);
            Assert.AreEqual(2, logCount, "EMAIL, SMS has not saved in logs. So, error in media");

            // check that all parameters are valid after save
            vNotification nSaved2 = (vNotification)service.GetByID(notification.NotificationID, new GetByIDParameters(GetSourceTypeEnum.View));
            Assert.IsNull(nSaved2.NotificationErrorMessage);
            Assert.IsNotNull(nSaved2.EmailSendDate);
            Assert.IsNotNull(nSaved2.SMSSendDate);
        }

        [TestMethod()]
        /// <summary>
        /// Saves a new notification email by email in database and delivers it by email
        /// </summary>
        public void DoActionEmailTest()
        {
            agent.TimerInterval = 100;
            agent.StartAgent(); 
            
            Notification notification = CreateNewNotification((short)EntityEnums.NotificationTemplateEnum.TestNotification);
            // insert a new notification
            INotificationService service = (INotificationService)
                EntityFactory.GetEntityServiceByName(vNotification.EntityName, "");
            service.Insert(notification, new InsertParameters());

            // wait for agent on another thread to send the notification
            System.Threading.Thread.Sleep(5000);

            // check saved notification to have sent status
            Notification nSaved = (Notification) service.GetByID(notification.NotificationID, new GetByIDParameters());
            Assert.AreEqual((int)EntityEnums.NotificationStatusEnum.Sent, nSaved.EmailNotificationStatusID, "EmailNotificationStatusID should be EntityEnums.NotificationStatusEnum.Sent");
            Assert.AreNotEqual(null, nSaved.EmailSendDate);
            Assert.IsTrue(string.IsNullOrEmpty(nSaved.NotificationErrorMessage));

        }

        /// <summary>
        /// Creates the new notification.
        /// </summary>
        /// <returns></returns>
        public static Notification CreateNewNotification(short notificationTemplateID)
        {
            Notification notification;

            notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.EmailSendDate = null;
            notification.SMSSendDate = null;
            notification.SenderUserID = (int)TestEnums.User.constDoctorID;
            notification.ReceiverUserID = (int)TestEnums.User.constPatientUserID;
            notification.NotificationTemplateID = notificationTemplateID;
            TemplateParams p = new TemplateParams();
            p.AddParameter("CustomParameter", "CustomParameterValue");
            notification.ParametersValues = p.SerializeToString();
            notification.SMSNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.EmailNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.NotificationErrorMessage = null;
            notification.IsSMS = false;
            notification.IsEmail = true;
            notification.IsWebMessage = true;
            notification.IsMobilePushMessage = false;
            notification.GotoURL = null;

            return notification;
        }



    }
}
