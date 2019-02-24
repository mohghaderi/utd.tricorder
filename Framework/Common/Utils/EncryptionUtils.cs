using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Common.Utils
{
    public class EncryptionUtils
    {
        /// <summary>
        /// Encrypts a string data based on UTF8 encoding
        /// </summary>
        /// <param name="data">data utf-8</param>
        /// <param name="key">encryption key</param>
        /// <returns></returns>
        public string EncryptString(string data, string key)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), key));
        }

        /// <summary>
        /// decrypts base 64 string and
        /// </summary>
        /// <param name="dataBase64">data base64</param>
        /// <param name="key">key</param>
        /// <returns>utf-8 encoding</returns>
        public string DecryptString(string dataBase64, string key)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(dataBase64), key));
        }

        public byte[] Encrypt(byte[] data, string key)
        {
            using (var encryptor = GetSymmetricAlgorithm(key))
            {
                return Encrypt(data, encryptor);
            }
        }

        public byte[] Decrypt(byte[] data, string key)
        {
            using (var encryptor = GetSymmetricAlgorithm(key))
            {
                return Decrypt(data, encryptor);
            }
        }

        private SymmetricAlgorithm GetSymmetricAlgorithm(string key)
        {
            byte[] keyBytes = ConvertStringKeyToBytes(key);
            var crypto = new AesCryptoServiceProvider()
            {
                Key = keyBytes,
                IV = _IV16
            };

            return crypto;
        }


        //http://stackoverflow.com/questions/13986877/decryptbytesfrombytes-aes-c-sharp

        public static Byte[] Encrypt(Byte[] input, SymmetricAlgorithm crypto)
        {
            return Transform(crypto.CreateEncryptor(), input, crypto.BlockSize);
        }

        public static Byte[] Decrypt(Byte[] input, SymmetricAlgorithm crypto)
        {
            return Transform(crypto.CreateDecryptor(), input, crypto.BlockSize);
        }

        private static Byte[] Transform(ICryptoTransform cryptoTransform, Byte[] input, Int32 blockSize)
        {
            if (input.Length > blockSize)
            {
                Byte[] ret1 = new Byte[((input.Length - 1) / blockSize) * blockSize];

                Int32 inputPos = 0;
                Int32 ret1Length = 0;
                for (inputPos = 0; inputPos < input.Length - blockSize; inputPos += blockSize)
                {
                    ret1Length += cryptoTransform.TransformBlock(input, inputPos, blockSize, ret1, ret1Length);
                }

                Byte[] ret2 = cryptoTransform.TransformFinalBlock(input, inputPos, input.Length - inputPos);

                Byte[] ret = new Byte[ret1Length + ret2.Length];
                Array.Copy(ret1, 0, ret, 0, ret1Length);
                Array.Copy(ret2, 0, ret, ret1Length, ret2.Length);
                return ret;
            }
            else
            {
                return cryptoTransform.TransformFinalBlock(input, 0, input.Length);
            }

        }

        public static readonly byte[] _IV8 = new byte[] { 240, 32, 45, 29, 0, 76, 173, 59 };
        public static readonly byte[] _IV16 = new byte[] { 240, 32, 45, 29, 0, 76, 173, 59, 45, 35, 74, 23, 7, 34, 120, 45 };
        public static readonly byte[] _IV32 = new byte[] { 240, 32, 45, 29, 0, 76, 173, 240, 32, 45, 29, 0, 76, 173, 59, 45, 35, 74, 23, 7, 34, 120, 45, 59, 45, 35, 74, 23, 7, 34, 120, 45 };

        //private byte[] GetIV(int size)
        //{
        //    if (size == 8)
        //        return _IV8;
        //    if (size == 16)
        //        return _IV16;
        //    if (size == 32)
        //        return _IV32;
        //    throw new Exception("Encryption intial vector size is not valid");
        //}

        public static byte[] ConvertStringKeyToBytes(string userKey)
        {
            Check.Require(string.IsNullOrEmpty(userKey) == false);

            const string randomKey = "*@&#@38&WJ"; // adding some randomization to encryption text keys
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] newkey = sha256.ComputeHash(Encoding.Unicode.GetBytes(randomKey + userKey));
            return newkey;
        }




    }
}
