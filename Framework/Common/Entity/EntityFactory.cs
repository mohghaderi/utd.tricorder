using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common.Entity;
using Framework.DataAccess;
using Framework.Service;
using Framework.Common.Cache;

namespace Framework.Common
{

    /// <summary>
    /// Creates entities information classes
    /// </summary>
    public static class EntityFactory
    {

        internal static IEntityFactory pEntityFactory;

        /// <summary>
        /// Gets the entity factory.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <returns></returns>
        private static IEntityFactory GetEntityFactory(string entityName)
        {
            Check.Require(string.IsNullOrEmpty(entityName) == false);

            if (pEntityFactory == null)
            {
                pEntityFactory = (IEntityFactory) FWUtils.ReflectionUtils.CreateInstance(FWUtils.ConfigUtils.GetAppSettings().Project.FactoryClassFullName);
            }
            return pEntityFactory;
        }


        private static SimpleObjectCacheManagement<EntityInfoBase> _EntityInfoCashe = new SimpleObjectCacheManagement<EntityInfoBase>();

        /// <summary>
        /// Gets the name of the entity info by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public static EntityInfoBase GetEntityInfoByName(string entityName, string additionalDataKey)
        {
            Check.Require(string.IsNullOrEmpty(entityName) == false);
            if (additionalDataKey == null)
                additionalDataKey = "";

            string cacheKey = entityName + additionalDataKey;
            return _EntityInfoCashe.GetOrCreate(cacheKey, (x) => GetEntityFactory(entityName).GetEntityInfoByName(entityName, additionalDataKey),null);
        }


        /// <summary>
        /// Gets the name of the entity service by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public static IServiceBase GetEntityServiceByName(string entityName, string additionalDataKey)
        {
            return GetEntityFactory(entityName).GetEntityServiceByName(entityName, additionalDataKey);
        }


        /// <summary>
        /// Gets the name of the entity data access by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public static IDataAccessBase GetEntityDataAccessByName(string entityName, string additionalDataKey)
        {
            return GetEntityFactory(entityName).GetEntityDataAccessByName(entityName, additionalDataKey);
        }

        /// <summary>
        /// Gets the name of the entity business rule by.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        /// <returns></returns>
        public static IBusinessRuleBase GetEntityBusinessRuleByName(string entityName, string additionalDataKey)
        {
            return GetEntityFactory(entityName).GetEntityBusinessRuleByName(entityName, additionalDataKey);
        }

        private static SimpleObjectCacheManagement<EntityObjectBase> _EntityObjectCache = new SimpleObjectCacheManagement<EntityObjectBase>();

        /// <summary>
        /// Gets the entity context.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static EntityObjectBase GetEntityObject(string entityName, GetSourceTypeEnum sourceType)
        {
            string cacheKey = entityName + ((int) sourceType);
            EntityObjectBase obj = _EntityObjectCache.GetOrCreate(cacheKey, (x) => GetEntityFactory(entityName).GetEntityObject(entityName, sourceType), null);
            return (EntityObjectBase) FWUtils.ReflectionUtils.CloneByFirstConstructor(obj.GetType());
            //return GetEntityFactory(entityName).GetEntityObject(entityName, sourceType);
        }
    }
}
