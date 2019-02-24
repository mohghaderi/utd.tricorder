using System;

namespace Framework.Common.Exceptions
{
    [Serializable]
    /// <summary>
    /// Exceptions that happened in the internal framework layers. 
    /// These exceptions should never happen if there is no bug 
    /// </summary>
    public class FWException : ExceptionBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FWException(string message)
           : base(message)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public FWException(string message, Exception innerExp)
            : base(message, innerExp)
        {
 
        }



    }
}