using System.Configuration;

namespace Framework.Common.Config
{
    /// <summary>
    /// Exception Settings
    /// </summary>
    public class ExceptionSettingConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the exception translator.
        /// </summary>
        /// <value>
        /// The exception translator.
        /// </value>
        [ConfigurationProperty("exceptionTranslatorClassFullName")]
        public string ExceptionTranslatorClassFullName
        {
            get { return (string)this["exceptionTranslatorClassFullName"]; }
            set { this["exceptionTranslatorClassFullName"] = value; }
        }

        [ConfigurationProperty("showDebug", DefaultValue = "false", IsRequired = true)]
        public bool ShowDebug
        {
            get { return (bool)this["showDebug"]; }
            set { this["showDebug"] = value; }
        }

    }
}
