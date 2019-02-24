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
	public partial class TimeSeriesType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _timeseriestypeid;//3

		//private IList<TimeSeries_SmallInt_Seconds> _TimeSeries_SmallInt_SecondsList; 

		//private IList<TimeSeriesStrip> _TimeSeriesStripList; 

		private string _timeseriestypename; 
		private string _timeseriestypecode; 		
		#endregion

		#region Constructor

		public TimeSeriesType()
		 //: base()
		{
			_timeseriestypeid = new byte(); 
			//_TimeSeries_SmallInt_SecondsList = new List<TimeSeries_SmallInt_Seconds>(); 
			//_TimeSeriesStripList = new List<TimeSeriesStrip>(); 
			_timeseriestypename = null; 
			_timeseriestypecode = null; 
		}

		public TimeSeriesType(
			byte timeseriestypeid, 
			string timeseriestypename, 
			string timeseriestypecode)
			: this()
		{
			_timeseriestypeid = timeseriestypeid;
			_timeseriestypename = timeseriestypename;
			_timeseriestypecode = timeseriestypecode;
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

		//public virtual void AddTimeSeries_SmallInt_Seconds(TimeSeries_SmallInt_Seconds obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_TimeSeries_SmallInt_SecondsList.Add(obj);
		//}
		

		//public virtual void AddTimeSeriesStrip(TimeSeriesStrip obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_TimeSeriesStripList.Add(obj);
		//}
		


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
