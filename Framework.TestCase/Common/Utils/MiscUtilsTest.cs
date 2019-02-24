using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using Framework.TestCase.CommonClasses;

namespace Framework.TestCase.Common.Utils
{
    /// <summary>
    ///This is a test class for CommaSeperatedUtilsTest and is intended
    ///to contain all CommaSeperatedUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MiscUtilsTest
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
        ///A test for CommaSeperatedUtils Constructor
        ///</summary>
        [TestMethod()]
        public void MiscUtilsConstructorTest()
        {
            MiscUtils target = new MiscUtils();
        }

        [TestMethod]
        public void GetReadableFileSizeTest()
        {
            MiscUtils target = new MiscUtils();
            long[] inputs = {1,1024, 2049, 1024*1024, 1024*1024 *1024};
            string[] expecteds = { "1 B", "1 KB", "2.001 KB", "1 MB", "1 GB" };
            for (int i = 0; i < inputs.Length; i++)
            {
                var actual = target.GetReadableFileSize(inputs[i]);
                Assert.AreEqual(expecteds[i], actual, "Incorrect readable file size for " + inputs[i] + " index " + i.ToString());
            }
        }

        [TestMethod]
        public void GetFileType_Test()
        {
            MiscUtils target = new MiscUtils();
            string[] inputs = { "", "withouttype", "f1.jpg", "myfile.zipdof", ".sjjaks" };
            string[] expecteds = { "", "", "jpg", "zipdof", "sjjaks" };
            for (int i = 0; i < inputs.Length; i++)
            {
                var actual = target.GetFileTypeByFileName(inputs[i]);
                Assert.AreEqual(expecteds[i], actual, "Incorrect readable file size for " + inputs[i] + " index " + i.ToString());
            }
        }

        [TestMethod]
        public void GenerateGuidIDByString()
        {
            MiscUtils target = new MiscUtils();
            string[] inputs = { "", null, "xecare.com", "نوشته یونیکد", "نوشته یونیکذ", "petcare.xecare.com"};
            Guid?[] expecteds = { null
                                    , null
                                    , new Guid("ce9a5d1e-b9c5-a0b3-ea8a-cb60d61668e2")
                                    , new Guid("790480ac-2b5d-1414-00c6-f4113293b9f4")
                                    , new Guid("7dc49e67-a87c-d44c-acbe-f7be22134e3c")
                                    , new Guid("befda0e9-b154-11f4-4824-50afbd1d1185")
                                };
            for (int i = 0; i < inputs.Length; i++)
            {
                var actual = target.GenerateGuidIDByString(inputs[i]);
                Assert.AreEqual(expecteds[i], actual, "Incorrect Guid generated for " + inputs[i] + " index " + i.ToString());
            }
        }

    }
}
