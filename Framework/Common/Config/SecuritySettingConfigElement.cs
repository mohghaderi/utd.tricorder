using System.Configuration;

namespace Framework.Common.Config
{
    /// <summary>
    /// Security Setting
    /// </summary>
    public class SecuritySettingConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets a value indicating whether [security enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [security enabled]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        [ConfigurationProperty("accessHelperClassFullName")]
        public string AccessHelperClassFullName
        {
            get { return (string)this["accessHelperClassFullName"]; }
            set { this["accessHelperClassFullName"] = value; }
        }

    }
}
