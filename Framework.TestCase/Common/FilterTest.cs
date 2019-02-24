using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common
{
    
    
    /// <summary>
    ///This is a test class for FilterTest and is intended
    ///to contain all FilterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterTest
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
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString;
            FilterOperatorEnum filterOperator = FilterOperatorEnum.EqualTo;
            Guid g = Guid.NewGuid();
            Filter target = new Filter(columnName, g, filterOperator); 
            object expected = g; 
            object actual;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Operator
        ///</summary>
        [TestMethod()]
        public void OperatorTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString;
            FilterOperatorEnum filterOperator = FilterOperatorEnum.Contains; 
            Filter target = new Filter(columnName, "Ali", filterOperator);
            FilterOperatorEnum expected = FilterOperatorEnum.Contains; 
            FilterOperatorEnum actual;
            actual = target.Operator;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ColumnName
        ///</summary>
        [TestMethod()]
        public void ColumnNameTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString; 
            FilterOperatorEnum filterOperator = FilterOperatorEnum.Like; 
            Filter target = new Filter(columnName, "Ali", filterOperator); 
            string expected = vTestCaseTester.ColumnNames.FieldString;
            string actual;
            actual = target.ColumnName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetFilterString
        ///</summary>
        [TestMethod()]
        public void GetFilterStringTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString;
            FilterOperatorEnum filterOperator = FilterOperatorEnum.Like;
            Filter target = new Filter(columnName, "C1", filterOperator);
            ICollection<object> values = new List<object>(); 
            string expected = "[" + vTestCaseTester.ColumnNames.FieldString + "] like " + Filter.ParameterPrefix + "0";
            string actual;
            actual = target.GetFilterString(values);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Filter Constructor
        ///</summary>
        [TestMethod()]
        public void FilterConstructorTest()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString; 
            object value = "C1";
            Filter target = new Filter(columnName, value);
            Assert.AreEqual(target.ColumnName, columnName);
            Assert.AreEqual(target.Value, value);
            Assert.AreEqual(target.Operator, FilterOperatorEnum.EqualTo);
        }

        /// <summary>
        ///A test for Filter Constructor
        ///</summary>
        [TestMethod()]
        public void FilterConstructorTest1()
        {
            string columnName = vTestCaseTester.ColumnNames.FieldString;
            object value = "(Select * from TestCaseTester)";
            FilterOperatorEnum op = FilterOperatorEnum.InSelect;
            Filter target = new Filter(columnName, value, op);
            Assert.AreEqual(target.ColumnName, columnName);
            Assert.AreEqual(target.Value, value);
            Assert.AreEqual(target.Operator, op);
        }
    }
}
