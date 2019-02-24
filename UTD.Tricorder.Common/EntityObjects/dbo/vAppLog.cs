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
	public partial class vAppLog : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

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
			public const string AppLogTypeName = "AppLogTypeName";
			public const string UserName = "UserName";
			public const string FirstName = "FirstName";
			public const string LastName = "LastName";
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
			_ColumnsList.Add("AppLogTypeName");
			_ColumnsList.Add("UserName");
			_ColumnsList.Add("FirstName");
			_ColumnsList.Add("LastName");

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
		private string _applogtypename; 
		private string _username; 
		private string _firstname; 
		private string _lastname; 		
		#endregion

		#region Constructor

		public vAppLog()
		 //: base()
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
			_applogtypename = null; 
			_username = null; 
			_firstname = null; 
			_lastname = null; 
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
			
		public virtual string AppLogTypeName
		{
			get
			{ 
				return _applogtypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppLogTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppLogTypeName", value, value.ToString());
				
				_applogtypename = value;
			}
		}
			
		public virtual string UserName
		{
			get
			{ 
				return _username;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				_username = value;
			}
		}
			
		public virtual string FirstName
		{
			get
			{ 
				return _firstname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FirstName", value, value.ToString());
				
				_firstname = value;
			}
		}
			
		public virtual string LastName
		{
			get
			{ 
				return _lastname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for LastName", value, value.ToString());
				
				_lastname = value;
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
