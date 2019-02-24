using System.Configuration;

namespace Framework.Common.Config
{
    /// <summary>
    /// Localization Setting
    /// </summary>
    public class LocalizationSettingConfigElement : ConfigurationElement
    {

        /// <summary>
        /// Gets or sets the name of the culture.
        /// </summary>
        /// <value>
        /// The name of the culture.
        /// </value>
        [ConfigurationProperty("cultureName", DefaultValue = "en-US")]
        public string CultureName
        {
            get { return (string)this["cultureName"]; }
            set { this["cultureName"] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the culture.
        /// </summary>
        /// <value>
        /// The name of the culture.
        /// </value>
        [ConfigurationProperty("tzdbFile", IsRequired=true)]
        public string TzdbFile
        {
            get { return (string)this["tzdbFile"]; }
            set { this["tzdbFile"] = value; }
        }


    }
}
