using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service.PreRequisite
{
    /// <summary>
    /// Checks all pre-requisites of using the application
    /// it can be filling out an information form or change in policy
    /// or changing password requirements,...
    /// </summary>
    public class PreRequisiteInfoChecker
    {
        List<PreRequisiteInfoBase> pilist = new List<PreRequisiteInfoBase>();

        public PreRequisiteInfoChecker()
        {
            pilist.Add(new PersonInfoPreRequisite());
            //pilist.Add(new UserApprovedPreRequisite());
            pilist.Add(new PaymentInfoPreRequisite());
            pilist.Add(new DoctorInfoPreRequisite());
            pilist.Add(new Doctor_SpecialtyPreRequisite());
            pilist.Add(new Doctor_InsurancePreRequisite());
            pilist.Add(new Doctor_USStatePreRequisite());
            pilist.Add(new User_LanguagePreRequisite());
        }


        /// <summary>
        /// Checks the and return next URL.
        /// </summary>
        /// <returns></returns>
        public string CheckAndReturnNextForm(object userID)
        {
            IUserService userService = (IUserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
            User userInfo = (User)userService.GetByID(userID, new GetByIDParameters());

            foreach (var item in pilist)
            {
                string url = item.Check(userInfo);
                if (string.IsNullOrEmpty(url) == false)
                    return url;
            }

            return "";
        }

    }
}