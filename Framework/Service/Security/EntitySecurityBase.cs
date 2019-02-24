using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Common;

namespace Framework.Service
{

    /// <summary>
    /// General class to check entity securities
    /// </summary>
    public abstract class EntitySecurityBase
    {

        /// <summary>
        /// Gets or sets a value indicating whether [disabled].
        /// If disabled, security won't be active
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disabled]; otherwise, <c>false</c>.
        /// </value>
        public bool Disabled { get; set; }

        private IServiceBase Service;

        protected EntityInfoBase Entity { get { return Service.Entity; } }


        public EntitySecurityBase(IServiceBase service)
        {
            Service = service;
        }

        public abstract void Insert(object entitySet, InsertParameters parameters);
        public abstract void Update(object entitySet, UpdateParameters parameters);
        public abstract void Delete(object entitySet, DeleteParameters parameters);
        public abstract void GetAll();
        public abstract void GetByFilter(GetByFilterParameters parameters);
        public abstract void GetByID(object keyValues, GetByIDParameters parameters, object entitySet);
        public abstract void GetAvg(string columnName, FilterExpression f);
        public abstract void GetMin(string columnName, FilterExpression f);
        public abstract void GetMax(string columnName, FilterExpression f);
        public abstract void GetCount(FilterExpression f);

    }


}
