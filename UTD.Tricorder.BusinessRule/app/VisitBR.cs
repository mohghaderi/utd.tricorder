using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class VisitBR : BusinessRuleBase<Visit, vVisit>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            //Visit visit = (Visit) entitySet;

            if (fnName == RuleFunctionSEnum.Insert)
            {



            }
        }

        public void CheckInsert(Visit visit, vDoctorSchedule doctorSchedule)
        {
            if (doctorSchedule.IsDisabled == true)
            {
                throw new BRException(BusinessErrorStrings.Visit.Insert_ScheduleIsDisabled);
            }

            if (doctorSchedule.SlotUnixEpoch < DateTimeEpoch.GetUtcNowEpoch())
            {
                throw new BRException(BusinessErrorStrings.Visit.Insert_TheTimeForThisScheduleHasPassed);
            }

            if (doctorSchedule.NumberOfAllowedPatients < doctorSchedule.NumberOfRegisteredPatients + 1)
            {
                throw new BRException(BusinessErrorStrings.Visit.TimeSlotIsFull);
            }
        }

        /// <summary>
        /// Checks business rules for cancelling a visit
        /// </summary>
        /// <param name="visit">The visit.</param>
        /// <exception cref="BRException">
        /// </exception>
        public void CancelVisit(vVisit visit)
        {
            if (visit == null)
                throw new BRException(BusinessErrorStrings.Visit.Visit_Deleted);

            if (visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.Scheduled)
            {
                throw new BRException(BusinessErrorStrings.Visit.CancelVisit_ThisVisitIsNotCancelable);
            }

        }


        /// <summary>
        /// Reschedules the visit.
        /// </summary>
        /// <param name="visit">The visit information</param>
        /// <param name="oldDoctorSchedule">The old doctor schedule.</param>
        /// <param name="newDoctorSchedule">The new doctor schedule.</param>
        /// <exception cref="BRException">
        /// </exception>
        public void RescheduleVisit(vVisit visit, DoctorSchedule oldDoctorSchedule, DoctorSchedule newDoctorSchedule)
        {
            if (visit == null)
                throw new BRException(BusinessErrorStrings.Visit.Visit_Deleted);

            if (newDoctorSchedule == null)
                throw new BRException(BusinessErrorStrings.Visit.RescheduleVisit_DoctorScheduleDeleted);

            if (visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.Scheduled)
            {
                throw new BRException(BusinessErrorStrings.Visit.RescheduleVisit_ThisVisitCannotBeChange);
            }

            if (oldDoctorSchedule.DoctorScheduleID == newDoctorSchedule.DoctorScheduleID)
            {
                throw new BRException(BusinessErrorStrings.Visit.RescheduleVisit_CantDoRescheduleOnTheSameTime);
            }

            if (oldDoctorSchedule.DoctorID != newDoctorSchedule.DoctorID)
            {
                throw new BRException(BusinessErrorStrings.Visit.RescheduleVisit_ReschuleOnlyForSameDoctor);
            }

            if (newDoctorSchedule.NumberOfAllowedPatients < newDoctorSchedule.NumberOfRegisteredPatients + 1)
            {
                throw new BRException(BusinessErrorStrings.Visit.TimeSlotIsFull);
            }


        }

        /// <summary>
        /// Check rules for ending a visit
        /// </summary>
        /// <param name="visit">visit</param>
        public void CompleteVisit(vVisit visit)
        {
            if (visit == null)
                throw new BRException(BusinessErrorStrings.Visit.Visit_Deleted);

            if (visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.Scheduled &&
                visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.InWaitingRoom)
            {
                throw new BRException(BusinessErrorStrings.Visit.CompleteVisit_StatusIsNotScheduledOrInWaitingRoom);
            }
        }

        /// <summary>
        /// checkes rules for reverting to canceled
        /// </summary>
        /// <param name="visit"></param>
        public void UndoStatusToRescheduled(vVisit visit)
        {
            if (visit == null)
                throw new BRException(BusinessErrorStrings.Visit.Visit_Deleted);

            // we can't undo the status from Canceled because of complex computation of number of visits
            // and also notification of the users
            if (visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.EndSuccess)
            {
                throw new BRException(BusinessErrorStrings.Visit.ReverseToRescheduled_StatusIsNotCompletedOrCanceled);
            }
        }

		#endregion



    }
}

