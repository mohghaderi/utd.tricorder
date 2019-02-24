using Framework.Common;
using Framework.Common.Utils;
using Framework.Service;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Service;

namespace UTD.Tricorder.TestCase.Service.app
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class TimeSeries_SmallInt_SecondsServiceTests
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
            TestUtils.Access.SetPrivateStaticField(typeof(FWUtils), "_SecurityUtils", new SecurityUtilsFake(TestEnums.User.constPatientUserID));
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {

        }
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
        public TimeSeries_SmallInt_SecondsService CreateNewTimeSeries_SmallInt_SecondsService()
        {
            return (TimeSeries_SmallInt_SecondsService)EntityFactory.GetEntityServiceByName(TimeSeries_SmallInt_Seconds.EntityName, "");
        }


        [TestMethod()]
        public void OnAfterInitializeTest()
        {
            // checking services be disabled

            TimeSeries_SmallInt_SecondsService service = (TimeSeries_SmallInt_SecondsService)CreateNewTimeSeries_SmallInt_SecondsService();
            DisableServicesEntitySecurity sec = (DisableServicesEntitySecurity)service.SecurityCheckers[0];
            Assert.IsTrue(sec is DisableServicesEntitySecurity);
            Assert.IsTrue(sec.InsertDisabled == false);
            Assert.IsTrue(sec.DeleteDisabled == true);
            Assert.IsTrue(sec.GetAllDisabled == true);
            Assert.IsTrue(sec.GetByFilterDisabled == true);
            Assert.IsTrue(sec.GetByIDDisabled == true);
            Assert.IsTrue(sec.GetCountDisabled == true);
            Assert.IsTrue(sec.GetMaxDisabled == true);
            Assert.IsTrue(sec.GetMinDisabled == true);
            Assert.IsTrue(sec.UpdateDisabled == true);
        }


        //[TestMethod()]
        //public void InsertTest()
        //{
        //    ITimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
        //    DateTime startDateTime = DateTime.UtcNow;
        //    int TSDateOffset = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    TimeSeries_SmallInt_Seconds v = GenerateTimeSeries_SmallInt_Seconds(TSDateOffset);
        //    service.Insert(v, new InsertParameters());
        //}


        private TimeSeriesStrip InsertStrip()
        {
            ITimeSeriesStripService service = (ITimeSeriesStripService)
                EntityFactory.GetEntityServiceByName(vTimeSeriesStrip.EntityName, "");

            TimeSeriesStrip st = new TimeSeriesStrip();
            //st.StartDateOffset = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
            st.TimeSeriesTypeID = (byte) EntityEnums.TimeSeriesTypeEnum.ECG;
            //st.UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong().Value;
            service.Insert(st, new InsertParameters());

            return st;
        }


        //[TestMethod()]
        //public void PopulateDatabaseByRandomValues()
        //{
        //    //DateTime startDateTime = new DateTime(2010, 1, 1);
        //    //DateTime startDateTime = DateTime.UtcNow;
        //    PopulateDatabaseByRandomValues(100);
        //}


        //[TestMethod]
        //public void PopulateDatabaseFromFileRealData()
        //{
        //    string fileName = @"I:\iosProjects\HealthCareTracker\Resources\Datasets\ECG-DataSamples\ecg_stream_sample.csv";
        //    //DateTime startDateTime = DateTime.UtcNow;
        //    int samplesPerSecond = 300;
        //    char samplesSeparator = ',';

        //    TimeSeriesStrip strip = InsertStrip();
        //    Guid stripId = strip.TimeSeriesStripID;

        //    TimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
        //    int TSDateOffset = strip.StartDateOffset; // DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);

        //    string fileContent = System.IO.File.ReadAllText(fileName);
        //    string[] numbers = fileContent.Split(samplesSeparator);
        //    StringBuilder samplesTextSB = new StringBuilder();

        //    int commaCount = 0;
        //    for (int i = 0; i < fileContent.Length; i++)
        //    {
        //        if (fileContent[i] == ',')
        //        {
        //            commaCount++;
        //            if (commaCount == samplesPerSecond) // once we got enough samples
        //            {
        //                // insert samples to database
        //                commaCount = 0;
        //                string samplesText = samplesTextSB.ToString();
        //                TimeSeries_SmallInt_Seconds v = GenerateTimeSeries_SmallInt_Seconds(TSDateOffset, stripId, samplesText);
        //                service.Insert(v, new InsertParameters());

        //                samplesTextSB.Clear();
        //                TSDateOffset++; // add one second
        //                continue;
        //            }
        //        }
        //        samplesTextSB.Append(fileContent[i]);
        //    }

        //}


        //[TestMethod()]
        private void PopulateDatabaseByRandomValues(int numberOfValues)
        {
            TimeSeriesStrip strip = InsertStrip();
            Guid stripId = strip.TimeSeriesStripID;

            TimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
            //DateTime startDateTime = new DateTime(2014, 1, 1);
            //int TSDateOffset = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
            int TSDateOffset = strip.StartDateOffset;

            for (int i = 0; i < numberOfValues; i++)
            {
                string samplesText = GetOneSecondSamples();
                TimeSeries_SmallInt_Seconds v = GenerateTimeSeries_SmallInt_Seconds(TSDateOffset, stripId, samplesText);
                service.Insert(v, new InsertParameters());
                TSDateOffset++; // add one second
            }
        }


        private TimeSeries_SmallInt_Seconds GenerateTimeSeries_SmallInt_Seconds(int timeOffset, Guid stripId, string samplesText)
        {
            TimeSeries_SmallInt_Seconds v = (TimeSeries_SmallInt_Seconds)EntityFactory.GetEntityObject(TimeSeries_SmallInt_Seconds.EntityName, GetSourceTypeEnum.Table);
            v.TSDateOffset = timeOffset;
            v.TSValue = Convert.ToInt16(TestUtils.RandomUtils.RandomNumber(0, short.MaxValue));
            v.TimeSeriesTypeID = (byte) EntityEnums.TimeSeriesTypeEnum.ECG;
            v.UserID = TestEnums.User.constPatientUserID;
            v.TSValueBinary = CompressionUtils.SerializeAndCompress(samplesText);
            v.TimeSeriesStripID = stripId;
            return v;
        }


        private static CompressionUtils CompressionUtils = new CompressionUtils();

        private string GetOneSecondSamples()
        {
            int samplesPerSecond = 600;
            StringBuilder sb = new StringBuilder();
            sb.Append("");  //sb.Append("["); // we don't need to store brackets to save a little more space
            for (int i = 0; i < samplesPerSecond; i++)
            {
                var number = Convert.ToInt16(TestUtils.RandomUtils.RandomNumber(0, short.MaxValue));
                sb.Append(number.ToString()).Append(",");
            }
            sb.Append(""); //sb.Append("]"); // we don't need to store brackets to save a little more space
            return sb.ToString();
        }




        /// <summary>
        /// Gets the data by range test.
        /// This is only integration test. Functions are tested in DataAcess Layer
        /// </summary>
        [TestMethod()]
        public void GetDataByRangeTest()
        {
            DateTime performanceStartDate = DateTime.UtcNow;

            ITimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
            int startDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2010, 1, 1));
            int endDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2010, 1, 2));
            byte timeSeriesTypeID = (byte)EntityEnums.TimeSeriesTypeEnum.ECG;
            long userID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            var list = service.GetDataByRange(startDate, endDate, timeSeriesTypeID, userID);
            Assert.IsTrue(list.Count == 100); // something returned!
            TimeSpan elapsed = DateTime.UtcNow - performanceStartDate;
            Assert.IsTrue(elapsed.Seconds <= 2); // Performance check
        }



        /// <summary>
        /// Gets the data by range test.
        /// This is only integration test. Functions are tested in DataAcess Layer
        /// </summary>
        [TestMethod()]
        public void GetRealTimeDataTest()
        {
            DateTime performanceStartDate = DateTime.UtcNow;

            ITimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
            int currentDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2014, 1, 2));
            byte timeSeriesTypeID = (byte)EntityEnums.TimeSeriesTypeEnum.ECG;
            long userID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            var list = service.GetRealTimeData(currentDate, timeSeriesTypeID, userID);
            Assert.IsTrue(list.Count == 1); // something returned!
            TimeSpan elapsed = DateTime.UtcNow - performanceStartDate;
            Assert.IsTrue(elapsed.Seconds <= 3); // Performance check
        }


        /// <summary>
        /// Gets the data by range test.
        /// This is only integration test. Functions are tested in DataAcess Layer
        /// </summary>
        [TestMethod()]
        public void GetRealTimeDataJsonTest()
        {
            DateTime performanceStartDate = DateTime.UtcNow;

            ITimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
            int currentDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2014, 1, 2));
            byte timeSeriesTypeID = (byte)EntityEnums.TimeSeriesTypeEnum.ECG;
            long userID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            string jsonText = service.GetRealTimeDataJson(currentDate, timeSeriesTypeID, userID);
            int len = jsonText.Length;
            //byte[] b = new Framework.Common.Utils.CompressionUtils().SerializeAndCompress(jsonText);
            //string s = System.Convert.ToBase64String(b)
            Assert.IsTrue(len > 0);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
            Assert.IsTrue(obj != null);
            int recordCount = 1;
            Assert.AreEqual(recordCount, ((Newtonsoft.Json.Linq.JContainer)(obj)).Count);
        }





        /// <summary>
        /// Gets the data by range json test.
        /// </summary>
        [TestMethod()]
        public void GetDataByRangeJsonTest()
        {
            ITimeSeries_SmallInt_SecondsService service = CreateNewTimeSeries_SmallInt_SecondsService();
            int startDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2010, 1, 1));
            int endDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2010, 1, 2));
            byte timeSeriesTypeID = (byte)EntityEnums.TimeSeriesTypeEnum.ECG;
            long userID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            string jsonText = service.GetDataByRangeJson(startDate, endDate, timeSeriesTypeID, userID);
            int len = jsonText.Length;
            //byte[] b = new Framework.Common.Utils.CompressionUtils().SerializeAndCompress(jsonText);
            //string s = System.Convert.ToBase64String(b)
            Assert.IsTrue(len > 0);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
            Assert.IsTrue(obj != null);
            int recordCount = 100;
            Assert.AreEqual(recordCount, ((Newtonsoft.Json.Linq.JContainer)(obj)).Count);
        }






    }
}
