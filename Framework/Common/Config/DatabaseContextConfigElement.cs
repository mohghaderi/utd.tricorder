using System.Configuration;

namespace Framework.Common.Config
{
    public class DatabaseContextConfigElement : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("settingsPath", IsRequired = true, DefaultValue = "")]
        public string SettingsPath
        {
            get { return (string)this["settingsPath"]; }
            set { this["settingsPath"] = value; }
        }

        [ConfigurationProperty("isTransactional", IsRequired = false, DefaultValue = false)]
        public bool IsTransactional
        {
            get { return (bool)this["isTransactional"]; }
            set { this["isTransactional"] = value; }
        }
    }
}
