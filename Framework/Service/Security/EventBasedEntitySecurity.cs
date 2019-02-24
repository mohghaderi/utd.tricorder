//using Framework.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Framework.Service.Security
//{
//    public class EventBasedEntitySecurity : EntitySecurityBase
//    {
//        public EventBasedEntitySecurity(IServiceBase security)
//            : base(security)
//        { 
//        }

//        public delegate void SecurityCheckInsert(object entitySet, InsertParameters parameters);
//        public event SecurityCheckInsert CheckInsert;

//        public delegate void SecurityCheckUpdate(object entitySet, UpdateParameters parameters);
//        public event SecurityCheckUpdate CheckUpdate;

//        public delegate void SecurityCheckDelete(object entitySet, DeleteParameters parameters);
//        public event SecurityCheckDelete CheckDelete;

//        public delegate void SecurityCheckGetAll();
//        public event SecurityCheckGetAll CheckGetAll;

//        public delegate void SecurityCheckGetByFilter(GetByFilterParameters parameters);
//        public event SecurityCheckGetByFilter CheckGetByFilter;

//        public delegate void SecurityCheckGetByID(object keyValues, GetByIDParameters parameters, object entitySet);
//        public event SecurityCheckGetByID CheckGetByID;


//        public override void Insert(object entitySet, InsertParameters parameters)
//        {
//            if (this.CheckInsert != null)
//                this.CheckInsert(entitySet, parameters);
//        }

//        public override void Update(object entitySet, UpdateParameters parameters)
//        {
//            if (this.CheckUpdate != null)
//                this.CheckUpdate(entitySet, parameters);
//        }

//        public override void Delete(object entitySet, DeleteParameters parameters)
//        {
//            if (this.CheckDelete != null)
//                this.CheckDelete(entitySet, parameters);
//        }

//        public override void GetAll()
//        {
//            if (this.CheckGetAll != null)
//                this.CheckGetAll();
//        }

//        public override void GetByFilter(GetByFilterParameters parameters)
//        {
//            if (this.CheckGetByFilter != null)
//                this.CheckGetByFilter(parameters);
//        }

//        public override void GetByID(object keyValues, GetByIDParameters parameters, object entitySet)
//        {
//            if (this.CheckGetByID != null)
//                this.CheckGetByID(keyValues, parameters, entitySet);
//        }


//    }
//}
