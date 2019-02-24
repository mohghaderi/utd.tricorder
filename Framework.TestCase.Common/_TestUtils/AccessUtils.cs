using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.TestCase.CommonClasses
{
    public class AccessUtils
    {

        //http://stackoverflow.com/questions/934930/can-i-change-a-private-readonly-field-in-c-sharp-using-reflection

        public void SetPrivateFieldValue(object obj, string pName, object value)
        {
            obj.GetType()
           .GetField(pName, BindingFlags.Instance | BindingFlags.NonPublic)
           .SetValue(obj, value);
        }

        public void SetPrivatePropertyValue(object obj, string pName, object value, object[] index)
        {
            obj.GetType()
           .GetProperty(pName, BindingFlags.Instance | BindingFlags.NonPublic)
           .SetValue(obj, value, index);
        }

        public void SetPrivateStaticField(Type t, string pName, object value)
        {
            t
           .GetField(pName, BindingFlags.Static | BindingFlags.NonPublic)
           .SetValue(null, value);
        }

        public void SetPrivateStaticPropertyValue(Type t, string pName, object value, object[] index)
        {
            t
           .GetProperty(pName, BindingFlags.Static | BindingFlags.NonPublic)
           .SetValue(null, value, index);
        }


        //http://www.codeproject.com/Articles/9715/How-to-Test-Private-and-Protected-methods-in-NET


        public object RunStaticMethod(System.Type t, string strMethod, object[] aobjParams)
        {
            BindingFlags eFlags =
             BindingFlags.Static | BindingFlags.Public |
             BindingFlags.NonPublic;
            return RunMethod(t, strMethod,
             null, aobjParams, eFlags);
        } //end of method


        public object RunInstanceMethod(System.Type t, string strMethod, object objInstance, object[] aobjParams)
        {
            BindingFlags eFlags = BindingFlags.Instance | BindingFlags.Public |
             BindingFlags.NonPublic;
            return RunMethod(t, strMethod,
             objInstance, aobjParams, eFlags);
        } //end of method


        private object RunMethod(System.Type t, string strMethod, object objInstance, object[] aobjParams, BindingFlags eFlags)
        {
            MethodInfo m;
            try
            {
                m = t.GetMethod(strMethod, eFlags);
                if (m == null)
                {
                    throw new ArgumentException("There is no method '" +
                     strMethod + "' for type '" + t.ToString() + "'.");
                }

                object objRet = m.Invoke(objInstance, aobjParams);
                return objRet;
            }
            catch
            {
                throw;
            }
        } //end of method



    }
}
