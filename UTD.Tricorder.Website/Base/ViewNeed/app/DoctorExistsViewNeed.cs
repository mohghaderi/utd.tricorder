using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Website.Base.ViewNeed;

namespace UTD.Tricorder.Website.Base
{
    public class DoctorInfoExistsViewNeed
    {
        public ViewNeedClass CheckNeed(long doctorId)
        {
            if (DoctorEN.GetService().GetCount(new FilterExpression(vDoctor.ColumnNames.DoctorID, doctorId)) < 1)
            {
                return new ViewNeedClass("Basic doctor information not found. Please fill it first", "Doctor-Form");
            }
            return null;
        }
    }
}