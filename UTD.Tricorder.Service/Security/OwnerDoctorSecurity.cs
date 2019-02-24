using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Service
{
    public class OwnerDoctorSecurity
    {
        public static void Check(string operationTitle, object entitySet, string doctorIdFieldName)
        {
            object fValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, doctorIdFieldName);
            if (fValue != null)
            {
                if (fValue.Equals(FWUtils.SecurityUtils.GetCurrentUserIDLong()) == false)
                {
                    throw new ServiceSecurityException(string.Format("Only the doctor can {0}.", operationTitle));
                }
            }
        }
    }
}
