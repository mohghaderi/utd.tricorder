using Framework.Common;
using Framework.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using UTD.Tricorder.Website.Base.ViewNeed;
using UTD.Tricorder.Website.Models;

namespace UTD.Tricorder.Website.Base
{
    /// <summary>
    /// Base class for entity services
    /// It provides default CRUD functions for each service.
    /// </summary>
    public abstract class EntityServiceControllerBase : ApiController
    {
        #region Default functions Security properties


        private bool _HasDefaultGet = true;
        /// <summary>
        /// If it has default get service or not
        /// </summary>
        public bool HasDefaultGet
        {
            get { return _HasDefaultGet; }
            set { _HasDefaultGet = value; }
        }


        private bool _HasDefaultGetByID = true;
        /// <summary>
        /// If it has default get service or not
        /// </summary>
        public bool HasDefaultGetByID
        {
            get { return _HasDefaultGetByID; }
            set { _HasDefaultGetByID = value; }
        }


        private bool _HasDefaultInsert = true;
        /// <summary>
        /// If it has default insert service or not
        /// </summary>
        public bool HasDefaultInsert
        {
            get { return _HasDefaultInsert; }
            set { _HasDefaultInsert = value; }
        }

        private bool _HasDefaultUpdate = true;
        /// <summary>
        /// If it has default update service or not
        /// </summary>
        public bool HasDefaultUpdate
        {
            get { return _HasDefaultUpdate; }
            set { _HasDefaultUpdate = value; }
        }


        private bool _HasDefaultDelete = true;
        /// <summary>
        /// If it has default delete service or not
        /// </summary>
        public bool HasDefaultDelete
        {
            get { return _HasDefaultDelete; }
            set { _HasDefaultDelete = value; }
        }


        #endregion


        #region Creating Service 

        private IServiceBase _Service = null;

        /// <summary>
        /// Gets service object. It creates the service class once
        /// </summary>
        /// <returns></returns>
        protected IServiceBase GetService()
        {
            if (_Service == null)
                _Service = CreateService();
            return _Service;
        }

        /// <summary>
        /// Creates the service object
        /// </summary>
        /// <returns></returns>
        protected virtual IServiceBase CreateService()
        {
            if (this.ControllerContext.RouteData != null)
            {
                // when it is executed by MVC framework Web API
                string entityName = FWUtils.EntityUtils.ConvertObjectToString(this.ControllerContext.RouteData.Values["controller"]);
                string adk = "";

                var hifenIndex = entityName.IndexOf("-");
                if (hifenIndex > 0)
                {
                    adk = entityName.Substring(hifenIndex + 1, entityName.Length - hifenIndex -1);
                    entityName = entityName.Substring(0, hifenIndex);
                }

                //if (this.ControllerContext.RouteData.Values.ContainsKey("adk"))
                //    adk = FWUtils.EntityUtils.ConvertObjectToString(this.ControllerContext.RouteData.Values["adk"]);

                return EntityFactory.GetEntityServiceByName(entityName, adk);
            }
            else
            {
                // When we execute it from the test cases
                string entityName = this.GetType().Name.Replace("Controller", "");
                string adk = "";
                return EntityFactory.GetEntityServiceByName(entityName, adk);
            }

            //string controllerName = FWUtils.EntityUtils.ConvertObjectToString(RouteData.Values["controller"]);
            //string[] s = controllerName.Split('_');
            //string entityName = s[0];
            //string adk = "";
            //if (s.Length > 1)
            //    adk = s[1];

        }

        #endregion

        #region Columns



        /// <summary>
        /// Gets default columns for get function
        /// null for all columns
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetDefaultGetColumns()
        {
            return null;
        }

        /// <summary>
        /// Gets default columns for getByID function
        /// null for all columns
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetDefaultGetByIDColumns()
        {
            return null;
        }

        /// <summary>
        /// Gets default columns for insert function
        /// null for all columns
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetDefaultInsertColumns()
        {
            return null;
        }

        [HttpGet]
        /// <summary>
        /// Gets default columns for update function
        /// null for all columns
        /// </summary>
        /// <returns></returns>
        protected virtual List<string> GetDefaultUpdateColumns()
        {
            return null;
        }

        #endregion

        #region Default functions body

