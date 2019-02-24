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
	public partial class vTimeSeriesType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TimeSeriesType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TimeSeriesTypeID = "TimeSeriesTypeID";
			public const string TimeSeriesTypeName = "TimeSeriesTypeName";
			public const string TimeSeriesTypeCode = "TimeSeriesTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TimeSeriesTypeID");
			_ColumnsList.Add("TimeSeriesTypeName");
			_ColumnsList.Add("TimeSeriesTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _timeseriestypeid; 
		private string _timeseriestypename; 
		private string _timeseriestypecode; 		
		#endregion

		#region Constructor

		public vTimeSeriesType()
		 //: base()
		{
			_timeseriestypeid = new byte(); 
			_timeseriestypename = null; 
			_timeseriestypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte TimeSeriesTypeID
		{
			get
			{ 
				return _timeseriestypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TimeSeriesTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TimeSeriesTypeID", value, value.ToString());
				
				_timeseriestypeid = value;
			}

		}
			
		public virtual string TimeSeriesTypeName
		{
			get
			{ 
				return _timeseriestypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TimeSeriesTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TimeSeriesTypeName", value, value.ToString());
				
				_timeseriestypename = value;
			}
		}
			
		public virtual string TimeSeriesTypeCode
		{
			get
			{ 
				return _timeseriestypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TimeSeriesTypeCode", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TimeSeriesTypeCode", value, value.ToString());
				
				_timeseriestypecode = value;
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
            return this.TimeSeriesTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
