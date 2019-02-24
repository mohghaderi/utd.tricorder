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
	public partial class DoctorSchedule : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _doctorscheduleid;//3

		//private IList<Visit> _VisitList; 
private long _doctorid;//0
//private Doctor _doctorid;//1

		private byte _numberofallowedpatients; 
		private byte _numberofregisteredpatients; 
		private byte[] _recordtimestamp; 
		private bool _isdisabled; 
		private bool _iswalkingqueue; private byte _doctorschedulevisitplaceid;//0
//private VisitPlace _doctorschedulevisitplaceid;//1

		private int _slotunixepoch; 		
		#endregion

		#region Constructor

		public DoctorSchedule()
		 //: base()
		{
			_doctorscheduleid = -1; 
			//_VisitList = new List<Visit>(); 
			_doctorid = -1; 
			_numberofallowedpatients = new byte(); 
			_numberofregisteredpatients = new byte(); 
			_recordtimestamp = null; 
			_isdisabled = false; 
			_iswalkingqueue = false; 
			_doctorschedulevisitplaceid = new byte(); 
			_slotunixepoch = -1; 
		}

		public DoctorSchedule(
			long doctorscheduleid, 
			long doctorid, 
			byte numberofallowedpatients, 
			byte numberofregisteredpatients, 
			byte[] recordtimestamp, 
			bool isdisabled, 
			bool iswalkingqueue, 
			byte doctorschedulevisitplaceid, 
			int slotunixepoch)
			: this()
		{
			_doctorscheduleid = doctorscheduleid;
			_doctorid = doctorid;
			_numberofallowedpatients = numberofallowedpatients;
			_numberofregisteredpatients = numberofregisteredpatients;
			_recordtimestamp = recordtimestamp;
			_isdisabled = isdisabled;
			_iswalkingqueue = iswalkingqueue;
			_doctorschedulevisitplaceid = doctorschedulevisitplaceid;
			_slotunixepoch = slotunixepoch;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddVisit(Visit obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_VisitList.Add(obj);
		//}
		


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
