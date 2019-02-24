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
    public class VisitService : ServiceBase<Visit, vVisit>, IVisitService
    {
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            Visit visit = (Visit) entitySet;
            var doctorScheduleService = DoctorScheduleEN.GetService("");
            vDoctorSchedule doctorScheduleV = doctorScheduleService.GetByIDV(visit.DoctorScheduleID, new GetByIDParameters());

            ((VisitBR)BusinessLogicObject).CheckInsert(visit, doctorScheduleV);

            visit.VisitStatusID = (int)EntityEnums.VisitStatusEnum.Scheduled;
            visit.DoctorReport = null;
            visit.ChiefComplaint = null;
            visit.Description = null;

            // updating doctor schedule number of registered patients
            DoctorSchedule doctorSchedule = doctorScheduleService.GetByIDT(visit.DoctorScheduleID, new GetByIDParameters());
            doctorSchedule.NumberOfRegisteredPatients++;

            parameters.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vDoctorSchedule.EntityName,
                FnName = RuleFunctionSEnum.Update,
                EntitySet = doctorSchedule
            });

            return true;
        }

        protected override bool onBeforeDelete(object entitySet, DeleteParameters parameters)
        {
            Visit visit = (Visit)entitySet;
            var doctorScheduleService = DoctorScheduleEN.GetService("");
            vDoctorSchedule doctorSchedule = doctorScheduleService.GetByIDV(visit.DoctorScheduleID, new GetByIDParameters());

            doctorSchedule.NumberOfRegisteredPatients--;
            parameters.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vDoctorSchedule.EntityName,
                FnName = RuleFunctionSEnum.Update,
                EntitySet = doctorSchedule
            });

            return true;
        }


        /// <summary>
        /// Gets the visits by date.
        /// </summary>
        /// <param name="doctorId">doctor identifier</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns></returns>
        public List<vVisit> GetDoctorVisitsByDate(long doctorId, DateTime selectedDate)
        {
            DateTime startDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
            DateTime endDate = startDate.AddDays(1);

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vVisit.ColumnNames.SlotUnixEpoch, DateTimeEpoch.ConvertDateToSecondsEpoch(startDate), FilterOperatorEnum.GreaterThanOrEqualTo));
            filter.AddFilter(new Filter(vVisit.ColumnNames.SlotUnixEpoch, DateTimeEpoch.ConvertDateToSecondsEpoch(endDate), FilterOperatorEnum.LessThan));
            filter.AddFilter(new Filter(vVisit.ColumnNames.DoctorID, doctorId));

            SortExpression sort = new SortExpression(vVisit.ColumnNames.SlotUnixEpoch);

            return (List<vVisit>)GetByFilter(new GetByFilterParameters(filter, sort, 0, 1000, null, GetSourceTypeEnum.View ));
        }

        /// <summary>
        /// Cancels a visit
        /// </summary>
        /// <param name="visitId">The visit identifier.</param>
        public void CancelVisit(long visitId)
        {
            vVisit visit = (vVisit)GetByIDV(visitId, new GetByIDParameters());
            ((VisitBR)BusinessLogicObject).CancelVisit(visit);

            OwnerPatientOrOwnerDoctorSecurity.Check("Cancel a visit", visit, vVisit.ColumnNames.PatientUserID, vVisit.ColumnNames.DoctorID);

            visit.VisitStatusID = (int)EntityEnums.VisitStatusEnum.Cancelled;

            // Automated refund removed to allow re-scheduling option to the patient

            //// if it had a payment and it was a completed payment then refund it
            //long paymentID = visit.VisitID;
            //IPaymentService paymentService = (IPaymentService)
            //    EntityFactory.GetEntityServiceByName(Payment.EntityName, "");
            //Payment payment = (Payment) paymentService.GetByID(paymentID, new GetByIDParameters());
            //if (payment != null)
            //{
            //    if (payment.PaymentStatusID == (int) EntityEnums.PaymentStatusEnum.Done)
            //    {
            //        paymentService.RefundPayment(visit.VisitID);
            //    }
            //}

            UpdateParameters updateParameters = new UpdateParameters();

            // Adding notification for user
            var notification = CreateScheduleNotification(visit);
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.VisitCanceled;
            TemplateParams p = new TemplateParams();
            p.AddParameter("Date", DateTimeEpoch.ConvertUnixEpochToLocalTime(visit.SlotUnixEpoch, visit.PatientWorldTimeZoneID).ToString());
            notification.ParametersValues = p.SerializeToString();
            updateParameters.DetailEntityObjects.Add(new DetailObjectInfo()
                {
                    EntityName = vNotification.EntityName,
                    EntitySet = notification,
                    FnName = RuleFunctionSEnum.Insert
                }
            );

            Update(visit, updateParameters);
        }


        /// <summary>
        /// Reschedules the visit.
        /// </summary>
        /// <param name="p">parameters</param>
        public void RescheduleVisit(VisitRescheduleVisitSP p)
        {
            IDoctorScheduleService doctorScheduleService = (IDoctorScheduleService)
                EntityFactory.GetEntityServiceByName(vDoctorSchedule.EntityName, "");

            vVisit visit = GetByIDV(p.VisitID, new GetByIDParameters());

            OwnerPatientOrOwnerDoctorSecurity.Check("reschedule an appointment", visit, vVisit.ColumnNames.PatientUserID, vVisit.ColumnNames.DoctorID);

            DoctorSchedule oldDoctorSchedule = doctorScheduleService.GetByIDT(visit.DoctorScheduleID, new GetByIDParameters());
            DoctorSchedule newDoctorSchedule = doctorScheduleService.GetByIDT(p.NewDoctorScheduleID, new GetByIDParameters());

            // checking business rules
            ((VisitBR)BusinessLogicObject).RescheduleVisit(visit, oldDoctorSchedule, newDoctorSchedule);

            // updating old schedule (it should allow +1 number of patients)
            if (oldDoctorSchedule.NumberOfRegisteredPatients != 0)
                oldDoctorSchedule.NumberOfRegisteredPatients--;
            UpdateParameters updateParameters = new UpdateParameters();
            updateParameters.DetailEntityObjects.Add(new DetailObjectInfo(){
                EntityName = vDoctorSchedule.EntityName,
                EntitySet = oldDoctorSchedule,
                FnName = RuleFunctionSEnum.Update
            });

            // updating new schedule (it should allow -1 number of patients)
            newDoctorSchedule.NumberOfRegisteredPatients++;
            updateParameters.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vDoctorSchedule.EntityName,
                EntitySet = newDoctorSchedule,
                FnName = RuleFunctionSEnum.Update
            });

            // Adding notification for user
            var notification = CreateScheduleNotification(visit);
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.VisitRescheduled;
            TemplateParams tmpP = new TemplateParams();
            tmpP.AddParameter("FromDate", DateTimeEpoch.ConvertUnixEpochToLocalTime(oldDoctorSchedule.SlotUnixEpoch, visit.PatientWorldTimeZoneID).ToString());
            tmpP.AddParameter("ToDate", DateTimeEpoch.ConvertUnixEpochToLocalTime(newDoctorSchedule.SlotUnixEpoch, visit.PatientWorldTimeZoneID).ToString());
            notification.ParametersValues = tmpP.SerializeToString();
            updateParameters.DetailEntityObjects.Add(new DetailObjectInfo()
                    {
                        EntityName = vNotification.EntityName,
                        EntitySet = notification,
                        FnName = RuleFunctionSEnum.Insert
                    }
            );

            // updating visit changes
            visit.DoctorScheduleID = p.NewDoctorScheduleID;
            Update(visit, updateParameters);
        }


        /// <summary>
        /// Creates the email verification notification.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreateScheduleNotification(vVisit visit)
        {
            Notification notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.EmailSendDate = null;
            notification.SMSSendDate = null;
            notification.SenderUserID = visit.DoctorID;
            notification.ReceiverUserID = visit.PatientUserID;
            //notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.;
            //TemplateParams p = new TemplateParams();
            //notification.ParametersValues = p.SerializeToString();
            notification.SMSNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.EmailNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.NotificationErrorMessage = null;
            notification.IsSMS = true;
            notification.IsEmail = true;
            notification.IsWebMessage = true;
            notification.IsMobilePushMessage = true;
            notification.GotoURL = null;
            return notification;
        }

        ///// <summary>
        ///// Updates the doctor report.
        ///// </summary>
        ///// <param name="visitID">The visit identifier.</param>
        ///// <param name="doctorReport">The doctor report.</param>
        ///// <exception cref="ServiceSecurityException"></exception>
        //public void UpdateDoctorReport(long visitID, string doctorReport)
        //{
        //    vVisit v = (vVisit) GetByID(visitID, new GetByIDParameters(GetSourceTypeEnum.View));

        //    // checking security that only doctor of visit can write a report
        //    long doctorUserID = v.DoctorID;
        //    if (doctorUserID != FWUtils.SecurityUtils.GetCurrentUserIDLong())
        //    {
        //        throw new ServiceSecurityException(BusinessErrorStrings.Visit.OnlyDoctorOfVisitCanWriteAReport);
        //    }

        //    UpdateDoctorReportInDatabase(visitID, doctorReport);
        //}

        ///// <summary>
        ///// Updates the doctor report in database.
        ///// </summary>
        ///// <param name="visitID">The visit identifier.</param>
        ///// <param name="doctorReport">The doctor report.</param>
        //private void UpdateDoctorReportInDatabase(long visitID, string doctorReport)
        //{
        //    Visit v = (Visit)GetByID(visitID, new GetByIDParameters());
        //    v.DoctorReport = doctorReport;
        //    Update(v, new UpdateParameters());
        //}


        /// <summary>
        /// Gets value of a section for a visit
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public string GetSectionValues(VisitGetSectionSP p)
        {
            vVisit obj = (vVisit) GetByIDV(p.VisitID);
            if (obj == null)
                return null;
            else
            {
                OwnerPatientOrADoctorSecurity.Check("Get the information of an appointment", obj, vVisit.ColumnNames.PatientUserID);

                if (p.SectionName == "SysReview")
                    return obj.DoctorSystemReviewJson;
                else
                    throw new ImpossibleExecutionException(p.SectionName);
            }
        }

        /// <summary>
        /// Saves the section information for one visit
        /// </summary>
        /// <param name="p">parameters</param>
        public void SaveSection(VisitSaveSectionSP p)
        {
            if (string.IsNullOrEmpty(p.SectionValuesJson) == false)
                if (FWUtils.EntityUtils.JsonIsValidThenDeserialize(p.SectionValuesJson) == null)
                    throw new ImpossibleExecutionException("SaveSection p.SectionValuesJson is not a valid json:" + p.SectionValuesJson);

            vVisit obj = GetByIDV(p.VisitID);
            if (obj == null)
            {
                throw new UserException(StringMsgs.BusinessErrors.RecordIsNotAvailable);
            }
            else
            {
                if (p.SectionName == "SysReview")
                {
                    OwnerDoctorSecurity.Check("write a review for an appointment", obj, vVisit.ColumnNames.DoctorID);
                    obj.DoctorSystemReviewJson = p.SectionValuesJson;
                }
                else
                    throw new ImpossibleExecutionException(p.SectionName);
                Update(obj);
            }
        }

        /// <summary>
        /// Completes a visit (changes status to end successfully)
        /// </summary>
        /// <param name="visitId">visit identifier</param>
        public void CompleteVisit(long visitId)
        {
            vVisit visit = (vVisit)GetByIDV(visitId, new GetByIDParameters());
            OwnerDoctorSecurity.Check("complete a visit", visit, vVisit.ColumnNames.DoctorID);

            ((VisitBR)BusinessLogicObject).CompleteVisit(visit);

            visit.VisitStatusID = (int)EntityEnums.VisitStatusEnum.EndSuccess;

            Update(visit);
        }

        /// <summary>
        /// reverse visit status to scheduled
        /// </summary>
        /// <param name="visitId">visit identifier</param>
        public void UndoStatusToRescheduled(long visitId)
        {
            vVisit visit = (vVisit)GetByIDV(visitId, new GetByIDParameters());
            OwnerDoctorSecurity.Check("change apppoinment status to scheduled", visit, vVisit.ColumnNames.DoctorID);

            ((VisitBR)BusinessLogicObject).UndoStatusToRescheduled(visit);

            visit.VisitStatusID = (int)EntityEnums.VisitStatusEnum.Scheduled;

            Update(visit);
        }




        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            foreach (EntityObjectBase entityObj in list)
            {
                // filling doctor profile picture data
                if (this.AdditionalDataKey == VisitEN.AdditionalData_MyVisitsDoctor
                    || this.AdditionalDataKey == VisitEN.AdditionalData_GridForPatient)
                {
                    long doctorId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vDoctor_Patient.ColumnNames.DoctorID);
                    var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)doctorId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "DoctorProfilePicUrl", entityObj, doctorProfileImageUrl);
                }

                // filing patient profile picture url
                if (this.AdditionalDataKey == VisitEN.AdditionalData_MyVisitsPatient
                    || this.AdditionalDataKey == VisitEN.AdditionalData_TodaysAppointments
                    || this.AdditionalDataKey == VisitEN.AdditionalData_GridForDoctor)
                {
                    long patientId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vDoctor_Patient.ColumnNames.PatientUserID);
                    var patientProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)patientId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "PatientProfilePicUrl", entityObj, patientProfileImageUrl);
                }
            }
        }


		#endregion

    }
}

