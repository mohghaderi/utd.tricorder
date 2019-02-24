using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.NotificationSystem
{
    // DEVELOPER NOTE: Change this file with the file in MobileApp (MobileNotificationTypeSEnum.as)

    /// <summary>
    /// MobileNotificationType is type of messages that the system can send to the mobile
    /// This type will be processed by the application later to decide about the action
    /// </summary>
    public class MobileNotificationTypeSEnum
    {
        public static MobileNotificationTypeSEnum TestPushSanity = new MobileNotificationTypeSEnum("TestPushSanity");
        public static MobileNotificationTypeSEnum PhoneRing = new MobileNotificationTypeSEnum("PhoneRing");

        private string fnName;

        public MobileNotificationTypeSEnum(string customFunction)
        {
            fnName = customFunction;
        }


        public string getFnName()
        {
            return fnName;
        }


        public static bool operator ==(MobileNotificationTypeSEnum e, string s)
        {
            return e.fnName == s;
        }

        public static bool operator !=(MobileNotificationTypeSEnum e, string s)
        {
            return e.fnName != s;
        }

        public static bool operator ==(MobileNotificationTypeSEnum e, MobileNotificationTypeSEnum s)
        {
            return e.fnName == s.fnName;
        }

        public static bool operator !=(MobileNotificationTypeSEnum e, MobileNotificationTypeSEnum s)
        {
            return e.fnName != s.fnName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null && fnName == null)
                return true;

            if (!(obj is string) && !(obj is MobileNotificationTypeSEnum)) return false;

            if (obj is string)
                return ((string)obj) == fnName;
            if (obj is MobileNotificationTypeSEnum)
                return ((MobileNotificationTypeSEnum)obj).getFnName() == this.fnName;
            else
                return false;
        }

        public override int GetHashCode()
        {
            if (this.fnName != null)
                return this.getFnName().GetHashCode();
            else
                return -1;
        }

    }
}
