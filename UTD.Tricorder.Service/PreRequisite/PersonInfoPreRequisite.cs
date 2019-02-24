using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service.PreRequisite
{
    public class PersonInfoPreRequisite : PreRequisiteInfoBase
    {
        //private const string url = 

        public override string Check(User userInfo)
        {
            IPersonService service = (IPersonService)EntityFactory.GetEntityServiceByName(vPerson.EntityName, Person.AdditionalData_Register);
            if (service.GetCount(new FilterExpression(new Filter(vPerson.ColumnNames.PersonID, userInfo.UserID))) == 1)
                return null;

            // "~/Pages/PersonInsert.aspx?Entity=" + Person.EntityName + "&AdditionalDataKey=" + Person.AdditionalData_Register + "&MasterEntityID=" +;
            //string url = FWUtils.UrlTemplateUtils.BuildInsertUrl(Person.EntityName, Person.AdditionalData_Register, FWUtils.SecurityUtils.GetCurrentUserIDString(), User.EntityName, "", "");
            //int indexQuestionMark = url.IndexOf('?');
            //url = "~/Pages/PersonInsert.aspx" + url.Substring(indexQuestionMark);
            //return url;
            return "Register/Person";
        }
    }
}