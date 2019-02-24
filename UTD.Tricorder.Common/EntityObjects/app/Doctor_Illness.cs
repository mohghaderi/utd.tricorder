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
	public partial class Doctor_Illness : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _doctor_illnessid; private long _doctorid;//0
//private Doctor _doctorid;//1
private int _illnessid;//0
//private Illness _illnessid;//1

		private decimal _defaultprice; 
		private bool _isdisabled; 		
		#endregion

		#region Constructor

		public Doctor_Illness()
		 //: base()
		{
			_doctor_illnessid = -1; 
			_doctorid = -1; 
			_illnessid = -1; 
			_defaultprice = -1; 
			_isdisabled = false; 
		}

		public Doctor_Illness(
			long doctor_illnessid, 
			long doctorid, 
			int illnessid, 
			decimal defaultprice, 
			bool isdisabled)
			: this()
		{
			_doctor_illnessid = doctor_illnessid;
			_doctorid = doctorid;
			_illnessid = illnessid;
			_defaultprice = defaultprice;
			_isdisabled = isdisabled;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_IllnessID
		{
			get
			{ 
				return _doctor_illnessid;
			}
			set
			{
				_doctor_illnessid = value;
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
			
		public virtual decimal DefaultPrice
		{
			get
			{ 
				return _defaultprice;
			}
			set
			{
				_defaultprice = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.Doctor_IllnessID;
			
        }
		
		#endregion //Public Functions
	}
}
