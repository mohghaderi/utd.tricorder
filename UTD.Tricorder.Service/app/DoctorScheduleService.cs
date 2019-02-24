using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class DoctorScheduleService : ServiceBase<DoctorSchedule, vDoctorSchedule>, IDoctorScheduleService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.\

        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();
            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            this.SecurityCheckers.Add(new MyRowViewAllEditMeEntitySecurity(this, vDoctorSchedule.ColumnNames.DoctorID, userId));
        }

        /// <summary>
        /// Adds a doctor schedule by batch
        /// </summary>
        /// <param name="p"></param>
        public void DoctorScheduleAddBatch(DoctorScheduleAddBatchSP p)
        {
            //foreach(string selectedTime in p.SelectedTimes)
            //{

            //    //DateTime availableDateTime = new DateTime(p.SelectedDate.Year, p.SelectedDate.Month, p.SelectedDate.Day);
            //    string[] time = selectedTime.Split(':');
            //    availableDateTime = availableDateTime.AddHours(Convert.ToDouble(time[0]));
            //    availableDateTime = availableDateTime.AddMinutes(Convert.ToDouble(time[1]));
            //    if (IsTimeAvailable(new DoctorScheduleIsTimeAvailableSP(){
            //        DoctorID = p.DoctorID,
            //        SelectedDateTimeUtc = availableDateTime
            //    }) == false)
            //    {
            //        DoctorSchedule obj = new DoctorSchedule();
            //        obj.DoctorID = p.DoctorID;
            //        obj.DoctorScheduleVisitPlaceID = p.DoctorScheduleVisitPlaceID;
            //        obj.NumberOfAllowedPatients = p.NumberOfAllowedPatients;
            //        obj.NumberOfRegisteredPatients = 0;
            //        obj.IsWalkingQueue = false;
            //        obj.IsDisabled = false;
            //        obj.AvailableDateTimeUnixEpoch = DateTimeEpoch.ConvertDateToSecondsEpoch(availableDateTime);

            //        Insert(obj);
            //    }
            //    //else do nothing. We don't want to throw exception for already available times

            //}
        }

        /// <summary>
        /// Checks if a doctor available in a certain time
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public bool IsTimeAvailable(DoctorScheduleIsTimeAvailableSP p)
        {
            FilterExpression filter = new FilterExpression(vDoctorSchedule.ColumnNames.DoctorID, p.DoctorID);
            filter.AddFilter(vDoctorSchedule.ColumnNames.SlotUnixEpoch, p.SelectedDateTimeUnixEpoch);
            return (this.GetCount(filter) > 0);
        }

        ///// <summary>
        ///// Get available times in format for an specific date
        ///// </summary>
        ///// <param name="p">parameters</param>
        ///// <returns></returns>
        //public IList<vDoctorSchedule> GetTimesByRange(DoctorScheduleGetByRangeSP p)
        //{
        //    List<string> columns = new List<string>();
        //    columns.Add(vDoctorSchedule.ColumnNames.DoctorScheduleID);
        //    columns.Add(vDoctorSchedule.ColumnNames.SlotUnixEpoch);
        //    return GetByRangeWithColumns(p, null);
        //}


        private IList<vDoctorSchedule> GetByRangeWithColumns(DoctorScheduleGetByRangeSP p, List<string> columns)
        {
            FilterExpression filter = GetByRangeFilter(p);
            filter.AndMerge(new FilterExpression(vDoctorSchedule.ColumnNames.NumberOfFreePositions, 0, FilterOperatorEnum.GreaterThan));

            SortExpression sort = new SortExpression(vDoctorSchedule.ColumnNames.SlotUnixEpoch);

            if (columns != null)
            {
                if (columns.Contains(vDoctorSchedule.ColumnNames.NumberOfAllowedPatients))
                    columns.Add(vDoctorSchedule.ColumnNames.NumberOfAllowedPatients);
                if (columns.Contains(vDoctorSchedule.ColumnNames.NumberOfRegisteredPatients))
                    columns.Add(vDoctorSchedule.ColumnNames.NumberOfRegisteredPatients);
            }

            GetByFilterParameters getParams = new GetByFilterParameters(filter, sort, 0, 1000, columns, GetSourceTypeEnum.View);

            IList<vDoctorSchedule> list = GetByFilterV(getParams);
            return list;

            // we filter the list from database to speed up the process.
            //List<vDoctorSchedule> results = new List<vDoctorSchedule>();
            //foreach (var item in list)
            //{
            //    if (item.NumberOfAllowedPatients > item.NumberOfRegisteredPatients)
            //        results.Add(item);
            //}
            //return results;
        }


        /// <summary>
        /// Gets available times that are reservable by patients
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public IList<vDoctorSchedule> GetByRange(DoctorScheduleGetByRangeSP p)
        {
            return GetByRangeWithColumns(p, null);
        }

        private FilterExpression GetByRangeFilter(DoctorScheduleGetByRangeSP p)
        {
            FilterExpression filter = new FilterExpression(vDoctorSchedule.ColumnNames.DoctorID, p.DoctorID);
            filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.SlotUnixEpoch, p.StartUnixEpoch, FilterOperatorEnum.GreaterThanOrEqualTo));
            filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.SlotUnixEpoch, p.EndUnixEpoch, FilterOperatorEnum.LessThan));
            filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.IsDisabled, false));
            filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.IsWalkingQueue, false));
            return filter;
        }


        /// <summary>
        /// Returns counts of avaiable slots by range
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public long GetCountByRange(DoctorScheduleGetByRangeSP p)
        {
            return GetCount(GetByRangeFilter(p));
        }


        /// <summary>
        /// Copies available times of a day to another day (by period)
        /// </summary>
        /// <param name="p"></param>
        public void CopyRange(DoctorScheduleCopyRangeSP p)
        {
            ((DoctorScheduleBR)this.BusinessLogicObject).CopyRange(p);

            var list = GetByRange(new DoctorScheduleGetByRangeSP()
            {
                DoctorID = p.DoctorID,
                StartUnixEpoch = p.SourceUnixEpoch,
                EndUnixEpoch = p.SourceUnixEpoch + (p.NumberOfDays * 86400)
            });

            foreach (var item in list)
            {
                int newSlotUnixEpoch = p.DestinationUnixEpoch + (item.SlotUnixEpoch - p.SourceUnixEpoch);
                if (IsTimeAvailable(new DoctorScheduleIsTimeAvailableSP()
                {
                    DoctorID = p.DoctorID,
                    SelectedDateTimeUnixEpoch = newSlotUnixEpoch
                }) == false)
                {
                    DoctorSchedule obj = new DoctorSchedule();
                    obj.DoctorID = item.DoctorID;
                    obj.DoctorScheduleVisitPlaceID = item.DoctorScheduleVisitPlaceID;
                    obj.NumberOfAllowedPatients = item.NumberOfAllowedPatients;
                    obj.NumberOfRegisteredPatients = 0;
                    obj.IsWalkingQueue = false;
                    obj.IsDisabled = false;
                    obj.SlotUnixEpoch = newSlotUnixEpoch;

                    try
                    {
                        Insert(obj);
                    }
                    catch (BRException)
                    {
                        // do nothing for business exceptions
                    }
                }
            }

        }

        /// <summary>
        /// Delets a slots by a defined range
        /// </summary>
        /// <param name="p"></param>
        public void DeleteRange(DoctorScheduleDeleteRangeSP p)
        {
            ((DoctorScheduleBR)this.BusinessLogicObject).DeleteRange(p);

            var filter = GetByRangeFilter(new DoctorScheduleGetByRangeSP()
            {
                DoctorID = p.DoctorID,
                StartUnixEpoch = p.StartUnixEpoch,
                EndUnixEpoch = p.EndUnixEpoch
            });

            GetByFilterParameters getParams = new GetByFilterParameters(filter, new SortExpression(), 0, 1000, null, GetSourceTypeEnum.Table);

            var list = GetByFilterT(getParams);

            foreach (var item in list)
            {
                try
                {
                    Delete(item);
                }
                catch (BRException) // we ignore business exceptions
                {
                    // ignore
                }
            }
        }

		#endregion

    }
}

