using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service.NotificationSystem
{

    /// <summary>
    /// sends sms notifications
    /// </summary>
    public class SMSNotificationSender : NotificationSenderBase
    {

        public override void SendNotification(vNotification notificationObj)
        {

            TemplateParams p = GetTemplateParams(notificationObj);
            string to = notificationObj.ReceiverUserPhoneNumber;
            string body = p.ProcessTemplate(notificationObj.SMSBody);
            SendSMS(to, body);
            //Console.WriteLine(message.Sid); 

            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Notify_SMS, UserID = notificationObj.ReceiverUserID, ExtraBigInt = notificationObj.NotificationID });
            //throw new NotImplementedException();
        }


        public void SendSMS(string to, string body)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account 
            var config = FWUtils.ConfigUtils.GetAppSettings().Twilio;
            if (config.Enabled)
            {
                string AccountSid = config.AccountSid;
                string AuthToken = config.AuthToken;
                string sendingPhoneNumber = config.FromNumber;
                var twilio = new TwilioRestClient(AccountSid, AuthToken);

                twilio.SendMessage(sendingPhoneNumber, to, body);
            }
        }


    }
}
