using Framework.Common.Exceptions;
using System;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// Exceptions that have a message for the user
    /// These messages will be automatically be translated for each culture
    /// They will not be logged. They should be used only if user needs to be
    /// informed about something. It can be a business rule exception or something else
    /// </summary>
    public class UserException : ExceptionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserException" /> class.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        public UserException(string messageId)
            :base(messageId)
        { 

        }

    }



}
