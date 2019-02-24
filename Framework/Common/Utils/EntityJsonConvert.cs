using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    /// <summary>
    /// To deserialize json string for framework interfaces
    /// </summary>
    internal class InterfaceJsonConvert : Newtonsoft.Json.JsonConverter
    {

        //http://stackoverflow.com/questions/5780888/casting-interfaces-for-deserialization-in-json-net

        private static readonly string IFilter_FULLNAME = typeof(IFilter).FullName;
        private static readonly string IFilterList_FULLNAME = typeof(IList<IFilter>).FullName;
        private static readonly string IFilterCollection_FULLNAME = typeof(ICollection<IFilter>).FullName;

        public override bool CanConvert(Type objectType)
        {
            if (objectType.FullName == IFilter_FULLNAME
                || objectType.FullName == IFilterList_FULLNAME
                || objectType.FullName == IFilterCollection_FULLNAME
                )
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (objectType.FullName == IFilter_FULLNAME)
                return serializer.Deserialize(reader, typeof(Filter));
            if (objectType.FullName == IFilterList_FULLNAME)
                return serializer.Deserialize(reader, typeof(List<IFilter>));
            if (objectType.FullName == IFilterCollection_FULLNAME)
                return serializer.Deserialize(reader, typeof(List<IFilter>));

            throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
