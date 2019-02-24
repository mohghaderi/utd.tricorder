using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property


    /// <summary>
    /// Utilities to create and parse comma separated values
    /// </summary>
    public class CommaSeperatedUtils
    {

        /// <summary>
        /// Finds the first element in IEnumerator.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public object FindFirstElementInIEnumerator(IEnumerable source)
        {
            Check.Require(source != null);

            IEnumerator iterator = source.GetEnumerator();
            if (!iterator.MoveNext())
            {
                return null;
            }
            return iterator.Current;
        }



        /// <summary>
        /// Convers to comma seperated string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="quoteChar">The quote char.</param>
        /// <returns></returns>
        public string ConverToCommaSeperatedString(IEnumerable list, bool autoQuote)
        {
            if (list == null)
                return "";

            StringBuilder sb = new StringBuilder();

            string quoteChar = "";
            if (autoQuote == true)
                quoteChar = FWUtils.DBTypeUtils.GetQuoteCharForObject(FindFirstElementInIEnumerator(list));

            foreach (object obj in list)
                sb.Append(quoteChar).Append(obj.ToString()).Append(quoteChar).Append(",");

            if (sb.Length > 0)
                sb = sb.Remove(sb.Length - 1, 1);

            return sb.ToString();

        }


        /// <summary>
        /// Convers to comma seperated string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="quoteChar">The quote char.</param>
        /// <returns></returns>
        public string ConverToCommaSeperatedString(IEnumerable list, bool autoQuote, string fieldName)
        {
            Check.Require(string.IsNullOrEmpty(fieldName) == false);

            if (list == null)
                return "";

            StringBuilder sb = new StringBuilder();

            string quoteChar = "";
            if (autoQuote == true)
            {
                object obj = FindFirstElementInIEnumerator(list);
                if (obj != null)
                    obj = FWUtils.EntityUtils.GetObjectFieldValueString(obj, fieldName);
                quoteChar = FWUtils.DBTypeUtils.GetQuoteCharForObject(obj);
            }

            foreach (object obj in list)
                sb.Append(quoteChar).Append(FWUtils.EntityUtils.GetObjectFieldValueString(obj, fieldName)).Append(quoteChar).Append(",");

            if (sb.Length > 0)
                sb = sb.Remove(sb.Length - 1, 1);

            return sb.ToString();

        }


    }
}
