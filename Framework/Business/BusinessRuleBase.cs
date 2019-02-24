using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Common.Exceptions;
using Framework.DataAccess;
using System.Collections.ObjectModel;

namespace Framework.Business
{
    /// <summary>
    /// Base class for checking business rules
    /// </summary>
    public class BusinessRuleBase<T, V> : IBusinessRuleBase<T, V>
    {

        #region Initialization

        public const string ClassPostFix = "BR";


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


        private BusinessRulesCheckUtils _CheckUtils;

        protected BusinessRulesCheckUtils CheckUtils { get { return _CheckUtils; } }




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
            _DataAccessObject = EntityFactory.GetEntityDataAccessByName(this.EntityName, this.AdditionalDataKey);
            _CheckUtils = new BusinessRulesCheckUtils(this);
            _IsInitialized = true;
        }

        #endregion



        private IDataAccessBase _DataAccessObject;

        /// <summary>
        /// Gets the data access object.
        /// </summary>
        /// <value>
        /// The data access object.
        /// </value>
        protected IDataAccessBase DataAccessObject
        {
            get
            {
                return _DataAccessObject;
            }
        }

        /// <summary>
        /// Inserts the specified parameters.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="BRException"></exception>
        public void Insert(object entitySet, InsertParameters parameters)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            BusinessRuleErrorList errors = new BusinessRuleErrorList();

            CheckRules(entitySet, RuleFunctionSEnum.Insert, errors);

            CheckDetailEntityRules(parameters.DetailEntityObjects, errors);

            if (errors.Count > 0) throw new BRException(errors);

