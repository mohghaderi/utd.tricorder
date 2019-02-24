using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct UserDeviceSettingRegisterDeviceSP
    {
        public Guid GeneratedUUID {get;set;} 
        public long UserID {get;set;} 
        public string CapabilitiesServerString {get;set;}
        public string PushToken { get; set; }
        public byte UserDeviceClientAppTypeID { get; set; }
        public string UserDeviceClientAppVersion { get; set; }
    }


    public struct SendPushSanitySP
    {
        public long UserID { get; set; }
    }


}
