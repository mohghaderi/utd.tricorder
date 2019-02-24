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
	public partial class vTestCaseTester : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TestCaseTester";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TestCaseTesterID = "TestCaseTesterID";
			public const string TestCaseTesterTitle = "TestCaseTesterTitle";
			public const string TestCaseTesterCode = "TestCaseTesterCode";
			public const string FieldGuid = "FieldGuid";
			public const string FieldByte = "FieldByte";
			public const string FieldInt16 = "FieldInt16";
			public const string FieldInt32 = "FieldInt32";
			public const string FieldInt64 = "FieldInt64";
			public const string FieldDouble = "FieldDouble";
			public const string FieldFloat = "FieldFloat";
			public const string FieldNtext = "FieldNtext";
			public const string FieldDateTime = "FieldDateTime";
			public const string FieldByteArray50 = "FieldByteArray50";
			public const string FieldVarByteArrayMax1024 = "FieldVarByteArrayMax1024";
			public const string FieldDecimal = "FieldDecimal";
			public const string FieldString = "FieldString";
			public const string FieldTimeStamp = "FieldTimeStamp";
			public const string InsertUser = "InsertUser";
			public const string InsertDate = "InsertDate";
			public const string UpdateUser = "UpdateUser";
			public const string UpdateDate = "UpdateDate";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TestCaseTesterID");
			_ColumnsList.Add("TestCaseTesterTitle");
			_ColumnsList.Add("TestCaseTesterCode");
			_ColumnsList.Add("FieldGuid");
			_ColumnsList.Add("FieldByte");
			_ColumnsList.Add("FieldInt16");
			_ColumnsList.Add("FieldInt32");
			_ColumnsList.Add("FieldInt64");
			_ColumnsList.Add("FieldDouble");
			_ColumnsList.Add("FieldFloat");
			_ColumnsList.Add("FieldNtext");
			_ColumnsList.Add("FieldDateTime");
			_ColumnsList.Add("FieldByteArray50");
			_ColumnsList.Add("FieldVarByteArrayMax1024");
			_ColumnsList.Add("FieldDecimal");
			_ColumnsList.Add("FieldString");
			_ColumnsList.Add("FieldTimeStamp");
			_ColumnsList.Add("InsertUser");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUser");
			_ColumnsList.Add("UpdateDate");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private Guid _testcasetesterid; 
		private string _testcasetestertitle; 
		private string _testcasetestercode; 
		private Guid? _fieldguid; 
		private byte? _fieldbyte; 
		private short? _fieldint16; 
		private int? _fieldint32; 
		private long? _fieldint64; 
		private double? _fielddouble; 
		private float? _fieldfloat; 
		private string _fieldntext; 
		private DateTime? _fielddatetime; 
		private byte[] _fieldbytearray50; 
		private byte[] _fieldvarbytearraymax1024; 
		private decimal? _fielddecimal; 
		private string _fieldstring; 
		private byte[] _fieldtimestamp; 
		private long? _insertuser; 
		private DateTime? _insertdate; 
		private long? _updateuser; 
		private DateTime? _updatedate; 		
		#endregion

		#region Constructor

		public vTestCaseTester()
		 //: base()
		{
			_testcasetesterid = new Guid(); 
			_testcasetestertitle = null; 
			_testcasetestercode = null; 
			_fieldguid = null; 
			_fieldbyte = null; 
			_fieldint16 = null; 
			_fieldint32 = null; 
			_fieldint64 = null; 
			_fielddouble = null; 
			_fieldfloat = null; 
			_fieldntext = null; 
			_fielddatetime = null; 
			_fieldbytearray50 = null; 
			_fieldvarbytearraymax1024 = null; 
			_fielddecimal = null; 
			_fieldstring = null; 
			_fieldtimestamp = null; 
			_insertuser = null; 
			_insertdate = null; 
			_updateuser = null; 
			_updatedate = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual Guid TestCaseTesterID
		{
			get
			{ 
				return _testcasetesterid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for TestCaseTesterID", value, "null");

				_testcasetesterid = value;
			}

		}
			
		public virtual string TestCaseTesterTitle
		{
			get
			{ 
				return _testcasetestertitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TestCaseTesterTitle", value, value.ToString());
				
				_testcasetestertitle = value;
			}
		}
			
		public virtual string TestCaseTesterCode
		{
			get
			{ 
				return _testcasetestercode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TestCaseTesterCode", value, value.ToString());
				
				_testcasetestercode = value;
			}
		}
			
		public virtual Guid? FieldGuid
		{
			get
			{ 
				return _fieldguid;
			}
			set
			{
				_fieldguid = value;
			}

		}
			
		public virtual byte? FieldByte
		{
			get
			{ 
				return _fieldbyte;
			}
			set
			{
				_fieldbyte = value;
			}

		}
			
		public virtual short? FieldInt16
		{
			get
			{ 
				return _fieldint16;
			}
			set
			{
				_fieldint16 = value;
			}

		}
			
		public virtual int? FieldInt32
		{
			get
			{ 
				return _fieldint32;
			}
			set
			{
				_fieldint32 = value;
			}

		}
			
		public virtual long? FieldInt64
		{
			get
			{ 
				return _fieldint64;
			}
			set
			{
				_fieldint64 = value;
			}

		}
			
		public virtual double? FieldDouble
		{
			get
			{ 
				return _fielddouble;
			}
			set
			{
				_fielddouble = value;
			}

		}
			
		public virtual float? FieldFloat
		{
			get
			{ 
				return _fieldfloat;
			}
			set
			{
				_fieldfloat = value;
			}

		}
			
		public virtual string FieldNtext
		{
			get
			{ 
				return _fieldntext;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for FieldNtext", value, value.ToString());
				
				_fieldntext = value;
			}
		}
			
		public virtual DateTime? FieldDateTime
		{
			get
			{ 
				return _fielddatetime;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for FieldDateTime", value, value.ToString());
						
				_fielddatetime = value;	
			}			
					
		}
			
		public virtual byte[] FieldByteArray50
		{
			get
			{ 
				return _fieldbytearray50;
			}
			set
			{
				_fieldbytearray50 = value;
			}

		}
			
		public virtual byte[] FieldVarByteArrayMax1024
		{
			get
			{ 
				return _fieldvarbytearraymax1024;
			}
			set
			{
				_fieldvarbytearraymax1024 = value;
			}

		}
			
		public virtual decimal? FieldDecimal
		{
			get
			{ 
				return _fielddecimal;
			}
			set
			{
				_fielddecimal = value;
			}

		}
			
		public virtual string FieldString
		{
			get
			{ 
				return _fieldstring;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for FieldString", value, value.ToString());
				
				_fieldstring = value;
			}
		}
			
		public virtual byte[] FieldTimeStamp
		{
			get
			{ 
				return _fieldtimestamp;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for FieldTimeStamp", value, "null");

				_fieldtimestamp = value;
			}

		}
			
		public virtual long? InsertUser
		{
			get
			{ 
				return _insertuser;
			}
			set
			{
				_insertuser = value;
			}

		}
			
		public virtual DateTime? InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());
						
				_insertdate = value;	
			}			
					
		}
			
		public virtual long? UpdateUser
		{
			get
			{ 
				return _updateuser;
			}
			set
			{
				_updateuser = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
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
            return this.TestCaseTesterID;
			
        }
		
		#endregion //Public Functions
	}
}
