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
    public class CommaSeperatedUtilsTest
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
        public void CommaSeperatedUtilsConstructorTest()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
        }

        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils(); 
            IEnumerable list = new List<string>(); 
            bool autoQuote = false;
            string fieldName = string.Empty; 
            string expected = string.Empty;
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest2()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<string> list = new List<string>();
            list.Add("Item1");
            list.Add("Item2");
            bool autoQuote = false;
            string fieldName = string.Empty;
            string expected = "Item1,Item2";
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest3()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<string> list = new List<string>();
            list.Add("Item1");
            list.Add("Item2");
            bool autoQuote = true;
            string fieldName = string.Empty;
            string expected = "'Item1','Item2'";
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest4()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<ComplexStructure> list = new List<ComplexStructure>();
            list.Add(new ComplexStructure() { Field1 = "Item1" });
            list.Add(new ComplexStructure() { Field1 = "Item2" });
            bool autoQuote = true;
            string fieldName = "Field1";
            string expected = "'Item1','Item2'";
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote, fieldName);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest5()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<ComplexStructure> list = new List<ComplexStructure>();
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();

            list.Add(new ComplexStructure() { Field1 = "Item1", Field2 = g1 });
            list.Add(new ComplexStructure() { Field1 = "Item2", Field2 = g2 });
            bool autoQuote = true;
            string fieldName = "Field2";
            string expected = "'" + g1.ToString() + "','" + g2.ToString() + "'";
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote, fieldName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConverToCommaSeperatedString
        ///</summary>
        [TestMethod()]
        public void ConverToCommaSeperatedStringTest6()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<int> list = new List<int>();
            list.Add(1000);
            list.Add(2000);
            bool autoQuote = true;
            string expected = "1000,2000";
            string actual;
            actual = target.ConverToCommaSeperatedString(list, autoQuote);
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for FindFirstElementInIEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Framework.dll")]
        public void FindFirstElementInIEnumeratorTest()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            IEnumerable source = new Dictionary<string, object>(); 
            object expected = null;
            object actual;
            try
            {
                actual = target.FindFirstElementInIEnumerator(source);
                Assert.AreEqual(expected, actual);
            }
            catch (DesignByContractException)
            { 
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        /// <summary>
        ///A test for FindFirstElementInIEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Framework.dll")]
        public void FindFirstElementInIEnumeratorTest2()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<string> source = new List<string>();
            source.Add("Item1");
            source.Add("Item2");
            object expected = "Item1";
            object actual;
            actual = target.FindFirstElementInIEnumerator(source);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for FindFirstElementInIEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Framework.dll")]
        public void FindFirstElementInIEnumeratorTest3()
        {
            CommaSeperatedUtils target = new CommaSeperatedUtils();
            List<ComplexStructure> source = new List<ComplexStructure>();
            ComplexStructure c1 = new ComplexStructure() { Field1 = "F1", Field2 = Guid.NewGuid() };
            ComplexStructure c2 = new ComplexStructure() { Field1 = "F1", Field2 = Guid.NewGuid() };
            source.Add(c1);
            source.Add(c2);
            object expected = c1;
            object actual;
            actual = target.FindFirstElementInIEnumerator(source);
            Assert.AreEqual(expected, actual);
        }



    }
}
