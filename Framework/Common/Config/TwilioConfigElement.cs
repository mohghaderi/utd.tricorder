using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public class TwilioConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("accountSid", DefaultValue = "", IsRequired = true)]
        public string AccountSid
        {
            get { return (string)this["accountSid"]; }
            set { this["accountSid"] = value; }
        }

        [ConfigurationProperty("authToken", DefaultValue = "", IsRequired = true)]
        public string AuthToken
        {
            get { return (string)this["authToken"]; }
            set { this["authToken"] = value; }
        }

        [ConfigurationProperty("fromNumber", DefaultValue = "", IsRequired = true)]
        public string FromNumber
        {
            get { return (string)this["fromNumber"]; }
            set { this["fromNumber"] = value; }
        }

        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

    }
}
