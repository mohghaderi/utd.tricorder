using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class DoctorScheduleBR : BusinessRuleBase<DoctorSchedule, vDoctorSchedule>
    {
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            var obj = (DoctorSchedule)entitySet;
            CheckUtils.CheckByteBetweenMinMax(vDoctorSchedule.ColumnNames.NumberOfAllowedPatients, 
                obj.NumberOfAllowedPatients, errors, 1, 100);

            CheckUtils.CheckByteBetweenMinMax(vDoctorSchedule.ColumnNames.NumberOfRegisteredPatients, 
                obj.NumberOfRegisteredPatients, errors, 0, 100);

            if (obj.SlotUnixEpoch <= DateTimeEpoch.GetUtcNowEpoch())
                errors.Add(vDoctorSchedule.ColumnNames.SlotUnixEpoch, BusinessErrorStrings.DoctorSchedule.CannotInsertOldTime);


            if (fnName == RuleFunctionSEnum.Insert)
            {
                DateTime dt = DateTimeEpoch.ConvertSecondsEpochToDateTime(obj.SlotUnixEpoch);

                // removing seconds and milliseconds from Date time (only hour and minute are allowed here)
                // obj.AvailableDateTime = new DateTime(obj.AvailableDateTime.Year, obj.AvailableDateTime.Month, obj.AvailableDateTime.Day, obj.AvailableDateTime.Hour, obj.AvailableDateTime.Minute, 0);
                if (dt.Minute == 0
                    && dt.Second == 0
                    && dt.Hour == 0
                    )
                {
                    obj.IsWalkingQueue = true;
                }
                else
                    obj.IsWalkingQueue = false;

                // check if time exists

                FilterExpression filter = new FilterExpression();
                filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.SlotUnixEpoch, obj.SlotUnixEpoch));
                filter.AddFilter(new Filter(vDoctorSchedule.ColumnNames.DoctorID, obj.DoctorID));
                if (DataAccessObject.GetCount(filter) > 0)
                {
                    errors.Add(new BusinessRuleError()
                        {
                            ColumnName = vDoctorSchedule.ColumnNames.SlotUnixEpoch,
                            ColumnTitle = this.Entity.EntityColumns[vDoctorSchedule.ColumnNames.SlotUnixEpoch].Caption,
                            ErrorDescription = BusinessErrorStrings.DoctorSchedule.TimeAllocatedBefore
                        });
                }

            }


            // delete rules
            if (fnName == RuleFunctionSEnum.Delete)
            {
                FilterExpression filter = new FilterExpression(vVisit.ColumnNames.DoctorScheduleID, obj.DoctorScheduleID);
                CheckUtils.CheckNoDependantRecordExists(vVisit.EntityName, "", filter, errors, BusinessErrorStrings.DoctorSchedule.CannotDeleteBecauseVisitExists);

                if (obj.SlotUnixEpoch <= DateTimeEpoch.GetUtcNowEpoch())
                    errors.Add(vDoctorSchedule.ColumnNames.SlotUnixEpoch, BusinessErrorStrings.DoctorSchedule.CannotDeleteOldTimeSchedules);
            }
        }


        public void CopyRange(DoctorScheduleCopyRangeSP p)
        {
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            if (p.DestinationUnixEpoch > p.SourceUnixEpoch)
            {
                if (p.DestinationUnixEpoch < p.SourceUnixEpoch + (p.NumberOfDays * 86400))
                {
                    throw new BRException(BusinessErrorStrings.DoctorSchedule.CopyOverlapInCopy);
                }
            }
            if (p.SourceUnixEpoch > p.DestinationUnixEpoch)
            {
                if (p.SourceUnixEpoch < p.DestinationUnixEpoch + (p.NumberOfDays * 86400))
                {
                    throw new BRException(BusinessErrorStrings.DoctorSchedule.CopyOverlapInCopy);
                }
            }
        }

        /// <summary>
        /// Checks business rules for deleting a range
        /// </summary>
        /// <param name="p">parameters</param>
        public void DeleteRange(DoctorScheduleDeleteRangeSP p)
        {
            if (p.EndUnixEpoch < p.StartUnixEpoch)
                throw new BRException(BusinessErrorStrings.DoctorSchedule.DeleteRangeEndDateShouldBeGreaterStartDate);
        }


        #endregion

    }
}

