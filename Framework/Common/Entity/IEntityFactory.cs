namespace Framework.Common.Entity
{
    /// <summary>
    /// Interface for Entity factories
    /// </summary>
    public interface IEntityFactory
    {
        /// <summary>
        /// Gets the name of the entity business rule by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        Framework.Business.IBusinessRuleBase GetEntityBusinessRuleByName(string entityName, string additionalDataKey);
        /// <summary>
        /// Gets the name of the entity info by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        Framework.Common.EntityInfoBase GetEntityInfoByName(string entityName, string additionalDataKey);
        /// <summary>
        /// Gets the name of the entity data access by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        Framework.DataAccess.IDataAccessBase GetEntityDataAccessByName(string entityName, string additionalDataKey);
        /// <summary>
        /// Gets the name of the entity service by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        Framework.Service.IServiceBase GetEntityServiceByName(string entityName, string additionalDataKey);


        /// <summary>
        /// Gets the entity object.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        EntityObjectBase GetEntityObject(string entityName, GetSourceTypeEnum sourceType);

    }
}
