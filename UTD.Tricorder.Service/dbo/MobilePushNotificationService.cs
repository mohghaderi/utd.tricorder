using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;
using UTD.Tricorder.Service.NotificationSystem;

namespace UTD.Tricorder.Service
{
    public class MobilePushNotificationService : ServiceBase<MobilePushNotification, vMobilePushNotification>, IMobilePushNotificationService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        private class TestSanitySampleParameters
        {
            public string param1 { get; set; }
            public string param2 { get; set; }
            public TestSanitySampleParameters(string _param1, string _param2)
            {
                this.param1 = _param1;
                this.param2 = _param2;
            }

        }

        public static UTD.Tricorder.Common.NotificationSystem.ISignalRPushSender SignalRPushSender = null;

        public override void OnAfterInitialize()
        {
            if (SignalRPushSender == null)
                SignalRPushSender = (UTD.Tricorder.Common.NotificationSystem.ISignalRPushSender) FWUtils.ConfigUtils.GetAppSettings().MobilePush.GetRealTimeNotifyClass();
        }



        protected override void onAfterInsert(object entitySet, InsertParameters parameters)
        {
            //to avoid db dependancy we send push right after the item inserted
            // TODO: re-write the code with database dependency
            // TODO: Cache all templates to avoid database request for each template

            var notification = (MobilePushNotification)entitySet;
            var template = MobilePushTemplateEN.GetService("").GetByIDV(notification.MobilePushTemplateID, new GetByIDParameters());

            SendToSignalRClient(entitySet, notification, template);
            SendToMobilePushServers(notification, template);
        }

        /// <summary>
        /// Sends to signal r client.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        private static void SendToSignalRClient(object entitySet, MobilePushNotification notification, vMobilePushTemplate template)
        {
            // sending realtime to web client
            SignalRPushSender.Send(notification, template);
        }

        private void SendToMobilePushServers(MobilePushNotification notification, vMobilePushTemplate template)
        {
            // sending as a mobile push
            if (template.MobilePushDeliveryTypeID == (byte)EntityEnums.MobilePushDeliveryType.MobileOnly
            || template.MobilePushDeliveryTypeID == (byte)EntityEnums.MobilePushDeliveryType.WebAndMobile)
            {
                var msg = new UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage();
                TemplateParams tp = TemplateParams.FromSerializedString(notification.TemplateParamsJSON);
                msg.Alert = tp.ProcessTemplate(template.AlertText);
                msg.Sound = template.SoundFileName;
                msg.TimeToLiveSeconds = template.TimeToLiveSeconds;
                msg.IsOneSufficient = template.IsOneSufficient;
                msg.ParamsJSON = notification.ParamsJSON;
                msg.Title = tp.ProcessTemplate(template.Title);
                msg.Type = new Common.NotificationSystem.MobileNotificationTypeSEnum(template.MobileNotificationTypeName);
                msg.DelayWhileIdle = template.DelayWhileIdle;
                PushNotification(notification.ReceiverUserID.Value, msg);
            }
        }




        /// <summary>
        /// Sends a notification to the user's device
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="message">Message</param>
        /// <returns>Number of delivered messages</returns>
        public int PushNotification(long userId, UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage message)
        {
            //// creating one message for all devices
            //// TODO: It should work without any problem, but there should be a test
            //// to test if it works properly if we had more than one device for one user
            //// for example, one ipad and one iphone and one galaxy android phone
            //UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage message 
            //    = new UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage();
            //message.MessageBody = messageBody;
            //message.Sound = sound;
            //message.TimeToLiveSeconds = timeToLiveSeconds;
            //if (string.IsNullOrEmpty(collapseKeyIfAny))
            //    message.IsOneSufficient = true;
            //message.CollapseKey = new CollapseKeySEnum(collapseKeyIfAny);
            //message.DelayWhileIdle = delayWhileIdle;
            var userDeviceService = UserDeviceSettingEN.GetService();

            List<string> sentPushTokenList = new List<string>();
            var deviceList = userDeviceService.GetByUserID(userId);
            foreach (var device in deviceList)
            {
                // if we didn't already sent the message to this device
                if (sentPushTokenList.Contains(device.PushNotificationToken) == false)
                {
                    sentPushTokenList.Add(device.PushNotificationToken);
                    message.DevicePushToken = device.PushNotificationToken;
                    PushNotificationToDevice(device, message);
                }
            }
            return deviceList.Count;
        }



