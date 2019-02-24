using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace UTD.Tricorder.Common
{
    public class CordovaCapabilities
    {

        private bool _IsNull;
        public bool IsNull { get { return _IsNull; } }

        public string connection { get; set; }
        public string model { get; set; }
        public string initialOrientation { get; set; }
        public string orientation { get; set; }
        public string osversion { get; set; }
        public string phonegapversion { get; set; }
        public string platform { get; set; }
        public string queryString { get; set; }
        public string uuid { get; set; }
        public bool hasCaching { get; set; }
        public bool hasStreaming { get; set; }
        public bool hasAnalytics { get; set; }
        public bool hasPush { get; set; }
        public bool hasUpdates { get; set; }
        public string lastStation { get; set; }


        private readonly string _capabilitiesString;

        internal bool IsSame(string capabilitiesString)
        {
            return _capabilitiesString == capabilitiesString;
        }


        public CordovaCapabilities(string capabilitiesString)
        {
            _capabilitiesString = capabilitiesString;
            ParseCapabilitiesString(capabilitiesString);
        }

        private void ParseCapabilitiesString(string capabilitiesString)
        {
            if (string.IsNullOrEmpty(capabilitiesString))
            {
                _IsNull = true;
            }
            else
            {
                try
                {
                    FWUtils.EntityUtils.JsonDeserializeOnObject(_capabilitiesString, this, null, true);
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, capabilitiesString);
                }

            }
        }

    }
}
