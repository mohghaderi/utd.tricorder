using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.Cache
{
    public class SimpleObjectCacheManagement<T>
    {
        private Dictionary<string, object> cacheDic = new Dictionary<string,object>();

        public delegate object CreateDelegate(object parameters);

        private static object lockObject = new object();

        public T GetOrCreate(string cacheKey, CreateDelegate createFunction, object parameters)
        {
            lock (lockObject)
            {
                if (cacheDic.ContainsKey(cacheKey))
                    return (T)cacheDic[cacheKey];
                else
                {
                    object o = createFunction(parameters); 
                    if (cacheDic.ContainsKey(cacheKey) == false) // Create function may use this caching technique to cache its object. It causes test cases to fail. That's why we need to check it again here.
                        cacheDic.Add(cacheKey, o);
                    return (T)o;
                }
            }
        }


    }
}
