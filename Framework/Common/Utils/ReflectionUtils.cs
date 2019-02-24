using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Simple methods to use .NET reflection
    /// </summary>
    public class ReflectionUtils
    {

        /// <summary>
        /// Creates the instance of a class using Reflection. It should be the class full name.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public object CreateInstance(string className)
        {
            Check.Require(string.IsNullOrEmpty(className) == false);
            try
            {
                Type typ = Type.GetType(className);
                Check.Ensure(typ != null, "Can not create instance for className" + className);
                return Activator.CreateInstance(typ);
            }
            catch (Exception exp)
            {
                throw new Exception("Reflection: Can't create class: " + className, exp);
            }

        }



        /// <summary>
        /// Creates the instance a class using Reflection.
        /// </summary>
        /// <param name="classNamespace">The class namespace.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public object CreateInstance(string classNamespace, string className, string assemblyName, params object[] args)
        {
            Check.Require(string.IsNullOrEmpty(classNamespace) == false);
            Check.Require(string.IsNullOrEmpty(className) == false);
            Check.Require(string.IsNullOrEmpty(assemblyName) == false);

            string classFullName = classNamespace + "." + className + "," + assemblyName;
            try
            {
                Type typ = Type.GetType(classFullName);
                Check.Ensure(typ != null, "Can not create class for " + classFullName);
                return Activator.CreateInstance(typ, args);
            }
            catch (Exception exp)
            {

                throw new Exception("Reflection: Can't create class: " + classFullName, exp);
            }
        }

        /// <summary>
        /// Gets EntityName from its typeName.
        /// As an example Company.Product.EntityObjects.Schema.EntityNameEN 
        /// </summary>
        /// <param name="typeFullName">type full name, can be obtained by this.GetType().FullName</param>
        /// <param name="postFix">postfix of type</param>
        /// <returns>Schema.EntityName</returns>
        public string GetEntityNameFromType(string typeFullName, string postFix)
        {
            if (postFix == null)
                postFix = "";
            
            Check.Require(string.IsNullOrEmpty(typeFullName) == false);

            if (string.IsNullOrEmpty(postFix) == false)
            {
                Check.Require(typeFullName.EndsWith(postFix));
                if (postFix.Length > 0)
                    typeFullName = typeFullName.Remove(typeFullName.Length - postFix.Length);
            }

            int lastDotIndex = typeFullName.LastIndexOf('.');
            Check.Ensure(lastDotIndex != -1);
            int secondLastDotIndex = typeFullName.LastIndexOf('.', lastDotIndex - 1);
            Check.Ensure(secondLastDotIndex > 0);
            
            if (FWUtils.ConfigUtils.GetAppSettings().Project.UseSchemaWithEntityName)
                return typeFullName.Substring(secondLastDotIndex + 1, typeFullName.Length - secondLastDotIndex -1);
            else
                return typeFullName.Substring(lastDotIndex + 1, typeFullName.Length - lastDotIndex - 1);
        }

        /// <summary>
        /// Clones the by first constructor.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object CloneByFirstConstructor(Type type)
        {
            ConstructorInfo[] ctors = type.GetConstructors();
            ConstructorInfo selectedCtor = ctors[0];
            if (ctors.Length > 1)
            {
                foreach (ConstructorInfo c in ctors)
                    if (c.GetParameters().Length == 0)
                    {
                        selectedCtor = c;
                        break;
                    }
            }
            // invoke the first public constructor with no parameters.
            var obj = selectedCtor.Invoke(new object[] { });
            return obj;
        }


    }

}
