using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace UTD.Tricorder.Service
{
    public class SameSiteIDSecurity
    {
        public static void Check(string exceptionMessage, object entitySet, string siteIdPropertyName)
        {
            if (entitySet == null)
                return;

            int? siteId = FWUtils.SecurityUtils.GetCurrentSiteID();
            if (siteId.HasValue)
            {
                object fValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, siteIdPropertyName);
                if (fValue != null)
                {
                    if (fValue.Equals(siteId.Value) == false)
                        throw new ServiceSecurityException(exceptionMessage);
                }
            }
        }
    }
}
