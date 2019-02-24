using UTD.Tricorder.Common.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Business;
using Framework.DataAccess;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.TestCase
{
    
    
    /// <summary>
    ///This is a test class for ProjectEntityFactoryTest and is intended
    ///to contain all ProjectEntityFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectEntityFactoryTest
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
        ///A test for ProjectEntityFactory Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectEntityFactoryConstructorTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
        }

        /// <summary>
        ///A test for GetEntityBusinessRuleByName
        ///</summary>
        [TestMethod()]
        public void GetEntityBusinessRuleByNameTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
            string entityName = vTestCaseTester.EntityName; 
            string additionalDataKey = ""; 
            IBusinessRuleBase expected = null;
            IBusinessRuleBase actual;
            actual = target.GetEntityBusinessRuleByName(entityName, additionalDataKey);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityDataAccessByName
        ///</summary>
        [TestMethod()]
        public void GetEntityDataAccessByNameTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
            string entityName = vTestCaseTester.EntityName;
            string additionalDataKey = ""; 
            IDataAccessBase expected = null; 
            IDataAccessBase actual;
            actual = target.GetEntityDataAccessByName(entityName, additionalDataKey);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityInfoByName
        ///</summary>
        [TestMethod()]
        public void GetEntityInfoByNameTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
            string entityName = vTestCaseTester.EntityName;
            string additionalDataKey = ""; 
            EntityInfoBase expected = null;
            EntityInfoBase actual;
            actual = target.GetEntityInfoByName(entityName, additionalDataKey);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityObject
        ///</summary>
        [TestMethod()]
        public void GetEntityObjectTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory(); 
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            object expected = null; 
            object actual;
            actual = target.GetEntityObject(entity.EntityName, GetSourceTypeEnum.Table);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityObject
        ///</summary>
        [TestMethod()]
        public void GetEntityObjectTest2()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            object expected = null;
            object actual;
            actual = target.GetEntityObject(entity.EntityName, GetSourceTypeEnum.View);
            Assert.AreNotEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetEntityServiceByName
        ///</summary>
        [TestMethod()]
        public void GetEntityServiceByNameTest()
        {
            ProjectEntityFactory target = new ProjectEntityFactory();
            string entityName = vTestCaseTester.EntityName;
            string additionalDataKey = ""; 
            IServiceBase expected = null; 
            IServiceBase actual;
            actual = target.GetEntityServiceByName(entityName, additionalDataKey);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
