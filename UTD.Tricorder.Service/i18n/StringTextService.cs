using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class StringTextService : ServiceBase<StringText, vStringText>, IStringTextService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Adds the item to database.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddItemToDatabase(i18nText item)
        {
            StringText s = new StringText();

            s.StringTextID = item.StringTextID;
            s.ValueEn = item.Value;
            s.KeyFullName = item.KeyFullName;
            s.InsertDate = DateTime.UtcNow;
            s.LastUsedDate = DateTime.UtcNow;
            s.SystemID = FWUtils.SecurityUtils.GetCurrentSiteID();

            try
            {
                Insert(s);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    throw;

                // if duplicated key found just ignore the exception
                if (ex.InnerException.Message.Contains("Cannot insert duplicate key") == false)
                    throw;
            }
        }

        /// <summary>
        /// Gets the all i18n text.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public System.Collections.Concurrent.ConcurrentDictionary<Guid, i18nText> GetAlli18nText()
        {
            System.Collections.Concurrent.ConcurrentDictionary<Guid, i18nText> dic = new System.Collections.Concurrent.ConcurrentDictionary<Guid, i18nText>();

            var list = this.GetByFilterV(new GetByFilterParameters(new FilterExpression()));
            foreach (var item in list)
            {
                i18nText t = new i18nText(item.KeyFullName, item.ValueEn);
                dic.TryAdd(item.StringTextID, t);
            }

            return dic;
        }
		

		#endregion

    }
}

