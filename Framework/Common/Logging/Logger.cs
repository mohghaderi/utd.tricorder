using Framework.Service;
using System;

namespace Framework.Common.Logging
{

    /// <summary>
    /// Logs the information in the program
    /// </summary>
    public class Logger
    {

        //#region static methods for ease of use

        ///// <summary>
        ///// Logs the info.
        ///// </summary>
        ///// <param name="message">The message.</param>
        //public static void LogInfo(string message)
        //{
        //    Logger.Instance.WriteLog(new AppLog(message, LogTypeEnum.Info));
        //}

        ///// <summary>
        ///// Logs the debug.
        ///// </summary>
        ///// <param name="message">The message.</param>
        //public static void LogDebug(string message)
        //{
        //    Logger.Instance.WriteLog(new LogEntry(message, LogTypeEnum.Debug));
        //}

        ///// <summary>
        ///// Logs the warn.
        ///// </summary>
        ///// <param name="message">The message.</param>
        //public static void LogWarn(string message)
        //{
        //    Logger.Instance.WriteLog(new LogEntry(message, LogTypeEnum.Warn));
        //}

        ///// <summary>
        ///// Logs the fatal.
        ///// </summary>
        ///// <param name="message">The message.</param>
        //public static void LogFatal(string message)
        //{
        //    Logger.Instance.WriteLog(new LogEntry(message, LogTypeEnum.Fatal));
        //}

        //#endregion


        /// <summary>
        /// log4Net logger class that logs the information in log4net library
        /// </summary>
        private static readonly log4net.ILog log4netLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IServiceBase _AppLogService;

        #region Constructor


        public Logger()
        {
            // sure that nothing will be happened during object creation
            try
            {
                //_LogWriter = (ILogWriter)FWUtils.ReflectionUtils.CreateInstance("LogWriter", "RPK.NetFW.Common.DataAccess.Logging", "RPK.NetFW.Common", null);
                //_LogWriter = (ILogWriter)EntityFactory.GetEntityServiceByName("SqlLog", "");

                //var appSettings = FWUtils.ConfigUtils.GetAppSettings();
                //if (String.IsNullOrEmpty(appSettings.Log.MainWriterClassFullName) == false)
                //    _LogWriter = (ILogWriter)FWUtils.ReflectionUtils.CreateInstance(appSettings.Log.MainWriterClassFullName);

                //if (String.IsNullOrEmpty(appSettings.Log.BackupWriterClassFullName) == false)
                //    _BackupLogWriter = (ILogWriter)FWUtils.ReflectionUtils.CreateInstance(appSettings.Log.MainWriterClassFullName);

                _AppLogService = EntityFactory.GetEntityServiceByName("AppLog", "");

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        //#region Singleton Pattern
        //static readonly object padlock = new object();
        //private static Logger _Instance;

        ///// <summary>
        ///// Gets the instance.
        ///// </summary>
        ///// <value>
        ///// The instance.
        ///// </value>
        //public static Logger Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (_Instance == null)
        //                _Instance = new Logger();
        //            return _Instance;
        //        }
        //    }
        //}

        //#endregion

        //#region Properties

        //private ILogWriter _LogWriter;
        ///// <summary>
        ///// Gets or sets the log writer.
        ///// </summary>
        ///// <value>
        ///// The log writer.
        ///// </value>
        //public ILogWriter LogWriter
        //{
        //    get { return _LogWriter; }
        //    set { _LogWriter = value; }
        //}


        //private ILogWriter _BackupLogWriter;

        ///// <summary>
        ///// Gets or sets the backup log writer. It will be used if the main log writer failed to act.
        ///// </summary>
        ///// <value>
        ///// The backup log writer.
        ///// </value>
        //public ILogWriter BackupLogWriter
        //{
        //    get { return _BackupLogWriter; }
        //    set { _BackupLogWriter = value; }
        //}

        //#endregion

        #region Methods


        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logEntry">The log entry.</param>
        /// <returns></returns>
        public bool WriteLog(IAppLog logEntry)
        {
            var appSettings = FWUtils.ConfigUtils.GetAppSettings();
            if (appSettings.Log.Enabled == false)
                return false;


            SetDefaultLogEntryProperties(logEntry);

            // first we use log4Net that is more reliable
            if (appSettings.Log.WriteToLog4NetEnabled)
                LogToLog4Net(logEntry);

            try
            {
                _AppLogService.Insert(logEntry, new InsertParameters());
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }

            return true;

            //// then we try to write on the first media, and if it was not successful, we will use the second media.

            //bool logWrited = false; // If the log is written or not

            //Exception WritingException = null; // The exception that happened in the first log writer
            //try
            //{
            //    if (this.LogWriter != null)
            //    {
            //        this.LogWriter.WriteLog(logEntry);
            //        logWrited = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logWrited = false;
            //    FWUtils.ExceptionLogger.LogError(ex, null);
            //}

            //if (logWrited == false) // if we couldn't write on the first media
            //{
            //    if (this.BackupLogWriter != null)
            //    {
            //        try
            //        {
            //            // first we log the main log
            //            BackupLogWriter.WriteLog(logEntry);
            //            logWrited = true;

            //        }
            //        catch (Exception ex)
            //        {
            //            FWUtils.ExceptionLogger.LogError(ex, null);
            //        }

            //    }
            //}

            //return logWrited;
        }

        private void SetDefaultLogEntryProperties(IAppLog logEntry)
        {
            logEntry.InsertDate = DateTime.UtcNow;

            if (FWUtils.ConfigUtils.IsInWebContext())
                if (string.IsNullOrEmpty(logEntry.IPAddress))
                    logEntry.IPAddress = FWUtils.WebUIUtils.GetRequestIPAddress();
            if (logEntry.UserID.HasValue == false)
                if (FWUtils.SecurityUtils.IsUserAuthenticated())
                    logEntry.UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong();
        }

        /// <summary>
        /// Writes Logs to log4net library.
        /// </summary>
        /// <param name="logEntry">The log entry.</param>
        private void LogToLog4Net(IAppLog logEntry)
        {
            string msg = logEntry.AppLogTypeID.ToString();
            log4netLogger.Info(msg);

            //switch (logEntry.LogType)
            //{
            //    case LogTypeEnum.Info:
            //        log4netLogger.Info(logEntry.Message);
            //        break;
            //    case LogTypeEnum.Fatal:
            //        log4netLogger.Fatal(logEntry.Message);
            //        break;
            //    case LogTypeEnum.Error:
            //        if (logEntry.ExceptionClass == null)
            //            log4netLogger.Error(logEntry.Message + "\r\n----\r\n" + logEntry.StackTrace);
            //        else
            //            log4netLogger.Error(logEntry.Message, logEntry.ExceptionClass);
            //        break;
            //    case LogTypeEnum.Warn:
            //        log4netLogger.Warn(logEntry.Message);
            //        break;
            //    case LogTypeEnum.Debug:
            //        log4netLogger.Debug(logEntry.Message);
            //        break;
            //    default:
            //        break;
            //}
        }



        #endregion

    }

}
