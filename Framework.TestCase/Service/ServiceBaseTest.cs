using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using Framework.Common.Entity;
using Framework.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Service
{
    
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for ServiceBaseTest and is intended
    ///to contain all ServiceBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServiceBaseTest
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

        private EntityObjectBase CreateNewT<T, V>()
        {
            TestCaseTester tester = new TestCaseTester();
            Guid g = Guid.NewGuid();
            tester.TestCaseTesterID = g;

            return (EntityObjectBase)(object)tester;
        }


        /// <summary>
        ///A test for Delete
        ///</summary>
        public void DeleteTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();

            EntityObjectBase tester = CreateNewT<T, V>();

            long entityCounts = target.GetCount(null);

            target.Insert(tester, new InsertParameters());

            Assert.AreEqual(entityCounts + 1, target.GetCount(null));

            object entitySet = target.GetByID(tester.GetPrimaryKeyValue(), new GetByIDParameters());

            Assert.AreNotEqual(entitySet, null);
            target.Delete(entitySet, new DeleteParameters());

            Assert.AreEqual(entityCounts, target.GetCount(null));
        }

        internal virtual ServiceBase<T, V> CreateServiceBase<T, V>()
        {
            // TODO: Instantiate an appropriate concrete class.
            ServiceBase<T, V> target = (ServiceBase<T, V>)EntityFactory.GetEntityServiceByName(vTestCaseTester.EntityName, "");
            return target;
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeleteTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for DeleteT
        ///</summary>
        public void DeleteTTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();
            EntityObjectBase tester = CreateNewT<T, V>();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));
            T entitySet = target.GetByIDT(tester.GetPrimaryKeyValue(), new GetByIDParameters());

            Assert.AreNotEqual(entitySet, null);
            target.DeleteT(entitySet, new DeleteParameters());

            Assert.AreEqual(entityCounts, target.GetCount(null));
        }

        [TestMethod()]
        public void DeleteTTest()
        {
            DeleteTTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        public void GetAllTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>(); 
            ICollection actual;
            actual = target.GetAll();
            long count = target.GetCount(new FilterExpression());
            Assert.AreEqual(count, actual.Count);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GetAllTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for GetAllT
        ///</summary>
        public void GetAllTTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();
            long count = target.GetCount(new FilterExpression());
            ICollection<T> actual;
            actual = target.GetAllT();
            Assert.AreEqual(count, actual.Count);
        }

        [TestMethod()]
        public void GetAllTTest()
        {
            GetAllTTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for GetByFilter
        ///</summary>
        public void GetByFilterTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();

            EntityObjectBase tester = CreateNewT<T, V>();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));

            FilterExpression f = new FilterExpression(new Filter(vTestCaseTester.ColumnNames.TestCaseTesterID, tester.GetPrimaryKeyValue()));
            GetByFilterParameters parameters = new GetByFilterParameters(f, new SortExpression(vTestCaseTester.ColumnNames.InsertDate));
            ICollection actual;
            actual = target.GetByFilter(parameters);
            long expectedCount = 1;
            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod()]
        public void GetByFilterTest()
        {
            GetByFilterTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for GetByFilterT
        ///</summary>
        public void GetByFilterTTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();

            EntityObjectBase tester = CreateNewT<T, V>();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));

            FilterExpression f = new FilterExpression(new Filter(vTestCaseTester.ColumnNames.TestCaseTesterID, tester.GetPrimaryKeyValue()));
            GetByFilterParameters parameters = new GetByFilterParameters(f, new SortExpression(vTestCaseTester.ColumnNames.InsertDate));
            ICollection<T> actual;
            actual = target.GetByFilterT(parameters);
            long expectedCount = 1;
            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod()]
        public void GetByFilterTTest()
        {
            GetByFilterTTestHelper<TestCaseTester, vTestCaseTester>();
        }


        /// <summary>
        ///A test for GetByIDT
        ///</summary>
        public void GetByIDTTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();
            EntityObjectBase tester = CreateNewMinTester();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));
            T actual = target.GetByIDT(tester.GetPrimaryKeyValue(), new GetByIDParameters());

            Assert.AreNotEqual(null, actual);
        }

        [TestMethod()]
        public void GetByIDTTest()
        {
            GetByIDTTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for GetCount
        ///</summary>
        public void GetCountTestHelper<T, V>()
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();

            EntityObjectBase tester = CreateNewT<T, V>();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));

            T entitySet = target.GetByIDT(tester.GetPrimaryKeyValue(), new GetByIDParameters());

            EntityObjectBase actual = (EntityObjectBase)(object)entitySet;

            // all fields should have equal values
            List<string> colNames = vTestCaseTester.GetColumnNamesList();
            foreach (string colName in colNames)
                if (colName != vTestCaseTester.ColumnNames.FieldTimeStamp
                    && colName != vTestCaseTester.ColumnNames.FieldByteArray50
                    && colName != vTestCaseTester.ColumnNames.FieldVarByteArrayMax1024
                    && colName != vTestCaseTester.ColumnNames.InsertDate
                    && colName != vTestCaseTester.ColumnNames.InsertUser
                    )
                    Assert.AreEqual(tester.GetFieldValue(colName), actual.GetFieldValue(colName), "ColumnName " + colName + "get another value after insert.");
        }

        [TestMethod()]
        public void GetCountTest()
        {
            GetCountTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        public void InitializeTestHelper<T, V>()
        {
            ServiceBase<T, V> target = (ServiceBase<T, V>) (object) new UTD.Tricorder.Service.TestCaseTesterService();
            string entityName = vTestCaseTester.EntityName;
            string additionalDataKey = "";
            target.Initialize(entityName, additionalDataKey);
            bool exptected = true;
            Assert.AreEqual(exptected, target.IsInitialized);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            InitializeTestHelper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        public void InitializeTest1Helper<T, V>()
        {
            ServiceBase<T, V> target = (ServiceBase<T, V>)(object)new UTD.Tricorder.Service.TestCaseTesterService();
            EntityInfoBase entity = EntityFactory.GetEntityInfoByName(vTestCaseTester.EntityName, ""); 
            target.Initialize(entity);
            bool exptected = true;
            Assert.AreEqual(exptected, target.IsInitialized);
        }

        [TestMethod()]
        public void InitializeTest1()
        {
            InitializeTest1Helper<TestCaseTester, vTestCaseTester>();
        }

        /// <summary>
        ///A test for InsertT
        ///</summary>
        public void InsertTTestHelper<T, V>(EntityObjectBase tester)
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();
            long entityCounts = target.GetCount(null);
            target.InsertT((T)(object) tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));
        }

        [TestMethod()]
        public void InsertTTest()
        {
            EntityObjectBase tester = CreateNewT<TestCaseTester, vTestCaseTester>();
            InsertTTestHelper<TestCaseTester, vTestCaseTester>(tester);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        public void UpdateTestHelperT<T, V>(TestCaseTester tester)
        {
            ServiceBase<T, V> target = CreateServiceBase<T, V>();
            long entityCounts = target.GetCount(null);
            target.Insert(tester, new InsertParameters());
            Assert.AreEqual(entityCounts + 1, target.GetCount(null));

            TestCaseTester t = CreateNewMaxTester();

            //tester.TestCaseTesterID = Guid.NewGuid();
            tester.TestCaseTesterTitle = t.TestCaseTesterTitle;
            tester.TestCaseTesterCode = t.TestCaseTesterCode;
            tester.FieldGuid = t.FieldGuid;
            tester.FieldByte = t.FieldByte;
            tester.FieldInt16 = t.FieldInt16;
            tester.FieldInt32 = t.FieldInt32;
            tester.FieldInt64 = t.FieldInt64;
            tester.FieldDouble = t.FieldDouble;
            tester.FieldFloat = t.FieldFloat;
            tester.FieldNtext = t.FieldNtext;
            tester.FieldDateTime = t.FieldDateTime;
            tester.FieldByteArray50 = t.FieldByteArray50;
            tester.FieldVarByteArrayMax1024 = t.FieldVarByteArrayMax1024;
            tester.FieldDecimal = t.FieldDecimal;
            tester.FieldString = t.FieldString;
            tester.InsertUser = t.InsertUser;
            tester.InsertDate = t.InsertDate;
            tester.UpdateUser = t.UpdateUser;
            tester.UpdateDate = t.UpdateDate;

            target.UpdateT((T) (object) tester, new UpdateParameters());

            TestCaseTester actual = (TestCaseTester) target.GetByID(tester.TestCaseTesterID, new GetByIDParameters());

            AssertEqualTwoTestCaseTesters(t, actual);
        }

        public static void AssertEqualTwoTestCaseTesters(TestCaseTester t, TestCaseTester actual)
        {
            Assert.AreEqual(t.TestCaseTesterTitle, actual.TestCaseTesterTitle);
            Assert.AreEqual(t.TestCaseTesterCode, actual.TestCaseTesterCode);
            Assert.AreEqual(t.FieldGuid, actual.FieldGuid);
            Assert.AreEqual(t.FieldByte, actual.FieldByte);
            Assert.AreEqual(t.FieldInt16, actual.FieldInt16);
            Assert.AreEqual(t.FieldInt32, actual.FieldInt32);
            Assert.AreEqual(t.FieldInt64, actual.FieldInt64);
            Assert.AreEqual(t.FieldDouble, actual.FieldDouble);
            Assert.AreEqual(t.FieldFloat, actual.FieldFloat);
            Assert.AreEqual(t.FieldNtext, actual.FieldNtext);
            Assert.AreEqual(t.FieldDateTime, actual.FieldDateTime);

            for (int i = 0; i < 50; i++)
                Assert.AreEqual(t.FieldByteArray50[i], actual.FieldByteArray50[i]);

            for (int i = 0; i < t.FieldVarByteArrayMax1024.Length; i++)
                Assert.AreEqual(t.FieldVarByteArrayMax1024[i], actual.FieldVarByteArrayMax1024[i]);

            Assert.AreEqual(t.FieldDecimal, actual.FieldDecimal);
            Assert.AreEqual(t.FieldString, actual.FieldString);
            Assert.AreEqual(t.InsertUser, actual.InsertUser);
            //Assert.AreEqual(t.InsertDate, actual.InsertDate); InsertDate will be replaced in DataAccess. So, not the same value
            //Assert.AreEqual(t.UpdateUser, actual.UpdateUser);
            //Assert.AreEqual(t.UpdateDate, actual.UpdateDate);
        }




        [TestMethod()]
        public void UpdateTestT()
        {
            TestCaseTester t = CreateNewMinTester();
            UpdateTestHelperT<TestCaseTester, vTestCaseTester>(t);
        }

        [TestMethod()]
        public void UpdateTestT1()
        {
            TestCaseTester t = CreateNewMaxTester();
            UpdateTestHelperT<TestCaseTester, vTestCaseTester>(t);
        }





        public static TestCaseTester CreateNewMaxTester()
        {
            TestCaseTester t = new TestCaseTester();
            t.TestCaseTesterID = Guid.NewGuid();
            t.TestCaseTesterTitle = "TestCaseTesterTitle";
            t.TestCaseTesterCode = "TestCaseTesterCode";
            t.FieldGuid = Guid.NewGuid();
            t.FieldByte = Byte.MaxValue;
            t.FieldInt16 = Int16.MaxValue;
            t.FieldInt32 = Int32.MaxValue;
            t.FieldInt64 = Int64.MaxValue;
            t.FieldDouble = Double.MaxValue;
            t.FieldFloat = float.MaxValue;
            t.FieldNtext = "FieldNtext";
            t.FieldDateTime = FWConsts.MaxDateTime;

            byte[] bytes50 = new byte[50];
            for (int i = 0; i < bytes50.Length; i++)
                bytes50[i] = byte.MaxValue;
            t.FieldByteArray50 = bytes50;

            byte[] varBytes = new byte[1024];
            for (int i = 0; i < varBytes.Length; i++)
                varBytes[i] = byte.MaxValue;
            t.FieldVarByteArrayMax1024 = varBytes;

            //t.FieldDecimal = Decimal.MaxValue;
            t.FieldString = "FieldString";
            t.InsertUser = 0;
            t.InsertDate = DateTime.UtcNow;
            t.UpdateUser = null;
            t.UpdateDate = null;

            return t;
        }

        public static TestCaseTester CreateNewMinTester()
        {
            TestCaseTester t = new TestCaseTester();
            t.TestCaseTesterID = Guid.NewGuid();
            t.TestCaseTesterTitle = "TestCaseTesterTitle";
            t.TestCaseTesterCode = "TestCaseTesterCode";
            t.FieldGuid = Guid.Empty;
            t.FieldByte = Byte.MinValue;
            t.FieldInt16 = Int16.MinValue;
            t.FieldInt32 = Int32.MinValue;
            t.FieldInt64 = Int64.MinValue;
            t.FieldDouble = Double.MinValue;
            t.FieldFloat = float.MinValue;
            t.FieldNtext = "FieldNtext";
            t.FieldDateTime = FWConsts.MinDateTime;

            byte[] bytes50 = new byte[50];
            for (int i = 0; i < bytes50.Length; i++)
                bytes50[i] = byte.MinValue;
            t.FieldByteArray50 = bytes50;

            byte[] varBytes = new byte[1024];
            for (int i = 0; i < varBytes.Length; i++)
                varBytes[i] = byte.MinValue;
            t.FieldVarByteArrayMax1024 = varBytes;

            //t.FieldDecimal = Decimal.MinValue;
            t.FieldString = "FieldString";
            t.InsertUser = 0;
            t.InsertDate = DateTime.UtcNow;
            t.UpdateUser = null;
            t.UpdateDate = null;

            return t;
        }

    }
}
