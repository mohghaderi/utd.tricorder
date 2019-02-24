using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using Framework.TestCase.CommonClasses;

namespace Framework.TestCase.Common.Utils
{
    
    
    /// <summary>
    ///This is a test class for DBTypeUtilsTest and is intended
    ///to contain all DBTypeUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBTypeUtilsTest
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
        ///A test for DBTypeUtils Constructor
        ///</summary>
        [TestMethod()]
        public void DBTypeUtilsConstructorTest()
        {
            DBTypeUtils target = new DBTypeUtils();
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetDBDataTypeFromDotNetType
        ///</summary>
        [TestMethod()]
        public void GetDBDataTypeFromDotNetTypeTest()
        {
            DBTypeUtils target = new DBTypeUtils(); 
            Type t = null; 
            DBDataType actual;
            try
            {
                actual = target.GetDBDataTypeFromDotNetType(t);
                // should throw an exception
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        ///A test for GetDBDataTypeFromDotNetType
        ///</summary>
        [TestMethod()]
        public void GetDBDataTypeFromDotNetTypeTest2()
        {
            DBTypeUtils target = new DBTypeUtils();
            object[] targetValues = { "Salam", (int)1000, (long)1000, Guid.NewGuid(), 'a', false, (float)1.02, (double)3.20 , new byte[] {}, DateTime.Now };
            object[] expectedValues = { DBDataType.String, DBDataType.Int32, DBDataType.Int64, DBDataType.Guid, DBDataType.Char, DBDataType.Boolean, DBDataType.Float, DBDataType.Double, DBDataType.Binary, DBDataType.DateTime };

            DBDataType actual;
            for (int i = 0; i < targetValues.Length; i++)
            {
                actual = target.GetDBDataTypeFromDotNetType(targetValues[i].GetType());
                Assert.AreEqual(expectedValues[i], actual);
            }
        }


        /// <summary>
        ///A test for GetDBDataTypeFromDotNetType
        ///</summary>
        [TestMethod()]
        public void GetDBDataTypeFromDotNetTypeTest3()
        {
            DBTypeUtils target = new DBTypeUtils();
            ComplexStructure targetValue = new ComplexStructure();
            //object expectedValue = null; // don't expect anything just check for exception

            DBDataType actual;
            try
            {
                actual = target.GetDBDataTypeFromDotNetType(targetValue.GetType());
            }
            catch (NotImplementedException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        /// <summary>
        ///A test for GetDotNetTypeFromDbType
        ///</summary>
        [TestMethod()]
        public void GetDotNetTypeFromDbTypeTest()
        {
            DBTypeUtils target = new DBTypeUtils();
            DBDataType[] targetValues = { DBDataType.String, DBDataType.Int32, DBDataType.Int64, DBDataType.Guid, DBDataType.Char, DBDataType.Boolean, DBDataType.Float, DBDataType.Double, DBDataType.Binary, DBDataType.DateTime, DBDataType.None };
            object[] expectedValues = { "Salam", (int)1000, (long)1000, Guid.NewGuid(), 'a', false, (float)1.02, (double)3.20, new byte[] { }, DateTime.Now, new object()};

            Type actual;
            for (int i = 0; i < targetValues.Length; i++)
            {
                actual = target.GetDotNetTypeFromDbType(targetValues[i]);
                Assert.IsInstanceOfType(expectedValues[i], actual);
            }
        }

        /// <summary>
        ///A test for GetQuoteCharForObject
        ///</summary>
        [TestMethod()]
        public void GetQuoteCharForObjectTest()
        {
            DBTypeUtils target = new DBTypeUtils(); 
            object obj = null; 
            string expected = string.Empty; 
            string actual;
            actual = target.GetQuoteCharForObject(obj);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetQuoteCharForObject
        ///</summary>
        [TestMethod()]
        public void GetQuoteCharForObjectTest2()
        {
            Guid g1 = Guid.NewGuid();
            DBTypeUtils target = new DBTypeUtils();
            object[] targetValues = { 12200, "StringValue", g1 };
            string[] expectedValues = { string.Empty, "'", "'" } ;
            string actual;
            for (int i = 0; i < targetValues.Length; i++)
            {
                actual = target.GetQuoteCharForObject(targetValues[i]);
                Assert.AreEqual(expectedValues[i], actual);
            }
        }



        /// <summary>
        ///A test for GetTypedDataValueFromDbType
        ///</summary>
        [TestMethod()]
        public void GetTypedDataValueFromDbTypeTest()
        {
            DBTypeUtils target = new DBTypeUtils(); 
            byte[] value = Guid.NewGuid().ToByteArray(); 
            DBDataType dbType = DBDataType.Guid; 
            object expected = new Guid(value); 
            object actual;
            actual = target.GetTypedDataValueFromDbType(value, dbType);
            Assert.AreEqual(expected, actual);
        }
    }
}
