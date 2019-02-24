//#DONT REGENERATE
using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface ITimeSeries_SmallInt_SecondsService : IServiceBaseT<TimeSeries_SmallInt_Seconds, TimeSeries_SmallInt_Seconds>
    {
        /// <summary>
        /// Gets the data by range.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        List<TimeSeries_SmallInt_Seconds> GetDataByRange(int startDate, int endDate, byte timeSeriesTypeID, long userID);


        /// <summary>
        /// Gets the data by range json.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        string GetDataByRangeJson(int startDate, int endDate, byte timeSeriesTypeID, long userID);


        /// <summary>
        /// Gets the real time data.
        /// </summary>
        /// <param name="currentDateOffset">The current date offset.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        List<TimeSeries_SmallInt_Seconds> GetRealTimeData(int currentDateOffset, byte timeSeriesTypeID, long userID);

        /// <summary>
        /// Gets the real time data json.
        /// </summary>
        /// <param name="currentDateOffset">The current date offset.</param>
        /// <param name="timeSeriesTypeID">The time series type identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        string GetRealTimeDataJson(int currentDateOffset, byte timeSeriesTypeID, long userID);


    }
}

