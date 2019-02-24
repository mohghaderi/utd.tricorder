using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common
{
    public class PhoneNumberUtils
    {
        /// <summary>
        /// make a searchable phone number based on the format that is stored in the database
        /// </summary>
        /// <param name="phoneNumber">Phone Number</param>
        /// <returns>searchable phone number</returns>
        public static string MakeSearchablePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            StringBuilder searchableNumber = new StringBuilder();

            char[] chars = phoneNumber.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (Char.IsLetterOrDigit(chars[i])) // we do accept letters for special phone numbers like 1-800-AllState
                {
                    searchableNumber.Append(Char.ToLower(chars[i]));
                }
            }

            return searchableNumber.ToString();
            
        }

    }
}
