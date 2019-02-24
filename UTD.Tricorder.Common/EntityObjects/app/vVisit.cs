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
	public partial class vVisit : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Doctor complate name
        /// </summary>
        public virtual string DoctorFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.DoctorNamePrefix, this.DoctorFirstName, this.DoctorLastName);
            }
        }

        /// <summary>
        /// Patient full name
        /// </summary>
        public virtual string PatientFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.PatientNamePrefix, this.PatientFirstName, this.PatientLastName);
            }
        }


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


		public const string EntityName = "Visit";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string VisitID = "VisitID";
			public const string PatientUserID = "PatientUserID";
			public const string VisitStatusID = "VisitStatusID";
			public const string VisitStatusCode = "VisitStatusCode";
			public const string VisitStatusTitle = "VisitStatusTitle";
			public const string DoctorNamePrefix = "DoctorNamePrefix";
			public const string DoctorFirstName = "DoctorFirstName";
			public const string DoctorLastName = "DoctorLastName";
			public const string PatientNamePrefix = "PatientNamePrefix";
			public const string PatientFirstName = "PatientFirstName";
			public const string PatientLastName = "PatientLastName";
			public const string Description = "Description";
			public const string DoctorReport = "DoctorReport";
			public const string DoctorScheduleID = "DoctorScheduleID";
			public const string IllnessID = "IllnessID";
			public const string ChiefComplaint = "ChiefComplaint";
			public const string DoctorID = "DoctorID";
			public const string SlotUnixEpoch = "SlotUnixEpoch";
			public const string PatientWorldTimeZoneID = "PatientWorldTimeZoneID";
			public const string DoctorWorldTimeZoneID = "DoctorWorldTimeZoneID";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string DoctorScheduleVisitPlaceID = "DoctorScheduleVisitPlaceID";
			public const string PatientVisitPlaceID = "PatientVisitPlaceID";
			public const string VisitPlaceTitle = "VisitPlaceTitle";
			public const string VisitPlaceIcon = "VisitPlaceIcon";
			public const string VisitStatusIcon = "VisitStatusIcon";
			public const string AmountPaid = "AmountPaid";
			public const string AmountOwed = "AmountOwed";
			public const string Prescription = "Prescription";
			public const string DoctorSystemReviewJson = "DoctorSystemReviewJson";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("VisitID");
			_ColumnsList.Add("PatientUserID");
			_ColumnsList.Add("VisitStatusID");
			_ColumnsList.Add("VisitStatusCode");
			_ColumnsList.Add("VisitStatusTitle");
			_ColumnsList.Add("DoctorNamePrefix");
			_ColumnsList.Add("DoctorFirstName");
			_ColumnsList.Add("DoctorLastName");
			_ColumnsList.Add("PatientNamePrefix");
			_ColumnsList.Add("PatientFirstName");
			_ColumnsList.Add("PatientLastName");
			_ColumnsList.Add("Description");
			_ColumnsList.Add("DoctorReport");
			_ColumnsList.Add("DoctorScheduleID");
			_ColumnsList.Add("IllnessID");
			_ColumnsList.Add("ChiefComplaint");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("SlotUnixEpoch");
			_ColumnsList.Add("PatientWorldTimeZoneID");
			_ColumnsList.Add("DoctorWorldTimeZoneID");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("DoctorScheduleVisitPlaceID");
			_ColumnsList.Add("PatientVisitPlaceID");
			_ColumnsList.Add("VisitPlaceTitle");
			_ColumnsList.Add("VisitPlaceIcon");
			_ColumnsList.Add("VisitStatusIcon");
			_ColumnsList.Add("AmountPaid");
			_ColumnsList.Add("AmountOwed");
			_ColumnsList.Add("Prescription");
			_ColumnsList.Add("DoctorSystemReviewJson");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _visitid; 
		private long _patientuserid; 
		private int _visitstatusid; 
		private string _visitstatuscode; 
		private string _visitstatustitle; 
		private string _doctornameprefix; 
		private string _doctorfirstname; 
		private string _doctorlastname; 
		private string _patientnameprefix; 
		private string _patientfirstname; 
		private string _patientlastname; 
		private string _description; 
		private string _doctorreport; 
		private long _doctorscheduleid; 
		private int _illnessid; 
		private string _chiefcomplaint; 
		private long _doctorid; 
		private int _slotunixepoch; 
		private short _patientworldtimezoneid; 
		private short _doctorworldtimezoneid; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private byte _doctorschedulevisitplaceid; 
		private byte _patientvisitplaceid; 
		private string _visitplacetitle; 
		private string _visitplaceicon; 
		private string _visitstatusicon; 
		private decimal? _amountpaid; 
		private decimal? _amountowed; 
		private string _prescription; 
		private string _doctorsystemreviewjson; 		
		#endregion

		#region Constructor

		public vVisit()
		 //: base()
		{
			_visitid = -1; 
			_patientuserid = -1; 
			_visitstatusid = -1; 
			_visitstatuscode = null; 
			_visitstatustitle = null; 
			_doctornameprefix = null; 
			_doctorfirstname = null; 
			_doctorlastname = null; 
			_patientnameprefix = null; 
			_patientfirstname = null; 
			_patientlastname = null; 
			_description = null; 
			_doctorreport = null; 
			_doctorscheduleid = -1; 
			_illnessid = -1; 
			_chiefcomplaint = null; 
			_doctorid = -1; 
			_slotunixepoch = -1; 
			_patientworldtimezoneid = -1; 
			_doctorworldtimezoneid = -1; 
			_updateuserid = null; 
			_updatedate = null; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_doctorschedulevisitplaceid = new byte(); 
			_patientvisitplaceid = new byte(); 
			_visitplacetitle = null; 
			_visitplaceicon = null; 
			_visitstatusicon = null; 
			_amountpaid = null; 
			_amountowed = null; 
			_prescription = null; 
			_doctorsystemreviewjson = null; 
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
			
		public virtual string VisitStatusCode
		{
			get
			{ 
				return _visitstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusCode", value, value.ToString());
				
				_visitstatuscode = value;
			}
		}
			
		public virtual string VisitStatusTitle
		{
			get
			{ 
				return _visitstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusTitle", value, value.ToString());
				
				_visitstatustitle = value;
			}
		}
			
		public virtual string DoctorNamePrefix
		{
			get
			{ 
				return _doctornameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorNamePrefix", value, value.ToString());
				
				_doctornameprefix = value;
			}
		}
			
		public virtual string DoctorFirstName
		{
			get
			{ 
				return _doctorfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorFirstName", value, value.ToString());
				
				_doctorfirstname = value;
			}
		}
			
		public virtual string DoctorLastName
		{
			get
			{ 
				return _doctorlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorLastName", value, value.ToString());
				
				_doctorlastname = value;
			}
		}
			
		public virtual string PatientNamePrefix
		{
			get
			{ 
				return _patientnameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientNamePrefix", value, value.ToString());
				
				_patientnameprefix = value;
			}
		}
			
		public virtual string PatientFirstName
		{
			get
			{ 
				return _patientfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PatientFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientFirstName", value, value.ToString());
				
				_patientfirstname = value;
			}
		}
			
		public virtual string PatientLastName
		{
			get
			{ 
				return _patientlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PatientLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientLastName", value, value.ToString());
				
				_patientlastname = value;
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
			
		public virtual short PatientWorldTimeZoneID
		{
			get
			{ 
				return _patientworldtimezoneid;
			}
			set
			{
				_patientworldtimezoneid = value;
			}

		}
			
		public virtual short DoctorWorldTimeZoneID
		{
			get
			{ 
				return _doctorworldtimezoneid;
			}
			set
			{
				_doctorworldtimezoneid = value;
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
			
		public virtual string VisitPlaceTitle
		{
			get
			{ 
				return _visitplacetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitPlaceTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceTitle", value, value.ToString());
				
				_visitplacetitle = value;
			}
		}
			
		public virtual string VisitPlaceIcon
		{
			get
			{ 
				return _visitplaceicon;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitPlaceIcon", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceIcon", value, value.ToString());
				
				_visitplaceicon = value;
			}
		}
			
		public virtual string VisitStatusIcon
		{
			get
			{ 
				return _visitstatusicon;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusIcon", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusIcon", value, value.ToString());
				
				_visitstatusicon = value;
			}
		}
			
		public virtual decimal? AmountPaid
		{
			get
			{ 
				return _amountpaid;
			}
			set
			{
				_amountpaid = value;
			}

		}
			
		public virtual decimal? AmountOwed
		{
			get
			{ 
				return _amountowed;
			}
			set
			{
				_amountowed = value;
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
