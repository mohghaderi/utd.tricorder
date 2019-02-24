using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Service
{
    public class MyRowViewAllEditMeEntitySecurity : EntitySecurityBase
    {
        private string _FName;
        public string FieldName { get { return _FName; } }

        private object _FValue;
        public object FieldValue { get { return _FValue; } }

        public MyRowViewAllEditMeEntitySecurity(IServiceBase service, string fieldName, object fieldValue)
            : base(service)
        {
            _FName = fieldName;
            _FValue = fieldValue;
        }


        public override void Insert(object entitySet, Common.InsertParameters parameters)
        {
            SecurityCheckMyRecord(entitySet);
        }

        public override void Update(object entitySet, Common.UpdateParameters parameters)
        {
            SecurityCheckMyRecord(entitySet);
        }

        public override void Delete(object entitySet, Common.DeleteParameters parameters)
        {
            SecurityCheckMyRecord(entitySet);
        }


        public override void GetByFilter(Common.GetByFilterParameters parameters)
        {
            //FilterExpression filter = new FilterExpression(new Filter(this.FieldName, this.FieldValue));
            //parameters.Filter.AndMerge(filter);
        }

        public override void GetByID(object keyValues, Common.GetByIDParameters parameters, object entitySet)
        {
             //SecurityCheckMyRecord(entitySet);
        }


        public override void GetAll()
        {
            throw new ServiceSecurityException();
        }



        protected void SecurityCheckMyRecord(object entitySet)
        {
            // checks that entityset has the appropriate field value
            // it doesn't allow access to the entity without allowed value
            // for example when user can only modify his own records, 
            // this adds UserID = Value to filters and prevents edit or delete, ... data of other users by this user
            if (entitySet == null)
                return;

            object fValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, this.FieldName);
            if (fValue != null)
            {
                if (fValue.Equals(this.FieldValue) == false)
                    throw new ServiceSecurityException();
            }

        }



        public override void GetAvg(string columnName, FilterExpression f)
        {
            //FilterExpression filter = new FilterExpression(new Filter(this.FieldName, this.FieldValue));
            //f.AndMerge(filter);
        }

        public override void GetMin(string columnName, FilterExpression f)
        {
            //FilterExpression filter = new FilterExpression(new Filter(this.FieldName, this.FieldValue));
            //f.AndMerge(filter);
        }

        public override void GetMax(string columnName, FilterExpression f)
        {
            //FilterExpression filter = new FilterExpression(new Filter(this.FieldName, this.FieldValue));
            //f.AndMerge(filter);
        }

        public override void GetCount(FilterExpression f)
        {
            //FilterExpression filter = new FilterExpression(new Filter(this.FieldName, this.FieldValue));
            //f.AndMerge(filter);
        }
    }
}
