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
	public partial class USState : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private string _usstateid;//3

		//private IList<Doctor_USState> _Doctor_USStateList; 

		//private IList<Person> _PersonList; 

		private string _statename; 
		private string _statenameabbrev; 		
		#endregion

		#region Constructor

		public USState()
		 //: base()
		{
			_usstateid = null; 
			//_Doctor_USStateList = new List<Doctor_USState>(); 
			//_PersonList = new List<Person>(); 
			_statename = null; 
			_statenameabbrev = null; 
		}

		public USState(
			string usstateid, 
			string statename, 
			string statenameabbrev)
			: this()
		{
			_usstateid = usstateid;
			_statename = statename;
			_statenameabbrev = statenameabbrev;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string StateName
		{
			get
			{ 
				return _statename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for StateName", value, "null");
				
				//if(  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateName", value, value.ToString());
				
				_statename = value;
			}
		}
			
		public virtual string StateNameAbbrev
		{
			get
			{ 
				return _statenameabbrev;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for StateNameAbbrev", value, "null");
				
				//if(  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateNameAbbrev", value, value.ToString());
				
				_statenameabbrev = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctor_USState(Doctor_USState obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_USStateList.Add(obj);
		//}
		

		//public virtual void AddPerson(Person obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PersonList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.USStateID;
			
        }
		
		#endregion //Public Functions
	}
}
