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
    /// When set value can not be done because of format exception
    /// </summary>
    public class FWPropertySetValueException : ExceptionBase
    {

        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FWPropertySetValueException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FWPropertySetValueException(string propertyName, object PropertyValue, Exception innerExp)
            : base(string.Format("Cannot set value: {0} to property {1}", FWUtils.EntityUtils.ConvertObjectToString(PropertyValue), propertyName), innerExp)
        {
            this.PropertyName = propertyName;
            this.PropertyValue = PropertyValue;
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="FWPropertySetValueException" /> class.
        ///// </summary>
        ///// <param name="message">The message.</param>
        ///// <param name="innerExp">The inner exp.</param>
        //public FWPropertySetValueException(string message, Exception innerExp)
        //    : base(message, innerExp)
        //{

        //}



    }
}
