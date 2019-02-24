using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTD.Tricorder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Common;
using UTD.Tricorder.TestCase;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using Framework.TestCase.CommonClasses;
using UTD.Tricorder.Common.SP;
namespace UTD.Tricorder.Service.Tests
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class VitalValueServiceTests
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestUtils.Access.SetPrivateStaticField(typeof(FWUtils), "_SecurityUtils", new SecurityUtilsFake(TestEnums.User.constPatientUserID));
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }
        //
        #endregion


        [TestMethod()]
        public void FakeSetupTest()
        {
            long? l = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            Assert.AreEqual(TestEnums.User.constPatientUserID, l.Value);
        }


        /// <summary>
        /// Creates the new vital value service.
        /// </summary>
        /// <returns></returns>
        public IVitalValueService CreateNewVitalValueService()
        {
            return (IVitalValueService)EntityFactory.GetEntityServiceByName(vVitalValue.EntityName, "");
        }


        //[TestMethod()]
        //public void OnAfterInitializeTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetAllChartDataTest()
        {
            IVitalValueService service = CreateNewVitalValueService();
            DateTime start = DateTime.UtcNow;
            var list = service.GetAllChartData(
                
                new GetAllChartDataSP() { UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong(), 
                VitalTypeID = (int)EntityEnums.VitalTypeEnum.Weight });

            //byte[] b = new Framework.Common.Utils.CompressionUtils().SerializeAndCompress(list);
            Assert.IsTrue(list.Count >= 10000);
            TimeSpan elapsed = DateTime.UtcNow - start;
            Assert.IsTrue(elapsed.Seconds <= 2); // Performance check
        }

        [TestMethod()]
        public void GetAllChartDataJsonTest()
        {
            //Compression Performance Tests Results:

            // for 10000 points between 0, 100
            // UnCompressed JsonText = 154XXX bytes
            // UnCompressed JsonText (Minutes) = 139XXX bytes
            // UnCompressed JsonText (Hour) = 119XXX bytes
            // Base64 (JsonText) = 76XXX bytes

            //1- GZip Compress byte[] of byte[]   = 92XXX bytes
            //2- GZip Compress List<vVitalValue>  = 95XXX bytes
            //3- GZip Compress JsonText (0 value after) = 52XXX bytes

            //1- Difference Compression JsonText = 106XXX bytes
            //2- GZip Difference Compression JsonText = 42XXX bytes
            //3- Difference Compression Minute JsonText = 89XXX bytes
            //4- Difference Compression Hour JsonText = 73XXX

            IVitalValueService service = CreateNewVitalValueService();
            string jsonText = service.GetAllChartDataJson(
                new GetAllChartDataSP() { UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong(), 
                                          VitalTypeID = (int)EntityEnums.VitalTypeEnum.Weight });
            int len = jsonText.Length;
            //byte[] b = new Framework.Common.Utils.CompressionUtils().SerializeAndCompress(jsonText);
            //string s = System.Convert.ToBase64String(b)
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
            Assert.IsTrue(obj != null);
        }


        [TestMethod()]
        public void InsertTest()
        {
            IVitalValueService service = CreateNewVitalValueService();
            VitalValue v = GenerateVitalValue();
            service.Insert(v, new InsertParameters());
        }


        //[TestMethod()]
        public void PopulateDatabaseByRandomValues()
        {
            IVitalValueService service = CreateNewVitalValueService();

            for (int i = 0; i < 100; i++)
            {
                VitalValue v = GenerateVitalValue();
                service.Insert(v, new InsertParameters());
            }
        }


        private VitalValue GenerateVitalValue()
        {
            DateTime startDateTime = new DateTime(2010, 1, 1);
            DateTime endDateTime = new DateTime(2030, 1, 1);
            VitalValue v = (VitalValue)EntityFactory.GetEntityObject(vVitalValue.EntityName, GetSourceTypeEnum.Table);
            v.DataValue = TestUtils.RandomUtils.RandomNumber(30,100);
            v.VitalTypeID = (int) EntityEnums.VitalTypeEnum.Height;
            v.IsManualEntry = false;
            v.RecordDateTime = TestUtils.RandomUtils.RandomDateTimeBetween(startDateTime, endDateTime);
            v.PersonID = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            return v;
        }


    }
}
