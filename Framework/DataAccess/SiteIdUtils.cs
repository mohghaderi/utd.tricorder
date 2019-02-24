using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;

namespace Framework.DataAccess
{
    public static class SiteIdUtils
    {
        public static void ComputeValuesOnce()
        {
            if (BaseNumberInt32 == -1)
            {
                var settings = FWUtils.ConfigUtils.GetAppSettings();
                int numberOfDigits = settings.Project.ServerPrefixDigitsForIDGenerator;
                BaseNumberInt32 = ConvertServerNumberToInt32Suffix(FWUtils.ConfigUtils.ServerNodeID, numberOfDigits);
                EndNumberInt32 = FindEndNumberInt32(BaseNumberInt32, numberOfDigits);

                BaseNumberInt64 = ConvertServerNumberToInt64Suffix(FWUtils.ConfigUtils.ServerNodeID, numberOfDigits);
                EndNumberInt64 = FindEndNumberInt64(BaseNumberInt64, numberOfDigits);


                Check.Ensure(BaseNumberInt32 != -1);
                Check.Ensure(EndNumberInt32 != -1);
                Check.Ensure(EndNumberInt32 - BaseNumberInt32 > 1000);

                Check.Ensure(BaseNumberInt64 != -1);
                Check.Ensure(EndNumberInt64 != -1);
                Check.Ensure(EndNumberInt64 - BaseNumberInt64 > 100000000);

            }
        }


        public static int BaseNumberInt32 = -1;
        public static int EndNumberInt32 = -1;

        public static long BaseNumberInt64 = -1;
        public static long EndNumberInt64 = -1;


        /// <summary>
        /// Converts the server number to int64 suffix.
        /// </summary>
        /// <param name="serverNumber">The server number.</param>
        /// <param name="numberOfSuffixDigits">The number of suffix digits.</param>
        /// <returns></returns>
        public static long ConvertServerNumberToInt64Suffix(int serverNumber, int numberOfSuffixDigits)
        {
            // Max Long = 9,223,372,036,854,775,808

            string maxInt64 = "9223372036854775808"; // 9,223,372,036,854,775,808

            int maxServerNumber = Convert.ToInt32(maxInt64.Substring(0, numberOfSuffixDigits)) - 1;

            Check.Require(serverNumber > 0 && serverNumber < maxServerNumber, "ServerNumber in config should be between 0 and " + maxServerNumber.ToString());
            Check.Require(maxInt64.Length - numberOfSuffixDigits > 3); // minimum 1,000 number for entities

            // allocating last digits
            long result = serverNumber * Convert.ToInt64(Math.Pow(10, maxInt64.Length - numberOfSuffixDigits));
            return result;
        }

        /// <summary>
        /// Converts the server number to int32 suffix.
        /// </summary>
        /// <param name="serverNumber">The server number.</param>
        /// <param name="numberOfSuffixDigits">The number of suffix digits.</param>
        /// <returns></returns>
        public static int ConvertServerNumberToInt32Suffix(int serverNumber, int numberOfSuffixDigits)
        {
            const string maxInt32 = "2147483648"; // 2,147,483,648

            int maxServerNumber = Convert.ToInt32(maxInt32.Substring(0, numberOfSuffixDigits)) - 1;

            Check.Require(serverNumber > 0 && serverNumber < maxServerNumber, "ServerNumber in config should be between 0 and " + maxServerNumber.ToString());
            Check.Require(maxInt32.Length - numberOfSuffixDigits > 3); // minimum 1,000 number for entities

            // allocating last digits
            int result = serverNumber * Convert.ToInt32(Math.Pow(10, maxInt32.Length - numberOfSuffixDigits));
            return result;
        }






        /// <summary>
        /// Finds the end number int32.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="numberOfSuffixDigits">The number of suffix digits.</param>
        /// <returns></returns>
        public static int FindEndNumberInt32(int baseNumber, int numberOfSuffixDigits)
        {
            const string maxInt32 = "2147483648"; // 2,147,483,648
            int endNumber = baseNumber + Convert.ToInt32(new String('9', maxInt32.Length - numberOfSuffixDigits));
            return endNumber;
        }

        /// <summary>
        /// Finds the end number int64.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="numberOfSuffixDigits">The number of suffix digits.</param>
        /// <returns></returns>
        public static long FindEndNumberInt64(long baseNumber, int numberOfSuffixDigits)
        {
            string maxInt64 = "9223372036854775808"; // 9,223,372,036,854,775,808
            long endNumber = baseNumber + Convert.ToInt64(new String('9', maxInt64.Length - numberOfSuffixDigits));
            return endNumber;
        }

    }
}
