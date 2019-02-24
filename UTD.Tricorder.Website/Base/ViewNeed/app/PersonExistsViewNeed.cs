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
    public class PersonExistsViewNeed
    {
        public ViewNeedClass CheckNeed(long personId)
        {
            if (PersonEN.GetService().GetCount(new FilterExpression(vPerson.ColumnNames.PersonID, personId)) < 1)
            {
                return new ViewNeedClass("Basic Person information not found. Please fill it first", "Person-Form");
            }
            return null;
        }
    }
}