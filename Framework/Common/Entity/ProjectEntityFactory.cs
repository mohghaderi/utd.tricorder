using Framework.Business;
using Framework.Common.Config;
using Framework.DataAccess;
using Framework.Service;

namespace Framework.Common.Entity
{
    /// <summary>
    /// Creates the required classes for the main project under the application
    /// </summary>
    internal class ProjectEntityFactory : IEntityFactory
    {
        /// <summary>
        /// Gets the name of the entity info by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public EntityInfoBase GetEntityInfoByName(string entityName, string additionalDataKey)
        {
            ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
            return (EntityInfoBase)FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".Common.EntityInfo", entityName, appSetting.Project.NamespacePrefix + ".Common", new object[] { additionalDataKey });
        }


        /// <summary>
        /// Gets the name of the entity service by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public IServiceBase GetEntityServiceByName(string entityName, string additionalDataKey)
        {
            ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
            IServiceBase obj = (IServiceBase)FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".Service", entityName + "Service", appSetting.Project.NamespacePrefix + ".Services", new object[] { additionalDataKey });
            obj.Initialize(entityName, additionalDataKey);
            return obj;
        }


        /// <summary>
        /// Gets the name of the entity data access by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public IDataAccessBase GetEntityDataAccessByName(string entityName, string additionalDataKey)
        {
            ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
            IDataAccessBase obj = (IDataAccessBase)FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".DataAccess", entityName + "DA", appSetting.Project.NamespacePrefix + ".DataAccess", new object[] { additionalDataKey });
            obj.Initialize(entityName, additionalDataKey);
            return obj;
        }

        /// <summary>
        /// Gets the name of the entity business rule by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public IBusinessRuleBase GetEntityBusinessRuleByName(string entityName, string additionalDataKey)
        {
            ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
            IBusinessRuleBase obj = (IBusinessRuleBase)FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".BusinessRule", entityName + "BL", appSetting.Project.NamespacePrefix + ".BusinessRules", new object[] { additionalDataKey });
            obj.Initialize(entityName, additionalDataKey);
            return obj;
        }


        /// <summary>
        /// Gets the entity object.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        public EntityObjectBase GetEntityObject(string entityName, GetSourceTypeEnum sourceType)
        {
            ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
            object obj = null;
            if (sourceType == GetSourceTypeEnum.Table)
                obj = FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".Common.EntityObjects", entityName, appSetting.Project.NamespacePrefix + ".Common");
            else
                obj = FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.NamespacePrefix + ".Common.EntityObjects", "v" + entityName, appSetting.Project.NamespacePrefix + ".Common");
            return (EntityObjectBase)obj;

        }
    }
}
