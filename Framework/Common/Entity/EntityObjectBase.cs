using System;

namespace Framework.Common
{
    [Serializable]
    public abstract class EntityObjectBase
    {
        public const string ClassPostFix = "";

        private string _EntityName;
        /// <summary>
        /// Gets EntityName from its class
        /// </summary>
        /// <returns></returns>
        public virtual string GetEntityNameFromItsType()
        {
            // it is not a property to avoid mistakes of the same property name in the database
            if (string.IsNullOrEmpty(_EntityName))
                _EntityName = FWUtils.ReflectionUtils.GetEntityNameFromType(this.GetType().FullName, ClassPostFix);
            return _EntityName;
        }

        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public virtual object GetFieldValue(string fieldName)
        {
            return FWUtils.EntityUtils.GetObjectFieldValue(this, fieldName);
        }

        public virtual void SetFieldValue(string fieldName, object value)
        {
            FWUtils.EntityUtils.SetEntityFieldValue(null, fieldName, this, value);
        }

        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public abstract object GetPrimaryKeyValue();
    }
}
