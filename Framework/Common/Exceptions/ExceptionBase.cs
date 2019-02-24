using System;

namespace Framework.Common.Exceptions
{
    [Serializable]
    /// <summary>
    /// Base class for all exceptions
    /// </summary>
    public abstract class ExceptionBase : Exception
    {

        public ExceptionBase()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExceptionBase(string message)
           : base(message)
        { 

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public ExceptionBase(string message, Exception innerExp)
            : base(message, innerExp)
        {
 
        }

    }



}
