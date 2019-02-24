using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using Framework.Common.Config;
using Framework.Common.Exceptions;
using Framework.DataAccess;
using System.Collections.ObjectModel;
using System.Text;


namespace Framework.Service
{
    public abstract class ServiceBase<T, V> : IServiceBaseT<T, V>
    {

        protected const char actionSeparationCharater = '|';

        #region Initialization

        public const string ClassPostFix = "Service";


        private string _EntityName;
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public string EntityName { get { return _EntityName; } }

        private string _AdditionalDataKey;
        /// <summary>
        /// Gets or sets the additional data key.
        /// </summary>
        /// <value>
        /// The additional data key.
        /// </value>
        public string AdditionalDataKey { get { return _AdditionalDataKey; } }


        private EntityInfoBase _Entity;
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public EntityInfoBase Entity { get { return _Entity; } }


        private bool _IsInitialized = false;

        public bool IsInitialized { get { return _IsInitialized; } }

        /// <summary>
        /// Initializes the object with the provided entityname and additionaldatakey
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="additionalDataKey">The additional data key.</param>
        public void Initialize(string entityName, string additionalDataKey)
        {
            Check.Require(string.IsNullOrEmpty(entityName) == false);
            Check.Require(additionalDataKey != null);

            _Entity = EntityFactory.GetEntityInfoByName(entityName, additionalDataKey);
            Initialize(_Entity);
        }


        /// <summary>
        /// Initializes the object with the provided entity class. It is fast when entity class is already created.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Initialize(EntityInfoBase entity)
        {
            Check.Require(_IsInitialized == false, "This class is already initialized.");

            Check.Require(entity != null);
#if DEBUG   // Checking the class refelection name with the provided name
            Check.Require(entity.EntityName == FWUtils.ReflectionUtils.GetEntityNameFromType(this.GetType().FullName, ClassPostFix), "EntityName provided is not match the class. Please make sure that the class is located in an appropriate location and EntityFactory class works correctly.");
#endif
            _EntityName = entity.EntityName;
            _AdditionalDataKey = entity.AdditionalDataKey;
            _Entity = entity;
            _DataAccessObject =  EntityFactory.GetEntityDataAccessByName(this.EntityName, this.AdditionalDataKey);
            _BusinessLogicObject = EntityFactory.GetEntityBusinessRuleByName(this.EntityName, this.AdditionalDataKey);
            this.SecurityCheckers = new List<EntitySecurityBase>();
            this.SecurityCheckers.Add(new ResourceCheckEntitySecurity(this));
            _IsInitialized = true;
            OnAfterInitialize();
        }

        #endregion

        public virtual void OnAfterInitialize()
        {
            ;
        }


        public List<EntitySecurityBase> SecurityCheckers { get; set; }

        //public object DataTransferObject { get; set; }
        //public virtual BusinessRuleErrorList CheckRules(object entitySet, string fnName)
        //{
        //    BusinessRuleErrorList errors = new BusinessRuleErrorList();
        //    BusinessLogicObject.CheckRules(entitySet, fnName, errors);
        //    return errors;
        //}  

        private IDataAccessBase _DataAccessObject;
        public IDataAccessBase DataAccessObject
        {
            get
            {
                return _DataAccessObject;
            }
        }

        private IBusinessRuleBase _BusinessLogicObject;
        public IBusinessRuleBase BusinessLogicObject
        {
            get
            {
                return _BusinessLogicObject;
            }

        }



        /// <summary>
        /// Inserts the specified parameters.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Insert(object entitySet, InsertParameters parameters = null)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");
            if (parameters == null)
                parameters = new InsertParameters();

            if (onBeforeInsert(entitySet, parameters))
            {
                foreach (EntitySecurityBase checker in this.SecurityCheckers)
                    checker.Insert(entitySet, parameters);

                BusinessLogicObject.Insert(entitySet, parameters);
                onAfterInsert(entitySet, parameters);
            }
        }


