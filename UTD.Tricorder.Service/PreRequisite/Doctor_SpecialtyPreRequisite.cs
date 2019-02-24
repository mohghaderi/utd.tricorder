using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service.PreRequisite
{
    public class Doctor_SpecialtyPreRequisite : PreRequisiteInfoBase
    {
        //private const string url = 

        public override string Check(User userInfo)
        {
            var service = Doctor_SpecialtyEN.GetService("");
            if (service.GetCount(new FilterExpression(vDoctor_Specialty.ColumnNames.DoctorID, userInfo.UserID)) >= 1)
                return null;
            else
            {
                // if our user was doctor and he doesn't have doctor's information
                var userInRoleService = UserInRoleEN.GetService("");
                var rolesList = userInRoleService.GetRolesIDUserID(userInfo.UserID.ToString());
                if (rolesList.Contains((long)EntityEnums.RoleEnum.Doctor))
                {
                    return "Register/Doctor_Specialty";
                }
            }
            return null;
        }
    }
}
