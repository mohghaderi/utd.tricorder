using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.TestCase.CommonClasses
{
    public class TestEnums
    {
        public class User
        {
            /// <summary>
            /// PatientID = 14
            /// </summary>
            public const long constPatientUserID = 14;
            /// <summary>
            /// DoctorID = 101
            /// </summary>
            public const long constDoctorID = 101;

        }


        public class Role
        {
            /// <summary>
            /// Patient RoleID = 1
            /// </summary>
            public const int constPatientRoleID = 1;
            /// <summary>
            /// Doctor RoleID = 2
            /// </summary>
            public const int constDoctorRoleID = 2;
        }


    }
}
