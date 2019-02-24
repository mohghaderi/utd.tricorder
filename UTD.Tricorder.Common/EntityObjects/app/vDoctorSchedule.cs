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
	public partial class vDoctorSchedule : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "DoctorSchedule";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string DoctorScheduleID = "DoctorScheduleID";
			public const string DoctorID = "DoctorID";
			public const string SlotUnixEpoch = "SlotUnixEpoch";
			public const string NumberOfAllowedPatients = "NumberOfAllowedPatients";
			public const string RecordTimeStamp = "RecordTimeStamp";
			public const string NumberOfRegisteredPatients = "NumberOfRegisteredPatients";
			public const string IsDisabled = "IsDisabled";
			public const string IsWalkingQueue = "IsWalkingQueue";
			public const string DoctorScheduleVisitPlaceID = "DoctorScheduleVisitPlaceID";
			public const string VisitPlaceTitle = "VisitPlaceTitle";
			public const string NumberOfFreePositions = "NumberOfFreePositions";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("DoctorScheduleID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("SlotUnixEpoch");
			_ColumnsList.Add("NumberOfAllowedPatients");
			_ColumnsList.Add("RecordTimeStamp");
			_ColumnsList.Add("NumberOfRegisteredPatients");
			_ColumnsList.Add("IsDisabled");
			_ColumnsList.Add("IsWalkingQueue");
			_ColumnsList.Add("DoctorScheduleVisitPlaceID");
			_ColumnsList.Add("VisitPlaceTitle");
			_ColumnsList.Add("NumberOfFreePositions");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctorscheduleid; 
		private long _doctorid; 
		private int _slotunixepoch; 
		private byte _numberofallowedpatients; 
		private byte[] _recordtimestamp; 
		private byte _numberofregisteredpatients; 
		private bool _isdisabled; 
		private bool _iswalkingqueue; 
		private byte _doctorschedulevisitplaceid; 
		private string _visitplacetitle; 
		private byte? _numberoffreepositions; 		
		#endregion

		#region Constructor

		public vDoctorSchedule()
		 //: base()
		{
			_doctorscheduleid = -1; 
			_doctorid = -1; 
			_slotunixepoch = -1; 
			_numberofallowedpatients = new byte(); 
			_recordtimestamp = null; 
			_numberofregisteredpatients = new byte(); 
			_isdisabled = false; 
			_iswalkingqueue = false; 
			_doctorschedulevisitplaceid = new byte(); 
			_visitplacetitle = null; 
			_numberoffreepositions = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long DoctorScheduleID
		{
			get
			{ 
				return _doctorscheduleid;
			}
			set
			{
				_doctorscheduleid = value;
			}

		}
			
		public virtual long DoctorID
		{
			get
			{ 
				return _doctorid;
			}
			set
			{
				_doctorid = value;
			}

		}
			
		public virtual int SlotUnixEpoch
		{
			get
			{ 
				return _slotunixepoch;
			}
			set
			{
				_slotunixepoch = value;
			}

		}
			
		public virtual byte NumberOfAllowedPatients
		{
			get
			{ 
				return _numberofallowedpatients;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for NumberOfAllowedPatients", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for NumberOfAllowedPatients", value, value.ToString());
				
				_numberofallowedpatients = value;
			}

		}
			
		public virtual byte[] RecordTimeStamp
		{
			get
			{ 
				return _recordtimestamp;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for RecordTimeStamp", value, "null");

				_recordtimestamp = value;
			}

		}
			
		public virtual byte NumberOfRegisteredPatients
		{
			get
			{ 
				return _numberofregisteredpatients;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for NumberOfRegisteredPatients", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for NumberOfRegisteredPatients", value, value.ToString());
				
				_numberofregisteredpatients = value;
			}

		}
			
		public virtual bool IsDisabled
		{
			get
			{ 
				return _isdisabled;
			}
			set
			{
				_isdisabled = value;
			}

		}
			
		public virtual bool IsWalkingQueue
		{
			get
			{ 
				return _iswalkingqueue;
			}
			set
			{
				_iswalkingqueue = value;
			}

		}
			
		public virtual byte DoctorScheduleVisitPlaceID
		{
			get
			{ 
				return _doctorschedulevisitplaceid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorScheduleVisitPlaceID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorScheduleVisitPlaceID", value, value.ToString());
				
				_doctorschedulevisitplaceid = value;
			}

		}
			
		public virtual string VisitPlaceTitle
		{
			get
			{ 
				return _visitplacetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceTitle", value, value.ToString());
				
				_visitplacetitle = value;
			}
		}
			
		public virtual byte? NumberOfFreePositions
		{
			get
			{ 
				return _numberoffreepositions;
			}
			set
			{
				_numberoffreepositions = value;
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
            return this.DoctorScheduleID;
			
        }
		
		#endregion //Public Functions
	}
}