        protected virtual bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            return true;
        }

        protected virtual void onAfterInsert(object entitySet, InsertParameters parameters)
        {
 
        }

        /// <summary>
        /// Updates the specified parameters.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Update(object entitySet, UpdateParameters parameters = null)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");
            if (parameters == null)
                parameters = new UpdateParameters();

            if (onBeforeUpdate(entitySet, parameters))
            {
                foreach (EntitySecurityBase checker in this.SecurityCheckers)
                    checker.Update(entitySet, parameters);

                BusinessLogicObject.Update(entitySet, parameters);
                onAfterUpdate(entitySet, parameters);
            }
        }


        protected virtual bool onBeforeUpdate(object entitySet, UpdateParameters parameters)
        {
            return true;
        }

        protected virtual void onAfterUpdate(object entitySet, UpdateParameters parameters)
        {

        }




        /// <summary>
        /// Deletes the specified entity set.
        /// It doesn't delete weak entititied included here, unless database does it using integrity rules
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Delete(object entitySet, DeleteParameters parameters = null)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet."); 
            Check.Require(entitySet != null);
            if (parameters == null)
                parameters = new DeleteParameters();

            if (onBeforeDelete(entitySet, parameters))
            {
                foreach (EntitySecurityBase checker in this.SecurityCheckers)
                    checker.Delete(entitySet, parameters);

                BusinessLogicObject.Delete(entitySet, parameters);
                onAfterDelete(entitySet, parameters);
            }
        }


        protected virtual bool onBeforeDelete(object entitySet, DeleteParameters parameters)
        {
            return true;
        }

        protected virtual void onAfterDelete(object entitySet, DeleteParameters parameters)
        {

        }


        public System.Collections.IList GetAll()
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetAll();

            return DataAccessObject.GetAll();
        }

        public System.Collections.IList GetByFilter(GetByFilterParameters parameters)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetByFilter(parameters);

            if (onBeforeGetByFilter(parameters))
            {
                //this.Entity.AddSelectParameters(parameters);
                parameters.Filter.AndMerge(this.Entity.DefaultFilter);

                var list = DataAccessObject.GetByFilter(parameters);
                onAfterGetByFilter(list, parameters);
                return list;
            }
            return null;
        }

        protected virtual bool onBeforeGetByFilter(GetByFilterParameters parameters)
        {
            return true;
        }

        protected virtual void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {

        }

        public object GetByID(object keyValues, GetByIDParameters parameters = null)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");
            if (parameters == null)
                parameters = new GetByIDParameters();

            object typedKeyObject = GetKeyObject(keyValues);

            if (onBeforeGetByID(typedKeyObject, parameters))
            {
                object entityObj = DataAccessObject.GetByID(typedKeyObject, parameters);

                foreach (EntitySecurityBase checker in this.SecurityCheckers)
                    checker.GetByID(keyValues, parameters, entityObj);

                onAfterGetByID(entityObj, typedKeyObject, parameters);
                return entityObj;
            }
            return null;
        }

        protected virtual bool onBeforeGetByID(object typedKeyObject, GetByIDParameters parameters)
        {
            return true;
        }

        protected virtual void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {

        }

        public long GetCount(FilterExpression filter)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");
            
            FilterExpression f = null;
            if (filter != null)
               f = (FilterExpression) filter.Clone();

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetCount(f);

            return DataAccessObject.GetCount(f);
        }


        /// <summary>
        /// Gets the maximum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public object GetMax(string columnName, FilterExpression filter)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            FilterExpression f = null;
            if (filter != null)
                f = (FilterExpression)filter.Clone();

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetMax(columnName, f);

            return this.DataAccessObject.GetMax(columnName, f);
        }

        /// <summary>
        /// Gets the maximum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public object GetMin(string columnName, FilterExpression filter)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            FilterExpression f = null;
            if (filter != null)
                f = (FilterExpression)filter.Clone();

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetMin(columnName, f);

            return this.DataAccessObject.GetMin(columnName, f);
        }

        /// <summary>
        /// Gets the avgerage value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public double GetAvg(string columnName, FilterExpression filter)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            FilterExpression f = null;
            if (filter != null)
                f = (FilterExpression)filter.Clone();

            foreach (EntitySecurityBase checker in this.SecurityCheckers)
                checker.GetAvg(columnName, f);

            return this.DataAccessObject.GetAvg(columnName, f);
        }



        #region Typed Functions


        /// <summary>
        /// Inserts the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void InsertT(T entitySet, InsertParameters parameters = null)
        {
            Insert(entitySet, parameters);
        }

        /// <summary>
        /// Updates the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void UpdateT(T entitySet, UpdateParameters parameters = null)
        {
            Update(entitySet, parameters);
        }

        /// <summary>
        /// Deletes the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        public void DeleteT(T entitySet, DeleteParameters parameters = null)
        {
            Delete(entitySet, parameters);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAllT()
        {
            IList<T> list = (IList<T>) GetAll();
            //return (ICollection<T>) (object) GetAll();
            return list;
        }

        /// <summary>
        /// Gets the by filter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<T> GetByFilterT(GetByFilterParameters parameters)
        {
            //IList<T> list = (IList<T>)GetByFilter(parameters);
            return (IList<T>)GetByFilter(parameters);
            //return list;
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public T GetByIDT(object keyValues, GetByIDParameters parameters = null)
        {
            return (T)GetByID(keyValues, parameters);
        }



        /// <summary>
        /// Gets all the records. (view data) It shouldn't be used unless the view has a few records for sure
        /// </summary>
        /// <returns></returns>
        public IList<V> GetAllV()
        {
            return (IList<V>)GetAll();
        }

        /// <summary>
        /// Gets the by filter. (view data)
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<V> GetByFilterV(GetByFilterParameters parameters)
        {
            Check.Assert(parameters != null);
            parameters.SourceType = GetSourceTypeEnum.View;
            return (IList<V>)GetByFilter(parameters);
        }

        /// <summary>
        /// Gets the by ID. (view data)
        /// </summary>
        /// <param name="keyValues">The key values</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public V GetByIDV(object keyValues, GetByIDParameters parameters = null)
        {
            if (parameters == null)
                parameters = new GetByIDParameters();
            parameters.SourceType = GetSourceTypeEnum.View;
            return (V)GetByID(keyValues, parameters);
        }

        #endregion


        /// <summary>
        /// Gets the key object.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        private object GetKeyObject(object keyValues)
        {
            if (keyValues is string)// if value was provided by user or as string, we need to convert it to its typed value
            {
                Check.Require(this.Entity.EntityColumns.ContainsKey(this.Entity.IDFieldName));

                string s = (string)keyValues;
                return FWUtils.EntityUtils.ConvertStringToObject(s, this.Entity.EntityColumns[this.Entity.IDFieldName].DataTypeDotNet);
            }
            else
                return keyValues;
        }



        /// <summary>
        /// Does the entity action batch.
        /// </summary>
        /// <param name="recordIDsCommaSeparated">The record ids.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameters">The parameters.</param>
        public void DoBatchAction(string recordIDsCommaSeparated, string actionName, string parameters)
        {
            Check.Require(recordIDsCommaSeparated != null, "recordIds can not be null in DoEntityActionBatch function");
            Check.Require(string.IsNullOrEmpty(actionName) == false, "actionName can not be null or empty in DoEntityActionBatch function");

            string[] recordIds = recordIDsCommaSeparated.Split(',');

            bool addRowIndexToError = false;
            if (recordIDsCommaSeparated.Length > 0)
                addRowIndexToError = true;

            StringBuilder ErrorsList = new StringBuilder();

            string actionTitle = this.Entity.FindActionByName(actionName).Caption;

            for (int i = 0; i < recordIds.Length; i++ )
            {
                try
                {
                    if (string.IsNullOrEmpty(recordIds[i]) == false)
                    {
                        DoAction(recordIds[i], actionName, parameters);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = FWUtils.WebUIUtils.GetExtExceptionMessageString(ex, true);
                    if (addRowIndexToError)
                        ErrorsList.Append(StringMsgs.GeneralMessages.ErrorInRow).Append(" ").Append(i).Append(": ");
                    ErrorsList.AppendLine(errorMsg);
                }
            }

            string errors = ErrorsList.ToString();
            if (string.IsNullOrEmpty(errors) == false)
                throw new UserException(errors);

            //if (recordIds.Length == 1)
            //    return string.Format(StringMsgs.GeneralMessages.Operation_ActionTitle_DoneSuccessfully, actionTitle);
            //else
            //    return string.Format(StringMsgs.GeneralMessages.Operation_ActionTitle_DoneSuccessfullyOn_X_Items, actionTitle, recordIds.Length);
        }

        /// <summary>
        /// Does the entity action.
        /// </summary>
        /// <param name="recordIds">The recordID</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameters">The parameters.</param>
        public virtual void DoAction(string recordId, string actionName, string parameters)
        {

        }


    }
}
