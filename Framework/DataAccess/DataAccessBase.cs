using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using NHibernate;
using System.Collections.ObjectModel;
using NHibernate.Criterion;
using System.Text;

namespace Framework.DataAccess
{
    // TODO: Apply performance:
    // in NHibernate config : <property name="connection.isolation">ReadUncommitted</property>
    // http://stackoverflow.com/questions/1302746/how-do-add-nolock-with-nhibernate
    // Here for GetByID : Session.BeginTransaction(IsolationLevel.ReadCommitted);
    // This should be done to increase listing performance

    //TODO: BUG: There is a bug in DataAccess. When we Insert an object in Table, get it from its view (GetByID) and try to save it again to Table
    // NHibernate mistakenly wants to update in View causes error. The problem may caused by HashCode of both Table and View entities or it may simply
    // because of a bug in nHibernate. To temprorary fix this problem, I added this line in all Get functions:
    // NHibernateSession.Clear(); // temprorary fix for DataAccess bug.
    // In the future, it is better to add dynamic-update=true in xml files and allow-insert=false allow-update=false for all fields in view, and use only one view or table entity
    // it is possible to use view entities for updating if we try to fix this problem.
    // In fact, we should return to our first design when we only had our View entities without table entities

    //TODO: Add a property to all entities that we read only a few columns to know them,
    // and throw an exception when the developer wanted to save them because they don't have all columns
    // NHibernate can't save them correctly.


    /// <summary>
    /// Base class to access entities
    /// </summary>
    /// <typeparam name="T">Table EntityObjectBase class</typeparam>
    /// <typeparam name="V">View EntityObjectBase class</typeparam>
    public class DataAccessBase<T, V> : IDataAccessBaseT<T, V>
    {
        #region Initialization

        public const string ClassPostFix = "DA";


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

        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
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
            this.AutoSave = true;
            _IsInitialized = true;
        }

        #endregion

        public bool AutoSave { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            try // adding try catch to fix bug of exception after flush
            // When we flush and an exception happens, Nhibernate doesn't remove error commands
            // So, when we want to work again with context, it still wants to execute the error command
            // NHibernateSession.Reconnect(); to reset all actions in the case of an exception
            {
                if (DBContext.HasOpenTransaction())
                {
                    DBContext.CommitTransaction();
                }
                else
                {
                    // If there's no transaction, just flush the changes
                    NHibernateSession.Flush();
                }
            }
            catch (NHibernate.ADOException)
            {
                try
                {
                    if (DBContext.HasOpenTransaction())
                        DBContext.RollbackTransaction();
                }
                catch (Exception)
                {
                }

                try
                {
                    // cancels all pending insert/updating (making further execution available like inserting logs)
                    // we need to close session after any exception
                    // http://stackoverflow.com/questions/493660/nhibernate-handling-an-itransaction-exception-so-that-new-transactions-can-cont
                    // It's not possible to re-use an NHibernate session after an exception is thrown. Quoting the documentation:
                    
                    // If the ISession throws an exception you should immediately rollback the
                    // transaction, call ISession.Close() and discard the ISession instance.
                    // Certain methods of ISession will not leave the session in a consistent state.
                    // TODO: Verify that transactional exceptions will also get the session close everywhere.

                    NHibernateSessionManager.Instance.GetContextByName(this.ContextName).CloseSession(); 
                }
                catch (Exception)
                {

                }

                //try
                //{
                //    NHibernateSession.Reconnect();
                //}
                //catch (Exception)
                //{
                //}

                throw;
            }
            catch (NHibernate.StaleObjectStateException ex)
            {
                throw new ObjectChangedBeforeUpdate(StringMsgs.Exceptions.ObjectChangedBeforeUpdate, ex);
            }
            catch (Exception)
            {
                //try
                //{
                    try
                    {
                        if (DBContext.HasOpenTransaction())
                            DBContext.RollbackTransaction();
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        // cancels all pending insert/updating (making further execution available like inserting logs)
                        NHibernateSessionManager.Instance.GetContextByName(this.ContextName).CloseSession();
                    }
                    catch (Exception)
                    {

                    }

                //    NHibernateSession.Reconnect();
                //}
                //catch (NHibernate.HibernateException ex2)
                //{
                //    if (ex2.Message != "session already connected")
                //        throw;
                //}
                throw;
            }
        }


