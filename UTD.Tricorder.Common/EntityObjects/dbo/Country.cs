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
	public partial class Country : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private string _countryid;//3

		//private IList<Person> _PersonList; 

		//private IList<Site> _SiteList; 

		//private IList<WorldTimeZone> _WorldTimeZoneList; 

		private string _countryname; 
		private string _countrytitle; 		
		#endregion

		#region Constructor

		public Country()
		 //: base()
		{
			_countryid = null; 
			//_PersonList = new List<Person>(); 
			//_SiteList = new List<Site>(); 
			//_WorldTimeZoneList = new List<WorldTimeZone>(); 
			_countryname = null; 
			_countrytitle = null; 
		}

		public Country(
			string countryid, 
			string countryname)
			: this()
		{
			_countryid = countryid;
			_countryname = countryname;
			_countrytitle = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual string CountryID
		{
			get
			{ 
				return _countryid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CountryID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryID", value, value.ToString());
				
				_countryid = value;
			}
		}
			
		public virtual string CountryName
		{
			get
			{ 
				return _countryname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CountryName", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryName", value, value.ToString());
				
				_countryname = value;
			}
		}
			
		public virtual string CountryTitle
		{
			get
			{ 
				return _countrytitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryTitle", value, value.ToString());
				
				_countrytitle = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddPerson(Person obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PersonList.Add(obj);
		//}
		

		//public virtual void AddSite(Site obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_SiteList.Add(obj);
		//}
		

		//public virtual void AddWorldTimeZone(WorldTimeZone obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_WorldTimeZoneList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.CountryID;
			
        }
		
		#endregion //Public Functions
	}
}
