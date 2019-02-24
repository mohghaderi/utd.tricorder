using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    /// <summary>
    /// This happens when concurrency of the object is violated in the database
    /// </summary>
    [Serializable]
    public class ObjectChangedBeforeUpdate : ExceptionBase
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ObjectChangedBeforeUpdate(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public ObjectChangedBeforeUpdate(string message, Exception innerExp)
            : base(message, innerExp)
        {

        }


    }
}
