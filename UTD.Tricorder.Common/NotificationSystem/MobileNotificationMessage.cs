using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.NotificationSystem
{
    public class MobileNotificationMessage
    {
        /// <summary>
        /// Message type. This will be parsed in the client
        /// </summary>
        public MobileNotificationTypeSEnum Type { get; set; }

        /// <summary>
        /// More information that helps to do action based on Type in MobileClient
        /// For example, it can be VisitId or other information.
        /// This goes to 'id' field of the message for GCM messages
        /// </summary>
        public string ParamsJSON { get; set; }

        /// <summary>
        /// Message body. Simple string message that user will see it
        /// This message comes in the system when MobileApp is deactive
        /// For example "Hello World!"
        /// http://afterisk.wordpress.com/2012/09/22/the-only-free-and-fully-functional-android-gcm-native-extension-for-adobe-air/comment-page-1/
        /// </summary>
        public string Alert { get; set; }

        /// <summary>
        /// Title of message (optional)
        /// This title comes in the system when MobileApp is deactive
        /// http://afterisk.wordpress.com/2012/09/22/the-only-free-and-fully-functional-android-gcm-native-extension-for-adobe-air/comment-page-1/
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Badge (it shows as a small number on program's icon in the OS). 
        /// For example 3 means three unread messages
        /// 
        /// Note: Badge is not supported in GCM
        /// </summary>
        public int Badge { get; set; }

        /// <summary>
        /// Sound file like Sound.caf
        /// 
        /// Note: Sound is not supported in GCM
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// Push token registered in the messaging service
        /// </summary>
        public string DevicePushToken { get; set; }

        
        private int? _TimeToLiveSeconds;
        /// <summary>
        ///  from 0 to 2,419,200 seconds (GCM)
        ///  For infinite TTL set it as null
        ///  GCM keeps messages for only four weeks.
        ///  
        /// For instant delivery use 0 because
        /// GCM will never throttle messages with a time_to_live value of 0 seconds. In other words, GCM will guarantee best effort for messages that must be delivered "now or never."
        /// Read more here: http://developer.android.com/google/gcm/adv.html#ttl
        /// </summary>
        public int? TimeToLiveSeconds
        { 
            get { return _TimeToLiveSeconds; } 
            set { _TimeToLiveSeconds = value; } 
        }


        /// <summary>
        /// Is one instance of the message is sufficient or not.
        /// One is sufficient when message is collapsible. For example, for each new mail received
        /// we don't need to inform user one by one. One 'new message' notificaion is enought so, 
        /// IsOneSufficient = true. But for doctor rington, it can't be collapsible; So, IsOneSufficient=false there.
        /// 
        /// Note: It is not supported in APNS
        /// </summary>
        public bool IsOneSufficient { get; set; }

        /// <summary>
        /// Key for collapse messages. It is used only when IsOneSufficient
        /// 
        /// Note: It is not supported in APNS
        /// </summary>
        public CollapseKeySEnum CollapseKey { get; set; }

        /// <summary>
        /// If the device was not available should it delay the delivery or not.
        /// For example for mobile rington DelayWhileIdle should be false
        /// For default value use null
        /// 
        /// Note: It is not supported in APNS
        /// </summary>
        public bool? DelayWhileIdle { get; set; }



    }
}