        ///// <summary>
        ///// Sends a notification to the user's device
        ///// </summary>
        ///// <param name="userId">user identifier</param>
        ///// <param name="messageBody">Message body. Simple string message that user will see it. For example "Hello World!"</param>
        ///// <param name="sound">Sound file like Sound.caf</param>
        ///// <param name="timeToLiveSeconds">
        ///// from 0 to 2,419,200 seconds (GCM)
        /////  For infinite TTL set it as null
        /////  GCM keeps messages for only four weeks.
        /////  
        ///// For instant delivery use 0 because
        ///// GCM will never throttle messages with a time_to_live value of 0 seconds. In other words, GCM will guarantee best effort for messages that must be delivered "now or never."
        ///// Read more here: http://developer.android.com/google/gcm/adv.html#ttl
        ///// </param>
        ///// <param name="collapseKeyIfAny">
        ///// One is sufficient when message is collapsible. For example, for each new mail received
        ///// we don't need to inform user one by one. One 'new message' notificaion is enought so, 
        ///// IsOneSufficient = true. But for doctor rington, it can't be collapsible; So, IsOneSufficient=false there.
        ///// </param>
        ///// <param name="delayWhileIdle">
        ///// If the device was not available should it delay the delivery or not.
        ///// For example for mobile rington DelayWhileIdle should be false
        ///// For default value use null
        ///// </param>
        //public bool PushNotificationToDevice(vUserDeviceSetting deviceSettings, string messageBody, string sound, int? timeToLiveSeconds, string collapseKeyIfAny, bool? delayWhileIdle)
        //{

        //}


        /// <summary>
        /// Sends a test message from the push server to test if the device receives the message or not.
        /// </summary>
        /// <param name="generatedUUID">device generated UUID</param>
        public vUserDeviceSetting TestPushSanity(Guid generatedUUID)
        {
            var userDeviceService = UserDeviceSettingEN.GetService();
            var userDeviceSetting = userDeviceService.GetByDeviceGeneratedUUID(generatedUUID);
            if (userDeviceSetting != null)
            {
                //vUserDeviceSetting userDeviceSetting = (vUserDeviceSetting)obj;
                //var pushNotification =
                //string messageJson = "TestPushSanityMessage"; //"{msgId: '" + Guid.NewGuid() + "', msgCode:'12', MsgInfo: {DoctorID:14, DoctorName: 'DoctorName'}";

                UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage message
                    = new UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage();

                message.Type = UTD.Tricorder.Common.NotificationSystem.MobileNotificationTypeSEnum.TestPushSanity;
                //message.ParamsJSON = null;
                var p = new TestSanitySampleParameters("p1Value", "p2Value");
                message.ParamsJSON = FWUtils.EntityUtils.JsonSerializeObject(p);
                message.Alert = "Test Push Sanity Message New Message";
                message.Title = "Message Title";
                message.Sound = "testSound.caf";
                //message.TimeToLiveSeconds = 0; // instant delivery ; It won't send it if it was not instant. It is bad because the message will be lost
                message.CollapseKey = null;
                message.DelayWhileIdle = false;

                PushNotificationToDevice(userDeviceSetting, message);
                //pushNotification.SendNotification(messageJson);
                return userDeviceSetting;
            }
            else // if it has no associated device
                throw new BRException("No device is registered with UUID: " + generatedUUID.ToString());
        }


        /// <summary>
        /// Sends a notification to the user's device
        /// </summary>
        /// <param name="deviceSettings">device settings</param>
        /// <param name="message">Message Information</param>
        public bool PushNotificationToDevice(vUserDeviceSetting deviceSettings, UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage message)
        {
            if (deviceSettings.PushNotificationIsActive
                && string.IsNullOrEmpty(deviceSettings.PushNotificationToken) == false)
            {
                //MobileNotificationMessage message = new MobileNotificationMessage();
                //message.MessageBody = notificationContent;
                message.DevicePushToken = deviceSettings.PushNotificationToken;
                //message.Sound = "ring.caf";

                if (deviceSettings.MobilePushServerID == (byte)EntityEnums.MobilePushServerEnum.Google_GCM)
                {
                    MobilePushMessageNotificationSender.SendGoogleNotification(message);
                    return true;
                }
                if (deviceSettings.MobilePushServerID == (byte)EntityEnums.MobilePushServerEnum.Apple_APNS)
                {
                    MobilePushMessageNotificationSender.SendAppleNotification(message);
                    return true;
                }
                else
                    throw new NotImplementedException();

                //Other push servers are not supported yet!
            }

            return false;
        }




		#endregion

    }
}

