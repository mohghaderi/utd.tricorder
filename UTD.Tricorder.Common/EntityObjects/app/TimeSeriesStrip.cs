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
	public partial class TimeSeriesStrip : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private Guid _timeseriesstripid; private long _userid;//0
//private Person _userid;//1

		private int _startdateoffset; 
		private int _enddateoffset; private byte _timeseriestypeid;//0
//private TimeSeriesType _timeseriestypeid;//1
		
		#endregion

		#region Constructor

		public TimeSeriesStrip()
		 //: base()
		{
			_timeseriesstripid = new Guid(); 
			_userid = -1; 
			_startdateoffset = -1; 
			_enddateoffset = -1; 
			_timeseriestypeid = new byte(); 
		}

		public TimeSeriesStrip(
			Guid timeseriesstripid, 
			long userid, 
			int startdateoffset, 
			int enddateoffset, 
			byte timeseriestypeid)
			: this()
		{
			_timeseriesstripid = timeseriesstripid;
			_userid = userid;
			_startdateoffset = startdateoffset;
			_enddateoffset = enddateoffset;
			_timeseriestypeid = timeseriestypeid;
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
