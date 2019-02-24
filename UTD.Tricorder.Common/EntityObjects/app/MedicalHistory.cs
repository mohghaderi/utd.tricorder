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
	public partial class MedicalHistory : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _medicalhistoryid; 
		private long _patientuserid; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private string _sectionname; 
		private string _sectionvaluesjson; 		
		#endregion

		#region Constructor

		public MedicalHistory()
		 //: base()
		{
			_medicalhistoryid = -1; 
			_patientuserid = -1; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_sectionname = null; 
			_sectionvaluesjson = null; 
		}

		public MedicalHistory(
			long medicalhistoryid, 
			long patientuserid, 
			long insertuserid, 
			DateTime insertdate, 
			string sectionname, 
			string sectionvaluesjson)
			: this()
		{
			_medicalhistoryid = medicalhistoryid;
			_patientuserid = patientuserid;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
			_sectionname = sectionname;
			_sectionvaluesjson = sectionvaluesjson;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long MedicalHistoryID
		{
			get
			{ 
				return _medicalhistoryid;
			}
			set
			{
				_medicalhistoryid = value;
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
			
		public virtual string SectionName
		{
			get
			{ 
				return _sectionname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SectionName", value, "null");
				
				//if(  value.Length > 20)
				//	throw new ArgumentOutOfRangeException("Invalid value for SectionName", value, value.ToString());
				
				_sectionname = value;
			}
		}
			
		public virtual string SectionValuesJson
		{
			get
			{ 
				return _sectionvaluesjson;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SectionValuesJson", value, "null");
				
				//if(  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for SectionValuesJson", value, value.ToString());
				
				_sectionvaluesjson = value;
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
            return this.MedicalHistoryID;
			
        }
		
		#endregion //Public Functions
	}
}
