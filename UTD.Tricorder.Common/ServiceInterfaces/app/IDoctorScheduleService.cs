using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IDoctorScheduleService : IServiceBaseT<DoctorSchedule, vDoctorSchedule>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Add time schedules batch
        /// </summary>
        /// <param name="p"></param>
        void DoctorScheduleAddBatch(DoctorScheduleAddBatchSP p);

        /// <summary>
        /// Checks if a doctor available in a certain time
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        bool IsTimeAvailable(DoctorScheduleIsTimeAvailableSP p);


        ///// <summary>
        ///// Get available times for a specific date
        ///// </summary>
        ///// <param name="p">parameters</param>
        ///// <returns></returns>
        //IList<long> GetTimesByDate(DoctorScheduleGetTimeByDateSP p);


        /// <summary>
        /// Gets available times that are reservable by patients
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        IList<vDoctorSchedule> GetByRange(DoctorScheduleGetByRangeSP p);

        /// <summary>
        /// Returns counts of avaiable slots by range
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        long GetCountByRange(DoctorScheduleGetByRangeSP p);


        /// <summary>
        /// Copies available times of a day to another day (by period)
        /// </summary>
        /// <param name="p"></param>
        void CopyRange(DoctorScheduleCopyRangeSP p);


        /// <summary>
        /// Delets a slots by a defined range
        /// </summary>
        /// <param name="p"></param>
        void DeleteRange(DoctorScheduleDeleteRangeSP p);


		#endregion
    }
}

