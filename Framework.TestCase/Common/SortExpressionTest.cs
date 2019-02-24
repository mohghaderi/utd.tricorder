using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common
{
    
    
    /// <summary>
    ///This is a test class for SortExpressionTest and is intended
    ///to contain all SortExpressionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SortExpressionTest
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
        ///A test for SortExpression Constructor
        ///</summary>
        [TestMethod()]
        public void SortExpressionConstructorTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString;
            SortExpression target = new SortExpression(columnName);
            Assert.AreEqual(target.SortInfoList.Count, 1);
            var enumerator = target.SortInfoList.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current.ColumnName, columnName);
                Assert.AreEqual(enumerator.Current.Direction, SortDirectionEnum.ASC);
            }
        }


        /// <summary>
        ///A test for AddSort
        ///</summary>
        [TestMethod()]
        public void AddSortTest()
        {
            SortExpression target = new SortExpression(); 
            string columnName = vTestCaseTester.ColumnNames.FieldString; 
            SortDirectionEnum sortDirection = SortDirectionEnum.DESC;
            target.AddSort(columnName, sortDirection);
            var enumerator = target.SortInfoList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(enumerator.Current.ColumnName, columnName);
                Assert.AreEqual(enumerator.Current.Direction, sortDirection);
            }
        }

        /// <summary>
        ///A test for GetSortExpressionString
        ///</summary>
        [TestMethod()]
        public void GetSortExpressionStringTest()
        {
            SortExpression target = new SortExpression();
            string expected = string.Empty;
            string actual;
            actual = target.GetSortExpressionString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetSortExpressionString
        ///</summary>
        [TestMethod()]
        public void GetSortExpressionStringTest2()
        {
            SortExpression target = new SortExpression();
            target.AddSort(new SortInfo(vTestCaseTester.ColumnNames.FieldString, SortDirectionEnum.DESC));
            string expected = vTestCaseTester.ColumnNames.FieldString + " " + "DESC";
            string actual;
            actual = target.GetSortExpressionString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetSortExpressionString
        ///</summary>
        [TestMethod()]
        public void GetSortExpressionStringTest3()
        {
            SortExpression target = new SortExpression();
            target.AddSort(new SortInfo(vTestCaseTester.ColumnNames.FieldInt32, SortDirectionEnum.ASC));
            target.AddSort(new SortInfo(vTestCaseTester.ColumnNames.FieldString, SortDirectionEnum.DESC));
            string expected = vTestCaseTester.ColumnNames.FieldInt32 + " ASC," + vTestCaseTester.ColumnNames.FieldString + " " + "DESC";
            string actual;
            actual = target.GetSortExpressionString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SortInfoList
        ///</summary>
        [TestMethod()]
        public void SortInfoListTest()
        {
            SortExpression target = new SortExpression();
            ICollection<SortInfo> actual;
            actual = target.SortInfoList;
            Assert.AreNotEqual(target.SortInfoList, null);
        }
    }
}
