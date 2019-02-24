using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;

namespace Framework.Service
{
    public interface IServiceBase : IEntityCRUDFunctions , IInitializeByEntity
    {
        /// <summary>
        /// Does the entity action batch.
        /// </summary>
        /// <param name="recordIds">The record ids.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Successful Message</returns>
        void DoBatchAction(string recordIDsCommaSeparated, string actionName, string parameters);
    }
}
