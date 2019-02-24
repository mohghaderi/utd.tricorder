using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common.Config;
using System.Configuration;
using Framework.Common.Exceptions;
using System.Web;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Configuration Utilities
    /// </summary>
    public class ConfigUtils
    {
        /// <summary>
        /// The base directory that app is started from. This is the location of the directory in the file system.
        /// for example: C:\IIS7\SampleWebsite\SampleProject\
        /// It always ends with '\'
        /// </summary>
        public string ApplicationPath { get; set; }

        ///// <summary>
        ///// Gets or sets the application base web URL.
        ///// for example: http://www.frameworkproject.com:8787/SampleWebsite
        ///// It always ends with '/'
        ///// </summary>
        ///// <value>
        ///// The application base web URL.
        ///// </value>
        //public string ApplicationBaseWebUrl { get; set; }

        /// <summary>
        /// Node id to know what server is this file
        /// </summary>
        public int ServerNodeID { get; set; }


        public int NumberOfSuffixDigits { get; set; }

        public ConfigUtils()
        {
            string cfgName = GetAppSettings().Project.ServerInfoConfigFile;
            
            this.ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (this.ApplicationPath.EndsWith("\\") == false)
                this.ApplicationPath += "\\";

            //this.ApplicationBaseWebUrl = VirtualPathUtility.ToAbsolute("~/"); //TODO: it should reflect the base weburl.
            //if (this.ApplicationBaseWebUrl.EndsWith("/") == false)
            //    this.ApplicationBaseWebUrl += "/";

            LoadServerInfoConfig(cfgName);
        }

        /// <summary>
        /// Loads the server info config.
        /// </summary>
        /// <param name="cfgName">Name of the CFG.</param>
        private void LoadServerInfoConfig(string cfgName)
        {
            Check.Require(string.IsNullOrEmpty(cfgName) == false);

            string serverInfoConfigFileName = System.IO.Path.Combine(this.ApplicationPath, cfgName);
            
            Check.Require(System.IO.File.Exists(serverInfoConfigFileName), "Serverinfo config file not found: " + serverInfoConfigFileName + ". Please make sure that you have all configuration files.");

            string computerName = System.Environment.MachineName.ToLower();
            int serverNumber = -1;

            string[] lines = System.IO.File.ReadAllLines(serverInfoConfigFileName);
            HashSet<int> listServerInfo = new HashSet<int>();
            string[] tmpLineSplit;
            int nodeId = -1;

            for (int i = 0; i< lines.Length; i++)
            {
                string s = lines[i];

                if (s.Trim().StartsWith("#") == false)
                {
                    tmpLineSplit = s.Split(' ');
                    Check.Assert(tmpLineSplit.Length == 2, "Each line of serverinfo config file should have two values: serverNodeId(int)[space]serverComputerName(string). Error in line number:" + i.ToString() + " of file:" + serverInfoConfigFileName);
                    bool b = int.TryParse(tmpLineSplit[0], out nodeId);
                    
                    Check.Assert(b == true, "Each line of serverinfo config file should have two values: serverNodeId(int), serverComputerName(string). Error in line number:" + i.ToString() + " of file:" + serverInfoConfigFileName);
                    Check.Assert(listServerInfo.Contains(nodeId) == false, "No node in serverinfo config file should be defined twice. This ID is repeated more than once: " + nodeId.ToString() + " " + "error line number: " + i.ToString() + " file name:" + serverInfoConfigFileName);

                    listServerInfo.Add(nodeId);

                    string serverName = tmpLineSplit[1];
                    Check.Assert(string.IsNullOrEmpty(serverName) == false, "server name can not be empty in serverinfo config file" + "error line number: " + i.ToString() + " file name:" + serverInfoConfigFileName);

                    if (serverName.ToLower() == computerName)
                        serverNumber = nodeId;
                }
            }

            Check.Ensure(serverNumber != 0, "severNumber can not be 0. Please check serverinfo config file: " + serverInfoConfigFileName);

            Check.Ensure(serverNumber > 0, "The name of this server, " + computerName + ", could not be found in the serverinfo config file : " + serverInfoConfigFileName + " Please make sure that you have a correct server information. (Just as a reminder, be cureful when you are copying your server information. there shouldn't be any server with the same serverNodeId.)");

            this.ServerNodeID = serverNumber;
        }

        private static ApplicationSetting _appSettings;

        /// <summary>
        /// Gets the application setting.
        /// </summary>
        /// <returns></returns>
        public  ApplicationSetting GetAppSettings()
        {
            if (_appSettings == null)
                LoadApplicationSettingsConfig();
            return _appSettings; 
        }


        /// <summary>
        /// Loads the application settings config.
        /// </summary>
        /// <exception cref="FWException">Configuration can not be loaded. Please make sure the format is correct.</exception>
        private void LoadApplicationSettingsConfig()
        {
            const string configurationSectionName = "applicationSetting";

            try
            {
                _appSettings = (ApplicationSetting)ConfigurationManager.GetSection(configurationSectionName);
            }
            catch (Exception ex)
            {
                throw new FWException("Configuration can not be loaded. Please make sure the format is correct." + ex.Message, ex);
            }

            if (_appSettings == null)
                throw new FWException(configurationSectionName + " is not available in configuration file.");
        }

        /// <summary>
        /// Checks if framework is running in a Web Context
        /// </summary>
        /// <returns></returns>
        public bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }



    }
}
