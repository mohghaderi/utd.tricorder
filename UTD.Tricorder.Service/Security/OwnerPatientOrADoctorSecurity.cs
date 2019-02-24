using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Service
{
    public class OwnerPatientOrADoctorSecurity
    {
        public static void Check(string operationTitle, object entitySet, string userIdFieldName)
        {
            if (entitySet == null)
                return;

            object fValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, userIdFieldName);
            CheckValue(operationTitle, fValue);
        }

        public static void CheckValue(string operationTitle, object fValue)
        {
            bool isOwnerPatient = false;
            bool hasDoctorRole = false;

            if (fValue != null)
            {
                if (fValue.Equals(FWUtils.SecurityUtils.GetCurrentUserIDLong()) == true)
                {
                    isOwnerPatient = true;
                    return;
                }
            }

            if (FWUtils.SecurityUtils.HasRole("Doctor"))
                hasDoctorRole = true;

            if (isOwnerPatient == false && hasDoctorRole == false)
                throw new ServiceSecurityException(string.Format("Only the patient of doctors can {0}.", operationTitle));
        }

    }
}
