using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class RandomUtils
    {
        // copied from http://stackoverflow.com/questions/1122483/c-sharp-random-string-generator
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden

        
        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public string RandomString(int length)
        {
            return RandomString(length, "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }


        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="chars">The chars.</param>
        /// <returns></returns>
        public string RandomString(int length, string chars)
        {
            if (chars == null)
                chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[random.Next(chars.Length)]);

            return builder.ToString();
        }

        /// <summary>
        /// Randoms the maximum length of the string.
        /// </summary>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="chars">The chars.</param>
        /// <returns></returns>
        public string RandomStringMaxLength(int maxLength, string chars)
        {
            int len = RandomNumber(1, maxLength);
            return RandomString(len, chars);
        }


        /// <summary>
        /// Randoms the number.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }


        /// <summary>
        /// Randoms a double number between 0 and 1
        /// </summary>
        /// <returns></returns>
        public double RandomDouble()
        {
            return random.NextDouble();
        }


        /// <summary>
        /// Randoms the email.
        /// </summary>
        /// <returns></returns>
        public string RandomEmail()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            string uName = RandomString(20, chars);
            string domainName = RandomString(20, chars);
            string www = RandomString(3, chars);
            return uName + "@" + domainName + "." + www;
        }


        /// <summary>
        /// Randoms the phone number.
        /// </summary>
        /// <returns></returns>
        public string RandomPhoneNumber()
        {
            string chars = "1234567890";
            return "+1" + RandomString(14, chars);
        }


        /// <summary>
        /// Randoms the name of the user.
        /// </summary>
        /// <returns></returns>
        public string RandomUserName()
        {
            //return "a" + RandomString(49);// invalid userName
            return "User" + RandomString(40, "0123456789");
        }


        /// <summary>
        /// Generates a random long number between min and max
        /// </summary>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>a random long number</returns>
        public long LongBetween(long maxValue, long minValue)
        {
            //http://thinketg.com/how-to-generate-better-random-numbers-in-c-net-2/
            return (long)Math.Round(random.NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        /// <summary>
        /// Randoms the date time between.
        /// </summary>
        /// <param name="minDate">The minimum datetime.</param>
        /// <param name="maxDate">The maximum datetime.</param>
        /// <returns></returns>
        public DateTime RandomDateTimeBetween(DateTime minDate, DateTime maxDate)
        {
            //http://stackoverflow.com/questions/18320833/genaerating-random-datetime-between-a-given-datetime-range-c-sharp
            long randTicks = LongBetween(0, maxDate.Ticks - minDate.Ticks);
            DateTime dtRand = minDate.AddTicks(randTicks);
            return dtRand;
        }


    }
}
