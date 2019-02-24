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
    public class Doctor_PatientService : ServiceBase<Doctor_Patient, vDoctor_Patient>, IDoctor_PatientService
    {
        
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            foreach (EntityObjectBase entityObj in list)
            {
                if (this.AdditionalDataKey == Doctor_PatientEN.AdditionalData_MyDoctors)
                {
                    long doctorId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vDoctor_Patient.ColumnNames.DoctorID);
                    var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)doctorId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "DoctorProfilePicUrl", entityObj, doctorProfileImageUrl);
                }

                if (this.AdditionalDataKey == Doctor_PatientEN.AdditionalData_MyPatients)
                {
                    long patientId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vDoctor_Patient.ColumnNames.PatientUserID);
                    var patientProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)patientId);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "PatientProfilePicUrl", entityObj, patientProfileImageUrl);
                }
            }
        }


		#endregion

    }
}

