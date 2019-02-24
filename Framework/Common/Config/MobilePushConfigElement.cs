using System.Configuration;

namespace Framework.Common.Config
{
    /// <summary>
    /// Mobile push
    /// </summary>
    public class MobilePushConfigElement : ConfigurationElement
    {

        /// <summary>
        /// Gets or sets the full name of the realtime notify class.
        /// </summary>
        /// <value>
        /// The full name of the realtime notify class.
        /// </value>
        [ConfigurationProperty("realtimeNotifyClassFullName")]
        public string RealtimeNotifyClassFullName
        {
            get { return (string)this["realtimeNotifyClassFullName"]; }
            set { this["realtimeNotifyClassFullName"] = value; }
        }


        private object _RealTimeNotifyClass = null;

        public object GetRealTimeNotifyClass()
        {
            if (_RealTimeNotifyClass == null)
                _RealTimeNotifyClass = FWUtils.ReflectionUtils.CreateInstance(this.RealtimeNotifyClassFullName);
            return _RealTimeNotifyClass;
        }

    }
}
