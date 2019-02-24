using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UTD.Tricorder.Common.EntityObjects;

namespace Framework.TestCase.Common
{
    
    
    /// <summary>
    ///This is a test class for FilterExpressionTest and is intended
    ///to contain all FilterExpressionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilterExpressionTest
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
        ///A test for FilterExpression Constructor
        ///</summary>
        [TestMethod()]
        public void FilterExpressionConstructorTest()
        {
            FilterExpression target = new FilterExpression();
            Assert.AreEqual(0, target.FiltersList.Count);
        }

        /// <summary>
        ///A test for FilterExpression Constructor
        ///</summary>
        [TestMethod()]
        public void FilterExpressionConstructorTest2()
        {
            FilterExpression target = new FilterExpression();
            string actual = target.GetFilterString(null);
            Assert.AreEqual("", actual);
        }

        /// <summary>
        ///A test for AddFilter
        ///</summary>
        [TestMethod()]
        public void AddFilterTest()
        {
            FilterExpression target = new FilterExpression();
            Filter filter = new Filter(vTestCaseTester.ColumnNames.FieldString, "C'ode");
            target.AddFilter(filter);
            Assert.AreEqual(target.FiltersList.Count, 1);
            var enumerator = target.FiltersList.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, filter);
        }

        /// <summary>
        ///A test for AddFilterExpression
        ///</summary>
        [TestMethod()]
        public void AddFilterExpressionTest()
        {
            FilterExpression target = new FilterExpression();
            FilterExpression filterExp = new FilterExpression();
            filterExp.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C'ode"));
            target.AddFilterExpression(filterExp);
            Assert.AreEqual(target.FiltersList.Count, 1);
            var enumerator = target.FiltersList.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(enumerator.Current, filterExp);
        }

        /// <summary>
        ///A test for AndMerge
        ///</summary>
        [TestMethod()]
        public void AndMergeTest()
        {
            // empty test
            FilterExpression target = new FilterExpression(); 
            FilterExpression filterExp2 = new FilterExpression();
            target.AndMerge(filterExp2);
            Assert.AreEqual(target.FiltersList.Count, 1);
            List<object> valuesList = new List<object>();
            string s = target.GetFilterString(valuesList);
            Assert.AreEqual(s, "");
        }

        /// <summary>
        ///A test for AndMerge
        ///</summary>
        [TestMethod()]
        public void AndMergeTest2()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            FilterExpression filterExp2 = new FilterExpression();
            filterExp2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C2")); 
            target.AndMerge(filterExp2);
            Assert.AreEqual(target.FiltersList.Count, 2);
            List<object> valuesList = new List<object>();
            string actual = target.GetFilterString(valuesList);
            string expected = "(" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") +
                " AND " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + ")";
            Assert.AreEqual(actual, expected);
        }

        private string GetSimpleFilterString(string colName, string op, string value)
        {
            return "[" + colName + "] " + op + " " + value;
        }


        /// <summary>
        ///A test for AndMerge
        ///</summary>
        [TestMethod()]
        public void AndMergeTest3()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C2"));
            target.LogicalOperator = FilterLogicalOperatorEnum.AND;
            FilterExpression filterExp2 = new FilterExpression();
            filterExp2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C3"));
            target.AndMerge(filterExp2);
            Assert.AreEqual(target.FiltersList.Count, 3);
            List<object> valuesList = new List<object>();
            string actual = target.GetFilterString(valuesList);
            string expected = "(" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") +
                " AND " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + "" +
                " AND " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "2") + ")";
            Assert.AreEqual(actual, expected);
        }


        /// <summary>
        ///A test for AndMerge
        ///</summary>
        [TestMethod()]
        public void AndMergeTest4()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C2"));
            target.LogicalOperator = FilterLogicalOperatorEnum.OR;
            FilterExpression filterExp2 = new FilterExpression();
            filterExp2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C3"));
            target.AndMerge(filterExp2);
            Assert.AreEqual(target.FiltersList.Count, 2);
            List<object> valuesList = new List<object>();
            string actual = target.GetFilterString(valuesList);
            string expected = "((" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") +
                " OR " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + ")" +
                " AND " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "2") + "" +
                ")";
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C2"));
            FilterExpression f2 = new FilterExpression();
            f2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C3"));
            target.AddFilterExpression(f2);
            FilterExpression actual;
            actual = (FilterExpression) target.Clone();
            Assert.AreEqual(actual.FiltersList.Count, target.FiltersList.Count);
            var enumeratorTarget = target.FiltersList.GetEnumerator();
            var enumeratorActual = actual.FiltersList.GetEnumerator();
            while (enumeratorTarget.MoveNext())
            {
                enumeratorActual.MoveNext();
                Assert.AreEqual(enumeratorTarget.Current, enumeratorActual.Current);
            }
        }

        /// <summary>
        ///A test for GetFilterString
        ///</summary>
        [TestMethod()]
        public void GetFilterStringTest()
        {
            FilterExpression target = new FilterExpression();
            Filter filter = new Filter(vTestCaseTester.ColumnNames.FieldString, "C'ode");
            List<object> filterValues = new List<object>();
            target.AddFilter(filter);
            string actual = target.GetFilterString(filterValues);
            string expected = "" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString,"=",Filter.ParameterPrefix + "0");
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(filterValues.Count, 1);
            Assert.AreEqual(filterValues[0], "C'ode");
        }

        /// <summary>
        ///A test for GetFilterString
        ///</summary>
        [TestMethod()]
        public void GetFilterStringTest2()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C0"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            List<object> filterValues = new List<object>();
            string actual = target.GetFilterString(filterValues);
            string expected = "(" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") + " " + "AND" +
                " " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + ")";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(filterValues.Count, 2);
            Assert.AreEqual(filterValues[0], "C0");
            Assert.AreEqual(filterValues[1], "C1");
        }

        /// <summary>
        ///A test for GetFilterString
        ///</summary>
        [TestMethod()]
        public void GetFilterStringTest3()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C0"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            target.LogicalOperator = FilterLogicalOperatorEnum.OR;
            List<object> filterValues = new List<object>();
            string actual = target.GetFilterString(filterValues);
            string expected = "(" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") + " " + "OR" +
                " " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + ")";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(filterValues.Count, 2);
            Assert.AreEqual(filterValues[0], "C0");
            Assert.AreEqual(filterValues[1], "C1");
        }

        /// <summary>
        ///A test for GetFilterString
        ///</summary>
        [TestMethod()]
        public void GetFilterStringTest4()
        {
            FilterExpression target = new FilterExpression();
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C1"));
            target.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C2"));
            target.LogicalOperator = FilterLogicalOperatorEnum.OR;
            FilterExpression filterExp2 = new FilterExpression();
            filterExp2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C3"));
            filterExp2.AddFilter(new Filter(vTestCaseTester.ColumnNames.FieldString, "C4"));
            target.AddFilterExpression(filterExp2);
            Assert.AreEqual(target.FiltersList.Count, 3);
            List<object> filterValues = new List<object>();
            string actual = target.GetFilterString(filterValues);
            string expected = "(" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "0") +
                " OR " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "1") + "" +
                " OR (" + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "2") + "" +
                " AND " + GetSimpleFilterString(vTestCaseTester.ColumnNames.FieldString, "=", Filter.ParameterPrefix + "3") + ")" +
                ")";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(filterValues.Count, 4);
            Assert.AreEqual(filterValues[0], "C1");
            Assert.AreEqual(filterValues[1], "C2");
            Assert.AreEqual(filterValues[2], "C3");
            Assert.AreEqual(filterValues[3], "C4");
        }






        /// <summary>
        ///A test for FiltersList
        ///</summary>
        [TestMethod()]
        public void FiltersListTest()
        {
            FilterExpression target = new FilterExpression();
            ICollection<IFilter> actual;
            actual = target.FiltersList;
            Assert.AreNotEqual(target.FiltersList, null);
        }

        /// <summary>
        ///A test for LogicalOperator
        ///</summary>
        [TestMethod()]
        public void LogicalOperatorTest()
        {
            FilterExpression target = new FilterExpression();
            FilterLogicalOperatorEnum expected = FilterLogicalOperatorEnum.AND;
            FilterLogicalOperatorEnum actual = target.LogicalOperator;
            actual = target.LogicalOperator;
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for LogicalOperator
        ///</summary>
        [TestMethod()]
        public void LogicalOperatorTest2()
        {
            FilterExpression target = new FilterExpression();
            target.LogicalOperator = FilterLogicalOperatorEnum.OR;
            FilterLogicalOperatorEnum expected = FilterLogicalOperatorEnum.OR;
            FilterLogicalOperatorEnum actual = target.LogicalOperator;
            actual = target.LogicalOperator;
            Assert.AreEqual(expected, actual);
        }

    }
}
