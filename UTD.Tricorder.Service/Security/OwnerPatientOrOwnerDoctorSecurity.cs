using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Service
{
    public class OwnerPatientOrOwnerDoctorSecurity
    {
        public static void Check(string operationTitle, object entitySet, string patientUserIdFieldName, string doctorUserIdFieldName)
        {
            if (entitySet == null)
                return;

            bool isOwnerPatient = false;
            bool isOwnerDoctor = false;
            bool hasDoctorRole = false;

            object fValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, patientUserIdFieldName);
            if (fValue != null)
            {
                if (fValue.Equals(FWUtils.SecurityUtils.GetCurrentUserIDLong()) == true)
                {
                    isOwnerPatient = true;
                    return;
                }
            }

            object fValue2 = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, doctorUserIdFieldName);
            if (fValue2 != null)
            {
                if (fValue2.Equals(FWUtils.SecurityUtils.GetCurrentUserIDLong()) == true)
                {
                    isOwnerDoctor = true;
                    return;
                }
            }

            if (FWUtils.SecurityUtils.HasRole("Doctor"))
                hasDoctorRole = true;

            if (!(isOwnerPatient == true || (hasDoctorRole == true && isOwnerDoctor == true)))
                throw new ServiceSecurityException(string.Format("Only the patient of the doctor can {0}.", operationTitle));
        }

        //public static bool FieldEqualsToCurrentUserID(object entitySet, string fieldName)
        //{

        //    return false;
        //}

    }
}
