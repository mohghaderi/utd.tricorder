using Framework.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Framework.TestCase.DataAccess
{
    
    
    /// <summary>
    ///This is a test class for ServerPrefixUtilsTest and is intended
    ///to contain all ServerPrefixUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SiteIdUtilsTest
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
        ///A test for ComputeValuesOnce
        ///</summary>
        [TestMethod()]
        public void ComputeValuesOnceTest()
        {
            SiteIdUtils.ComputeValuesOnce();
        }

        /// <summary>
        ///A test for ConvertServerNumberToInt32Suffix
        ///</summary>
        [TestMethod()]
        public void ConvertServerNumberToInt32SuffixTest()
        {
            int serverNumber = 2000; 
            int numberOfSuffixDigits = 4; 
            int expected = 2000000000; //2,147,483,648
            int actual;
            actual = SiteIdUtils.ConvertServerNumberToInt32Suffix(serverNumber, numberOfSuffixDigits);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for ConvertServerNumberToInt64Suffix
        ///</summary>
        [TestMethod()]
        public void ConvertServerNumberToInt64SuffixTest()
        {
            int serverNumber = 2000; 
            int numberOfSuffixDigits = 6;
            long expected = 0020000000000000000;   // 9,223,372,036,854,775,808
            long actual;
            actual = SiteIdUtils.ConvertServerNumberToInt64Suffix(serverNumber, numberOfSuffixDigits);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindEndNumberInt32
        ///</summary>
        [TestMethod()]
        public void FindEndNumberInt32Test()
        {
            int baseNumber = 0010000000; 
            int numberOfSuffixDigits = 6;
            int expected = 0010009999;   //2,147,483,648
            int actual;
            actual = SiteIdUtils.FindEndNumberInt32(baseNumber, numberOfSuffixDigits);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindEndNumberInt64
        ///</summary>
        [TestMethod()]
        public void FindEndNumberInt64Test()
        {
            long baseNumber = 0020000000000000000; 
            int numberOfSuffixDigits = 6; 
            long expected = 0020009999999999999; 
            long actual;
            actual = SiteIdUtils.FindEndNumberInt64(baseNumber, numberOfSuffixDigits);
            Assert.AreEqual(expected, actual);
        }
    }
}