        [HttpGet]
        // GET api/entity_adk
        public ServiceActionResult Get(string p)
        //public ServiceActionResult Get(GetByFilterParmsJsonCompatible p)
        {
            try
            {
                GetByFilterParmsJsonCompatible pG = null;
                if (string.IsNullOrEmpty(p) == false)
                {
                    pG = (GetByFilterParmsJsonCompatible)
                        FWUtils.EntityUtils.JsonDeserializeObject(p, typeof(GetByFilterParmsJsonCompatible));
                }

                if (this.HasDefaultGet == false)
                    throw new ServiceSecurityException();

                IServiceBase service = GetService();

                GetByFilterParameters filterParams = null;
                if (pG != null)
                    filterParams = pG.ConvertToGetByFilterParameters(service.Entity);

                if (filterParams == null) // if no filter provided
                    filterParams = new GetByFilterParameters(
                        new FilterExpression(), new SortExpression(), 0, 100, null, GetSourceTypeEnum.View);

                RemoveServerOnlyColumns(filterParams);

                var data = service.GetByFilter(filterParams);
                //return new ServiceActionResult(data);
                string s = FWUtils.EntityUtils.JsonSerializeObject(data, true, service.Entity.ServerOnlyColumns);
                return new ServiceActionResult(s);
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        private void RemoveServerOnlyColumns(GetByFilterParameters p)
        {
            var service = GetService();
            if (service.Entity.ServerOnlyColumns.Count == 0) // if there was not column to exclude just return
                return;

            // handling columns and prevention of security fields
            List<string> colNames = new List<string>();
            if (p.SelectColumns == null)
            {
                foreach (var colName in service.Entity.EntityColumns.Keys) // all columns excluding important columns
                    if (service.Entity.ServerOnlyColumns.Contains(colName) == false)
                        colNames.Add(colName);
            }
            else
            {
                foreach (var colName in p.SelectColumns)
                    if (service.Entity.ServerOnlyColumns.Contains(colName) == false)
                        colNames.Add(colName);
            }
            p.SelectColumns = colNames;
        }

        [HttpGet]
        // GET api/entity_adk/5
        public virtual ServiceActionResult GetByID(string id)
        {
            try
            {
                if (this.HasDefaultGetByID == false)
                    throw new ServiceSecurityException();

                IServiceBase service = GetService();

                var filter = new FilterExpression(service.Entity.IDFieldName, id);
                var filterParams = new GetByFilterParameters(
                    filter, new SortExpression(), 0, 1, null, GetSourceTypeEnum.View);

                RemoveServerOnlyColumns(filterParams);
                var data = service.GetByFilter(filterParams);
                if (data.Count > 0)
                    return new ServiceActionResult(FWUtils.EntityUtils.JsonSerializeObject(data[0], true, service.Entity.ServerOnlyColumns));
                else
                    return new ServiceActionResult(null);
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        [HttpPost]
        // PUT api/entity_adk
        public virtual ServiceActionResult Insert([FromBody]FWPostBody p)
        {
            try
            {
                if (this.HasDefaultInsert == false)
                    throw new ServiceSecurityException();

                IServiceBase service = GetService();
                var obj = EntityFactory.GetEntityObject(service.EntityName, GetSourceTypeEnum.Table);
                FWUtils.EntityUtils.JsonDeserializeOnObject(p.data, obj, null, true);
                service.Insert(obj, new InsertParameters());
                return ServiceActionResult.CreateSuccess(UIText.Base.EntityService.SuccessMsgs.General.Insert);
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        [HttpPut]
        // PUT api/entity_adk/5
        public virtual ServiceActionResult Update(string id, [FromBody] FWPostBody p)
        {
            try
            {
                if (this.HasDefaultUpdate == false)
                    throw new ServiceSecurityException();

                IServiceBase service = GetService();
                //object id = FWUtils.EntityUtils.GetObjectFieldValue(p.data)
                var obj = service.GetByID(id, new GetByIDParameters(GetSourceTypeEnum.Table));
                // TODO: Fix this function in a way that it reads default Update fields from the entity and updates only those fields
                FWUtils.EntityUtils.JsonDeserializeOnObject(p.data, obj, null, true);
                service.Update(obj, new UpdateParameters());
                return ServiceActionResult.CreateSuccess(UIText.Base.EntityService.SuccessMsgs.General.Update);
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        [HttpDelete]
        // DELETE api/entity_adk/5
        public virtual ServiceActionResult Delete(string id)
        {
            try 
	        {
                if (this.HasDefaultDelete == false)
                    throw new ServiceSecurityException();

                IServiceBase service = GetService();
                var entity = service.GetByID(id, new GetByIDParameters(GetSourceTypeEnum.Table, GetModeEnum.Load));
                service.Delete(entity, new DeleteParameters());
                return ServiceActionResult.CreateSuccess(UIText.Base.EntityService.SuccessMsgs.General.Delete);
	        }
	        catch (Exception ex)
	        {
                return UIUtils.GetExceptionActionResult(ex);
	        }

        }

        #endregion

        #region exec

        //TODO: add method complete description to framework so that all services provides
        // a complete description of the action to its callers

        public static Dictionary<string, string> SuccessStrings = null;

        public string GetSuccessString(string methodName)
        {
            if (SuccessStrings == null)
                LoadSuccessStringList();

            string key = this.GetService().EntityName + "." + methodName;
            if (SuccessStrings.ContainsKey(key))
                return SuccessStrings[key];

            return null;
        }

        private void LoadSuccessStringList()
        {
            SuccessStrings = new Dictionary<string, string>();
            SuccessStrings.Add("User.SendEmailVerificationLetter", UIText.Base.EntityService.SuccessMsgs.User.SendEmailVerificationLetter);
            SuccessStrings.Add("User.SendPhoneNumberVerification", UIText.Base.EntityService.SuccessMsgs.User.SendPhoneNumberVerification);
            SuccessStrings.Add("User.VerifyEmail", UIText.Base.EntityService.SuccessMsgs.User.VerifyEmail);
            SuccessStrings.Add("User.VerifyPhoneNumber", UIText.Base.EntityService.SuccessMsgs.User.VerifyPhoneNumber);
        }



        [HttpPost]
        public ServiceActionResult Exec(string methodName, [FromBody]FWPostBody p)
        {
            try
            {
                IServiceBase service = GetService();

                var method = service.GetType().GetMethod(methodName);
                if (method == null)
                    throw new ServiceSecurityException();
                else
                {
                    object result = null;
                    var mParameters = method.GetParameters();
                    Check.Assert(mParameters.Length <= 1, "Only services with one or less parameter is allowed");

                    if (mParameters.Length == 0)
                    {
                        result = method.Invoke(service, null);
                    }
                    else if (mParameters.Length == 1)
                    {
                        ParameterInfo param1 = null;
                        foreach (var item in mParameters)
                        {
                            param1 = item;
                        }
                        object parameterValue = FWUtils.EntityUtils.ConvertStringToObject(p.data, param1.ParameterType);

                        object[] methodParams = { parameterValue };
                        result = method.Invoke(service, methodParams);
                    }

                    if (result != null)
                        return new ServiceActionResult(result);
                    else
                        return ServiceActionResult.CreateSuccess(GetSuccessString(methodName));
                }
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                return UIUtils.GetExceptionActionResult(ex.InnerException);
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        [HttpGet]
        public ServiceActionResult GetViewNeeds(string p)
        {
            try
            {
                ViewNeedRequest r = (ViewNeedRequest)FWUtils.EntityUtils.JsonDeserializeObject(p, typeof(ViewNeedRequest));
                return new ServiceActionResult(CheckViewNeeds(r));
            }
            catch (Exception ex)
            {
                return UIUtils.GetExceptionActionResult(ex);
            }
        }

        /// <summary>
        /// Checks for view pre requisites if any
        /// </summary>
        /// <param name="p">parameters</param>
        protected virtual ViewNeedResponse CheckViewNeeds(ViewNeedRequest p)
        {
            return null;
        }


        //private object ConvertStringToObject(string data, Type t)
        //{
        //    if (t == typeof(string))
        //        return data;

        //    if (t.IsClass)
        //    {
        //        if (t == typeof(Guid))
        //            return FWUtils.EntityUtils.JsonDeserializeObject(data, t);
        //    }
        //    return FWUtils.EntityUtils.ChangeValueType(data, t);
        //}


        #endregion






    }
}