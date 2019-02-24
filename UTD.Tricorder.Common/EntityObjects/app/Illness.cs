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
	public partial class Illness : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _illnessid;//3

		//private IList<Doctor_Illness> _Doctor_IllnessList; 

		//private IList<Illness_Specialty> _Illness_SpecialtyList; 

		//private IList<Visit> _VisitList; 

		private string _illnesstitle; 		
		#endregion

		#region Constructor

		public Illness()
		 //: base()
		{
			_illnessid = -1; 
			//_Doctor_IllnessList = new List<Doctor_Illness>(); 
			//_Illness_SpecialtyList = new List<Illness_Specialty>(); 
			//_VisitList = new List<Visit>(); 
			_illnesstitle = null; 
		}

		public Illness(
			int illnessid, 
			string illnesstitle)
			: this()
		{
			_illnessid = illnessid;
			_illnesstitle = illnesstitle;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string IllnessTitle
		{
			get
			{ 
				return _illnesstitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for IllnessTitle", value, "null");
				
				//if(  value.Length > 350)
				//	throw new ArgumentOutOfRangeException("Invalid value for IllnessTitle", value, value.ToString());
				
				_illnesstitle = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctor_Illness(Doctor_Illness obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_IllnessList.Add(obj);
		//}
		

		//public virtual void AddIllness_Specialty(Illness_Specialty obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Illness_SpecialtyList.Add(obj);
		//}
		

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
            return this.IllnessID;
			
        }
		
		#endregion //Public Functions
	}
}
