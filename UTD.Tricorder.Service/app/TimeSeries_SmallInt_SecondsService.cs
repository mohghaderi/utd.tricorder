//#DONT REGENERATE
using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service
{
    public class TimeSeries_SmallInt_SecondsService : ServiceBase<TimeSeries_SmallInt_Seconds, TimeSeries_SmallInt_Seconds>, ITimeSeries_SmallInt_SecondsService
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public const string AdditionalData_MyVital = "MyVital";


        public override void OnAfterInitialize()
        {
            this.SecurityCheckers.Clear(); // no default security (for performance only)

            var sec = new DisableServicesEntitySecurity(this);
            sec.DisableAll();
            sec.InsertDisabled = false;

            this.SecurityCheckers.Add(sec);
        }


        /// <summary>
        /// Gets the data by range.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public List<TimeSeries_SmallInt_Seconds> GetDataByRange(int start, int end, byte timeSeriesTypeID, long userID)
        {
            return ((UTD.Tricorder.DataAccess.TimeSeries_SmallInt_SecondsDA)
                this.DataAccessObject).GetDataByRange(start, end, timeSeriesTypeID, userID);
        }

        /// <summary>
        /// Gets the data by range json.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public string GetDataByRangeJson(int startDate, int endDate, byte timeSeriesTypeID, long userID)
        {
            List<TimeSeries_SmallInt_Seconds> list = GetDataByRange(startDate, endDate, timeSeriesTypeID, userID);
            return ConvertToJson(list);
        }

        private static string ConvertToJson(List<TimeSeries_SmallInt_Seconds> list)
        {

            Framework.Common.Utils.CompressionUtils compUtils = new Framework.Common.Utils.CompressionUtils();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("[");
            long tsOffset = 0;
            TimeSeries_SmallInt_Seconds prevItem = null;
            for (int i = 0; i < list.Count; i++)
            {
                TimeSeries_SmallInt_Seconds item = list[i];

                tsOffset = Convert.ToInt64(item.TSDateOffset);

                //// Delta Compression
                if (prevItem != null)
                    tsOffset = item.TSDateOffset - prevItem.TSDateOffset;

                sb.Append("[")
                    .Append(tsOffset.ToString()).Append(",")  //offset
                    .Append(item.TSValue.ToString()); // value

                if (item.TSValueBinary != null) // samples
                {
                    sb.Append(",");
                    sb.Append("[");
                    sb.Append(compUtils.DecompressAndDeserialze(item.TSValueBinary));
                    sb.Append("]");
                }

                sb.Append("]");

                if (i != list.Count - 1)
                    sb.Append(",");



                prevItem = item;
            }
            //sb.Append("[").Append(DateTimeEpoch.ConvertDateToSecondsEpoch(DateTime.UtcNow)).Append(", null]"); // creating end of the date null
            sb.Append("]");

            return sb.ToString();
        }


        /// <summary>
        /// Gets the real time data.
        /// </summary>
        /// <param name="currentDateOffset">The current date offset.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public List<TimeSeries_SmallInt_Seconds> GetRealTimeData(int currentDateOffset, byte timeSeriesTypeID, long userID)
        {
            return ((UTD.Tricorder.DataAccess.TimeSeries_SmallInt_SecondsDA)
                this.DataAccessObject).GetRealTimeData(currentDateOffset, timeSeriesTypeID, userID);
        }

        /// <summary>
        /// Gets the real time data json.
        /// </summary>
        /// <param name="currentDateOffset">The current date offset.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public string GetRealTimeDataJson(int currentDateOffset, byte timeSeriesTypeID, long userID)
        {
            List<TimeSeries_SmallInt_Seconds> list = GetRealTimeData(currentDateOffset, timeSeriesTypeID, userID);
            return ConvertToJson(list);
        }


        private static Framework.Common.Utils.CompressionUtils CompressionUtils = new Framework.Common.Utils.CompressionUtils();

        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            TimeSeries_SmallInt_Seconds obj = (TimeSeries_SmallInt_Seconds)entitySet;
            
            if (this.AdditionalDataKey == VitalValueEN.AdditionalData_MyVital)
                obj.UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            // if only raw data was provided then compress it before insertion
            if (obj.RawString != null)
            {
                obj.TSValueBinary = CompressionUtils.SerializeAndCompress(obj.RawString); 
            }

            obj.TSDateOffset = DateTimeEpoch.GetUtcNowEpoch();
            return true;
        }


        #endregion

    }
}

