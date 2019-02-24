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
	public partial class vVitalValue : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "VitalValue";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string VitalValueID = "VitalValueID";
			public const string PersonID = "PersonID";
			public const string DataValue = "DataValue";
			public const string RecordDateTime = "RecordDateTime";
			public const string VitalTypeID = "VitalTypeID";
			public const string IsManualEntry = "IsManualEntry";
			public const string VitalTypeTitle = "VitalTypeTitle";
			public const string VitalTypeCode = "VitalTypeCode";
			public const string AfterDecimalPointDigits = "AfterDecimalPointDigits";
			public const string RecordDateTimeUnix = "RecordDateTimeUnix";
			public const string Comment = "Comment";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("VitalValueID");
			_ColumnsList.Add("PersonID");
			_ColumnsList.Add("DataValue");
			_ColumnsList.Add("RecordDateTime");
			_ColumnsList.Add("VitalTypeID");
			_ColumnsList.Add("IsManualEntry");
			_ColumnsList.Add("VitalTypeTitle");
			_ColumnsList.Add("VitalTypeCode");
			_ColumnsList.Add("AfterDecimalPointDigits");
			_ColumnsList.Add("RecordDateTimeUnix");
			_ColumnsList.Add("Comment");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _vitalvalueid; 
		private long _personid; 
		private double _datavalue; 
		private DateTime _recorddatetime; 
		private int _vitaltypeid; 
		private bool _ismanualentry; 
		private string _vitaltypetitle; 
		private string _vitaltypecode; 
		private byte _afterdecimalpointdigits; 
		private int? _recorddatetimeunix; 
		private string _comment; 		
		#endregion

		#region Constructor

		public vVitalValue()
		 //: base()
		{
			_vitalvalueid = -1; 
			_personid = -1; 
			_datavalue = new double(); 
			_recorddatetime = DateTime.MinValue; 
			_vitaltypeid = -1; 
			_ismanualentry = false; 
			_vitaltypetitle = null; 
			_vitaltypecode = null; 
			_afterdecimalpointdigits = new byte(); 
			_recorddatetimeunix = null; 
			_comment = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long VitalValueID
		{
			get
			{ 
				return _vitalvalueid;
			}
			set
			{
				_vitalvalueid = value;
			}

		}
			
		public virtual long PersonID
		{
			get
			{ 
				return _personid;
			}
			set
			{
				_personid = value;
			}

		}
			
		public virtual double DataValue
		{
			get
			{ 
				return _datavalue;
			}
			set
			{
				_datavalue = value;
			}

		}
			
		public virtual DateTime RecordDateTime
		{
			get
			{ 
				return _recorddatetime;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecordDateTime", value, value.ToString());

				_recorddatetime = value;	
			}
					
		}
			
		public virtual int VitalTypeID
		{
			get
			{ 
				return _vitaltypeid;
			}
			set
			{
				_vitaltypeid = value;
			}

		}
			
		public virtual bool IsManualEntry
		{
			get
			{ 
				return _ismanualentry;
			}
			set
			{
				_ismanualentry = value;
			}

		}
			
		public virtual string VitalTypeTitle
		{
			get
			{ 
				return _vitaltypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VitalTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for VitalTypeTitle", value, value.ToString());
				
				_vitaltypetitle = value;
			}
		}
			
		public virtual string VitalTypeCode
		{
			get
			{ 
				return _vitaltypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VitalTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VitalTypeCode", value, value.ToString());
				
				_vitaltypecode = value;
			}
		}
			
		public virtual byte AfterDecimalPointDigits
		{
			get
			{ 
				return _afterdecimalpointdigits;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AfterDecimalPointDigits", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for AfterDecimalPointDigits", value, value.ToString());
				
				_afterdecimalpointdigits = value;
			}

		}
			
		public virtual int? RecordDateTimeUnix
		{
			get
			{ 
				return _recorddatetimeunix;
			}
			set
			{
				_recorddatetimeunix = value;
			}

		}
			
		public virtual string Comment
		{
			get
			{ 
				return _comment;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Comment", value, value.ToString());
				
				_comment = value;
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
            return this.VitalValueID;
			
        }
		
		#endregion //Public Functions
	}
}
