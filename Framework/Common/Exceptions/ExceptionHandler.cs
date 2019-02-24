using System;
using Framework.Common.Logging;

namespace Framework.Common.Exceptions
{
    /// <summary>
    /// Keeps possible exception policy. It can be used later to define exception behavior
    /// </summary>
    public class PolicyName
    {
        public const string GlobalPolicy = "GlobalPolicy";
    }

    /// <summary>
    /// Handles exceptions happened in the program. It logs them, and then translates them
    /// </summary>
    public class ExceptionHandler
    {

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns></returns>
        public bool HandleException(ref System.Exception exception, string policyName)
        {

            try
            {
                if (exception is UserException)
                {
                    return true;  // Propagate Policy
                }
                else
                {
                    // logs the exception
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(exception, null);

                    // tries to translate an exception before showing it to the user
                    ExceptionTranslator t = new ExceptionTranslator();
                    exception = t.TryToTranslate(exception); // if translation is successful, it created a UserException
                }

            }
            catch (Exception)
            {
                // Excution should never be here
                exception = new UserException(StringMsgs.Exceptions.UnknownExceptionHappened);
                return false;
            }

            return true;
        }






    }
}
