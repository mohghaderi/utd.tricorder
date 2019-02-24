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
	public partial class Visit : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        private string _DoctorProfilePicUrl;

        public virtual string DoctorProfilePicUrl
        {
            get
            {
                return _DoctorProfilePicUrl;
            }
            set
            {
                _DoctorProfilePicUrl = value;
            }
        }

        private string _PatientProfilePicUrl;

        public virtual string PatientProfilePicUrl
        {
            get
            {
                return _PatientProfilePicUrl;
            }
            set
            {
                _PatientProfilePicUrl = value;
            }
        }

		#endregion

		#region Private Members

		private long _visitid; private long _patientuserid;//0
//private User _patientuserid;//1
private long _doctorscheduleid;//0
//private DoctorSchedule _doctorscheduleid;//1

		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; private int _illnessid;//0
//private Illness _illnessid;//1
private int _visitstatusid;//0
//private VisitStatus _visitstatusid;//1

		private string _doctorreport; 
		private string _chiefcomplaint; 
		private string _description; private byte _patientvisitplaceid;//0
//private VisitPlace _patientvisitplaceid;//1

		private string _prescription; 
		private string _doctorsystemreviewjson; 		
		#endregion

		#region Constructor

		public Visit()
		 //: base()
		{
			_visitid = -1; 
			_patientuserid = -1; 
			_doctorscheduleid = -1; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_illnessid = -1; 
			_visitstatusid = -1; 
			_doctorreport = null; 
			_chiefcomplaint = null; 
			_description = null; 
			_patientvisitplaceid = new byte(); 
			_prescription = null; 
			_doctorsystemreviewjson = null; 
		}

		public Visit(
			long visitid, 
			long patientuserid, 
			long doctorscheduleid, 
			long insertuserid, 
			DateTime insertdate, 
			int illnessid, 
			int visitstatusid, 
			byte patientvisitplaceid)
			: this()
		{
			_visitid = visitid;
			_patientuserid = patientuserid;
			_doctorscheduleid = doctorscheduleid;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
			_illnessid = illnessid;
			_visitstatusid = visitstatusid;
			_doctorreport = String.Empty;
			_chiefcomplaint = String.Empty;
			_description = String.Empty;
			_patientvisitplaceid = patientvisitplaceid;
			_prescription = String.Empty;
			_doctorsystemreviewjson = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long VisitID
		{
			get
			{ 
				return _visitid;
			}
			set
			{
				_visitid = value;
			}

		}
			
		public virtual long PatientUserID
		{
			get
			{ 
				return _patientuserid;
			}
			set
			{
				_patientuserid = value;
			}

		}
			
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
			
		public virtual long InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
			}			
					
		}
			
		public virtual int IllnessID
		{
			get
			{ 
				return _illnessid;
			}
			set
			{
				_illnessid = value;
			}

		}
			
		public virtual int VisitStatusID
		{
			get
			{ 
				return _visitstatusid;
			}
			set
			{
				_visitstatusid = value;
			}

		}
			
		public virtual string DoctorReport
		{
			get
			{ 
				return _doctorreport;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorReport", value, value.ToString());
				
				_doctorreport = value;
			}
		}
			
		public virtual string ChiefComplaint
		{
			get
			{ 
				return _chiefcomplaint;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for ChiefComplaint", value, value.ToString());
				
				_chiefcomplaint = value;
			}
		}
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual byte PatientVisitPlaceID
		{
			get
			{ 
				return _patientvisitplaceid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PatientVisitPlaceID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientVisitPlaceID", value, value.ToString());
				
				_patientvisitplaceid = value;
			}

		}
			
		public virtual string Prescription
		{
			get
			{ 
				return _prescription;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Prescription", value, value.ToString());
				
				_prescription = value;
			}
		}
			
		public virtual string DoctorSystemReviewJson
		{
			get
			{ 
				return _doctorsystemreviewjson;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorSystemReviewJson", value, value.ToString());
				
				_doctorsystemreviewjson = value;
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
            return this.VisitID;
			
        }
		
		#endregion //Public Functions
	}
}
