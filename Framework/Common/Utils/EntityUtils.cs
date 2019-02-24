using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Utilities to do get value or set value in entity objects
    /// </summary>
    public class EntityUtils
    {
        /// <summary>
        /// Exculdes defined properties form the JSON object to prevent from serialization
        /// It is used in serialize function only
        /// </summary>
        class JsonExcludingPropertiesResolver : DefaultContractResolver
        {
            private List<string> _ExcludingProperties;

            public JsonExcludingPropertiesResolver(List<string> excludingProperties)
            {
                _ExcludingProperties = excludingProperties;
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                if (_ExcludingProperties == null || _ExcludingProperties.Count == 0)
                {
                    return base.CreateProperties(type, memberSerialization);
                }
                else
                {
                    IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
                    List<JsonProperty> results = new List<JsonProperty>();
                    foreach (var p in props)
                    {
                        if (_ExcludingProperties.Contains(p.PropertyName) == false)
                            results.Add(p);
                    }
                    return results;
                }
            }

            public IList<JsonProperty> finallist { get; set; }
        }


        /// <summary>
        /// Gets the name of the entity field type. 
        /// If it is nullable, it returns the inner type
        /// For example, return value for int?  is  int
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public Type GetObjectFieldType(object obj, string fieldName)
        {
            var property = obj.GetType().GetProperty(fieldName);
            if (property == null)
                throw new FWPropertyNotFoundException(fieldName, obj);
            Type propertyType = property.PropertyType;

            FixPropertyTypeIfNullable(ref propertyType, false);
            return propertyType;
        }


        /// <summary>
        /// Gets the entity field value string.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="dataTransferObject">The data transfer object.</param>
        /// <returns></returns>
        public string GetEntityFieldValueString(object dataTransferObject, string fieldName, EntityInfoBase entity)
        {
            // we defined the separate function to support CustomFields later in the framework
            return GetObjectFieldValueString(dataTransferObject, fieldName);
        }

        /// <summary>
        /// Gets the object field value string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public string GetObjectFieldValueString(object obj, string fieldName)
        {
            if (obj == null)
                return null;
            if (string.IsNullOrEmpty(fieldName))
                return null;

            var property = obj.GetType().GetProperty(fieldName);
            if (property == null)
                throw new FWPropertyNotFoundException(fieldName, obj);

            object value = property.GetValue(obj, null);
            if (value == null)
                return null;
            else
                return value.ToString();
        }

        /// <summary>
        /// Sets the object field value string.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="dataTransferObject">The data transfer object.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.Exception">Generic types are not acceptable for SetEntityFieldValueString</exception>
        /// <param name="ignoreIfPropertyNotExists">should not throw an exception if property was not available</param>
        public void SetObjectFieldValueString(string fieldName, object dataTransferObject, string value)
        {
            if (dataTransferObject == null)
                return;
            if (string.IsNullOrEmpty(fieldName))
                return;

            var property = dataTransferObject.GetType().GetProperty(fieldName);
            if (property == null)
                throw new FWPropertyNotFoundException(fieldName, dataTransferObject);
            object objectValue = ConvertStringToObject(value, property.PropertyType);
            property.SetValue(dataTransferObject, objectValue, null);
        }



        /// <summary>
        /// Converts the type of the string value to object by.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Generic types are not acceptable for SetEntityFieldValueString</exception>
        public object ConvertStringToObject(string value, Type propertyType)
        {
            if (value == null)
                return null;

            // handles empty string. we don't want to convert empty string to null using this function
            if (value is string && propertyType == typeof(string))
                return value;

            object objectValue = null;

            if (string.IsNullOrEmpty(value) == false)
            {
                FixPropertyTypeIfNullable(ref propertyType, true);

                if (propertyType.IsPrimitive) // if it is C# primitive type
                    objectValue = ChangeValueType(value, propertyType);
                else if (propertyType.IsValueType && !propertyType.IsPrimitive) // means a struct
                {
                    if (propertyType == typeof(Guid) || propertyType == typeof(DateTime))
                        objectValue = ChangeValueType(value, propertyType);
                    else if (propertyType.IsEnum)
                        objectValue = Enum.Parse(propertyType, value);
                    else
                        objectValue = FWUtils.EntityUtils.JsonDeserializeObject(value, propertyType);
                }
                else if (propertyType.IsClass)
                {
                    objectValue = FWUtils.EntityUtils.JsonDeserializeObject(value, propertyType);
                }
                else // rest of the cases (this should never happen)
                    throw new ImpossibleExecutionException("ConvertStringToObject and unknown type:" + propertyType.ToString());
            }

            return objectValue;
        }

        /// <summary>
        /// Fixes the property type if nullable.
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="exceptionIfGeneric">if set to <c>true</c> [exception if generic].</param>
        /// <exception cref="System.Exception">Generic types are not acceptable for ConvertStringValueToObjectByType</exception>
        private void FixPropertyTypeIfNullable(ref Type propertyType, bool exceptionIfGeneric)
        {
            if (propertyType.IsGenericType)
            {
                if (propertyType.Name.StartsWith("Nullable"))
                {
                    propertyType = System.Nullable.GetUnderlyingType(propertyType);
                }
                else if (propertyType.Name.StartsWith("ICollection"))
                {
                    var underlyingType = propertyType.GetGenericArguments()[0];
                    if (underlyingType == typeof(string))
                        propertyType = typeof(List<string>);
                    if (underlyingType == typeof(IFilter))
                        propertyType = typeof(List<Filter>);
                }
                else
                    if (exceptionIfGeneric)
                        throw new Exception("Generic types are not acceptable for assigning or getting property values");
            }
        }

        /// <summary>
        /// Changes the type of the value.
        /// </summary>
        internal object ChangeValueType(object value, Type type)
        {
            if (value == null)
                return value;
            if (type == typeof(object)) // everything is an object. we can't change their type!
                return value;

            if (value is string && type == typeof(Guid))
                //if ((string)value != "")
                return new Guid((string)value);
            //else
            //    return null;
            else if (type == typeof(string))
            {
                return this.ConvertObjectToString(value);
            }
            else if (type == typeof(double) && value is string) // C# doesn't convert min value and max value correctly from string and reverse
            // read more here: http://msdn.microsoft.com/en-us/library/7yd1h1be(v=vs.110).aspx
            {
                if (((string)value) == "-1.79769313486232E+308")
                    return Double.MinValue;
                if ((string)value == "1.79769313486232E+308")
                    return Double.MaxValue;
                else
                    return Double.Parse((string)value);
            }
            else
                return Convert.ChangeType(value, type);
        }


        /// <summary>
        /// Sets the entity field value string.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="dataTransferObject">The data transfer object.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.Exception"></exception>
        public void SetEntityFieldValueString(EntityInfoBase entity, string fieldName, object dataTransferObject, string value)
        {
            SetObjectFieldValueString(fieldName, dataTransferObject, value);
        }


        /// <summary>
        /// Sets the object field value.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="obj">The data transfer object.</param>
        /// <param name="value">The value.</param>
        public void SetObjectFieldValue(string fieldName, object obj, object value)
        {
            if (obj == null)
                return;
            if (string.IsNullOrEmpty(fieldName))
                return;

            var property = obj.GetType().GetProperty(fieldName);
            if (property == null)
                throw new FWPropertyNotFoundException(fieldName, obj);
            Type propertyType = property.PropertyType;

            try
            {
                // if the value type was the same as the type we had, just set it!
                if (value != null && propertyType == value.GetType())
                {
                    property.SetValue(obj, value, null);
                    return;
                }

                // handle null and empty cases
                if (propertyType.IsGenericType && propertyType.Name.StartsWith("Nullable"))
                    if (value == null || (value is string && ((string)value == "")))
                    {
                        property.SetValue(obj, null, null);
                        return;
                    }

                // if it was not nullable then try to convert the value
                FixPropertyTypeIfNullable(ref propertyType, true);
                value = ChangeValueType(value, propertyType);

                property.SetValue(obj, value, null);
            }
            catch (FormatException ex) // in the case of format exception
            {
                throw new FWPropertySetValueException(fieldName,value, ex);
            }
        }


        /// <summary>
        /// Sets the entity field value string.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="dataTransferObject">The data transfer object.</param>
        /// <param name="value">The value.</param>
        public void SetEntityFieldValue(EntityInfoBase entity, string fieldName, object dataTransferObject, object value)
        {
            SetObjectFieldValue(fieldName, dataTransferObject, value);
        }


        ///// <summary>
        ///// Gets the entity field value.
        ///// </summary>
        ///// <param name="entity">The entity.</param>
        ///// <param name="fieldName">Name of the field.</param>
        ///// <param name="dataTransferObject">The data transfer object.</param>
        ///// <returns></returns>
        //public object GetEntityFieldValue(EntityInfoBase entity, string fieldName, object dataTransferObject)
        //{
        //    return GetObjectFieldValue(dataTransferObject, fieldName);
        //}


        /// <summary>
        /// Gets the object field value.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public object GetObjectFieldValue(object obj, string fieldName)
        {
            return GetObjectFieldValueIndex(obj, fieldName, null);
        }

        public object GetObjectFieldValueIndex(object obj, string fieldName, object[] index)
        {
            Check.Require(obj != null);
            Check.Require(string.IsNullOrEmpty(fieldName) == false);
            //if (dataTransferObject == null)
            //    return null;
            //if (string.IsNullOrEmpty(fieldName))
            //    return null;

            var property = obj.GetType().GetProperty(fieldName);
            if (property == null)
                throw new FWPropertyNotFoundException(fieldName, obj);

            object value = property.GetValue(obj, index);
            if (value == null)
                return null;
            else
                return value;
        }

        /// <summary>
        /// Objects the has property.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public bool ObjectHasProperty(object obj, string propertyName)
        {
            if (obj == null || string.IsNullOrEmpty(propertyName))
                return false;

            var prop = obj.GetType().GetProperty(propertyName);
            if (prop == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Invokes the object method.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="obj">The obj.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object InvokeObjectMethod(string methodName, object obj, object[] parameters)
        {
            Check.Require(obj != null);
            Check.Require(string.IsNullOrEmpty(methodName) == false);

            //if (obj == null)
            //    return null;

            object value = obj.GetType().GetMethod(methodName).Invoke(obj, parameters);
            if (value == null)
                return null;
            else
                return value;
        }


        /// <summary>
        /// Converts the object to string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public string ConvertObjectToString(object obj)
        {
            if (obj == null)
                return "";

            if (obj is string)
                return ((string)obj);

            if (obj is double)
                return ((double)obj).ToString("r");

            Type type = obj.GetType();
            if (type.IsPrimitive)
                return obj.ToString();

            // in the case of byte array and some other
            if (type.IsArray
                || (type.IsValueType && !type.IsPrimitive) // means a struct
                || type.IsClass
            )
                return JsonSerializeObject(obj, true);

            return obj.ToString();
        }


        /// <summary>
        /// Concats the strings.
        /// </summary>
        /// <param name="separator">separator</param>
        /// <param name="stringValues">The string values.</param>
        /// <returns></returns>
        public string ConcatStrings(string separator, params string[] stringValues)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stringValues.Length; i++)
            {
                sb.Append(stringValues[i]);
                if (i != stringValues.Length - 1)
                    sb.Append(separator);
            }
            return sb.ToString();
        }


        ///// <summary>
        ///// Serializes an object to JSON string
        ///// </summary>
        ///// <param name="obj">the object</param>
        ///// <returns></returns>
        //public string JsonSerializeObject(object obj)
        //{
        //    return JsonConvert.SerializeObject(obj);
        //}

        /// <summary>
        /// Serializes an object to JSON string
        /// </summary>
        /// <param name="obj">the object</param>
        /// <returns></returns>
        public string JsonSerializeObject(object obj, bool ignoreNullValues = false, List<string> excludingColumns = null, bool indentedFormatting = false)
        {
            var settings = new JsonSerializerSettings();
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc; // treat all times as UTC time
            if (ignoreNullValues)
                settings.NullValueHandling = NullValueHandling.Ignore;
            if (excludingColumns != null)
                settings.ContractResolver = new JsonExcludingPropertiesResolver(excludingColumns);
            if (indentedFormatting != false)
                settings.Formatting = Formatting.Indented;
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        /// Deserializes a json string to an object
        /// </summary>
        /// <param name="jsonString">json string</param>
        /// <param name="objectType">type of the object</param>
        /// <returns></returns>
        public object JsonDeserializeObject(string jsonString, Type objectType)
        {
            var settings = new JsonSerializerSettings();
            Check.Assert(string.IsNullOrEmpty(jsonString) == false, "jsonString should not be empty");
            Check.Assert(objectType != null, "objecttype should not be null.");
            return JsonConvert.DeserializeObject(jsonString, objectType, settings);
        }

        /// <summary>
        /// Checks Json is valid or not. If it's valid, it returns the deserialized value; otherwise, it returns null
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public object JsonIsValidThenDeserialize(string jsonString)
        {
            Check.Assert(string.IsNullOrEmpty(jsonString) == false, "jsonString should not be empty");

            try
            {
                return JsonConvert.DeserializeObject(jsonString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// deserializes a json string on a real object
        /// </summary>
        /// <param name="jsonString">json string</param>
        /// <param name="obj">the object that will be changed</param>
        /// <param name="onlyPropertyNamesList">this only replaces propertynames in this list and ignore others. Use null to set all properties in json</param>
        /// <param name="ignoreErrors">When the list is null, if a property not found, it will ignore it</param>
        public void JsonDeserializeOnObject(string jsonString, object obj, List<string> onlyPropertyNamesList = null, bool ignoreErrors = false)
        {
            Check.Assert(string.IsNullOrEmpty(jsonString) == false, "jsonString should not be empty");
            Check.Assert(obj != null, "object should not be null");

            var settings = new JsonSerializerSettings();
            settings.Converters.Clear();
            Newtonsoft.Json.Linq.JObject o = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonString, settings);

            foreach (var p in o.Properties())
            {
                try
                {
                    string fieldName = p.Name;
                    if (onlyPropertyNamesList != null)
                        if (onlyPropertyNamesList.Contains(fieldName) == false)
                            continue; // if it was not in the list just skip it

                    Newtonsoft.Json.Linq.JToken jValue = p.Value;
                    object value = null;
                    if (jValue != null && jValue.Type != Newtonsoft.Json.Linq.JTokenType.Null)
                        value = jValue.ToObject(this.GetObjectFieldType(obj, fieldName));

                    this.SetObjectFieldValue(fieldName, obj, value);

                }
                catch (FormatException ex)
                {
                    throw new FWPropertySetValueException(p.Name, p.Value, ex);
                }
                catch (FWPropertyNotFoundException)
                {
                    if (ignoreErrors == false)
                        throw;
                }

                //try
                //{
                //}
                //catch (FWPropertyNotFoundException)
                //{
                //    // ignoring the properties that are not available
                //}
            }

        }

    }

}
