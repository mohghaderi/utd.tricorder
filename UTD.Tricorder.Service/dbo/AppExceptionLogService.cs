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
    public class AppExceptionLogService : ServiceBase<AppExceptionLog, vAppExceptionLog>, IAppExceptionLogService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            //return base.onBeforeInsert(entitySet, parameters);
            try
            {
                if (FWUtils.WebUIUtils.IsLocalHost() == false)
                {
                    System.Text.StringBuilder body = new System.Text.StringBuilder();

                    string msg = FWUtils.EntityUtils.GetObjectFieldValueString(entitySet, vAppExceptionLog.ColumnNames.Message);

                    body.Append("StackTrace: ").Append(FWUtils.EntityUtils.GetObjectFieldValueString(entitySet, vAppExceptionLog.ColumnNames.StackTrace)).Append("\n");
                    //body.Append("Url: ").Append(FWUtils.EntityUtils.GetObjectFieldValueString(entitySet, vAppExceptionLog.ColumnNames.Url)).Append("\n");
                    //body.Append("UserID: ").Append(FWUtils.EntityUtils.GetObjectFieldValueString(entitySet, vAppExceptionLog.ColumnNames.UserID)).Append("\n");
                    //body.Append("DateTime: ").Append(DateTime.UtcNow).Append("\n");

                    body.Append("Complete Exception Info:").AppendLine();
                    body.AppendLine(FWUtils.EntityUtils.JsonSerializeObject(entitySet, false, null, true));

                    NotificationSystem.NotificationSenderAgent
                        .emailNotificationSender.SendEmailMessage("\"Xecare exception\" <errorreport@xecare.com>", "mohghaderi@gmail.com", "New Exception - " + msg, body.ToString(), false);
                }

            }
            catch (Exception)
            {
                // preventing recursive logging
                //FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }
            return true;
        }

		#endregion

    }
}

