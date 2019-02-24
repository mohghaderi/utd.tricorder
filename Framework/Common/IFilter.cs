using System.Collections.Generic;

namespace Framework.Common
{
    /// <summary>
    /// interface that is common between Filter and FilterExpression. 
    /// It is for framework's internal use only
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Gets the filter string.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        string GetFilterString(ICollection<object> values);
    }

}
