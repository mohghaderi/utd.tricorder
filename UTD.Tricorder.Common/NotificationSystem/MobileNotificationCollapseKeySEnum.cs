using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.NotificationSystem
{
    /// <summary>
    /// Mobile Notification Collapse KeySEnum
    /// This key is for Send-to-sync messages. These messages don't have a content.
    /// They just inform the application to pull the information from the server.
    /// It is like a 'new mail' message
    /// 
    /// NOTE: GCM allows a maximum of 4 different collapse keys for one app: http://developer.android.com/google/gcm/adv.html#retry
    /// </summary>
    public class CollapseKeySEnum
    {
        public static CollapseKeySEnum Message1 = new CollapseKeySEnum("Message1");
        public static CollapseKeySEnum Message2 = new CollapseKeySEnum("Message2");
        public static CollapseKeySEnum Message3 = new CollapseKeySEnum("Message3");
        public static CollapseKeySEnum Message4 = new CollapseKeySEnum("Message4");
        // DEVELOPER NOTE: Please don't add more than four here. GCM doesn't support it

        private string fnName;

        public CollapseKeySEnum(string customFunction)
        {
            fnName = customFunction;
        }


        public string getFnName()
        {
            return fnName;
        }


        public static bool operator ==(CollapseKeySEnum e, string s)
        {
            return e.fnName == s;
        }

        public static bool operator !=(CollapseKeySEnum e, string s)
        {
            return e.fnName != s;
        }

        public static bool operator ==(CollapseKeySEnum e, CollapseKeySEnum s)
        {
            return e.fnName == s.fnName;
        }

        public static bool operator !=(CollapseKeySEnum e, CollapseKeySEnum s)
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
