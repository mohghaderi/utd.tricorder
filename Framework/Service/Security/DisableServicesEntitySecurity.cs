using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Service
{
    /// <summary>
    /// Security for special classes that some services needs to be disabled
    /// </summary>
    public class DisableServicesEntitySecurity : EntitySecurityBase
    {
        public DisableServicesEntitySecurity(IServiceBase service)
            :base(service)
        { 
        }

        public bool InsertDisabled { get; set; }
        public bool UpdateDisabled { get; set; }
        public bool DeleteDisabled { get; set; }
        public bool GetAllDisabled { get; set; }
        public bool GetByFilterDisabled { get; set; }

        public bool GetByIDDisabled { get; set; }
        public bool GetAvgDisabled { get; set; }
        public bool GetMinDisabled { get; set; }
        public bool GetMaxDisabled { get; set; }
        public bool GetCountDisabled { get; set; }

        public void DisableAll()
        {
            InsertDisabled = true;
            UpdateDisabled = true;
            DeleteDisabled = true;
            GetAllDisabled = true;
            GetByIDDisabled = true;
            GetByFilterDisabled = true;
            GetAvgDisabled = true;
            GetMinDisabled = true;
            GetMaxDisabled = true;
            GetCountDisabled = true;
        }


        public override void Insert(object entitySet, Common.InsertParameters parameters)
        {
            if (this.InsertDisabled)
                throw new ServiceSecurityException();
        }

        public override void Update(object entitySet, Common.UpdateParameters parameters)
        {
            if (this.UpdateDisabled)
                throw new ServiceSecurityException();
        }

        public override void Delete(object entitySet, Common.DeleteParameters parameters)
        {
            if (this.DeleteDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetAll()
        {
            if (this.GetAllDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetByFilter(Common.GetByFilterParameters parameters)
        {
            if (this.GetByFilterDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetByID(object keyValues, Common.GetByIDParameters parameters, object entitySet)
        {
            if (this.GetByIDDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetAvg(string columnName, Common.FilterExpression f)
        {
            if (this.GetAvgDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetMin(string columnName, Common.FilterExpression f)
        {
            if (this.GetMinDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetMax(string columnName, Common.FilterExpression f)
        {
            if (this.GetMaxDisabled)
                throw new ServiceSecurityException();
        }

        public override void GetCount(Common.FilterExpression f)
        {
            if (this.GetCountDisabled)
                throw new ServiceSecurityException();
        }
    }
}
