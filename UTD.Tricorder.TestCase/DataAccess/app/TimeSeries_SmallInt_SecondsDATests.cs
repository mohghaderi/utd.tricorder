using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTD.Tricorder.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.TestCase;
using UTD.Tricorder.Common.ServiceInterfaces;
using Framework.TestCase.CommonClasses;
namespace UTD.Tricorder.DataAccess.Tests
{
    [DeploymentItem("_Config\\")]
    [TestClass()]
    public class TimeSeries_SmallInt_SecondsDATests
    {

        private TimeSeries_SmallInt_SecondsDA GetTarget()
        {
            return (TimeSeries_SmallInt_SecondsDA) EntityFactory.GetEntityDataAccessByName(TimeSeries_SmallInt_Seconds.EntityName, "");
        }

        [TestMethod()]
        public void GetDataByRangeSecondsTableOneSecTest()
        {
            var target = GetTarget();
            DateTime startDateTime = new DateTime(2014, 3, 20, 13, 01, 36);
            DateTime endDateTime = new DateTime(2014, 3, 20, 13, 01, 36);
            int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
            int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
            byte timeSeriesTypeID = 1;
            long userID = TestEnums.User.constPatientUserID;

            List<TimeSeries_SmallInt_Seconds> list = target.GetDataByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID);
            Assert.IsTrue(list.Count == 0, "There should be no row in the range less than a second");
        }


