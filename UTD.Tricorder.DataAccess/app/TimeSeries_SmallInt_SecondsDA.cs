//#DONT REGENERATE
using System;
using System.Collections.Generic;
using Framework.DataAccess;
using UTD.Tricorder.Common.EntityObjects;
using Framework.Common;

namespace UTD.Tricorder.DataAccess
{
    public class TimeSeries_SmallInt_SecondsDA : DataAccessBase<TimeSeries_SmallInt_Seconds, TimeSeries_SmallInt_Seconds>
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public List<TimeSeries_SmallInt_Seconds> GetDataByRange(int startDateSeconds_From_Epoch, int endDateSeconds_From_Epoch, byte timeSeriesTypeID, long userID)
        {
            // Changing NHibernate TableName is hard. We wanted to go for a faster implementation
            // it is not database independant, but it is fast 

            string[] pNames = { "StartDate", "EndDate", "TimeSeriesTypeID", "UserID" };
            object[] pValues = { startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, timeSeriesTypeID, userID };

            List<string> cols = new List<string>();
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset);
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValue);
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValueBinary);

            System.Collections.IList list = ExecStoredProcedureQuery("app.TimeSeries_SmallInt_Get", new List<string>(pNames), new List<object>(pValues));
            return (List<TimeSeries_SmallInt_Seconds>)
                ConvertToTypedList(GetSourceTypeEnum.Table, cols, list);

            //FilterExpression filter = new FilterExpression();
            //filter.AddFilter(new Filter(TimeSeries_SmallInt_Seconds.ColumnNames.TimeSeriesTypeID, timeSeriesTypeID));
            //filter.AddFilter(new Filter(TimeSeries_SmallInt_Seconds.ColumnNames.UserID, userID));
            //filter.AddFilter(new Filter(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset, startDateSeconds_From_Epoch, FilterOperatorEnum.GreaterThanOrEqualTo));
            //filter.AddFilter(new Filter(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset, endDateSeconds_From_Epoch, FilterOperatorEnum.LessThanOrEqualTo));

            //List<string> cols = new List<string>();
            //cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset);
            //cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValue);
            //cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValueBinary);

            //string dataType = "SmallInt";
            //string tableName = GetTableNameByRange(startDateSeconds_From_Epoch, endDateSeconds_From_Epoch, dataType);


            //GetByFilterParameters p = new GetByFilterParameters(this.Entity, filter, new SortExpression(), 0, 100,cols, GetSourceTypeEnum.Table);
            //return (List<TimeSeries_SmallInt_Seconds>) this.GetByFilter(p);
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
            // Changing NHibernate TableName is hard. We wanted to go for a faster implementation
            // it is not database independant, but it is fast 

            string[] pNames = { "currentDateOffset", "TimeSeriesTypeID", "UserID" };
            object[] pValues = { currentDateOffset, timeSeriesTypeID, userID };

            List<string> cols = new List<string>();
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset);
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValue);
            cols.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValueBinary);

            System.Collections.IList list = ExecStoredProcedureQuery("app.TimeSeries_SmallInt_GetRealTimeData", new List<string>(pNames), new List<object>(pValues));
            return (List<TimeSeries_SmallInt_Seconds>)
                ConvertToTypedList(GetSourceTypeEnum.Table, cols, list);
        }

        ///// <summary>
        ///// Gets the table name by range.
        ///// </summary>
        ///// <param name="startDateSeconds_From_Epoch">The start date.</param>
        ///// <param name="endDateSeconds_From_Epoch">The end date.</param>
        ///// <param name="dataType">Type of the data.</param>
        ///// <returns></returns>
        //public string GetTableNameByRange(int startDateSeconds_From_Epoch, int endDateSeconds_From_Epoch, string dataType)
        //{
        //    string granularity = "";

        //    int range = (endDateSeconds_From_Epoch - startDateSeconds_From_Epoch); // range seconds

        //    if (range <= 60) // less than 60 seconds
        //    {
        //        granularity = "Seconds";
        //    }
        //    else if (range <= 60 * 60) // 1 min to 60 minutes
        //    {
        //        granularity = "Minutes"; 
        //    }
        //    else if (range <= 60 * 60 * 24)
        //    {
        //        granularity = "Hours";
        //    }
        //    else //if (range < 60 * 60 * 24)
        //    {
        //        granularity = "Days";
        //    }

        //    return "TimeSeries_" + dataType + "_" + granularity;
        //}


        #endregion


    }
}

