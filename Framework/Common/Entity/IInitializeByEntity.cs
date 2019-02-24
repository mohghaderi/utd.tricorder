using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    /// <summary>
    /// Interface to indicate that this object is entity initializable
    /// </summary>
    public interface IInitializeByEntity
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        string EntityName { get; }

        /// <summary>
        /// Gets or sets the additional data key.
        /// </summary>
        /// <value>
        /// The additional data key.
        /// </value>
        string AdditionalDataKey { get; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        EntityInfoBase Entity { get; }


        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
        bool IsInitialized { get; }

        /// <summary>
        /// Initializes the object with the provided entityname and additionaldatakey
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        void Initialize(string entityName, string additionalDataKey);


        /// <summary>
        /// Initializes the object with the provided entity class. It is fast when entity class is already created.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Initialize(EntityInfoBase entity);

    }
}