        [TestMethod()]
        public void GetDataByRangeSecondsTableTest()
        {
            var target = GetTarget();
            DateTime startDateTime = new DateTime(2014, 3, 20, 13, 01, 36);
            DateTime endDateTime = new DateTime(2014, 3, 20, 13, 02, 36);
            int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
            int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
            byte timeSeriesTypeID = 1;
            long userID = TestEnums.User.constPatientUserID;

            List<TimeSeries_SmallInt_Seconds> list = target.GetDataByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID);
            Assert.IsTrue(list.Count > 0);
            foreach (TimeSeries_SmallInt_Seconds i in list)
            {
                Assert.AreNotEqual(null, i.TSValueBinary);
            }
        }


        /// <summary>
        /// RealTimeData should return the latest available value in the database
        /// </summary>
        [TestMethod()]
        public void GetRealTimeDataTest1()
        {
            var target = GetTarget();
            DateTime currentDateTime = new DateTime(2014, 1, 1, 00, 00, 00);
            int currentDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(currentDateTime);
            byte timeSeriesTypeID = 1;
            long userID = TestEnums.User.constPatientUserID;
            int lastEndDateSeconds_From_Epoch = GetMaxEndOffset(timeSeriesTypeID, userID);

            List<TimeSeries_SmallInt_Seconds> list = 
                target.GetRealTimeData(currentDateSeconds_From_Epoch, timeSeriesTypeID, userID);

            Assert.IsTrue(list.Count == 1);
            Assert.AreEqual(lastEndDateSeconds_From_Epoch, list[0].TSDateOffset);
            Assert.AreNotEqual(null, list[0].TSValueBinary);
        }

        /// <summary>
        /// There shouldn't be any record return after Maximum end offset
        /// </summary>
        [TestMethod()]
        public void GetRealTimeDataTest2()
        {
            var target = GetTarget();
            //DateTime currentDateTime = new DateTime(2014, 1, 1, 00, 00, 00);
            //int currentDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(currentDateTime);

            byte timeSeriesTypeID = (byte)EntityEnums.TimeSeriesTypeEnum.ECG;
            long userID = TestEnums.User.constPatientUserID;
            int currentDateSeconds_From_Epoch = GetMaxEndOffset(timeSeriesTypeID, userID);

            List<TimeSeries_SmallInt_Seconds> list =
                target.GetRealTimeData(currentDateSeconds_From_Epoch, timeSeriesTypeID, userID);

            Assert.IsTrue(list.Count == 0);
        }


        /// <summary>
        /// Gets the maximum end offset.
        /// </summary>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        private int GetMaxEndOffset(byte timeSeriesTypeID, long userID)
        {
            // NOTE: Service can not be used because no user credential is available here
            //ITimeSeriesStripService service = (ITimeSeriesStripService)
            //    EntityFactory.GetEntityServiceByName(TimeSeriesStrip.EntityName, "");

            TimeSeriesStripDA service = (TimeSeriesStripDA)
                EntityFactory.GetEntityDataAccessByName(vTimeSeriesStrip.EntityName, "");

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vTimeSeriesStrip.ColumnNames.UserID, userID));
            filter.AddFilter(new Filter(vTimeSeriesStrip.ColumnNames.TimeSeriesTypeID, timeSeriesTypeID));

            return Convert.ToInt32(service.GetMax(vTimeSeriesStrip.ColumnNames.EndDateOffset, filter));
        }


        //[TestMethod()]
        //public void GetDataByRangeMinutesTableTest()
        //{
        //    var target = GetTarget();
        //    DateTime startDateTime = new DateTime(2014, 1, 1, 00, 00, 00);
        //    DateTime endDateTime = new DateTime(2014, 1, 1, 00, 59, 00);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    byte timeSeriesTypeID = 1;
        //    long userID = TestEnums.User.constPatientUserID;

        //    List<TimeSeries_SmallInt_Seconds> list = target.GetDataByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID);
        //    Assert.IsTrue(list.Count > 0);
        //    foreach (TimeSeries_SmallInt_Seconds i in list)
        //    {
        //        DateTime dt = DateTimeEpoch.ConvertSecondsEpochToDateTime(i.TSDateOffset);
        //        Assert.AreEqual(0, dt.Second);
        //    }
        //}

        //[TestMethod()]
        //public void GetDataByRangeHoursTableTest()
        //{
        //    var target = GetTarget();
        //    DateTime startDateTime = new DateTime(2014, 1, 1);
        //    DateTime endDateTime = new DateTime(2014, 1, 2);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    byte timeSeriesTypeID = 1;
        //    long userID = TestEnums.User.constPatientUserID;

        //    List<TimeSeries_SmallInt_Seconds> list = target.GetDataByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID);
        //    Assert.IsTrue(list.Count > 0);
        //    foreach (TimeSeries_SmallInt_Seconds i in list)
        //    {
        //        DateTime dt = DateTimeEpoch.ConvertSecondsEpochToDateTime(i.TSDateOffset);
        //        Assert.AreEqual(0, dt.Minute);
        //        Assert.AreEqual(0, dt.Second);
        //    }

        //}

        //[TestMethod()]
        //public void GetDataByRangeDaysTableTest()
        //{
        //    var target = GetTarget();
        //    DateTime startDateTime = new DateTime(2014, 1, 1);
        //    DateTime endDateTime = new DateTime(2015,1,1);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    byte timeSeriesTypeID = 1;
        //    long userID = TestEnums.User.constPatientUserID;

        //    List<TimeSeries_SmallInt_Seconds> list = target.GetDataByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID);
        //    Assert.IsTrue(list.Count > 0);
        //    foreach (TimeSeries_SmallInt_Seconds i in list)
        //    {
        //        DateTime dt = DateTimeEpoch.ConvertSecondsEpochToDateTime(i.TSDateOffset);
        //        Assert.AreEqual(0, dt.Hour);
        //        Assert.AreEqual(0, dt.Minute);
        //        Assert.AreEqual(0, dt.Second);
        //    }
        //}





        ////-------------------------  GetTableNameByRange --------------------------


        //[TestMethod()]
        //public void GetTableNameByRangeDaysTest()
        //{
        //    // large range should return by days
        //    var target = GetTarget();

        //    DateTime startDateTime = new DateTime(2014, 1, 1);
        //    DateTime endDateTime = new DateTime(2015, 1, 1);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    string dataType = "SmallInt";

        //    string tableName = target.GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);
        //    Assert.AreEqual("TimeSeries_SmallInt_Days", tableName);
        //}


        //[TestMethod()]
        //public void GetTableNameByRangeHourTest()
        //{
        //    // less than a day by hours
        //    var target = GetTarget();

        //    DateTime startDateTime = new DateTime(2014, 1, 1);
        //    DateTime endDateTime = new DateTime(2014, 1, 2);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    string dataType = "SmallInt";

        //    string tableName = target.GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);
        //    Assert.AreEqual("TimeSeries_SmallInt_Hours", tableName);
        //}


        //[TestMethod()]
        //public void GetTableNameByRangeMinutesTest()
        //{
        //    // less than an hour by minutes
        //    var target = GetTarget();

        //    DateTime startDateTime = new DateTime(2014, 1, 1, 12, 00, 00);
        //    DateTime endDateTime = new DateTime(2014, 1, 1, 12, 59, 00);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    string dataType = "SmallInt";

        //    string tableName = target.GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);
        //    Assert.AreEqual("TimeSeries_SmallInt_Minutes", tableName);
        //}

        //[TestMethod()]
        //public void GetTableNameByRangeSecondsTest()
        //{
        //    // less than a minute by seconds
        //    var target = GetTarget();

        //    DateTime startDateTime = new DateTime(2014, 1, 1, 12, 00, 00);
        //    DateTime endDateTime = new DateTime(2014, 1, 1, 12, 01, 00);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    string dataType = "SmallInt";

        //    string tableName = target.GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);
        //    Assert.AreEqual("TimeSeries_SmallInt_Seconds", tableName);
        //}

        //[TestMethod()]
        //public void GetTableNameByRangeSecondsTest2()
        //{
        //    // very small range by seconds
        //    var target = GetTarget();

        //    DateTime startDateTime = new DateTime(2014, 1, 1, 12, 00, 00);
        //    DateTime endDateTime = new DateTime(2014, 1, 1, 12, 00, 00);
        //    int startDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDateTime);
        //    int endDateSeconds_From_Epoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDateTime);
        //    string dataType = "SmallInt";

        //    string tableName = target.GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);
        //    Assert.AreEqual("TimeSeries_SmallInt_Seconds", tableName);
        //}




        public byte EntityEnum { get; set; }
    }
}
