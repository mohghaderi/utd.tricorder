using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    [Serializable]
    public class AuthenticationIsRequiredException: ExceptionBase
    {

        public AuthenticationIsRequiredException()
            : base()
        { 
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationIsRequiredException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public AuthenticationIsRequiredException(string message)
           : base(message)
        { 
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="AuthenticationIsRequiredException" /> class.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <param name="innerExp">The inner exp.</param>
        //public AuthenticationIsRequiredException(string message, Exception innerExp)
        //    : base(message, innerExp)
        //{
 
        //}



    }
}
