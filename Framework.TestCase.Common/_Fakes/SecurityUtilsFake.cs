using Framework.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.TestCase.CommonClasses
{
    public class SecurityUtilsFake : Framework.Common.Utils.SecurityUtils
    {

        private long? _UserID;


        public SecurityUtilsFake(long? userId)
            : base()
        {
            _UserID = userId;
        }

        public override string GetCurrentUserIDString()
        {
            return _UserID.ToString();
        }

        public override long GetCurrentUserIDLong()
        {
            return _UserID.Value;
        }

        public override Guid? GetCurrentUserIDGuid()
        {
            return null;
        }





    }
}
