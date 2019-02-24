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
    public class StringTextTranService : ServiceBase<StringTextTran, vStringTextTran>, IStringTextTranService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all accepted translations.
        /// </summary>
        /// <returns></returns>
        public IList<IFWStringTextTranObj> GetAllAcceptedTranslations()
        {
            FilterExpression filter = new FilterExpression(vStringTextTran.ColumnNames.IsAccepted, true);

            List<IFWStringTextTranObj> listR = new List<IFWStringTextTranObj>();
            var list = GetByFilterV(new GetByFilterParameters(filter, null, 0, int.MaxValue));
            foreach (var item in list)
                listR.Add(item);
            return listR;
        }
		

		#endregion

    }
}

