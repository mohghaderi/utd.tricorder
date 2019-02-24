using System.Configuration;

namespace Framework.Common.Config
{

    /// <summary>
    /// Log Setting
    /// </summary>
    public class LogSettingConfigElement : ConfigurationElement
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


        /// <summary>
        /// Gets or sets a value indicating whether [write to log4 net enabled].
        /// </summary>
        /// <value>
        /// <c>true</c> if [write to log4 net enabled]; otherwise, <c>false</c>.
        /// </value>
        [ConfigurationProperty("writeToLog4NetEnabled")]
        public bool WriteToLog4NetEnabled
        {
            get { return (bool)this["writeToLog4NetEnabled"]; }
            set { this["writeToLog4NetEnabled"] = value; }
        }


        /// <summary>
        /// Gets or sets the full name of the main writer class.
        /// </summary>
        /// <value>
        /// The full name of the main writer class.
        /// </value>
        [ConfigurationProperty("mainWriterClassFullName")]
        public string MainWriterClassFullName
        {
            get { return (string)this["mainWriterClassFullName"]; }
            set { this["mainWriterClassFullName"] = value; }
        }



        /// <summary>
        /// Gets or sets the full name of the backup writer class.
        /// </summary>
        /// <value>
        /// The full name of the backup writer class.
        /// </value>
        [ConfigurationProperty("backupWriterClassFullName")]
        public string BackupWriterClassFullName
        {
            get { return (string)this["backupWriterClassFullName"]; }
            set { this["backupWriterClassFullName"] = value; }
        }


    }
}
