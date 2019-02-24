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
	public partial class vTimeSeriesStrip : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TimeSeriesStrip";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TimeSeriesStripID = "TimeSeriesStripID";
			public const string UserID = "UserID";
			public const string StartDateOffset = "StartDateOffset";
			public const string EndDateOffset = "EndDateOffset";
			public const string TimeSeriesTypeID = "TimeSeriesTypeID";
			public const string StartDateTime = "StartDateTime";
			public const string EndDateTime = "EndDateTime";
			public const string DurationSeconds = "DurationSeconds";
			public const string TimeSeriesTypeName = "TimeSeriesTypeName";
			public const string TimeSeriesTypeCode = "TimeSeriesTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TimeSeriesStripID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("StartDateOffset");
			_ColumnsList.Add("EndDateOffset");
			_ColumnsList.Add("TimeSeriesTypeID");
			_ColumnsList.Add("StartDateTime");
			_ColumnsList.Add("EndDateTime");
			_ColumnsList.Add("DurationSeconds");
			_ColumnsList.Add("TimeSeriesTypeName");
			_ColumnsList.Add("TimeSeriesTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private Guid _timeseriesstripid; 
		private long _userid; 
		private int _startdateoffset; 
		private int _enddateoffset; 
		private byte _timeseriestypeid; 
		private DateTime? _startdatetime; 
		private DateTime? _enddatetime; 
		private int? _durationseconds; 
		private string _timeseriestypename; 
		private string _timeseriestypecode; 		
		#endregion

		#region Constructor

		public vTimeSeriesStrip()
		 //: base()
		{
			_timeseriesstripid = new Guid(); 
			_userid = -1; 
			_startdateoffset = -1; 
			_enddateoffset = -1; 
			_timeseriestypeid = new byte(); 
			_startdatetime = null; 
			_enddatetime = null; 
			_durationseconds = null; 
			_timeseriestypename = null; 
			_timeseriestypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual Guid TimeSeriesStripID
		{
			get
			{ 
				return _timeseriesstripid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for TimeSeriesStripID", value, "null");

				_timeseriesstripid = value;
			}

		}
			
		public virtual long UserID
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
			
		public virtual int StartDateOffset
		{
			get
			{ 
				return _startdateoffset;
			}
			set
			{
				_startdateoffset = value;
			}

		}
			
		public virtual int EndDateOffset
		{
			get
			{ 
				return _enddateoffset;
			}
			set
			{
				_enddateoffset = value;
			}

		}
			
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
			
		public virtual DateTime? StartDateTime
		{
			get
			{ 
				return _startdatetime;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for StartDateTime", value, value.ToString());
						
				_startdatetime = value;	
			}			
					
		}
			
		public virtual DateTime? EndDateTime
		{
			get
			{ 
				return _enddatetime;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for EndDateTime", value, value.ToString());
						
				_enddatetime = value;	
			}			
					
		}
			
		public virtual int? DurationSeconds
		{
			get
			{ 
				return _durationseconds;
			}
			set
			{
				_durationseconds = value;
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
            return this.TimeSeriesStripID;
			
        }
		
		#endregion //Public Functions
	}
}
