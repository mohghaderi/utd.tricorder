using Framework.Common.Logging;
using System;
using System.Data.SqlClient;

namespace Framework.Common.Exceptions
{
    /// <summary>
    /// Translates the exception for the user. So, he can understand what's happened.
    /// It can be a database duplicate record, or an unavailable database, or anything else
    /// It returns an unknown exception for the user, if it couldn't translate it.
    /// If it is on the localhost, it shows stack trace to the users.
    /// </summary>
    public class ExceptionTranslator
    {

        /// <summary>
        /// Tries to translate.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public UserException TryToTranslate(Exception exception)
        {
            //if (exception is System.Data.UpdateException)
            //{
            //    if (exception.InnerException != null)
            //        if (exception.InnerException.Message.StartsWith("Cannot insert duplicate key row in object"))
            //            return new UserException("امكان ايجاد رديف تكراري در ديتابيس وجود ندارد.");
            //}

            //if (exception.Message == "Failed to enable constraints. One or more rows contain values violating non-null, unique, or foreign-key constraints.")
            //{
            //    return
            //        new UserException(
            //            "اطلاعات بدست آمده از ديتابيس با اطلاعات ديتاست ايجاد شده يكسان نمي باشد. لطفا بررسي كنيد كه از نظر نال بودن, كليد خارجي و... ديتاست دقيقا با اطلاعات بازيابي شده مطابقت داشته باشد.");
            //}

            try
            {
                if (exception is SqlException && exception.Message.Contains("error: 40 - Could not open a connection to SQL Server"))
                {
                    return new UserException(StringMsgs.Exceptions.DatabaseServerIsNotAccessible);
                }

                if (exception is ServiceSecurityException)
                {
                    if (string.IsNullOrEmpty(exception.Message))
                        return new UserException(StringMsgs.Exceptions.AccessDenied);
                    else
                        return new UserException(exception.Message);
                }

                if (exception is ObjectChangedBeforeUpdate) // This is concurrency error and it can be translated as a user exception
                {
                    return new UserException(exception.Message);
                }

                if (exception is HoneyPotException)
                {
                    // we show access denied for honey pots, but we capture and identify users
                    // TODO: Automatically lock users who got this exception
                    // TODO: ban requests of the users who got this exception or do force logout
                    return new UserException(StringMsgs.Exceptions.AccessDenied);
                }

                //if (FWUtils.WebUIUtils.IsLocalHost())
                if (FWUtils.ConfigUtils.GetAppSettings().ExceptionHandling.ShowDebug)
                {
                    //return new FWException("<div dir=ltr><B>" + exception.Message + "</B><br />" + exception.StackTrace + "</div>"); // don't work with ExtJs
                    string newExpMessage = ExceptionLogger.CreateRecursiveStackTrace("", exception, 0);
                    return new UserException(newExpMessage);
                }
            }
            catch (Exception)
            {
            }

            return new UserException(StringMsgs.Exceptions.UnknownExceptionHappened);
        }

    }
}
