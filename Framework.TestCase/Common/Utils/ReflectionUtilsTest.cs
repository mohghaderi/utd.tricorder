using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using Framework.TestCase.CommonClasses;

namespace Framework.TestCase.Common.Utils
{
    
    
    /// <summary>
    ///This is a test class for ReflectionUtilsTest and is intended
    ///to contain all ReflectionUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReflectionUtilsTest
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
        ///A test for ReflectionUtils Constructor
        ///</summary>
        [TestMethod()]
        public void ReflectionUtilsConstructorTest()
        {
            ReflectionUtils target = new ReflectionUtils();
        }

        /// <summary>
        ///A test for CreateInstance
        ///</summary>
        [TestMethod()]
        public void CreateInstanceTest()
        {
            ReflectionUtils target = new ReflectionUtils();
            string className = "FakeClassName"; 
            object actual;
            try
            {
                actual = target.CreateInstance(className);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Reflection: Can't create class:") == false)
                    Assert.Fail();
            }
        }

        /// <summary>
        ///A test for CreateInstance
        ///</summary>
        [TestMethod()]
        public void CreateInstanceTest1()
        {
            ReflectionUtils target = new ReflectionUtils();
            string className = "Framework.TestCase.Common.Utils.ReflectionUtilsTest, Framework.TestCase";
            object actual;
            try
            {
                actual = target.CreateInstance(className);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        /// <summary>
        ///A test for CreateInstance
        ///</summary>
        [TestMethod()]
        public void CreateInstanceTest2()
        {
            ReflectionUtils target = new ReflectionUtils(); 
            string classNamespace = "Framework.Common.Utils";
            string className = "ReflectionUtils"; 
            string assemblyName = "Framework"; 
            object[] args = null; 
            object actual;
            try
            {
                actual = target.CreateInstance(classNamespace, className, assemblyName, args);
            }
            catch (Exception)
            {
                Assert.Fail();
            } 
        }

        /// <summary>
        ///A test for CreateInstance
        ///</summary>
        [TestMethod()]
        public void CreateInstanceTest3()
        {
            ReflectionUtils target = new ReflectionUtils();
            string classNamespace = "Framework.Common.Utils";
            string className = "FakeClassName";
            string assemblyName = "Framework";
            object[] args = null;
            object actual;
            try
            {
                actual = target.CreateInstance(classNamespace, className, assemblyName, args);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Reflection: Can't create class:") == false)
                    Assert.Fail();
            }
        }



        /// <summary>
        ///A test for GetEntityNameFromType
        ///</summary>
        [TestMethod()]
        public void GetEntityNameFromTypeTest()
        {
            ReflectionUtils target = new ReflectionUtils();
            string typeFullName = "Company.Product.EntityObjects.Schema.EntityNameEN";
            string postFix = "EN";

            string expected = "";
            if (FWUtils.ConfigUtils.GetAppSettings().Project.UseSchemaWithEntityName)
                expected = "Schema.EntityName";
            else
                expected = "EntityName";

            string actual;
            actual = target.GetEntityNameFromType(typeFullName, postFix);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetEntityNameFromType
        ///</summary>
        [TestMethod()]
        public void GetEntityNameFromTypeTest2()
        {
            ReflectionUtils target = new ReflectionUtils();
            string typeFullName = "UTD.Tricorder.Services.mem.UserService";
            string postFix = "Service";

            string expected = "";
            if (FWUtils.ConfigUtils.GetAppSettings().Project.UseSchemaWithEntityName)
                expected = "mem.User";
            else
                expected = "User";

            string actual;
            actual = target.GetEntityNameFromType(typeFullName, postFix);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetEntityNameFromType
        ///</summary>
        [TestMethod()]
        public void GetEntityNameFromTypeTest3()
        {
            ReflectionUtils target = new ReflectionUtils();
            string typeFullName = "UTD.mem.User";
            string postFix = null;
            
            string expected = "";
            if (FWUtils.ConfigUtils.GetAppSettings().Project.UseSchemaWithEntityName)
                expected = "mem.User";
            else
                expected = "User";

            string actual;
            actual = target.GetEntityNameFromType(typeFullName, postFix);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for CloneByFirstConstructor
        ///</summary>
        [TestMethod()]
        public void CloneByFirstConstructorTest1()
        {
            ReflectionUtils target = new ReflectionUtils();
            ComplexStructure c = new ComplexStructure();
            c.Field1 = "SomeValue";
            Type t = c.GetType();
            ComplexStructure actual;
            try
            {
                actual = (ComplexStructure) target.CloneByFirstConstructor(t);
                Assert.AreEqual(null, actual.Field1);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}