            this.DataAccessObject.Insert(entitySet, parameters);
        }

        /// <summary>
        /// Checks the detail entity rules.
        /// </summary>
        /// <param name="detailList">The list.</param>
        /// <param name="fnName">Name of the function.</param>
        /// <param name="errors">The errors.</param>
        private void CheckDetailEntityRules(List<DetailObjectInfo> detailList, BusinessRuleErrorList errors)
        {
            if (detailList == null)
                return;

            foreach (var detailInfo in detailList)
            {
                string entityName = detailInfo.EntityName;
                IBusinessRuleBase biz = EntityFactory.GetEntityBusinessRuleByName(entityName, detailInfo.AdditionalDataKey);
                biz.CheckRules(detailInfo.EntitySet, detailInfo.FnName, errors);
            }
        }

        /// <summary>
        /// Updates the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="BRException"></exception>
        public void Update(object entitySet, UpdateParameters parameters)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            BusinessRuleErrorList errors = new BusinessRuleErrorList();

            CheckRules(entitySet, RuleFunctionSEnum.Update, errors);

            CheckDetailEntityRules(parameters.DetailEntityObjects, errors);

            if (errors.Count > 0) throw new BRException(errors);

            this.DataAccessObject.Update(entitySet, parameters);
        }

        /// <summary>
        /// Deletes the specified entity set.
        /// It doesn't delete weak entititied included here, unless database does it using integrity rules
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="BRException"></exception>
        public void Delete(object entitySet, DeleteParameters parameters)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            BusinessRuleErrorList errors = new BusinessRuleErrorList();

            CheckRules(entitySet, RuleFunctionSEnum.Delete, errors);

            if (errors.Count > 0) throw new BRException(errors);

            this.DataAccessObject.Delete(entitySet, parameters);
        }

        /// <summary>
        /// Gets all the records. It shouldn't be used unless the table has a few records for sure
        /// </summary>
        /// <returns></returns>
        public System.Collections.IList GetAll()
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");
            
            return this.DataAccessObject.GetAll();
        }

        /// <summary>
        /// Gets the by filter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public System.Collections.IList GetByFilter(GetByFilterParameters parameters)
        {
            return this.DataAccessObject.GetByFilter(parameters);
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object GetByID(object keyValues, GetByIDParameters parameters)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            return this.DataAccessObject.GetByID(keyValues, parameters);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public long GetCount(FilterExpression filter)
        {
            Check.Require(_IsInitialized, "The class is not initialized yet.");

            return this.DataAccessObject.GetCount(filter);
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

            return this.DataAccessObject.GetMax(columnName, filter);
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

            return this.DataAccessObject.GetMin(columnName, filter);
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

            return this.DataAccessObject.GetAvg(columnName, filter);
        }



        /// <summary>
        /// Checks the rules.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="fnName">Name of the fn.</param>
        /// <param name="errors">The errors.</param>
        public virtual void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            CheckAutomatedRules(entitySet, fnName, errors);
        }


        protected virtual void CheckAutomatedRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            foreach (var colInfo in this.Entity.EntityColumns)
            {
                ColumnInfo col = colInfo.Value;

                if (
                       (col.IsUpdatable && fnName == RuleFunctionSEnum.Update)
                    || (col.IsInsertable && fnName == RuleFunctionSEnum.Insert)
                    )
                {
                    object val = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, col.Name);

                    // check allow blank for all types
                    if (col.ValidationIsNullable == false)
                    {
                        if (val == null)
                        {
                            errors.Add(col.Name, string.Format(StringMsgs.BusinessErrors.NotNull, col.Caption));
                            continue;
                        }
                        // TODO: fix foreign key integer value checking for int
                        //// for integer values if the column is id column, we check not to enter -1 value (that is the default for not having a value)
                        //if (col.Name.EndsWith("ID") && (val is Int16 || val is Int32 || val is Int64))
                        //    if (Convert.ToInt64(val) == -1)
                        //    {
                        //        errors.Add(col.Name, string.Format(StringMsgs.BusinessErrors.NotNull, col.Caption));
                        //        continue;
                        //    }
                    }

                    // checking string length
                    if (col.DataTypeDotNet == typeof(string))
                    {
                        if (col.ValidationIsNullable == false && ((string) val) == "")
                            errors.Add(col.Name, string.Format(StringMsgs.BusinessErrors.StringNotNullOrEmpty, col.Caption));

                        CheckUtils.CheckStringLenBetweenMinAndMax(col.Name, (string) val, errors, col.ValidationMinLength, col.ValidationMaxLength);
                    }

                    // checking minimum maximum value if existed
                    if (col.ValidationMaxValue != null || col.ValidationMinValue != null)
                    {
                        if (col.DataTypeDotNet == typeof(int))
                            CheckUtils.CheckIntBetweenMinMax(col.Name, (int) val, errors, (int?)col.ValidationMinValue, (int?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(long))
                            CheckUtils.CheckLongBetweenMinMax(col.Name, (long)val, errors, (long?)col.ValidationMinValue, (long?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(double))
                            CheckUtils.CheckDoubleBetweenMinMax(col.Name, (double)val, errors, (double?)col.ValidationMinValue, (double?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(float))
                            CheckUtils.CheckFloatBetweenMinMax(col.Name, (float)val, errors, (float?)col.ValidationMinValue, (float?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(decimal))
                            CheckUtils.CheckDecimalBetweenMinMax(col.Name, (decimal)val, errors, (decimal?)col.ValidationMinValue, (decimal?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(DateTime))
                            CheckUtils.CheckDateTimeBetweenMinMax(col.Name, (DateTime)val, errors, (DateTime?)col.ValidationMinValue, (DateTime?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(short))
                            CheckUtils.CheckShortBetweenMinMax(col.Name, (short)val, errors, (short?)col.ValidationMinValue, (short?)col.ValidationMaxValue);
                        else if (col.DataTypeDotNet == typeof(byte))
                            CheckUtils.CheckByteBetweenMinMax(col.Name, (byte)val, errors, (byte?)col.ValidationMinValue, (byte?)col.ValidationMaxValue);
                    }

                    // duplicate check
                    if (errors.Count == 0 && col.ValidationNoDuplicate) // Perfomance: We check database only if no error is there.
                    {
                        object idValue = ((EntityObjectBase)entitySet).GetPrimaryKeyValue();
                        CheckUtils.CheckDuplicateValueNotToBeExists(col.Name, val, idValue, errors, null, fnName == RuleFunctionSEnum.Insert, null);
                    }


                } // end of if column should be validated or not
            } // end foreach column
        }


        #region Typed Functions


        /// <summary>
        /// Checks the rules.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="fnName">Name of the fn.</param>
        /// <param name="errors">The errors.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CheckRulesT(T entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            CheckRules(entitySet, fnName, errors);
        }

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
        /// <param name="parameters">The parameters.</param>
        public void UpdateT(T entitySet, UpdateParameters parameters)
        {
            Update(entitySet, parameters);
        }

        /// <summary>
        /// Deletes the specified entity set.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="parameters">The parameters.</param>
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
            parameters.SourceType = GetSourceTypeEnum.View;
            return (IList<V>)GetByFilter(parameters);
        }

        /// <summary>
        /// Gets the by ID. (view data)
        /// </summary>
        /// <param name="keyValues">The key values</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public V GetByIDV(object keyValues, GetByIDParameters parameters)
        {
            parameters.SourceType = GetSourceTypeEnum.View;
            return (V)GetByID(keyValues, parameters);
        }


        #endregion






    }
}
