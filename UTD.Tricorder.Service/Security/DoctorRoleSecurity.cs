using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;

namespace UTD.Tricorder.Service
{
    public class DoctorRoleSecurity
    {
        public static void Check(string operationTitle)
        {
            if (FWUtils.SecurityUtils.HasRole("Doctor") == false)
                throw new ServiceSecurityException(string.Format("Only doctors can {0}", operationTitle));
        }
    }
}
