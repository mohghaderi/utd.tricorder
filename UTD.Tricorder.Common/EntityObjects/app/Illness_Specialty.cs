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
	public partial class Illness_Specialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private int _illness_specialtyid; private int _illnessid;//0
//private Illness _illnessid;//1
private int _specialtyid;//0
//private Specialty _specialtyid;//1
		
		#endregion

		#region Constructor

		public Illness_Specialty()
		 //: base()
		{
			_illness_specialtyid = -1; 
			_illnessid = -1; 
			_specialtyid = -1; 
		}

		public Illness_Specialty(
			int illness_specialtyid, 
			int illnessid, 
			int specialtyid)
			: this()
		{
			_illness_specialtyid = illness_specialtyid;
			_illnessid = illnessid;
			_specialtyid = specialtyid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int Illness_SpecialtyID
		{
			get
			{ 
				return _illness_specialtyid;
			}
			set
			{
				_illness_specialtyid = value;
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
			
		public virtual int SpecialtyID
		{
			get
			{ 
				return _specialtyid;
			}
			set
			{
				_specialtyid = value;
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
            return this.Illness_SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
