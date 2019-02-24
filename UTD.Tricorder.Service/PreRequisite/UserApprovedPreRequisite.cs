using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service.PreRequisite
{
    public class UserApprovedPreRequisite : PreRequisiteInfoBase
    {
        public const string urlApprovalNeeded = "~/Pages/UserApproval.aspx?Msg=NeedApproval";

        public override string Check(User userInfo)
        {
            // We don't check password and lock fails here. They are all handled in Login page
            if (userInfo.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.Approved)
                return null;
            else if (userInfo.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration)
                return null;
            else if (userInfo.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.WaitingForApproval)
                return urlApprovalNeeded;
            else
                throw new Exception("ApprovalID is not defined:" + userInfo.UserApprovalStatusID.ToString());
        }
    }
}
