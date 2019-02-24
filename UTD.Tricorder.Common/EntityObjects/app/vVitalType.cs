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
	public partial class vVitalType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "VitalType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string VitalTypeID = "VitalTypeID";
			public const string VitalTypeTitle = "VitalTypeTitle";
			public const string VitalTypeCode = "VitalTypeCode";
			public const string AfterDecimalPointDigits = "AfterDecimalPointDigits";
			public const string UnitCode = "UnitCode";
			public const string UnitTitle = "UnitTitle";
			public const string ValueSuffix = "ValueSuffix";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("VitalTypeID");
			_ColumnsList.Add("VitalTypeTitle");
			_ColumnsList.Add("VitalTypeCode");
			_ColumnsList.Add("AfterDecimalPointDigits");
			_ColumnsList.Add("UnitCode");
			_ColumnsList.Add("UnitTitle");
			_ColumnsList.Add("ValueSuffix");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _vitaltypeid; 
		private string _vitaltypetitle; 
		private string _vitaltypecode; 
		private byte _afterdecimalpointdigits; 
		private string _unitcode; 
		private string _unittitle; 
		private string _valuesuffix; 		
		#endregion

		#region Constructor

		public vVitalType()
		 //: base()
		{
			_vitaltypeid = -1; 
			_vitaltypetitle = null; 
			_vitaltypecode = null; 
			_afterdecimalpointdigits = new byte(); 
			_unitcode = null; 
			_unittitle = null; 
			_valuesuffix = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string UnitCode
		{
			get
			{ 
				return _unitcode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UnitCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for UnitCode", value, value.ToString());
				
				_unitcode = value;
			}
		}
			
		public virtual string UnitTitle
		{
			get
			{ 
				return _unittitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UnitTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for UnitTitle", value, value.ToString());
				
				_unittitle = value;
			}
		}
			
		public virtual string ValueSuffix
		{
			get
			{ 
				return _valuesuffix;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ValueSuffix", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for ValueSuffix", value, value.ToString());
				
				_valuesuffix = value;
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
            return this.VitalTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
