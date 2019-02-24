using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    /// <summary>
    /// translable text
    /// </summary>
    public class i18nText
    {
        private Dictionary<string, IFWStringTextTranObj> Translations = new Dictionary<string, IFWStringTextTranObj>();

        ///// <summary>
        ///// constructor for i18ntext that makes a translable text class
        ///// </summary>
        ///// <param name="nameSpace">name space of the text</param>
        ///// <param name="keyName">key name</param>
        ///// <param name="value">value of the text (that is the string)</param>
        //public i18nText(string nameSpace, string keyName, string value)
        //{
        //    string keyFullName = nameSpace + "." + keyName;
        //    _StringTextID = FWUtils.MiscUtils.GenerateGuidIDByString(keyFullName).Value;
        //    _KeyFullName = keyFullName;
        //    _Value = value;
        //    _NumberOfArguments = (byte) value.Count(f => f == '{');
        //}

        /// <summary>
        /// constructor for i18ntext that makes a translable text class
        /// </summary>
        /// <param name="keyFullName">key full name like FW.Exceptions.NotNull</param>
        /// <param name="value">string value for default culture en-US</param>
        public i18nText(string keyFullName, string value)
        {
            _StringTextID = FWUtils.MiscUtils.GenerateGuidIDByString(keyFullName).Value;
            _KeyFullName = keyFullName;
            _Value = value;
            _NumberOfArguments = (byte)value.Count(f => f == '{');
        }

        public static i18nText Create(string keyFullName, string value)
        {
            var s = FWUtils.MiscUtils.GenerateGuidIDByString(keyFullName).Value;
            if (i18nLib.dic.ContainsKey(s))
                return i18nLib.dic[s];
            else
                return new i18nText(keyFullName, value);
        }

        private Guid _StringTextID;
        private string _KeyFullName;
        private string _Value;
        private byte _NumberOfArguments;

        /// <summary>
        /// Gets the string text identifier.
        /// </summary>
        /// <value>
        /// The string text identifier.
        /// </value>
        public Guid StringTextID { get { return _StringTextID; } }
        /// <summary>
        /// Gets the full name of the key.
        /// </summary>
        /// <value>
        /// The full name of the key.
        /// </value>
        public string KeyFullName { get { return _KeyFullName; } }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get { return _Value; } }
        /// <summary>
        /// Gets the number of arguments.
        /// </summary>
        /// <value>
        /// The number of arguments.
        /// </value>
        public byte NumberOfArguments { get { return _NumberOfArguments; } }

        public static implicit operator string(i18nText d)
        {
            try
            {
                i18nLib.Add(d); // adding to library for sync and getting translations
            }
            catch (Exception)
            {
            }

            return d.GetTranslation(FWUtils.SecurityUtils.GetCultureInfo().Name);
        }


        public override string ToString()
        {
            try
            {
                i18nLib.Add(this); // adding to library for sync and getting translations
            }
            catch (Exception)
            {
            }

            return this.GetTranslation(FWUtils.SecurityUtils.GetCultureInfo().Name);
        }

        /// <summary>
        /// sets a translation for a culture
        /// </summary>
        public void SetTranslation(IFWStringTextTranObj tran)
        {
            string cultureName = tran.CultureName;
            if (Translations.ContainsKey(cultureName) == false)
                Translations.Add(cultureName, tran);
        }

        /// <summary>
        /// Gets translation of the text based on the culture name
        /// </summary>
        /// <param name="cultureName">culture name</param>
        /// <returns></returns>
        public string GetTranslation(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
            {
                if (string.IsNullOrEmpty(this.Value))
                    return this.KeyFullName;
                else
                    return this.Value;
            }

            if (Translations.ContainsKey(cultureName))
                return Translations[cultureName].TranValue;
            else
                return GetTranslation(GetClosestCulture(cultureName));
        }

        /// <summary>
        /// gets closest culturename to a culture by removing the last part
        /// For example, it converts en-us-1293 to en-us
        /// and en-us to en
        /// and en to null
        /// </summary>
        /// <param name="cultureName">culture name</param>
        /// <returns></returns>
        public static string GetClosestCulture(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
                return null;

            var i = cultureName.LastIndexOf('-');
            if (i > 0)
                return cultureName.Substring(0, i);
            else
                return null;
        }

        /// <summary>
        /// Gets closest supported culture name in the list of provided cultures
        /// culturename and culture names list should be all lower case
        /// </summary>
        /// <param name="cultureNameLowerCase">culture names</param>
        /// <param name="supportedLocalesLowerCases"></param>
        /// <returns></returns>
        public static string GetClosestSupportedCulture(string cultureNameLowerCase, List<string> supportedLocalesLowerCases)
        {
            if (supportedLocalesLowerCases == null)
                return null;
            if (string.IsNullOrEmpty(cultureNameLowerCase))
                return null;

            if (supportedLocalesLowerCases.Contains(cultureNameLowerCase))
                return cultureNameLowerCase;
            else
                return GetClosestSupportedCulture(GetClosestCulture(cultureNameLowerCase), supportedLocalesLowerCases);
        }



    }
}