        /// <summary>
        /// Inserts the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Insert(object entitySet, InsertParameters parameters)
        {
            SetEntityObjectAutomaticValueForInsert(entitySet);
            if (parameters.DetailEntityObjects == null
               || parameters.DetailEntityObjects.Count == 0)
            {
                NHibernateSession.Save(entitySet);
                if (this.AutoSave)
                    SaveChanges();
            }
            else
            {
                using (var tx = NHibernateSession.BeginTransaction())
                {
                    NHibernateSession.Save(entitySet);
                    AutoSetDetailFK((EntityObjectBase) entitySet, parameters.DetailEntityObjects);
                    SaveDetailEntities(parameters.DetailEntityObjects);
                    tx.Commit();
                }
                //SaveChanges(); no save is required.
            }
        }

        /// <summary>
        /// Sets the entity object automatic value for insert.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        private void SetEntityObjectAutomaticValueForInsert(object entitySet)
        {
            if (entitySet == null)
                return;

            var idValue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, this.Entity.IDFieldName);
            if (idValue is Guid)
                if ((Guid)idValue == Guid.Empty)
                    FWUtils.EntityUtils.SetObjectFieldValue(this.Entity.IDFieldName, entitySet, Guid.NewGuid());


            string currentUser = FWUtils.SecurityUtils.GetCurrentUserIDString();
            //if (FWUtils.EntityUtils.ObjectHasProperty(entitySet, "InsertUserID"))
            try
            {
                FWUtils.EntityUtils.SetEntityFieldValueString(this.Entity, "InsertUserID", entitySet, currentUser);
            }
            catch (FWPropertyNotFoundException)
            {
            }
            //if (FWUtils.EntityUtils.ObjectHasProperty(entitySet, "InsertDate"))
            try
            {
                FWUtils.EntityUtils.SetObjectFieldValue("InsertDate", entitySet, DateTime.UtcNow);
            }
            catch (FWPropertyNotFoundException){}
        }

        /// <summary>
        /// Sets the entity object automatic value for update.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        private void SetEntityObjectAutomaticValueForUpdate(object entitySet)
        {
            if (entitySet == null)
                return;

            string currentUser = FWUtils.SecurityUtils.GetCurrentUserIDString();
            //if (FWUtils.EntityUtils.ObjectHasProperty(entitySet, "UpdateUserID"))
            try
            {
                FWUtils.EntityUtils.SetEntityFieldValueString(this.Entity, "UpdateUserID", entitySet, currentUser);
            }
            catch (FWPropertyNotFoundException) { }
            //if (FWUtils.EntityUtils.ObjectHasProperty(entitySet, "UpdateDate"))
            try
            {
                FWUtils.EntityUtils.SetObjectFieldValue("UpdateDate", entitySet, DateTime.UtcNow);
            }
            catch (FWPropertyNotFoundException) { }
        }


        /// <summary>
        /// Sets the forieng key of the detail entity automatically based on the master entity
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="detailList">The detail list.</param>
        private void AutoSetDetailFK(EntityObjectBase entitySet, List<DetailObjectInfo> detailList)
        {
            if (detailList == null)
                return;
            
            object masterIdValue = entitySet.GetPrimaryKeyValue();

            foreach (var detailInfo in detailList)
            {
                if (string.IsNullOrEmpty(detailInfo.FKColumnNameForAutoSet) == false)
                {
                    FWUtils.EntityUtils.SetObjectFieldValue(detailInfo.FKColumnNameForAutoSet, detailInfo.EntitySet, masterIdValue);
                }
            }
        }

        protected void SaveDetailEntities(List<DetailObjectInfo> detailList)
        {
            if (detailList == null)
                return;

            foreach (var detailInfo in detailList)
            {
                IDataAccessBase da = EntityFactory.GetEntityDataAccessByName(detailInfo.EntityName, detailInfo.AdditionalDataKey);
                da.AutoSave = false;
                if (detailInfo.FnName == RuleFunctionSEnum.Insert)
                    da.Insert(detailInfo.EntitySet, new InsertParameters());
                else if (detailInfo.FnName == RuleFunctionSEnum.Update)
                    da.Update(detailInfo.EntitySet, new UpdateParameters());
                else if (detailInfo.FnName == RuleFunctionSEnum.Delete)
                    da.Delete(detailInfo.EntitySet, new DeleteParameters());
                else
                    throw new Exception("Function " + detailInfo.FnName + " is not defined in DataAccessLayer");
            }
        }


        /// <summary>
        /// Updates the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Update(object entitySet, UpdateParameters parameters)
        {
            SetEntityObjectAutomaticValueForUpdate(entitySet);

            if (parameters.DetailEntityObjects == null
                || parameters.DetailEntityObjects.Count == 0)
            {
                // update without transaction
                NHibernateSession.SaveOrUpdate(entitySet);
                if (this.AutoSave)
                    SaveChanges();
            }
            else
            {
                // update with transaction
                //TODO: It needs to use dataaccess layer of that entity
                using (var tx = NHibernateSession.BeginTransaction())
                {
                    NHibernateSession.SaveOrUpdate(entitySet);
                    SaveDetailEntities(parameters.DetailEntityObjects);
                    tx.Commit();
                }
                if (this.AutoSave)
                    SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified entity set.
        /// It doesn't delete weak entititied included here, unless database does it using integrity rules
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void Delete(object entitySet, DeleteParameters parameters)
        {
            if (parameters.DetailEntityObjects == null
                || parameters.DetailEntityObjects.Count == 0)
            {
                // delete without transaction
                NHibernateSession.Delete(entitySet);
                if (this.AutoSave)
                    SaveChanges();
            }
            else
            {
                // update with transaction
                //TODO: It needs to use dataaccess layer of that entity
                using (var tx = NHibernateSession.BeginTransaction())
                {
                    NHibernateSession.Delete(entitySet);
                    SaveDetailEntities(parameters.DetailEntityObjects);
                    tx.Commit();
                }
                if (this.AutoSave)
                    SaveChanges();
            }

        }

        /// <summary>
        /// Gets all the records. It shouldn't be used unless the table has a few records for sure
        /// </summary>
        /// <returns></returns>
        public System.Collections.IList GetAll()
        {
            //NHibernateSession.Clear(); // temprorary fix for Dataaccess bug

            ICriteria criteria = NHibernateSession.CreateCriteria(persistentTypeT);
            return criteria.List<T>() as List<T>;
        }

        /// <summary>
        /// Gets the by filter.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public System.Collections.IList GetByFilter(GetByFilterParameters parameters)
        {
            //NHibernateSession.Clear(); // temprorary fix for Dataaccess bug

            // used from http://ayende.com/blog/4023/nhibernate-queries-examples

            string selectColumns = "";
            SortExpression sort = parameters.Sort;
            FilterExpression filter = parameters.Filter;
            int pageIndex = parameters.PageIndex;
            int pageSize = parameters.PageSize;
            if (pageSize == -1) // invalid value
                pageSize = this.Entity.DefaultPageSize;

            // Column Names
            ICollection<string> colNames = parameters.SelectColumns;
            if (colNames != null && colNames.Count > 0)
            {
                // adding ID field name to any select from the database to prevent null (-1) id problems
                if (string.IsNullOrEmpty(this.Entity.IDFieldName) == false)
                {
                    if (colNames.Contains(this.Entity.IDFieldName) == false)
                        colNames.Add(this.Entity.IDFieldName);
                }
                selectColumns = "Select ";
                int i = 0;
                foreach (string col in colNames)
                {
                    selectColumns += col;
                    if (i != colNames.Count - 1)
                        selectColumns += ",";
                    else
                        selectColumns += " ";
                    i++;
                }
            }

            // sort
            string sortString = sort.GetSortExpressionString();
            if (string.IsNullOrEmpty(sortString) == false)
                sortString = " Order By " + sortString;

            // adding filter
            List<object> parameterValues = new List<object>();
            string filterString = filter.GetFilterString(parameterValues);
            if (string.IsNullOrEmpty(filterString) == false)
                filterString = " Where (" + filterString + ")";

            string hqlQuery = selectColumns + "from " + this.GetTableName(parameters.SourceType) + filterString + sortString;
            hqlQuery = hqlQuery.Replace("[", "").Replace("]", "");
            var query = NHibernateSession.CreateQuery(hqlQuery);

            // adding parameters
            for (int i = 0; i < parameterValues.Count; i++)
            {
                string paramName = Filter.ParameterPrefix.Substring(1) + i;
                if (parameterValues[i] is System.Collections.ICollection)  // for in operator, we can have a list of items. It works in HQL, but we need to pass it as parameterList
                    // read more here: http://stackoverflow.com/questions/3390561/nhibernate-update-single-field-without-loading-entity
                    query.SetParameterList(paramName, (System.Collections.ICollection)parameterValues[i]);
                else
                    query.SetParameter(paramName, parameterValues[i]);
            }

            // set paging
            query.SetFirstResult(pageIndex * pageSize).SetMaxResults(pageSize);

            if (colNames == null)
            {
                if (parameters.SourceType == GetSourceTypeEnum.Table)
                    return query.List<T>() as List<T>;
                else
                    return query.List<V>() as List<V>;
            }
            else
            {
                var list = query.List();
                return ConvertToTypedList(parameters.SourceType, colNames, list);
            }
        }

        protected System.Collections.IList ConvertToTypedList(GetSourceTypeEnum sourceType, ICollection<string> colNames, System.Collections.IList list)
        {
            System.Collections.IList resultList = null;
            if (sourceType == GetSourceTypeEnum.Table)
                resultList = new List<T>();
            else
                resultList = new List<V>();

            foreach (var item in list)
            {
                int i = 0;
                object obj = EntityFactory.GetEntityObject(this.EntityName, sourceType);
                foreach (string colName in colNames)
                {
                    //obj.GetType().GetProperty(fieldName)
                    if (item is object[])
                    {
                        object value = ((object[])item)[i];
                        FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, colName, obj, value);
                    }
                    else                     
                        // when we have only one column, then item is not object[]
                    {
                        object value = item;
                        FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, colName, obj, value);
                    }
                    i++;
                }
                resultList.Add(obj);
            }

            return resultList;
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public object GetByID(object keyValues, GetByIDParameters parameters)
        {
            NHibernateSession.Clear(); // it should get the object freshly from database to avoid inconsistency

            object id = keyValues;

            object entity = null;

            var persistentType = persistentTypeT;
            if (parameters.SourceType == GetSourceTypeEnum.View)
                persistentType = persistentTypeV;

            if (parameters.GetMode == GetModeEnum.Get)
            {
                entity = NHibernateSession.Get(persistentType, id, parameters.GetNHibernateLockMode());
            }
            else
            {
                entity = NHibernateSession.Load(persistentType, id, parameters.GetNHibernateLockMode());
            }

            //bool shouldLock = false;

            //if (shouldLock)
            //{
            //    //entity = NHibernateSession.Load(persitentType, id, LockMode.Upgrade);
            //    entity = NHibernateSession.Get(persitentType, id, LockMode.Upgrade);
            //}
            //else
            //{
            //    //entity = NHibernateSession.Load(persitentType, id);
            //    entity = NHibernateSession.Get(persitentType, id);
            //}

            return entity;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public long GetCount(FilterExpression filter)
        {
            if (filter == null)
                filter = new FilterExpression();

            // adding filter
            List<object> parameterValues = new List<object>();
            string filterString = filter.GetFilterString(parameterValues);
            if (string.IsNullOrEmpty(filterString) == false)
                filterString = " Where (" + filterString + ")";

            string hqlQuery = "Select count(*) from " + this.GetTableName(GetSourceTypeEnum.View) + filterString;
            hqlQuery = hqlQuery.Replace("[", "").Replace("]", "");
            var query = NHibernateSession.CreateQuery(hqlQuery);

            // adding parameters
            for (int i = 0; i < parameterValues.Count; i++)
            {
                query.SetParameter(Filter.ParameterPrefix.Substring(1) + i, parameterValues[i]);
            }

            var currentSeq = query.List();
            if (currentSeq == null)
                return 0;
            else
                return (long)currentSeq[0];

            // old way to do that. Filtering doesn't work here.

            //long rowCount = Convert.ToInt64(
            //    NHibernateSession.CreateCriteria(persistentTypeV)
            //    .SetProjection(Projections.RowCount()).UniqueResult());
            //return rowCount;
        }

        /// <summary>
        /// Gets the maximum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public object GetMax(string columnName, FilterExpression filter)
        {
            return GetAggregatedValue("max(" + columnName + ")", filter);
            //return NHibernateSession.CreateCriteria(persistentTypeT).SetProjection(Projections.Max(columnName)).UniqueResult();
        }


        private object GetAggregatedValue(string fnName, FilterExpression filter)
        {
            // adding filter
            List<object> parameterValues = new List<object>();
            string filterString = filter.GetFilterString(parameterValues);
            if (string.IsNullOrEmpty(filterString) == false)
                filterString = " Where (" + filterString + ")";

            string hqlQuery = "Select " + fnName + " from " + this.GetTableName(GetSourceTypeEnum.View) + filterString;
            hqlQuery = hqlQuery.Replace("[", "").Replace("]", "");
            var query = NHibernateSession.CreateQuery(hqlQuery);

            // adding parameters
            for (int i = 0; i < parameterValues.Count; i++)
            {
                query.SetParameter(Filter.ParameterPrefix.Substring(1) + i, parameterValues[i]);
            }

            var currentSeq = query.List();
            if (currentSeq == null)
                return null;
            else
                return currentSeq[0];
        }

        /// <summary>
        /// Gets the maximum value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public object GetMin(string columnName, FilterExpression filter)
        {
            return GetAggregatedValue("min(" + columnName + ")", filter);

            //return NHibernateSession.CreateCriteria(persistentTypeT).SetProjection(Projections.Max(columnName)).UniqueResult();
        }

        /// <summary>
        /// Gets the avgerage value of a column filter by an specified filter
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public double GetAvg(string columnName, FilterExpression filter)
        {
            return Convert.ToDouble(GetAggregatedValue("avg(" + columnName + ")", filter));
            //double avg = Convert.ToDouble(NHibernateSession.CreateCriteria(persistentTypeT).SetProjection(Projections.Avg(columnName)).UniqueResult());
            //return avg;
        }


        #region Typed Functions


        /// <summary>
        /// Inserts the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        public void InsertT(T entitySet, InsertParameters parameters)
        {
            Insert(entitySet, parameters);
        }

        /// <summary>
        /// Updates the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="checkConcurrency">if set to <c>true</c> [check concurrency].</param>
        public void UpdateT(T entitySet, UpdateParameters parameters)
        {
            Update(entitySet, parameters);
        }

        /// <summary>
        /// Deletes the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        public void DeleteT(T entitySet, DeleteParameters parameters)
        {
            Delete(entitySet, parameters);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAllT()
        {
            return (IList<T>)GetAll();
        }

        /// <summary>
        /// Gets the by filter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<T> GetByFilterT(GetByFilterParameters parameters)
        {
            return (IList<T>)GetByFilter(parameters);
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        public T GetByIDT(object keyValues, GetByIDParameters parameters)
        {
            return (T)GetByID(keyValues, parameters);
        }

        /// <summary>
        /// Gets all (view)
        /// </summary>
        /// <returns></returns>
        public IList<V> GetAllV()
        {
            ICriteria criteria = NHibernateSession.CreateCriteria(persistentTypeV);
            return criteria.List<V>() as List<V>;
        }

        /// <summary>
        /// Gets all the records. (view data) It shouldn't be used unless the view has a few records for sure
        /// </summary>
        /// <returns></returns>
        public IList<V> GetByFilterV(GetByFilterParameters parameters)
        {
            parameters.SourceType = GetSourceTypeEnum.View;
            return (IList<V>)GetByFilter(parameters);
        }

        public V GetByIDV(object keyValues, GetByIDParameters parameters)
        {
            parameters.SourceType = GetSourceTypeEnum.View;
            return (V)GetByID(keyValues, parameters);
        }





        #endregion




        #region NHibernate properties

        /// <summary>
        /// Gets the DB context.
        /// </summary>
        /// <value>
        /// The DB context.
        /// </value>
        protected NHibernateSessionContext DBContext
        {
            get { return NHibernateSessionManager.Instance.GetContextByName(this.ContextName); }
        }


        /// <summary>
        /// Gets the name of the context.
        /// </summary>
        /// <value>
        /// The name of the context.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        protected string ContextName
        {
            get { return this.Entity.ContextName; }
        }



        /// <summary>
        /// Exposes the ISession used within the DAO.
        /// </summary>
        protected ISession NHibernateSession
        {
            get
            {
                return NHibernateSessionManager.Instance.GetContextByName(this.ContextName).GetSession();
            }
        }

        protected Type persistentTypeT = typeof(T);
        protected Type persistentTypeV = typeof(V);

        #endregion


        #region Utilities


        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <returns></returns>
        private string GetTableName(GetSourceTypeEnum sourceType)
        {
            if (sourceType == GetSourceTypeEnum.Table)
                return this.Entity.ClassName;
            else
                return "v" + this.Entity.ClassName;

            //string entitySetName = this.Entity.EntityName;
            //Check.Require(string.IsNullOrEmpty(entitySetName) == false);

            //if (entitySetName.IndexOf(".") < 0)
            //{
            //    return entitySetName;
            //}
            //else
            //{
            //    char[] ch = new char[1];
            //    ch[0] = '.';
            //    string[] sepname = this.Entity.EntityName.Split(ch);
            //    string tableName = sepname[1];
            //    //if (string.IsNullOrEmpty(this.Entity.Schema) == false)
            //    //    tableName = this.Entity.Schema + "_" + tableName;
            //    return tableName;
            //}
        }


        ///// <summary>
        ///// Inserts the audit.
        ///// </summary>
        ///// <param name="data">The data.</param>
        ///// <param name="operation">The operation.</param>
        //protected void InsertAudit(object data, char operation)
        //{
        //    if (this.Entity.AuditLogEnabled == false)
        //        return;

        //    try
        //    {
        //        IAuditService auditService = (IAuditService)EntityFactory.GetEntityServiceByName("AuditLog", "");
        //        if (auditService != null)
        //        {
        //            string entityId = "";
        //            if (string.IsNullOrEmpty(this.Entity.IDFieldName) == false)
        //                entityId = FWUtils.EntityUtils.GetObjectFieldValueString(data, this.Entity.IDFieldName);

        //            string entityTitleFieldName = null;
        //            if (string.IsNullOrEmpty(this.Entity.TitleFieldName) == false)
        //                entityTitleFieldName = FWUtils.EntityUtils.GetObjectFieldValueString(data, this.Entity.TitleFieldName);

        //            int personID = (int)ConfigurationBase.DefaultInstance.CurrentPersonID;
        //            string changeString = null;
        //            auditService.InsertAudit(this.EntityName, entityId, entityTitleFieldName, personID, changeString, operation);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}


        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="parameterNames">The parameter names.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public System.Collections.IList ExecStoredProcedureQuery(string spName, List<string> parameterNames, List<object> parameterValues)
        {
            //IQuery query = this.NHibernateSession.GetNamedQuery(spName);
            //for (int i =0; i< parameterNames.Count; i++)
            //{
            //    query.SetParameter(parameterNames[i], parameterValues[i]);
            //}
            //return query.List();
            string pNamesString = "";
            for (int i = 0; i < parameterNames.Count; i++)
            {
                pNamesString += " ?";
                if (i != parameterNames.Count - 1)
                    pNamesString += ",";
            }

            // exec app.TimeSeries_SmallInt_Get ?, ?, ?, ?
            IQuery query = NHibernateSession.CreateSQLQuery(spName + pNamesString);

            for (int i = 0; i < parameterNames.Count; i++)
                query.SetParameter(i, parameterValues[i]);

            return query.List();
        }

        #endregion


    }
}
