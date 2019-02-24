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
	public partial class vWorldTimeZone : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "WorldTimeZone";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string WorldTimeZoneID = "WorldTimeZoneID";
			public const string CountryID = "CountryID";
			public const string WorldTimeZoneIANAName = "WorldTimeZoneIANAName";
			public const string WorldTimeZoneTitle = "WorldTimeZoneTitle";
			public const string WorldTimeZoneComments = "WorldTimeZoneComments";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("WorldTimeZoneID");
			_ColumnsList.Add("CountryID");
			_ColumnsList.Add("WorldTimeZoneIANAName");
			_ColumnsList.Add("WorldTimeZoneTitle");
			_ColumnsList.Add("WorldTimeZoneComments");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _worldtimezoneid; 
		private string _countryid; 
		private string _worldtimezoneiananame; 
		private string _worldtimezonetitle; 
		private string _worldtimezonecomments; 		
		#endregion

		#region Constructor

		public vWorldTimeZone()
		 //: base()
		{
			_worldtimezoneid = -1; 
			_countryid = null; 
			_worldtimezoneiananame = null; 
			_worldtimezonetitle = null; 
			_worldtimezonecomments = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short WorldTimeZoneID
		{
			get
			{ 
				return _worldtimezoneid;
			}
			set
			{
				_worldtimezoneid = value;
			}

		}
			
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
			
		public virtual string WorldTimeZoneIANAName
		{
			get
			{ 
				return _worldtimezoneiananame;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneIANAName", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneIANAName", value, value.ToString());
				
				_worldtimezoneiananame = value;
			}
		}
			
		public virtual string WorldTimeZoneTitle
		{
			get
			{ 
				return _worldtimezonetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneTitle", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneTitle", value, value.ToString());
				
				_worldtimezonetitle = value;
			}
		}
			
		public virtual string WorldTimeZoneComments
		{
			get
			{ 
				return _worldtimezonecomments;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneComments", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneComments", value, value.ToString());
				
				_worldtimezonecomments = value;
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
            return this.WorldTimeZoneID;
			
        }
		
		#endregion //Public Functions
	}
}
