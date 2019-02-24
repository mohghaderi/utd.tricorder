using System;
namespace Framework.Common.Security
{
    public interface IvUserInRole
    {
        DateTime? EndDate { get; set; }
        DateTime? InsertDate { get; set; }
        long? InsertUserID { get; set; }
        bool IsActive { get; set; }
        string MembershipAreaCode { get; set; }
        long MembershipAreaID { get; set; }
        string MembershipAreaName { get; set; }
        string RoleCode { get; set; }
        long RoleID { get; set; }
        string RoleName { get; set; }
        DateTime StartDate { get; set; }
        long UesrInRoleID { get; set; }
        DateTime? UpdateDate { get; set; }
        long? UpdateUserID { get; set; }
        long UserID { get; set; }
    }
}
