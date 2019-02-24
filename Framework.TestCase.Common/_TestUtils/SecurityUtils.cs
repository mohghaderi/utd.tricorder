using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.TestCase.CommonClasses
{
    public class SecurityUtils
    {
        public void SetCurrentUser(long userId)
        {
            TestUtils.Access.SetPrivateStaticField(typeof(FWUtils), "_SecurityUtils", new SecurityUtilsFake(userId));
        }
    }
}
