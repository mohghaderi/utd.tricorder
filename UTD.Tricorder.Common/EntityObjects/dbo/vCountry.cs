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
	public partial class vCountry : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Country";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string CountryID = "CountryID";
			public const string CountryName = "CountryName";
			public const string CountryTitle = "CountryTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("CountryID");
			_ColumnsList.Add("CountryName");
			_ColumnsList.Add("CountryTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private string _countryid; 
		private string _countryname; 
		private string _countrytitle; 		
		#endregion

		#region Constructor

		public vCountry()
		 //: base()
		{
			_countryid = null; 
			_countryname = null; 
			_countrytitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual string CountryID
		{
			get
			{ 
				return _countryid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CountryID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryID", value, value.ToString());
				
				_countryid = value;
			}
		}
			
		public virtual string CountryName
		{
			get
			{ 
				return _countryname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CountryName", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryName", value, value.ToString());
				
				_countryname = value;
			}
		}
			
		public virtual string CountryTitle
		{
			get
			{ 
				return _countrytitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryTitle", value, value.ToString());
				
				_countrytitle = value;
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
            return this.CountryID;
			
        }
		
		#endregion //Public Functions
	}
}
