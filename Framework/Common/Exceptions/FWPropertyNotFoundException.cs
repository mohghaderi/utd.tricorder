using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// Exceptions that happened in the internal framework layers. 
    /// These exceptions should never happen if there is no bug 
    /// </summary>
    public class FWPropertyNotFoundException : ExceptionBase
    {

        public string PropertyName { get; set; }
        public object Object { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FWPropertyNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FWPropertyNotFoundException(string propertyName, object obj)
           : base(string.Format("Property {0} not found", propertyName))
        {
            this.PropertyName = propertyName;
            this.Object = obj;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWPropertyNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerExp">The inner exp.</param>
        public FWPropertyNotFoundException(string message, Exception innerExp)
            : base(message, innerExp)
        {
 
        }



    }
}
