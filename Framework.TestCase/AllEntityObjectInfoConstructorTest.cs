using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase
{
    [TestClass]
    [DeploymentItem("_Config\\")]
    public class AllEntityObjectInfoConstructorTest
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

        private class EntityADK
        {
            public string EntityName;
            public string AdditionalDataKey;
            public EntityADK(string entityName, string additionalDataKey)
            {
                this.EntityName = entityName;
                this.AdditionalDataKey = additionalDataKey;
            }
        }


        [TestMethod()]
        public void memEntities_EN_ConstructorTest()
        {
            List<EntityADK> list = new List<EntityADK>();
            list.Add(new EntityADK(vMembershipArea.EntityName, ""));
            list.Add(new EntityADK(vPermission.EntityName, ""));
            list.Add(new EntityADK(vPermissionType.EntityName, ""));
            list.Add(new EntityADK(vResource.EntityName, ""));
            list.Add(new EntityADK(vResourceType.EntityName, ""));
            list.Add(new EntityADK(vRole.EntityName, ""));
            list.Add(new EntityADK(vUserApprovalStatus.EntityName, ""));
            list.Add(new EntityADK(vUserInRole.EntityName, ""));
            list.Add(new EntityADK(vUser.EntityName, ""));
            list.Add(new EntityADK(vUser.EntityName, UserEN.AdditionalData_Approve));

            TestList(list);
            
        }

        [TestMethod()]
        public void dboEntities_EN_ConstructorTest()
        {
            List<EntityADK> list = new List<EntityADK>();
            list.Add(new EntityADK(vAppEntity.EntityName, ""));
            list.Add(new EntityADK(vAppFile.EntityName, ""));
            list.Add(new EntityADK(vAppFileType.EntityName, ""));
            list.Add(new EntityADK(vAppFileStorageType.EntityName, ""));
            list.Add(new EntityADK(vAppFileUploadStatus.EntityName, ""));
            list.Add(new EntityADK(vAppExceptionLog.EntityName, ""));
            list.Add(new EntityADK(vAppLog.EntityName, ""));
            list.Add(new EntityADK(vAppLogType.EntityName, ""));
            list.Add(new EntityADK(vCountry.EntityName, ""));
            list.Add(new EntityADK(vLanguage.EntityName, ""));
            list.Add(new EntityADK(vMobilePushServer.EntityName, ""));
            list.Add(new EntityADK(vNotification.EntityName, ""));
            list.Add(new EntityADK(vNotificationStatus.EntityName, ""));
            list.Add(new EntityADK(vUser_Language.EntityName, ""));
            list.Add(new EntityADK(vUserDeviceSetting.EntityName, ""));
            list.Add(new EntityADK(vUSState.EntityName, ""));
            list.Add(new EntityADK(vWorldTimeZone.EntityName, ""));

            TestList(list);

        }


        private void TestList(List<EntityADK> list)
        {
            foreach (EntityADK en in list)
                CreateTest(en.EntityName, en.AdditionalDataKey);
        }





        private void CreateTest(string entityName, string additionalDataKey)
        {
            EntityInfoBase en = EntityFactory.GetEntityInfoByName(entityName, additionalDataKey);
            Assert.IsTrue(en != null);
            //Assert.IsTrue(string.IsNullOrEmpty(en.TitleFieldName) == false);
            //Assert.IsTrue(string.IsNullOrEmpty(en.CodeFieldName) == false);
        }



    }
}
