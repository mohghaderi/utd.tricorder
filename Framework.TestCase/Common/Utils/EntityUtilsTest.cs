using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.EntityInfos;
using Framework.TestCase.CommonClasses;
using Framework.TestCase.Service;
using System.Collections.Generic;

namespace Framework.TestCase.Common.Utils
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for EntityUtilsTest and is intended
    ///to contain all EntityUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EntityUtilsTest
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
        ///A test for EntityUtils Constructor
        ///</summary>
        [TestMethod()]
        public void EntityUtilsConstructorTest()
        {
            EntityUtils target = new EntityUtils();
        }

        /// <summary>
        ///A test for GetEntityFieldTypeName
        ///</summary>
        [TestMethod()]
        public void GetEntityFieldTypeNameTest()
        {
            EntityUtils target = new EntityUtils(); 

            TestCaseTester ind = new TestCaseTester();
            //ind.FieldString = "IndCode123";
            string fieldName = "FieldString"; 
            Type expected = typeof(string); 
            Type actual;
            actual = target.GetObjectFieldType(ind, fieldName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityFieldTypeName
        ///</summary>
        [TestMethod()]
        public void GetEntityFieldTypeNameTest2()
        {
            // testing nullable Guid?

            EntityUtils target = new EntityUtils();

            TestCaseTester ind = new TestCaseTester();
            //ind.FieldGuid = "";
            string fieldName = "FieldGuid";
            Type expected = typeof(Guid);
            Type actual;
            actual = target.GetObjectFieldType(ind, fieldName);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void GetEntityFieldValueStringTest()
        {
            EntityUtils target = new EntityUtils(); 
            TestCaseTesterEN entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            TestCaseTester dataTransferObject = new TestCaseTester();
            dataTransferObject.TestCaseTesterID = Guid.NewGuid();
            string fieldName = vTestCaseTester.ColumnNames.TestCaseTesterID;
            string expected = dataTransferObject.TestCaseTesterID.ToString(); 
            string actual;
            actual = target.GetEntityFieldValueString(dataTransferObject, fieldName, entity);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetObjectFieldValue
        ///</summary>
        [TestMethod()]
        public void GetObjectFieldValueTest()
        {
            EntityUtils target = new EntityUtils(); 
            TestCaseTesterEN entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            TestCaseTester dataTransferObject = new TestCaseTester();
            dataTransferObject.TestCaseTesterID = Guid.NewGuid();
            string fieldName = vTestCaseTester.ColumnNames.TestCaseTesterID;
            object expected = dataTransferObject.TestCaseTesterID; 
            object actual;
            actual = target.GetObjectFieldValue(dataTransferObject, fieldName);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetObjectFieldValue
        ///</summary>
        [TestMethod()]
        public void GetObjectFieldValueTest2()
        {
            // test for nullable path
            EntityUtils target = new EntityUtils();
            TestCaseTesterEN entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            TestCaseTester dataTransferObject = new TestCaseTester();
            dataTransferObject.UpdateDate = DateTime.UtcNow;
            string fieldName = vTestCaseTester.ColumnNames.UpdateDate;
            object expected = dataTransferObject.UpdateDate;
            object actual;
            actual = target.GetObjectFieldValue(dataTransferObject, fieldName);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetObjectFieldValueString
        ///</summary>
        [TestMethod()]
        public void GetObjectFieldValueStringTest()
        {
            EntityUtils target = new EntityUtils();
            ComplexStructure obj = new ComplexStructure() { Field2 = Guid.NewGuid() };
            string fieldName = "Field1";
            string expected = null; 
            string actual;
            actual = target.GetObjectFieldValueString(obj, fieldName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetObjectFieldValueString
        ///</summary>
        [TestMethod()]
        public void GetObjectFieldValueStringTest1()
        {
            EntityUtils target = new EntityUtils();
            ComplexStructure obj = null;
            string fieldName = "Field1";
            string expected = null;
            string actual;
            actual = target.GetObjectFieldValueString(obj, fieldName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetObjectFieldValueString
        ///</summary>
        [TestMethod()]
        public void GetObjectFieldValueStringTest2()
        {
            EntityUtils target = new EntityUtils();
            ComplexStructure obj = new ComplexStructure() { Field2 = Guid.NewGuid() };
            string fieldName = "Field2";
            string expected = obj.Field2.ToString();
            string actual;
            actual = target.GetObjectFieldValueString(obj, fieldName);
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for InvokeObjectMethod
        ///</summary>
        [TestMethod()]
        public void InvokeObjectMethodTest()
        {
            EntityUtils target = new EntityUtils();
            string methodName = "MethodTest";
            object obj = new ComplexStructure();
            object[] parameters = null;
            object expected = "Success!";
            object actual;
            actual = target.InvokeObjectMethod(methodName, obj, parameters);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InvokeObjectMethod
        ///</summary>
        [TestMethod()]
        public void InvokeObjectMethodTest1()
        {
            EntityUtils target = new EntityUtils(); 
            string methodName = "EchoMethodTest";
            object obj = new ComplexStructure(); 
            object[] parameters = { "TestEcho!" } ;
            object expected = "TestEcho!";
            object actual;
            actual = target.InvokeObjectMethod(methodName, obj, parameters);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObjectHasProperty
        ///</summary>
        [TestMethod()]
        public void ObjectHasPropertyTest()
        {
            EntityUtils target = new EntityUtils(); 
            object obj = new ComplexStructure();
            string propertyName = "Field1"; 
            bool expected = true; 
            bool actual;
            actual = target.ObjectHasProperty(obj, propertyName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ObjectHasProperty
        ///</summary>
        [TestMethod()]
        public void ObjectHasPropertyTest2()
        {
            EntityUtils target = new EntityUtils();
            object obj = new ComplexStructure();
            string propertyName = "FakeFieldTest";
            bool expected = false;
            bool actual;
            actual = target.ObjectHasProperty(obj, propertyName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetEntityFieldValueStringTest()
        {
            EntityUtils target = new EntityUtils(); 
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            string fieldName = vTestCaseTester.ColumnNames.TestCaseTesterID; 
            TestCaseTester dataTransferObject = new TestCaseTester(); 
            object value = Guid.NewGuid();
            target.SetEntityFieldValueString(entity, fieldName, dataTransferObject, value.ToString());
            Assert.AreEqual(dataTransferObject.TestCaseTesterID, value);
        }

        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetEntityFieldValueStringTest2()
        {
            // nullable test

            EntityUtils target = new EntityUtils();
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            DateTime t = DateTime.UtcNow;
            string fieldName = vTestCaseTester.ColumnNames.UpdateDate;
            TestCaseTester dataTransferObject = new TestCaseTester();
            string value = t.ToString();
            target.SetEntityFieldValueString(entity, fieldName, dataTransferObject, value);
            Assert.AreEqual(dataTransferObject.UpdateDate.Value.ToString(), value);
        }


        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetEntityFieldValueTest1()
        {
            EntityUtils target = new EntityUtils();
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            TestCaseTester dataTransferObject = new TestCaseTester();
            string fieldName = vTestCaseTester.ColumnNames.TestCaseTesterID;
            object value = Guid.NewGuid();
            target.SetEntityFieldValue(entity, fieldName, dataTransferObject, value);
            Assert.AreEqual(dataTransferObject.TestCaseTesterID, value);
        }



        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetEntityFieldValueTest2()
        {
            // nullable field value
            EntityUtils target = new EntityUtils();
            EntityInfoBase entity = new TestCaseTesterEN();
            entity.Initialize(vTestCaseTester.EntityName, "");
            DateTime t = DateTime.UtcNow;
            string fieldName = vTestCaseTester.ColumnNames.UpdateDate;
            TestCaseTester dataTransferObject = new TestCaseTester();
            object value = t;
            target.SetEntityFieldValue(entity, fieldName, dataTransferObject, value);
            Assert.AreEqual(dataTransferObject.UpdateDate.Value, value);
        }


        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetObjectFieldValueTest()
        {
            EntityUtils target = new EntityUtils();
            DateTime t = DateTime.UtcNow;
            string fieldName = vTestCaseTester.ColumnNames.UpdateDate;
            TestCaseTester dataTransferObject = new TestCaseTester();
            object value = t;
            target.SetObjectFieldValue(fieldName, dataTransferObject, value);
            Assert.AreEqual(dataTransferObject.UpdateDate.Value, value);
        }


        /// <summary>
        ///A test for SetEntityFieldValueString
        ///</summary>
        [TestMethod()]
        public void SetObjectFieldValueTest2()
        {
            EntityUtils target = new EntityUtils();
            string fieldName = vTestCaseTester.ColumnNames.TestCaseTesterID;
            TestCaseTester dataTransferObject = new TestCaseTester();
            object value = Guid.NewGuid();
            target.SetObjectFieldValueString(fieldName, dataTransferObject, value.ToString());
            Assert.AreEqual(dataTransferObject.TestCaseTesterID, value);
        }

        [TestMethod()]
        public void ConcatStringsTest1()
        {
            EntityUtils target = new EntityUtils();
            string s1 = "S1";
            string s2 = "S2";
            string s3 = "S3";
            string actual = target.ConcatStrings(".", s1, s2, s3);
            string expected = "S1.S2.S3";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConcatStringsTest2()
        {
            EntityUtils target = new EntityUtils();
            string s1 = null;
            string s2 = "String 2";
            string s3 = null;
            string actual = target.ConcatStrings(s1, s2, s3);
            string expected = s2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConcatStringsTest3()
        {
            EntityUtils target = new EntityUtils();
            string actual = target.ConcatStrings(" ");
            string expected = "";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConcatStringsTest4()
        {
            EntityUtils target = new EntityUtils();
            string name = "JustOneString";
            string actual = target.ConcatStrings(" ", name);
            string expected = name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void JsonSerializeObject1()
        {
            ComplexStructure cs = new ComplexStructure();
            cs.Field1 = "f1Value";
            cs.Field2 = new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a");
            cs.Field3 = new DateTime(2013, 1, 1);

            EntityUtils target = new EntityUtils();
            string actual = target.JsonSerializeObject(cs);
            string expected = "{\"Field1\":\"f1Value\",\"Field2\":\"0cf8f670-c742-4f12-ba0b-98d8f3b9077a\",\"Field3\":\"2013-01-01T00:00:00Z\"}";

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void JsonSerializeObject2()
        {
            ComplexStructure cs = new ComplexStructure();
            cs.Field1 = null;
            cs.Field2 = new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a");
            cs.Field3 = new DateTime(2013, 1, 1);

            EntityUtils target = new EntityUtils();
            bool ignoreNullValues = true;
            string actual = target.JsonSerializeObject(cs, ignoreNullValues);
            string expected = "{\"Field2\":\"0cf8f670-c742-4f12-ba0b-98d8f3b9077a\",\"Field3\":\"2013-01-01T00:00:00Z\"}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void JsonSerializeObject3()
        {
            ComplexStructure cs = new ComplexStructure();
            cs.Field1 = null;
            cs.Field2 = new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a");
            cs.Field3 = new DateTime(2013, 1, 1);

            EntityUtils target = new EntityUtils();
            bool ignoreNullValues = false;
            string actual = target.JsonSerializeObject(cs, ignoreNullValues);
            string expected = "{\"Field1\":null,\"Field2\":\"0cf8f670-c742-4f12-ba0b-98d8f3b9077a\",\"Field3\":\"2013-01-01T00:00:00Z\"}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void JsonSerializeObject4()
        {
            ComplexStructure cs = null;

            EntityUtils target = new EntityUtils();
            string actual = target.JsonSerializeObject(cs);
            string expected = "null";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void JsonSerializeObject5()
        {
            // testing excluding properties
            ComplexStructure cs = new ComplexStructure();
            cs.Field1 = null;
            cs.Field2 = new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a");
            cs.Field3 = new DateTime(2013, 1, 1);

            EntityUtils target = new EntityUtils();
            List<string> excludingProperties = new List<string>();
            excludingProperties.Add("Field2");

            bool ignoreNullValues = false;
            string actual = target.JsonSerializeObject(cs, ignoreNullValues, excludingProperties);
            string expected = "{\"Field1\":null,\"Field3\":\"2013-01-01T00:00:00Z\"}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void JsonDeserializeObject1()
        {
            EntityUtils target = new EntityUtils();

            string jsonString = "{\"Field1\":\"f1Value\",\"Field2\":\"0cf8f670-c742-4f12-ba0b-98d8f3b9077a\",\"Field3\":\"2013-01-01T00:00:00\"}";
            object jsonObject = target.JsonDeserializeObject(jsonString, typeof (ComplexStructure));

            ComplexStructure cs2 = (ComplexStructure)jsonObject;
            Assert.AreEqual("f1Value", cs2.Field1);
            Assert.AreEqual(new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a"), cs2.Field2);
            Assert.AreEqual(new DateTime(2013,1,1), cs2.Field3);
        }

        [TestMethod()]
        public void JsonSerializeDeserializeTogether()
        {
            var expected = ServiceBaseTest.CreateNewMaxTester();

            EntityUtils target = new EntityUtils();

            string jsonString = target.JsonSerializeObject(expected);
            TestCaseTester actual = (TestCaseTester)target.JsonDeserializeObject(jsonString, expected.GetType());

            // check if two test case testers are equal in all values for a json object
            ServiceBaseTest.AssertEqualTwoTestCaseTesters(expected, actual);
        }

        [TestMethod()]
        public void JsonSerializeDeserializeTogether2()
        {
            var expected = ServiceBaseTest.CreateNewMinTester();

            EntityUtils target = new EntityUtils();

            string jsonString = target.JsonSerializeObject(expected);
            TestCaseTester actual = (TestCaseTester)target.JsonDeserializeObject(jsonString, expected.GetType());

            // check if two test case testers are equal in all values for a json object
            ServiceBaseTest.AssertEqualTwoTestCaseTesters(expected, actual);
        }


        [TestMethod()]
        public void JsonDeserializeOnObject1()
        {
            // all min values for testCaseTester
            string jsonString = "{\"TestCaseTesterID\":\"edce87b7-32b2-40a6-8f13-92e8c4c97563\",\"TestCaseTesterTitle\":\"TestCaseTesterTitle\",\"TestCaseTesterCode\":\"TestCaseTesterCode\",\"FieldGuid\":\"00000000-0000-0000-0000-000000000000\",\"FieldByte\":0,\"FieldInt16\":-32768,\"FieldInt32\":-2147483648,\"FieldInt64\":-9223372036854775808,\"FieldDouble\":-1.7976931348623157E+308,\"FieldFloat\":-3.40282347E+38,\"FieldNtext\":\"FieldNtext\",\"FieldDateTime\":\"1753-01-01T00:00:00\",\"FieldByteArray50\":\"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=\",\"FieldVarByteArrayMax1024\":\"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==\",\"FieldDecimal\":null,\"FieldString\":\"FieldString\",\"FieldTimeStamp\":\"\",\"InsertUser\":0,\"InsertDate\":\"2014-08-06T22:16:33.9058174Z\",\"UpdateUser\":null,\"UpdateDate\":null}";

            EntityUtils target = new EntityUtils();

            TestCaseTester actual = new TestCaseTester();
            target.JsonDeserializeOnObject(jsonString, actual);

            TestCaseTester expected = ServiceBaseTest.CreateNewMinTester();

            // check if two test case testers are equal in all values for a json object
            ServiceBaseTest.AssertEqualTwoTestCaseTesters(expected, actual);
        }

        [TestMethod()]
        public void JsonDeserializeOnObject2()
        {
            // all max values for testCaseTester
            string jsonString = "{\"TestCaseTesterID\":\"8fd37568-ca5b-4912-ba6f-09ff31652262\",\"TestCaseTesterTitle\":\"TestCaseTesterTitle\",\"TestCaseTesterCode\":\"TestCaseTesterCode\",\"FieldGuid\":\"b930c9dd-1fa1-47be-a1a2-3555270d57e4\",\"FieldByte\":255,\"FieldInt16\":32767,\"FieldInt32\":2147483647,\"FieldInt64\":9223372036854775807,\"FieldDouble\":1.7976931348623157E+308,\"FieldFloat\":3.40282347E+38,\"FieldNtext\":\"FieldNtext\",\"FieldDateTime\":\"9999-12-31T00:00:00\",\"FieldByteArray50\":\"//////////////////////////////////////////////////////////////////8=\",\"FieldVarByteArrayMax1024\":\"/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////w==\",\"FieldDecimal\":null,\"FieldString\":\"FieldString\",\"FieldTimeStamp\":\"\",\"InsertUser\":0,\"InsertDate\":\"2014-08-06T23:11:39.0773639Z\",\"UpdateUser\":null,\"UpdateDate\":null}";

            EntityUtils target = new EntityUtils();

            TestCaseTester actual = new TestCaseTester();
            target.JsonDeserializeOnObject(jsonString, actual);

            TestCaseTester expected = ServiceBaseTest.CreateNewMaxTester();
            expected.FieldGuid = new Guid("b930c9dd-1fa1-47be-a1a2-3555270d57e4"); // because it creates a random guid every time, we need to replace it

            // check if two test case testers are equal in all values for a json object
            ServiceBaseTest.AssertEqualTwoTestCaseTesters(expected, actual);
        }


        [TestMethod()]
        public void JsonDeserializeOnObject3()
        {
            // settings only two values
            string jsonString = "{\"TestCaseTesterID\":\"edce87b7-32b2-40a6-8f13-92e8c4c97563\",\"InvalidPropertyName\":\"TestCaseTesterTitle\"}";

            EntityUtils target = new EntityUtils();

            TestCaseTester actual = ServiceBaseTest.CreateNewMinTester();

            try
            {
                target.JsonDeserializeOnObject(jsonString, actual);
                Assert.Fail();
            }
            catch (FWPropertyNotFoundException ex)
            {
                Assert.AreEqual(ex.PropertyName, "InvalidPropertyName");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unknown exception: " + ex.ToString());
            }

        }


        [TestMethod()]
        public void JsonDeserializeOnObject4()
        {
            //invalidproperty should be skipped because it is not in the include list

            // settings only two values
            string jsonString = "{\"TestCaseTesterID\":\"edce87b7-32b2-40a6-8f13-92e8c4c97563\",\"InvalidPropertyName\":\"TestCaseTesterTitle\"}";

            EntityUtils target = new EntityUtils();

            TestCaseTester actual = ServiceBaseTest.CreateNewMinTester();

            List<string> includeList = new List<string>();
            includeList.Add("TestCaseTesterID"); // only this will be replaced

            target.JsonDeserializeOnObject(jsonString, actual, includeList);
            Assert.AreEqual(new Guid("edce87b7-32b2-40a6-8f13-92e8c4c97563"), actual.TestCaseTesterID);
        }


        [TestMethod()]
        public void JsonIsValidThenDeserialize()
        {
            // all min values for testCaseTester
            string jsonString = "{\"TestCaseTesterID\":\"edce87b7-32b2-40a6-8f13-92e8c4c97563\",\"TestCaseTesterTitle\":\"TestCaseTesterTitle\",\"TestCaseTesterCode\":\"TestCaseTesterCode\",\"FieldGuid\":\"00000000-0000-0000-0000-000000000000\",\"FieldByte\":0,\"FieldInt16\":-32768,\"FieldInt32\":-2147483648,\"FieldInt64\":-9223372036854775808,\"FieldDouble\":-1.7976931348623157E+308,\"FieldFloat\":-3.40282347E+38,\"FieldNtext\":\"FieldNtext\",\"FieldDateTime\":\"1753-01-01T00:00:00\",\"FieldByteArray50\":\"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=\",\"FieldVarByteArrayMax1024\":\"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==\",\"FieldDecimal\":null,\"FieldString\":\"FieldString\",\"FieldTimeStamp\":\"\",\"InsertUser\":0,\"InsertDate\":\"2014-08-06T22:16:33.9058174Z\",\"UpdateUser\":null,\"UpdateDate\":null}";

            EntityUtils target = new EntityUtils();

            var actual = target.JsonIsValidThenDeserialize(jsonString);

            Assert.AreNotEqual(null, actual);
        }

        [TestMethod()]
        public void JsonIsValidThenDeserialize2()
        {
            // all min values for testCaseTester
            string jsonString = "{InvalidJSON:InvalidatedJson}";

            EntityUtils target = new EntityUtils();

            var actual = target.JsonIsValidThenDeserialize(jsonString);

            Assert.AreEqual(null, actual);
        }


        [TestMethod]
        public void ConvertStringToObjectAllTypes()
        {
            // testing all major types

            EntityUtils target = new EntityUtils();
            
            bool MFieldbool = false;
            short MFieldint16 = 10;
            int MFieldint32 = 10;
            long MFieldint64 = 10;
            double MFielddouble = 100.111;
            float MFieldfloat = 100.111f;
            DateTime MFielddatetime = new DateTime(2013,1,1);
            decimal MFielddecimal = 8438938383832;
            string MFieldstring = "Some string for test";

            object[] testValues = {
                                    MFieldbool,
                                    MFieldint16,
                                    MFieldint32,
                                    MFieldint64,
                                    MFielddouble,
                                    MFieldfloat,
                                    MFielddatetime,
                                    MFielddecimal,
                                    MFieldstring,
                                };
            for (int i = 0; i < testValues.Length; i++)
            {
                object result = target.ConvertStringToObject(testValues[i].ToString(), testValues[i].GetType());
                Assert.AreEqual(testValues[i], result);
            }

        }

        [TestMethod]
        public void ConvertStringToObjectGuid()
        {
            EntityUtils target = new EntityUtils();

            Guid fieldGuid = Guid.NewGuid();
            object result = target.ConvertStringToObject(fieldGuid.ToString(), fieldGuid.GetType());
            Assert.AreEqual(fieldGuid, result);
        }

        [TestMethod]
        public void ConvertStringToObjectEnumByName()
        {
            EntityUtils target = new EntityUtils();
            GetSourceTypeEnum testE = GetSourceTypeEnum.View;
            object result = target.ConvertStringToObject(testE.ToString(), testE.GetType());
            Assert.AreEqual(testE, result);
        }

        [TestMethod]
        public void ConvertStringToObjectEnumByValue()
        {
            EntityUtils target = new EntityUtils();
            GetSourceTypeEnum testE = GetSourceTypeEnum.View;
            object result = target.ConvertStringToObject(((int)testE).ToString(), testE.GetType());
            Assert.AreEqual(testE, result);
        }

        [TestMethod]
        public void ConvertStringToObjectByteArray()
        {
            // testing a byte[] for all values from 0 to 255

            byte[] MFieldbytearray50 = new byte[255];
            for (byte i = 0; i < 255; i++)
                MFieldbytearray50[i] = i;

            EntityUtils target = new EntityUtils();
            string objectJson = target.JsonSerializeObject(MFieldbytearray50);

            object o = target.ConvertStringToObject(objectJson, MFieldbytearray50.GetType());

            Assert.IsTrue(o.GetType() == typeof(byte[]));

            for (int i = 0; i < MFieldbytearray50.Length; i++)
                Assert.AreEqual(MFieldbytearray50[i], ((byte[])o)[i]);
        }


        [TestMethod]
        public void ConvertStringToObjectComplexFormat()
        {
            // testing a byte[] for all values from 0 to 255

            string value = "{\"Field1\":\"f1Value\",\"Field2\":\"0cf8f670-c742-4f12-ba0b-98d8f3b9077a\",\"Field3\":\"2013-01-01T00:00:00\"}";


            EntityUtils target = new EntityUtils();
            object o = target.ConvertStringToObject(value, typeof(ComplexStructure));

            Assert.IsTrue(o.GetType() == typeof(ComplexStructure));
            ComplexStructure cs = (ComplexStructure)o;
            Assert.AreEqual("f1Value", cs.Field1);
            Assert.AreEqual(new Guid("0cf8f670-c742-4f12-ba0b-98d8f3b9077a"), cs.Field2);
            Assert.AreEqual(new DateTime(2013,1,1) , cs.Field3);

        }


    }
}
