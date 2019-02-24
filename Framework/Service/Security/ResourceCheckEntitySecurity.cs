using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Service
{
    public class ResourceCheckEntitySecurity : EntitySecurityBase
    {
        protected const string strDelimiter = "-";

        public ResourceCheckEntitySecurity(IServiceBase security)
            : base(security)
        { 
        }

        public override void Insert(object entitySet, InsertParameters parameters)
        {
            string resourceCode = this.Entity.SecurityResourceCode + strDelimiter + SecurityFunctionSEnum.Insert;
            FWUtils.SecurityUtils.HasAccess(resourceCode, throwIfNoAccess: true);
        }

        public override void Update(object entitySet, UpdateParameters parameters)
        {
            string resourceCode = this.Entity.SecurityResourceCode + strDelimiter + SecurityFunctionSEnum.Update;
            FWUtils.SecurityUtils.HasAccess(resourceCode, throwIfNoAccess: true);
        }

        public override void Delete(object entitySet, DeleteParameters parameters)
        {
            string resourceCode = this.Entity.SecurityResourceCode + strDelimiter + SecurityFunctionSEnum.Delete;
            FWUtils.SecurityUtils.HasAccess(resourceCode, throwIfNoAccess: true);
        }

        public override void GetAll()
        {
            string resourceCode = this.Entity.SecurityResourceCode + strDelimiter + SecurityFunctionSEnum.View;
            FWUtils.SecurityUtils.HasAccess(resourceCode, throwIfNoAccess: true);
        }

        public override void GetByFilter(GetByFilterParameters parameters)
        {
            string resourceCode = this.Entity.SecurityResourceCode + strDelimiter + SecurityFunctionSEnum.View;
            FWUtils.SecurityUtils.HasAccess(resourceCode, throwIfNoAccess: true);
        }

        public override void GetByID(object keyValues, GetByIDParameters parameters, object entitySet)
        {

        }



        public override void GetAvg(string columnName, FilterExpression f)
        {

        }

        public override void GetMin(string columnName, FilterExpression f)
        {

        }

        public override void GetMax(string columnName, FilterExpression f)
        {

        }

        public override void GetCount(FilterExpression f)
        {

        }


    }
}
