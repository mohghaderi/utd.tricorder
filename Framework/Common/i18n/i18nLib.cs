using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public static class i18nLib
    {
        public static ConcurrentDictionary<Guid, i18nText> dic = new ConcurrentDictionary<Guid, i18nText>();
        private static int ExpirationDicDateTimeEpoch = 0;

        public static void Add(i18nText item)
        {
            Check.Require(dic != null, "InitAlli18nTexts should must be called before adding translations");

            Check.Require(item != null, "item argument should not be null");
            if (dic.ContainsKey(item.StringTextID) == false)
            {
                dic.TryAdd(item.StringTextID, item);
                AddItemToDatabase(item);
                AssignTranslations(item);
            }

            // for debug purposes, we refresh the whole translations on local host 
            // to test views without resta
            if (FWUtils.WebUIUtils.IsLocalHost() == true)
            {
                LoadAllTranslations(true);
                AssignTranslations(item);
            }
        }

        public static IList<IFWStringTextTranObj> allTranslations = null;

        private static object lockAllTran = new object();

        /// <summary>
        /// adds a text item to database for translation
        /// </summary>
        /// <param name="item">item</param>
        private static void AddItemToDatabase(i18nText item)
        {
            IFWStringTextService service = (IFWStringTextService)EntityFactory.GetEntityServiceByName("StringText", "");
            service.AddItemToDatabase(item);
        }


        /// <summary>
        /// Intializes all i18nTexts and assigns their translations
        /// from the database
        /// </summary>
        public static void InitAlli18nTexts()
        {
            IFWStringTextService service = (IFWStringTextService)EntityFactory.GetEntityServiceByName("StringText", "");
            dic = service.GetAlli18nText();
            LoadAllTranslations();
            foreach (var item in allTranslations)
            {
                if (dic.ContainsKey(item.StringTextID))
                {
                    dic[item.StringTextID].SetTranslation(item);
                }
            }
        }

        /// <summary>
        /// gets all translations and assign translation to a text
        /// so that it can show the right translation to the users
        /// </summary>
        /// <param name="item">item</param>
        private static void AssignTranslations(i18nText item)
        {
            Check.Require(allTranslations != null, "InitAlli18nTexts should must be called before assigning translations");

            foreach (var tran in allTranslations)
            {
                if (tran.StringTextID == item.StringTextID)
                    item.SetTranslation(tran);
            }
            
        }

        private static void LoadAllTranslations(bool forceLoad = false)
        {
            if (allTranslations == null || forceLoad == true || ExpirationDicDateTimeEpoch < DateTimeEpoch.GetUtcNowEpoch())
            {
                lock (lockAllTran)
                {
                    if (allTranslations == null || forceLoad == true || ExpirationDicDateTimeEpoch < DateTimeEpoch.GetUtcNowEpoch())
                    {
                        // Gets all tranlsations from the database, and fill all translations
                        IFWStringTextTranService service = (IFWStringTextTranService)EntityFactory.GetEntityServiceByName("StringTextTran", "");
                        allTranslations = service.GetAllAcceptedTranslations();
                        ExpirationDicDateTimeEpoch = DateTimeEpoch.GetUtcNowEpoch() + (60 * 5);
                    }
                }
            }
        }


    }
}
