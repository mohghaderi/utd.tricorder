using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IDoctor_SpecialtyService : IServiceBaseT<Doctor_Specialty, vDoctor_Specialty>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        IList<vDoctor_Specialty> GetByDoctorID(long DoctorID);

		#endregion
    }
}

