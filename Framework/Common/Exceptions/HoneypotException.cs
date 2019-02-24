using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// An execption that should never happen if user doesn't tamper anything
    /// For example calling deleting log, tamering login tokens, ...
    /// This exception is to find users who are trying to hack the system
    /// </summary>
    public class HoneyPotException : ExceptionBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public HoneyPotException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public HoneyPotException(string message, Exception innerExp)
            : base(message, innerExp)
        {

        }


    }
}
