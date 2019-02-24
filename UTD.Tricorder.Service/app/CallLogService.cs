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
    public class CallLogService : ServiceBase<CallLog, vCallLog>, ICallLogService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        private struct PhoneRingParameters
        {
            public long CallLogID { get; set; }
            public string SenderFullName { get; set; }
        }

        private struct AnswerCallParameters
        {
            public long CallLogID { get; set; }
            public bool IsCaller { get; set; }
            public long? EntityRecordID { get; set; }
        }

        public static UTD.Tricorder.Common.NotificationSystem.ISignalRPushSender SignalRPushSender = null;

        public override void OnAfterInitialize()
        {
            if (SignalRPushSender == null)
                SignalRPushSender = (UTD.Tricorder.Common.NotificationSystem.ISignalRPushSender)FWUtils.ConfigUtils.GetAppSettings().MobilePush.GetRealTimeNotifyClass();
        }

        protected override bool onBeforeDelete(object entitySet, DeleteParameters parameters)
        {
            throw new ImpossibleExecutionException("Delete function is not available for logs");
        }


        /// <summary>
        /// Sends call notification for the patient based on the visit information
        /// </summary>s
        /// <param name="p">parameters</param>
        public CallLogCallPatientResponseSP VisitCallPatient(CallLogVisitCallPatientSP p)
        {
            long visitID = p.VisitID; 
            vVisit v = VisitEN.GetService().GetByIDV(visitID, new GetByIDParameters());
            if (v == null)
                throw new BRException(BusinessErrorStrings.Visit.Visit_Deleted);
            OwnerDoctorSecurity.Check("call a patient", v, vVisit.ColumnNames.DoctorID);

            // inserting call log to the database
            var callLogService = CallLogEN.GetService();
            var callLog = CallLogEN.GetEntityObjectT();
            callLog.StartDate = DateTime.UtcNow;
            callLog.SenderUserID = v.DoctorID;
            callLog.ReceiverUserID = v.PatientUserID;
            callLog.DurationSeconds = 0;
            callLog.EntityRecordID = v.VisitID;
            callLog.AppEntityID = (short)EntityEnums.AppEntityEnum.Visit;
            callLogService.Insert(callLog, null);


            var mobilePushService = MobilePushNotificationEN.GetService();
            var mobilePush = MobilePushNotificationEN.GetEntityObjectT();
            mobilePush.MobilePushTemplateID = (byte)EntityEnums.MobilePushTemplateType.Call_PhoneRing;
            mobilePush.ParamsJSON = FWUtils.EntityUtils.JsonSerializeObject(new PhoneRingParameters() { CallLogID = callLog.CallLogID, SenderFullName = v.DoctorFullName });
            mobilePush.TemplateParamsJSON = new TemplateParams("caller", v.DoctorFullName).SerializeToString();
            mobilePush.ReceiverUserID = callLog.ReceiverUserID;
            mobilePush.MobilePushNotificationStatusID = (byte) EntityEnums.NotificationStatusEnum.Pending;
            mobilePush.InsertDate = DateTime.UtcNow;
            mobilePush.SenderUserID = v.DoctorID;
            mobilePushService.Insert(mobilePush, null);


            CallLogCallPatientResponseSP response = new CallLogCallPatientResponseSP();
            response.CallLogID = callLog.CallLogID;
            response.ReceiverUserID = v.PatientUserID;
            response.ReceiverFullName = v.PatientFullName;
            response.ReceiverProfilePicUrl = AppFileEN.GetService().GetUserProfileImageUrl(v.PatientUserID);
            return response;

            //var userDeviceSettingsService = UserDeviceSettingEN.GetService("");

            ////string messageBody = "Doctor " + v.DoctorFirstName + " " + v.DoctorLastName + " is calling.";
            ////string sound = "RingPhone.caf";
            ////int? timeToLiveSeconds = 0;
            ////string collapseKeyIfAny = null;
            ////bool? delayWhileIdle = null;
            ////userDeviceSettingsService.PushNotification(v.PatientUserID, messageBody, sound, timeToLiveSeconds, collapseKeyIfAny, delayWhileIdle);

            //UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage msg 
            //    = new UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage();
            //msg.Type = UTD.Tricorder.Common.NotificationSystem.MobileNotificationTypeSEnum.PhoneRing;
            //msg.Title = "Visit Call"; // No title
            //msg.Alert = "Doctor " + v.DoctorFirstName + " " + v.DoctorLastName + " is calling you.";
            ////msg.ParamsJSON = "{visitId: '" + visitID.ToString() + "', patientId:'" + v.PatientUserID.ToString() + "'}"; // we may need to do authentication before answering calls
            //msg.ParamsJSON = FWUtils.EntityUtils.JsonSerializeObject(new PhoneRingParameters(visitID.ToString()));
            ////msg.TimeToLiveSeconds = 0;
            //msg.IsOneSufficient = false;
            //msg.Sound = "Rington2.mp3";
            //msg.DelayWhileIdle = false;

            //FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Visit_CallPatient, UserID = v.PatientUserID, ExtraBigInt = visitID });

            //int devicesCount = userDeviceSettingsService.PushNotification(v.PatientUserID, msg);
            //if (devicesCount == 0)
            //{
            //    throw new BRException(BusinessErrorStrings.Visit.CallPatient_NoDeviceAttachedToThisUser);
            //}
        }

        /// <summary>
        /// Ends a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        public void CancelCall(CallLogCancelCallSP p)
        {
            var callLog = GetByIDT(p.CallLogID);
            callLog.CallStatusID = (byte)EntityEnums.CallStatus.Cancelled;
            Update(callLog);

            SignalRPushSender.SendToUser(callLog.ReceiverUserID, "Call_CancelCall", FWUtils.EntityUtils.JsonSerializeObject(p));
        }


        /// <summary>
        /// Ends a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        public void EndCall(CallLogEndCallSP p)
        {
            var callLog = GetByIDT(p.CallLogID);
            callLog.EndDate = DateTime.UtcNow;
            callLog.DurationSeconds = Convert.ToInt32((callLog.EndDate.Value - callLog.StartDate).TotalSeconds);
            callLog.CallStatusID = (byte)EntityEnums.CallStatus.Ended;
            Update(callLog);

            SignalRPushSender.SendToUser(callLog.ReceiverUserID, "Call_EndCall", FWUtils.EntityUtils.JsonSerializeObject(p));
            SignalRPushSender.SendToUser(callLog.SenderUserID, "Call_EndCall", FWUtils.EntityUtils.JsonSerializeObject(p));

            //FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Visit_EndCall, UserID = callLog.SenderUserID, ExtraBigInt = callLog.EntityRecordID });
        }



        /// <summary>
        /// Answers a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        public void AnswerCall(CallLogAnswerCallSP p)
        {
            var callLog = GetByIDT(p.CallLogID);
            callLog.EndDate = DateTime.UtcNow;
            callLog.DurationSeconds = Convert.ToInt32((callLog.EndDate.Value - callLog.StartDate).TotalSeconds);
            callLog.CallStatusID = (byte)EntityEnums.CallStatus.CalleeAnswered;
            Update(callLog);

            var senderParameters = new AnswerCallParameters() { CallLogID = p.CallLogID, IsCaller = true, EntityRecordID = callLog.EntityRecordID };
            SignalRPushSender.SendToUser(callLog.SenderUserID, "Call_AnswerCall", FWUtils.EntityUtils.JsonSerializeObject(senderParameters));
            var receiverParameters = new AnswerCallParameters() { CallLogID = p.CallLogID, IsCaller = true, EntityRecordID = callLog.EntityRecordID };
            SignalRPushSender.SendToUser(callLog.ReceiverUserID, "Call_AnswerCall", FWUtils.EntityUtils.JsonSerializeObject(receiverParameters));
            //FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Visit_EndCall, UserID = callLog.SenderUserID, ExtraBigInt = callLog.EntityRecordID });
        }


        /// <summary>
        /// Declines a call
        /// </summary>
        /// <param name="p">Parameters</param>
        public void DeclineCall(CallLogDeclineCallSP p)
        {
            var callLog = GetByIDT(p.CallLogID);
            callLog.EndDate = DateTime.UtcNow;
            callLog.DurationSeconds = Convert.ToInt32((callLog.EndDate.Value - callLog.StartDate).TotalSeconds);
            callLog.CallStatusID = (byte)EntityEnums.CallStatus.Declined;
            Update(callLog);

            SignalRPushSender.SendToUser(callLog.SenderUserID, "Call_DeclineCall", FWUtils.EntityUtils.JsonSerializeObject(p));

            //FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Visit_EndCall, UserID = callLog.SenderUserID, ExtraBigInt = callLog.EntityRecordID });
        }


        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            if (this.AdditionalDataKey == CallLogEN.AdditionalData_PhoneRing
                || this.AdditionalDataKey == CallLogEN.AdditionalData_VisitCallPatient)
            {
                foreach (EntityObjectBase entityObj in list)
                {
                    long doctorId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.SenderUserID);
                    var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)doctorId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "SenderProfilePicUrl", entityObj, doctorProfileImageUrl);

                    long patientId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.ReceiverUserID);
                    var patientProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)patientId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "ReceiverProfilePicUrl", entityObj, patientProfileImageUrl);
                }
            }
        }

        protected override void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {
            if (this.AdditionalDataKey == CallLogEN.AdditionalData_PhoneRing
                || this.AdditionalDataKey == CallLogEN.AdditionalData_VisitCallPatient)
            {
                long doctorId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.SenderUserID);
                var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)doctorId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "SenderProfilePicUrl", entityObj, doctorProfileImageUrl);

                long patientId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.ReceiverUserID);
                var patientProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)patientId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "ReceiverProfilePicUrl", entityObj, patientProfileImageUrl);
            }
        }

		#endregion

    }
}

