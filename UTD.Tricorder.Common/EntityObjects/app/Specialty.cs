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
	public partial class Specialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _specialtyid;//3

		//private IList<Doctor_Specialty> _Doctor_SpecialtyList; 

		//private IList<Illness_Specialty> _Illness_SpecialtyList; 

		private string _specialtytitle; 
		private bool _ispopular; 		
		#endregion

		#region Constructor

		public Specialty()
		 //: base()
		{
			_specialtyid = -1; 
			//_Doctor_SpecialtyList = new List<Doctor_Specialty>(); 
			//_Illness_SpecialtyList = new List<Illness_Specialty>(); 
			_specialtytitle = null; 
			_ispopular = false; 
		}

		public Specialty(
			int specialtyid, 
			string specialtytitle, 
			bool ispopular)
			: this()
		{
			_specialtyid = specialtyid;
			_specialtytitle = specialtytitle;
			_ispopular = ispopular;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string SpecialtyTitle
		{
			get
			{ 
				return _specialtytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SpecialtyTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for SpecialtyTitle", value, value.ToString());
				
				_specialtytitle = value;
			}
		}
			
		public virtual bool IsPopular
		{
			get
			{ 
				return _ispopular;
			}
			set
			{
				_ispopular = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctor_Specialty(Doctor_Specialty obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_SpecialtyList.Add(obj);
		//}
		

		//public virtual void AddIllness_Specialty(Illness_Specialty obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Illness_SpecialtyList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
