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
	public partial class vGenderType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "GenderType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string GenderTypeID = "GenderTypeID";
			public const string GenderTypeTitle = "GenderTypeTitle";
			public const string GenderTypeCode = "GenderTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("GenderTypeID");
			_ColumnsList.Add("GenderTypeTitle");
			_ColumnsList.Add("GenderTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _gendertypeid; 
		private string _gendertypetitle; 
		private string _gendertypecode; 		
		#endregion

		#region Constructor

		public vGenderType()
		 //: base()
		{
			_gendertypeid = -1; 
			_gendertypetitle = null; 
			_gendertypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int GenderTypeID
		{
			get
			{ 
				return _gendertypeid;
			}
			set
			{
				_gendertypeid = value;
			}

		}
			
		public virtual string GenderTypeTitle
		{
			get
			{ 
				return _gendertypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for GenderTypeTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for GenderTypeTitle", value, value.ToString());
				
				_gendertypetitle = value;
			}
		}
			
		public virtual string GenderTypeCode
		{
			get
			{ 
				return _gendertypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for GenderTypeCode", value, "null");
				
				//if(  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for GenderTypeCode", value, value.ToString());
				
				_gendertypecode = value;
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
            return this.GenderTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
