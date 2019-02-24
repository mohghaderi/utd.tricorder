using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IIllness_SpecialtyService : IServiceBaseT<Illness_Specialty, vIllness_Specialty>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        
        IList<vIllness_Specialty> GetByDoctorID(long DoctorID);
		

		#endregion
    }
}

