using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// An execption that should never happen if program operates correctly.
    /// For example form can not be saved if it is opened in readonly mode
    /// </summary>
    public class ImpossibleExecutionException : ExceptionBase
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ImpossibleExecutionException(string message)
           : base(message)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public ImpossibleExecutionException(string message, Exception innerExp)
            : base(message, innerExp)
        {
 
        }


    }
}
