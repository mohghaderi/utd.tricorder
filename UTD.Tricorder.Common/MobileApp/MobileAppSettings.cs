using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.MobileApp
{
    public class MobileAppSettings
    {
        public static MobileAppSettings GetAllSettings()
        {
            MobileAppSettings settings = new MobileAppSettings();
            settings.videoServiceHost = FWUtils.ConfigUtils.GetAppSettings().Project.VideoServiceHost;
            settings.videoMeetingName = FWUtils.ConfigUtils.GetAppSettings().Project.VideoMeetingName;
            settings.videoDefaultConnectionType = FWUtils.ConfigUtils.GetAppSettings().Project.VideoDefaultConnectionType;
            settings.userID = FWUtils.SecurityUtils.GetCurrentUserIDString();
            return settings;
        }

        public string videoServiceHost { get; set; }

        public string videoMeetingName { get; set; }

        public string videoDefaultConnectionType { get; set; }

        public string userID { get; set; }
    }
}
