//#DONT REGENERATE
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Framework.Common;
using Framework.Common.Entity;
using System.Diagnostics.CodeAnalysis;


namespace UTD.Tricorder.Common.EntityObjects
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class AppLog : EntityObjectBase, Framework.Common.Logging.IAppLog
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public AppLog(short logTypeId)
        {
            _applogid = -1;
            _applogtypeid = logTypeId;
            _userid = null;
            _insertdate = DateTime.MinValue;
            _ipaddress = null;
            _extrastring1 = null;
            _extrastring2 = null;
            _extraint = null;
            _extradouble = null;
            _extrabigint = null;
            _extraguid = null;
        }

        #endregion

        public const string EntityName = "AppLog";

        #region ColumnNames Class

        public static class ColumnNames
        {
            public const string AppLogID = "AppLogID";
            public const string AppLogTypeID = "AppLogTypeID";
            public const string UserID = "UserID";
            public const string InsertDate = "InsertDate";
            public const string IPAddress = "IPAddress";
            public const string ExtraString1 = "ExtraString1";
            public const string ExtraString2 = "ExtraString2";
            public const string ExtraInt = "ExtraInt";
            public const string ExtraDouble = "ExtraDouble";
            public const string ExtraBigInt = "ExtraBigInt";
            public const string ExtraGuid = "ExtraGuid";
        }


        private static List<String> _ColumnsList;

        public static List<String> GetColumnNamesList()
        {
            if (_ColumnsList != null)
                return _ColumnsList;

            _ColumnsList = new List<string>();
            _ColumnsList.Add("AppLogID");
            _ColumnsList.Add("AppLogTypeID");
            _ColumnsList.Add("UserID");
            _ColumnsList.Add("InsertDate");
            _ColumnsList.Add("IPAddress");
            _ColumnsList.Add("ExtraString1");
            _ColumnsList.Add("ExtraString2");
            _ColumnsList.Add("ExtraInt");
            _ColumnsList.Add("ExtraDouble");
            _ColumnsList.Add("ExtraBigInt");
            _ColumnsList.Add("ExtraGuid");

            return _ColumnsList;
        }

        #endregion // end columnNames class

        #region Private Members

        private long _applogid;
        private short _applogtypeid;
        private long? _userid;
        private DateTime _insertdate;
        private string _ipaddress;
        private string _extrastring1;
        private string _extrastring2;
        private int? _extraint;
        private double? _extradouble;
        private long? _extrabigint;
        private Guid? _extraguid;
        #endregion

        #region Constructor

        public AppLog()
        {
            _applogid = -1;
            _applogtypeid = -1;
            _userid = null;
            _insertdate = DateTime.MinValue;
            _ipaddress = null;
            _extrastring1 = null;
            _extrastring2 = null;
            _extraint = null;
            _extradouble = null;
            _extrabigint = null;
            _extraguid = null;
        }

        public AppLog(
            long applogid,
            short applogtypeid,
            long? userid,
            DateTime insertdate)
            : this()
        {
            _applogid = applogid;
            _applogtypeid = applogtypeid;
            _userid = userid;
            _insertdate = insertdate;
            _ipaddress = null;
            _extrastring1 = null;
            _extrastring2 = null;
            _extraint = null;
            _extradouble = null;
            _extrabigint = null;
            _extraguid = null;
        }
        #endregion // End Constructor

        #region Public Properties

        public virtual long AppLogID
        {
            get
            {
                return _applogid;
            }
            set
            {
                _applogid = value;
            }

        }

        public virtual short AppLogTypeID
        {
            get
            {
                return _applogtypeid;
            }
            set
            {
                _applogtypeid = value;
            }

        }

        public virtual long? UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }

        }

        public virtual DateTime InsertDate
        {
            get
            {
                return _insertdate;
            }

            set
            {
                //if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
                //	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

                _insertdate = value;
            }

        }

        public virtual string IPAddress
        {
            get
            {
                return _ipaddress;
            }

            set
            {
                //if(  value != null &&  value.Length > 50)
                //	throw new ArgumentOutOfRangeException("Invalid value for IPAddress", value, value.ToString());

                _ipaddress = value;
            }
        }

        public virtual string ExtraString1
        {
            get
            {
                return _extrastring1;
            }

            set
            {
                //if(  value != null &&  value.Length > 2147483647)
                //	throw new ArgumentOutOfRangeException("Invalid value for ExtraString1", value, value.ToString());

                _extrastring1 = value;
            }
        }

        public virtual string ExtraString2
        {
            get
            {
                return _extrastring2;
            }

            set
            {
                //if(  value != null &&  value.Length > 2147483647)
                //	throw new ArgumentOutOfRangeException("Invalid value for ExtraString2", value, value.ToString());

                _extrastring2 = value;
            }
        }

        public virtual int? ExtraInt
        {
            get
            {
                return _extraint;
            }
            set
            {
                _extraint = value;
            }

        }

        public virtual double? ExtraDouble
        {
            get
            {
                return _extradouble;
            }
            set
            {
                _extradouble = value;
            }

        }

        public virtual long? ExtraBigInt
        {
            get
            {
                return _extrabigint;
            }
            set
            {
                _extrabigint = value;
            }

        }

        public virtual Guid? ExtraGuid
        {
            get
            {
                return _extraguid;
            }
            set
            {
                _extraguid = value;
            }

        }


        #endregion

        #region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.AppLogID;

        }

        #endregion //Public Functions
    }
}
