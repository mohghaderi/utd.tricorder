using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common.Exceptions;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Database type conversion utilities
    /// </summary>
    public class DBTypeUtils
    {

        /// <summary>
        /// Gets the quote char for object.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        internal string GetQuoteCharForObject(object obj)
        {
            if (obj == null)
                return "";

            if (obj is string || obj is Guid)
                return "'";
            else
                return "";
        }



        /// <summary>
        /// Gets the type of the DB data type from dot net.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public DBDataType GetDBDataTypeFromDotNetType(Type t)
        {
            Check.Require(t != null);

            if (t == typeof(string))
                return DBDataType.String;
            else if (t == typeof(int))
                return DBDataType.Int32;
            else if (t == typeof(long))
                return DBDataType.Int64;
            else if (t == typeof(Guid))
                return DBDataType.Guid;
            else if (t == typeof(char))
                return DBDataType.Char;
            else if (t == typeof(bool))
                return DBDataType.Boolean;
            else if (t == typeof(float))
                return DBDataType.Float;
            else if (t == typeof(double))
                return DBDataType.Double;
            else if (t == typeof(byte[]))
                return DBDataType.Binary;
            else if (t == typeof(DateTime))
                return DBDataType.DateTime;
            else
                throw new NotImplementedException();
        }



        /// <summary>
        /// Gets dot net type from db type.
        /// </summary>
        /// <param name="databaseType">database type</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Type GetDotNetTypeFromDbType(DBDataType databaseType)
        {
            //Check.Require(databaseType != null);     struct can't be null

            switch (databaseType)
            {
                case DBDataType.Boolean:
                    return typeof(bool);
                case DBDataType.Char:
                    return typeof(char);
                case DBDataType.String:
                    return typeof(string);
                case DBDataType.Guid:
                    return typeof(Guid);
                case DBDataType.Int32:
                    return typeof(int);
                case DBDataType.Int64:
                    return typeof(long);
                case DBDataType.Binary:
                    return typeof(byte[]);
                case DBDataType.Double:
                    return typeof(double);
                case DBDataType.Float:
                    return typeof(float);
                case DBDataType.Date:
                    return typeof(DateTime);
                case DBDataType.DateTime:
                    return typeof(DateTime);
                case DBDataType.None:
                    return typeof(object);
                default:
                    throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Gets typed data value from db type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dbType">database type.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="Framework.Common.FWException"></exception>
        public object GetTypedDataValueFromDbType(object value, DBDataType dbType)
        {
            Check.Require(value != null);

            switch (dbType)
            {
                case DBDataType.Boolean:
                    return Convert.ToBoolean(value);
                case DBDataType.Char:
                    return Convert.ToChar(value);
                case DBDataType.String:
                    return value.ToString();
                case DBDataType.Guid:
                    if (value is Guid)
                        return value;
                    else if (value is byte[])
                    {
                        return new Guid((byte[])(value));
                    }
                    else
                        return new Guid(value.ToString());
                case DBDataType.Int32:
                    return Convert.ToInt32(value);
                case DBDataType.Int64:
                    return Convert.ToInt64(value);
                case DBDataType.Binary:
                    return value;
                case DBDataType.Double:
                    return Convert.ToDouble(value);
                case DBDataType.Float:
                    return Convert.ToSingle(value);
                case DBDataType.DateTime:
                    return Convert.ToDateTime(value);
                case DBDataType.Date:
                    return Convert.ToDateTime(value).Date;
                default:
                    throw new NotImplementedException();
            }

        }





    }
}
