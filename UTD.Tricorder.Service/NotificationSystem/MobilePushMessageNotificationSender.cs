using Framework.Common;
using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.NotificationSystem;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service.NotificationSystem
{

    /// <summary>
    /// sends mobile push notifications to the clients
    /// </summary>
    public class MobilePushMessageNotificationSender : NotificationSenderBase
    {
        public static PushBroker push;

        /// <summary>
        /// GCM message format used by GCMAir library
        /// This is not a good format, but since we used that library we have to use it for now
        /// In the future, we need to have a better format
        /// </summary>
        private class GCMAirMessage
        {
            public string alert { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string title { get; set; }
        }

        private class CordovaGCMMessage
        {
            public string id { get; set; }
            public string type { get; set; }
            public string message { get; set; }
            public int msgcnt { get; set; }
            public string title { get; set; }
            public string icon { get; set; }
        }



        private class FreshPlanetAirMessage
        {
            public string contentTitle { get; set; }
            public string contentText { get; set; }
            public string tickerText { get; set; }
        }

        /// <summary>
        /// Initializes Google Cloud Messaging (GCM) Service 
        /// </summary>
        public static void InitGoogleCloudMessagingService()
        {
            push = new PushBroker();
            string googleApiKey = FWUtils.ConfigUtils.GetAppSettings().Project.GoogleApiServerKey;
            //Registering the GCM Service and sending an Android Notification
            push.RegisterGcmService(new GcmPushChannelSettings(googleApiKey));
            push.OnServiceException += push_OnServiceException;
            push.OnDeviceSubscriptionExpired += push_OnDeviceSubscriptionExpired;
        }

        static void push_OnDeviceSubscriptionExpired(object sender, string expiredSubscriptionId, DateTime expirationDateUtc, PushSharp.Core.INotification notification)
        {
            //TODO: Add event to Deactive the device from the database
        }

        static void push_OnServiceException(object sender, Exception error)
        {
            FWUtils.ExpLogUtils.ExceptionLogger.LogError(error, null);
        }

        /// <summary>
        /// Initializes Apple Push Notification Service (APNS)
        /// </summary>
        public static void InitApplePushNotificationService()
        {
            //Registering the Apple Service and sending an iOS Notification
            //byte[] appleCert = File.ReadAllBytes("ApnsSandboxCert.p12");
            byte[] appleCert = DLLResources.AppleCertificate;
            string appleCertPassword = FWUtils.ConfigUtils.GetAppSettings().Project.AppleCertificatePassword;

            push.RegisterAppleService(new ApplePushChannelSettings(appleCert, appleCertPassword));
        }

        /// <summary>
        /// Stops Google and Apple and other services
        /// </summary>
        public static void StopAllServices()
        {
            push.StopAllServices(waitForQueuesToFinish: true);
        }


        /// <summary>
        /// Sends a notification by a notification object
        /// </summary>
        /// <param name="notificationObj">notification object</param>
        public override void SendNotification(vNotification notificationObj)
        {
            ////throw new NotImplementedException();
            //TemplateParams p = GetTemplateParams(notificationObj);

            //IUserDeviceSettingService service = UserDeviceSettingEN.GetService("");
            //MobileNotificationMessage message = new MobileNotificationMessage();
            //message.Type = new MobileNotificationTypeSEnum(notificationObj.MobilePushType);
            //message.ParamsJSON = p.ProcessTemplate(notificationObj.MobilePushParamsJSON);
            //message.Alert = p.ProcessTemplate(notificationObj.MobilePushAlert);
            //message.Title = p.ProcessTemplate(notificationObj.MobilePushTitle);
            //message.Sound = p.ProcessTemplate(notificationObj.MobilePushSound);
            //message.TimeToLiveSeconds = notificationObj.TimeToLiveSeconds;
            //message.CollapseKey = null;
            //message.DelayWhileIdle = null;
            //message.IsOneSufficient = false;

            ////string messageBody = p.ProcessTemplate(notificationObj.MobilePushBody);
            ////string sound = notificationObj.MobilePushSound;
            ////int? timeToLiveSeconds = notificationObj.TimeToLiveSeconds;
            ////string collapseKeyIfAny = null;
            ////bool? delayWhileIdle = null;
            ////service.PushNotification(notificationObj.ReceiverUserID, messageBody, sound, timeToLiveSeconds, collapseKeyIfAny, delayWhileIdle);
            //service.PushNotification(notificationObj.ReceiverUserID, message);

            //FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Notify_MobilePush, UserID = notificationObj.ReceiverUserID, ExtraBigInt = notificationObj.NotificationID });
        }


        /// <summary>
        /// Sends a push notification to Apple Push Notification Service
        /// </summary>
        /// <param name="message">the message object</param>
        public static void SendAppleNotification(MobileNotificationMessage message)
        {
            push.QueueNotification(ConvertToAppleNotification(message));
        }

        /// <summary>
        /// Sends a push notification to Google Cloud Messaging
        /// 
        /// GCM will store up to 100 non-collapsible messages. 
        /// Order of delivery is not guaranteed
        /// Read more here: http://developer.android.com/google/gcm/adv.html#retry
        /// </summary>
        /// <param name="message">the message object</param>
        public static void SendGoogleNotification(MobileNotificationMessage message)
        {
            //Fluent construction of an Android GCM Notification
            //IMPORTANT: For Android you MUST use your own RegistrationId here that gets generated within your Android app itself!
            push.QueueNotification(ConvertToGCMNotification(message));
        }



        /// <summary>
        /// Converts the message of this class to Apple Notification
        /// </summary>
        /// <returns></returns>
        public static AppleNotification ConvertToAppleNotification(MobileNotificationMessage message)
        {
            AppleNotification appleMessage = new AppleNotification();
            appleMessage.DeviceToken = message.DevicePushToken;

            if (message.TimeToLiveSeconds.HasValue)
                if (message.TimeToLiveSeconds.Value != 0) // 0 means instant sending in GCM, but here it just expires the message
                    appleMessage.Expiration = DateTime.UtcNow.AddSeconds(message.TimeToLiveSeconds.Value);

            appleMessage.Payload = new AppleNotificationPayload(message.Alert, message.Badge, message.Sound);

            return appleMessage;
            //return new AppleNotification()
            //               .ForDeviceToken(this.DevicePushToken)
            //               .WithAlert(this.MessageBody)
            //               .WithBadge(this.Badge)
            //               .WithSound(this.Sound);
        }


        /// <summary>
        /// Converts the message of this class to GCM Notification
        /// </summary>
        /// <returns></returns>
        public static GcmNotification ConvertToGCMNotification(MobileNotificationMessage message)
        {
            // string messageJSON = "{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}";
            //string messageJSON = "{\"alert\":\"" + GetSafeJSonString(message.Alert)
            //                    + "\",\"badge\":" + message.Badge.ToString() +
            //                    ",\"sound\":\"" + GetSafeJSonString(message.Sound) + "\"}";



            //GCMAirMessage msg = new GCMAirMessage();
            CordovaGCMMessage msg = new CordovaGCMMessage();
            msg.type = message.Type.getFnName();
            msg.message = message.Alert;
            msg.title = message.Title;
            msg.id = message.ParamsJSON;
            //msg.icon = "";
            msg.msgcnt = 1;

            //FreshPlanetAirMessage msg = new FreshPlanetAirMessage();
            //msg.tickerText = message.Alert;
            //msg.contentText = message.Alert;
            //msg.contentTitle = message.Title;


            string messageJSON = FWUtils.EntityUtils.JsonSerializeObject(msg);


            //StringBuilder messageJSON = new StringBuilder();

            //messageJSON.Append("{\"alert\":\"" + GetSafeJSonString(message.Alert) + "\"");
            //messageJSON.Append(",\"type\":\"" + message.Type.getFnName() + "\"");

            //if (string.IsNullOrEmpty(message.Title) == false)
            //    messageJSON.Append(",\"title\": \"" + GetSafeJSonString(message.Title) + "\"");

            //if (message.ParamsJSON != null)
            //    messageJSON.Append(",\"id\":\"" + GetSafeJSonString(message.ParamsJSON) + "\"");

            //messageJSON.Append("}");


            GcmNotification gcmMessage = new GcmNotification();

            if (message.IsOneSufficient)
                gcmMessage.CollapseKey = message.CollapseKey.getFnName();

            gcmMessage.TimeToLive = message.TimeToLiveSeconds;
            gcmMessage.JsonData = messageJSON;
            gcmMessage.RegistrationIds.Add(message.DevicePushToken);
            //gcmMessage.QueuedCount = message.Badge;  QueuedCount is for number of messages to send one by one. It is 7, it delivers the message 7 times. I don't know the real usage. It maybe to make sure that message will be delivered
            gcmMessage.DelayWhileIdle = message.DelayWhileIdle;

            return gcmMessage;

            //return new GcmNotification().ForDeviceRegistrationId(this.DevicePushToken)
            //                      .WithJson(messageJSON);
        }

    }
}
