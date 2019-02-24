using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;

namespace Framework.DataAccess
{
    public interface IDataAccessBase : IEntityCRUDFunctions , IInitializeByEntity
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Gets or sets a value indicating whether [automatic save].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic save]; otherwise, <c>false</c>.
        /// </value>
        bool AutoSave { get; set; }
    }
}
