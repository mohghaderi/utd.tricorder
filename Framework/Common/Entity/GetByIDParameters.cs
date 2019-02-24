using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Framework.Common
{
    public enum GetModeEnum
    {
        /// <summary>
        /// Get Mode only gets the object from the database and if not available it returns null
        /// </summary>
        Get=0,
        /// <summary>
        /// This loads the object from database, and if it was not available it returns an exception
        /// </summary>
        Load = 1
    }

    public enum LockModeEnum
    {
        /// <summary>
        /// Summary:
        ///     No lock required.
        ///
        /// Remarks:
        ///     If an object is requested with this lock mode, a Read lock might be obtained
        ///     if necessary.
        /// </summary>
        None = 0,
        /// <summary>
        /// //
        /// Summary:
        ///     A shared lock.
        ///
        /// Remarks:
        ///     Objects are loaded in Read mode by default
        /// </summary>
        Read,
        /// <summary>
        ///
        /// Summary:
        ///     An upgrade lock.
        ///
        /// Remarks:
        ///     Objects loaded in this lock mode are materialized using an SQL SELECT ...
        ///     FOR UPDATE
        /// </summary>
        Upgrade,
       
        /// <summary>
        ///
        /// Summary:
        ///     Attempt to obtain an upgrade lock, using an Oracle-style SELECT ... FOR UPGRADE
        ///     NOWAIT.
        ///
        /// Remarks:
        ///     The semantics of this lock mode, once obtained, are the same as Upgrade
        /// </summary>
        UpgradeNoWait,

        /// <summary>
        ///
        /// Summary:
        ///     A Write lock is obtained when an object is updated or inserted.
        ///
        /// Remarks:
        ///     This is not a valid mode for Load() or Lock().
        /// </summary>
        Write,
        /// <summary>
        ///   Similar to NHibernate.LockMode.Upgrade except that, for versioned entities,
        ///     it results in a forced version increment.
        /// </summary>
        Force,
    }

    /// <summary>
    /// Class to define parameters used by GetByID function in framework layers
    /// </summary>
    public class GetByIDParameters
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIDParameters"/> class.
        /// </summary>
        public GetByIDParameters()
            : this(GetSourceTypeEnum.Table, GetModeEnum.Get, LockModeEnum.None)
        {
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIDParameters"/> class.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        public GetByIDParameters(GetSourceTypeEnum sourceType)
            : this(sourceType, GetModeEnum.Get, LockModeEnum.None)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIDParameters"/> class.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="getMode">The get mode.</param>
        public GetByIDParameters(GetSourceTypeEnum sourceType, GetModeEnum getMode)
            : this(sourceType, getMode, LockModeEnum.None)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByIDParameters"/> class.
        /// </summary>
        /// <param name="getMode">The get mode.</param>
        /// <param name="lockMode">The lock mode.</param>
        public GetByIDParameters(GetSourceTypeEnum sourceType, GetModeEnum getMode, LockModeEnum lockMode)
        {
            _GetMode = getMode;
            _LockMode = lockMode;
            _SourceType = sourceType;
        }


        #endregion




        private LockModeEnum _LockMode;

        /// <summary>
        /// Gets or sets the lock mode.
        /// </summary>
        /// <value>
        /// The lock mode.
        /// </value>
        public LockModeEnum LockMode
        {
            get { return _LockMode; }
            set { _LockMode = value; }
        }


        private GetModeEnum _GetMode;

        /// <summary>
        /// Gets or sets the get mode.
        /// </summary>
        /// <value>
        /// The get mode.
        /// </value>
        public GetModeEnum GetMode
        {
            get { return _GetMode; }
            set { _GetMode = value; } 
        }


        private GetSourceTypeEnum _SourceType;

        /// <summary>
        /// Gets or sets the type of the source.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public GetSourceTypeEnum SourceType
        {
            get { return _SourceType; }
            set { _SourceType = value; }
        }



        public NHibernate.LockMode GetNHibernateLockMode()
        {
            var mode = this.LockMode;
            switch (mode)
            {
                case LockModeEnum.None:
                    return NHibernate.LockMode.None;

                case LockModeEnum.Read:
                    return NHibernate.LockMode.Read;

                case LockModeEnum.Upgrade:
                    return NHibernate.LockMode.Upgrade;

                case LockModeEnum.UpgradeNoWait:
                    return NHibernate.LockMode.UpgradeNoWait;

                case LockModeEnum.Write:
                    return NHibernate.LockMode.Write;

                case LockModeEnum.Force:
                    return NHibernate.LockMode.Force;
                default:
                    throw new NotImplementedException("GetLockModeByEnum not implemented for mode: " + Enum.GetName(typeof(LockModeEnum), mode));
            }

        }


    }
}
