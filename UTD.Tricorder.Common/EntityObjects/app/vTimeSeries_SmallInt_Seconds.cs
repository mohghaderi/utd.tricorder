//#DONT REGENERATE
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
	public partial class vTimeSeries_SmallInt_Seconds : EntityObjectBase
	{



		public const string EntityName = "TimeSeries_SmallInt_Seconds";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TSDateOffset = "TSDateOffset";
			public const string TSValue = "TSValue";
			public const string TimeSeriesTypeID = "TimeSeriesTypeID";
			public const string UserID = "UserID";
			public const string TSValueBinary = "TSValueBinary";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TSDateOffset");
			_ColumnsList.Add("TSValue");
			_ColumnsList.Add("TimeSeriesTypeID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("TSValueBinary");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _tsdateoffset; 
		private short _tsvalue; 
		private byte _timeseriestypeid; 
		private long _userid; 
		private byte[] _tsvaluebinary; 		
		#endregion

		#region Constructor

		public vTimeSeries_SmallInt_Seconds()
		{
			_tsdateoffset = -1; 
			_tsvalue = -1; 
			_timeseriestypeid = new byte(); 
			_userid = -1; 
			_tsvaluebinary = null; 
		}

		public vTimeSeries_SmallInt_Seconds(
			int tsdateoffset, 
			short tsvalue, 
			byte timeseriestypeid, 
			long userid, 
			byte[] tsvaluebinary)
			: this()
		{
			_tsdateoffset = tsdateoffset;
			_tsvalue = tsvalue;
			_timeseriestypeid = timeseriestypeid;
			_userid = userid;
			_tsvaluebinary = tsvaluebinary;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int TSDateOffset
		{
			get
			{ 
				return _tsdateoffset;
			}
			set
			{
				_tsdateoffset = value;
			}

		}
			
		public virtual short TSValue
		{
			get
			{ 
				return _tsvalue;
			}
			set
			{
				_tsvalue = value;
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
			
		public virtual byte[] TSValueBinary
		{
			get
			{ 
				return _tsvaluebinary;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for TSValueBinary", value, "null");

				_tsvaluebinary = value;
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
            return this.TSDateOffset;
			
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TimeSeriesNHibernateCompositeKey id;
            id = (TimeSeriesNHibernateCompositeKey)obj;
            if (id == null)
                return false;
            if (UserID == id.UserID && TSDateOffset == id.TSDateOffset && TimeSeriesTypeID == id.TimeSeriesTypeID)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (TimeSeriesTypeID + "|" + UserID + "|" + TSDateOffset).GetHashCode();
        }

		#endregion //Public Functions
	}
}
