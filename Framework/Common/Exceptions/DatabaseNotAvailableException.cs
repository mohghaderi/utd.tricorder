using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// When program database is not accessible
    /// </summary>
    public class DatabaseNotAvailableException : ExceptionBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DatabaseNotAvailableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public DatabaseNotAvailableException(string message, Exception innerExp)
            : base(message, innerExp)
        {

        }


    }
}
