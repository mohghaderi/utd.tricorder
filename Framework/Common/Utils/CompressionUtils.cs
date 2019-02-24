using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Framework.Common.Utils
{
    public class CompressionUtils
    {
        public byte[] SerializeAndCompress(object obj)
        {

            //using (MemoryStream ms = new MemoryStream())
            MemoryStream ms = new MemoryStream();
            {
                using (GZipStream zs = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(zs, obj);
                }
                return ms.ToArray();
            }
        }
        public object DecompressAndDeserialze(byte[] data)
        {

            //using (MemoryStream ms = new MemoryStream(data))
            MemoryStream ms = new MemoryStream(data);
            {
                using (GZipStream zs = new GZipStream(ms, CompressionMode.Decompress, true))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return bf.Deserialize(zs);
                }
            }
        }

    }
}
