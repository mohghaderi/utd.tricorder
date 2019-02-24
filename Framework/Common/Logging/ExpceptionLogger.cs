using Framework.Service;
using System;

namespace Framework.Common.Logging
{

    /// <summary>
    /// Logs the exception
    /// </summary>
    public class ExceptionLogger
    {
        private IServiceBase _ExceptionService;

        public ExceptionLogger()
        {
            _ExceptionService = EntityFactory.GetEntityServiceByName("AppExceptionLog", "");
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public bool LogError(Exception ex, object additionalInfo)
        {
            try
            {
                //LogExceptionRecursive(ex, 0);

                var exp = ConvertExceptionToLogEntry(ex, additionalInfo);
                _ExceptionService.Insert(exp, new InsertParameters());

                if (FWUtils.ConfigUtils.GetAppSettings().Log.WriteToLog4NetEnabled)
                {
                    
                }
                return true;
            }
            catch (Exception) // RESUME -- DoNoting in Error 
            {
                return false;
            }
        }


        /// <summary>
        /// Converts the exception to log entry.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="additionalinfo">The additionalinfo.</param>
        /// <param name="errornumber">The errornumber.</param>
        /// <returns></returns>
        public static IAppExceptionLog ConvertExceptionToLogEntry(Exception ex, object additionalinfo)
        {
            Check.Require(ex != null, "exception shouldn't be null");

            IAppExceptionLog logInfo = (IAppExceptionLog)EntityFactory.GetEntityObject("AppExceptionLog", GetSourceTypeEnum.Table);

            logInfo.Message = ex.Message;
            logInfo.Source = ex.Source;
            if (FWUtils.SecurityUtils.IsUserAuthenticated())
                logInfo.UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            logInfo.InsertDate = DateTime.UtcNow;
            if (ex.GetType() != null)
                logInfo.ClassType = ex.GetType().ToString();
            if (string.IsNullOrEmpty(ex.StackTrace) == false)
                logInfo.StackTrace = ExceptionLogger.CreateRecursiveStackTrace("", ex, 0);
            if (ex.TargetSite != null)
                logInfo.Target = ex.TargetSite.ToString();
            if (FWUtils.ConfigUtils.IsInWebContext())
                logInfo.IPAddress = FWUtils.WebUIUtils.GetRequestIPAddress();
            if (FWUtils.ConfigUtils.IsInWebContext())
                logInfo.Url = FWUtils.WebUIUtils.GetRequestUrl();

            if (additionalinfo != null)
            {
                if (additionalinfo is string)
                    if ((string)additionalinfo != "")
                    logInfo.DataInformation = (string)additionalinfo;
                else
                {
                    try
                    {
                        logInfo.DataInformation = FWUtils.EntityUtils.JsonSerializeObject(additionalinfo, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }       


            return logInfo;
        }


        /// <summary>
        /// Creates the exception message string from an exception to show it to the user
        /// </summary>
        /// <param name="msg">initial message</param>
        /// <param name="ex">the exception</param>
        /// <param name="recursiveSafeCounter">safe counter for recursive loop</param>
        /// <returns></returns>
        public static string CreateRecursiveStackTrace(string msg, Exception ex, int recursiveSafeCounter)
        {
            // preventing possibly 
            recursiveSafeCounter++;
            if (recursiveSafeCounter > 7)
                return msg;

            string newExpMessage = msg + ex.Message ;
            if (string.IsNullOrEmpty(ex.StackTrace) == false)
                newExpMessage += "\r\n" + ex.StackTrace + "";
            if (ex.InnerException != null)
                newExpMessage += "\r\n-----------------------------------------------------------------\r\n Inner Exception : \r\n"
                    + CreateRecursiveStackTrace(msg, ex.InnerException, recursiveSafeCounter);

            return newExpMessage;

        }


    }
}