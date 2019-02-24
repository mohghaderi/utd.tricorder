using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.TestCase.Common
{
    [TestClass]
    [DeploymentItem("_Config\\")]
    public class AllEntityObjectInfoConstructorTest
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

        private class EntityADK
        {
            public string EntityName;
            public string AdditionalDataKey;
            public EntityADK(string entityName, string additionalDataKey)
            {
                this.EntityName = entityName;
                this.AdditionalDataKey = additionalDataKey;
            }
        }


        [TestMethod()]
        public void appEntities_EN_ConstructorTest()
        {
            List<EntityADK> list = new List<EntityADK>();

            vUser v = new vUser();
            // we find all classes in common layer and we test all classes against it
            List<string> classes = GetClasses("UTD.Tricorder.Common.ServiceInterfaces", v.GetType().Assembly);
            foreach(string c in classes)
            {
                string className = c.Substring(1, c.Length - 8);
                list.Add(new EntityADK(className, ""));
            }

            list.Add(new EntityADK(vVitalValue.EntityName, VitalValueEN.AdditionalData_MyVital));

            TestList(list);

        }

        private void TestList(List<EntityADK> list)
        {
            foreach (EntityADK en in list)
                CreateTest(en.EntityName, en.AdditionalDataKey);
        }





        private void CreateTest(string entityName, string additionalDataKey)
        {
            EntityInfoBase en = EntityFactory.GetEntityInfoByName(entityName, additionalDataKey);
            Assert.IsTrue(en != null);
            //Assert.IsTrue(string.IsNullOrEmpty(en.TitleFieldName) == false);
            //Assert.IsTrue(string.IsNullOrEmpty(en.CodeFieldName) == false);
        }

        // copied from : http://stackoverflow.com/questions/79693/getting-all-types-in-a-namespace-via-reflection
        /// <summary>
        /// Get classes inside a namespace
        /// </summary>
        /// <param name="nameSpace">name space</param>
        /// <param name="asm">assembly</param>
        /// <returns></returns>
        public static List<string> GetClasses(string nameSpace, Assembly asm)
        {
            //Assembly asm = Assembly.GetExecutingAssembly();

            List<string> namespacelist = new List<string>();
            List<string> classlist = new List<string>();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == nameSpace)
                    namespacelist.Add(type.Name);
            }

            foreach (string classname in namespacelist)
                classlist.Add(classname);

            return classlist;
        }


    }
}
