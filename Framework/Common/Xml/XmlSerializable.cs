using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Framework.Common.Xml
{
    /// <summary>
    /// The base class for xml serializable classes. It allows the object to be serialized in XML, and deserialized from XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlSerializable<T>
        where T : class
    {
        /// <summary>
        /// To the XML.
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream m = new MemoryStream())
            {
                serializer.Serialize(m, this);
                System.Text.UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(m.ToArray(), 0, (int)m.Length);
            }
        }

        /// <summary>
        /// To the XML file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void ToXmlFile(string filename)
        {
            System.IO.File.WriteAllText(filename, ToXml());
        }

        /// <summary>
        /// Froms the XML.
        /// </summary>
        /// <param name="xmlstring">The xmlstring.</param>
        /// <returns></returns>
        public static T FromXml(string xmlstring)
        {
            if (string.IsNullOrEmpty(xmlstring) == false)
                return null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream m = new MemoryStream())
            {
                System.Text.UTF8Encoding utf = new UTF8Encoding();

                m.Write(utf.GetBytes(xmlstring), 0, utf.GetByteCount(xmlstring));
                m.Flush();
                m.Seek(0, SeekOrigin.Begin);

                return (T)serializer.Deserialize(m);
            }
        }

        /// <summary>
        /// Froms the XML file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static T FromXmlFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }

}