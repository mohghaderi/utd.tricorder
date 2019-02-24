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
	public partial class Doctor_USState : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _doctor_usstateid; private long _doctorid;//0
//private Doctor _doctorid;//1
private string _usstateid;//0
//private USState _usstateid;//1
		
		#endregion

		#region Constructor

		public Doctor_USState()
		 //: base()
		{
			_doctor_usstateid = -1; 
			_doctorid = -1; 
			_usstateid = null; 
		}

		public Doctor_USState(
			long doctor_usstateid, 
			long doctorid, 
			string usstateid)
			: this()
		{
			_doctor_usstateid = doctor_usstateid;
			_doctorid = doctorid;
			_usstateid = usstateid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_USStateID
		{
			get
			{ 
				return _doctor_usstateid;
			}
			set
			{
				_doctor_usstateid = value;
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
			
		public virtual string USStateID
		{
			get
			{ 
				return _usstateid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for USStateID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStateID", value, value.ToString());
				
				_usstateid = value;
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
            return this.Doctor_USStateID;
			
        }
		
		#endregion //Public Functions
	}
}
