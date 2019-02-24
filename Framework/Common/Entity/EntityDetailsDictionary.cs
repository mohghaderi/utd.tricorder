using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Framework.Common.Exceptions;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// A dictionary that keeps detail information for the entity
    /// </summary>
    public class EntityDetailsDictionary
    {
        private Dictionary<string, EntityDetail> details = new Dictionary<string, EntityDetail>();


        public EntityDetailsDictionary()
        {
 
        }

        /// <summary>
        /// Adds the specified entity name.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalData">The additional data.</param>
        public void Add(string entityName, string additionalData, string relatedColumnName)
        {
            string key = GetKey(entityName, additionalData);
            details.Add(key, new EntityDetail(entityName, additionalData, relatedColumnName));
        }

        /// <summary>
        /// Adds the specified detail.
        /// </summary>
        /// <param name="detail">The detail.</param>
        public void Add(EntityDetail detail)
        {
            if (detail.IsValidInfo() == false)
                throw new FWException("Detail information is not valid.");

            string key = GetKey(detail.EntityName, detail.AdditionalData);
            if (details.ContainsKey(key))
                throw new FWException("Another Detail with the same EntityName and AdditionalDataKey is already added to the details of this entity");

            details.Add(key, detail);
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalData">The additional data.</param>
        /// <returns></returns>
        public EntityDetail FindDetail(string entityName, string additionalData)
        {
            string key = GetKey(entityName, additionalData);
            if (details.ContainsKey(key))
                return details[key];
            return null;
        }

        /// <summary>
        /// Gets the key for using in dictionary
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalData">The additional data.</param>
        /// <returns></returns>
        private string GetKey(string entityName, string additionalData)
        {
            Check.Require(string.IsNullOrEmpty(entityName) == false);
            if (additionalData == null)
                additionalData = "";

            return entityName + additionalData;
        }

        /// <summary>
        /// Gets the details dictionary.
        /// Please don't use this to add items to the dictionary. It is for framework usage
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, EntityDetail> __GetDetailsDictionary()
        {
            return details;
        }

        //public void Add(string entityName, string additionalData, string title, DetailEntityEditFormTypes editType, string customUrl, bool visible)
        //{   
        //    this.Add(new EntityDetail(){ EntityName = entityName, AdditionalData = additionalData, Title = title, EditType = editType, CustomUrl = customUrl, Visible= visible});
        //}

    }
}
