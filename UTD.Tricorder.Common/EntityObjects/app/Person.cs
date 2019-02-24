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
	public partial class Person : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public const string AdditionalData_Register = "Register";

        private string _UserProfilePicUrl;

        public virtual string UserProfilePicUrl
        {
            get
            {
                return _UserProfilePicUrl;
            }
            set
            {
                _UserProfilePicUrl = value;
            }
        }

		#endregion

		#region Private Members
		private long _personid;//3

		//private IList<TimeSeries_SmallInt_Seconds> _TimeSeries_SmallInt_SecondsList; 

		//private IList<TimeSeriesStrip> _TimeSeriesStripList; 

		//private IList<VitalValue> _VitalValueList; 

		//private IList<Person> _PersonList; 

		private DateTime? _birthday; private int? _gendertypeid;//0
//private GenderType _gendertypeid;//1

		private string _addressline1; 
		private string _addressline2; private string _usstateid;//0
//private USState _usstateid;//1

		private string _nonusstatetitle; 
		private string _city; 
		private string _zipcode; private string _countryid;//0
//private Country _countryid;//1
		
		#endregion

		#region Constructor

		public Person()
		 //: base()
		{
			_personid = -1; 
			//_TimeSeries_SmallInt_SecondsList = new List<TimeSeries_SmallInt_Seconds>(); 
			//_TimeSeriesStripList = new List<TimeSeriesStrip>(); 
			//_VitalValueList = new List<VitalValue>(); 
			//_PersonList = new List<Person>(); 
			_birthday = null; 
			_gendertypeid = null; 
			_addressline1 = null; 
			_addressline2 = null; 
			_usstateid = null; 
			_nonusstatetitle = null; 
			_city = null; 
			_zipcode = null; 
			_countryid = null; 
		}

		public Person(
			long personid)
			: this()
		{
			_personid = personid;
			_birthday = null;
			_gendertypeid = null;
			_addressline1 = String.Empty;
			_addressline2 = String.Empty;
			_usstateid = String.Empty;
			_nonusstatetitle = String.Empty;
			_city = String.Empty;
			_zipcode = String.Empty;
			_countryid = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PersonID
		{
			get
			{ 
				return _personid;
			}
			set
			{
				_personid = value;
			}

		}
			
		public virtual DateTime? Birthday
		{
			get
			{ 
				return _birthday;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for Birthday", value, value.ToString());
						
				_birthday = value;	
			}			
					
		}
			
		public virtual int? GenderTypeID
		{
			get
			{ 
				return _gendertypeid;
			}
			set
			{
				_gendertypeid = value;
			}

		}
			
		public virtual string AddressLine1
		{
			get
			{ 
				return _addressline1;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AddressLine1", value, value.ToString());
				
				_addressline1 = value;
			}
		}
			
		public virtual string AddressLine2
		{
			get
			{ 
				return _addressline2;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AddressLine2", value, value.ToString());
				
				_addressline2 = value;
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
				//if(  value != null &&  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStateID", value, value.ToString());
				
				_usstateid = value;
			}
		}
			
		public virtual string NonUSStateTitle
		{
			get
			{ 
				return _nonusstatetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for NonUSStateTitle", value, value.ToString());
				
				_nonusstatetitle = value;
			}
		}
			
		public virtual string City
		{
			get
			{ 
				return _city;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				
				_city = value;
			}
		}
			
		public virtual string ZipCode
		{
			get
			{ 
				return _zipcode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 15)
				//	throw new ArgumentOutOfRangeException("Invalid value for ZipCode", value, value.ToString());
				
				_zipcode = value;
			}
		}
			
		public virtual string CountryID
		{
			get
			{ 
				return _countryid;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryID", value, value.ToString());
				
				_countryid = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddTimeSeries_SmallInt_Seconds(TimeSeries_SmallInt_Seconds obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_TimeSeries_SmallInt_SecondsList.Add(obj);
		//}
		

		//public virtual void AddTimeSeriesStrip(TimeSeriesStrip obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_TimeSeriesStripList.Add(obj);
		//}
		

		//public virtual void AddVitalValue(VitalValue obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_VitalValueList.Add(obj);
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
            return this.PersonID;
			
        }
		
		#endregion //Public Functions
	}
}
