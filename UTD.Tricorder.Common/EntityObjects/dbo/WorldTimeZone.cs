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
	public partial class WorldTimeZone : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _worldtimezoneid;//3

		//private IList<User> _UserList; 
private string _countryid;//0
//private Country _countryid;//1

		private string _worldtimezoneiananame; 
		private string _worldtimezonetitle; 
		private string _worldtimezonecomments; 		
		#endregion

		#region Constructor

		public WorldTimeZone()
		 //: base()
		{
			_worldtimezoneid = -1; 
			//_UserList = new List<User>(); 
			_countryid = null; 
			_worldtimezoneiananame = null; 
			_worldtimezonetitle = null; 
			_worldtimezonecomments = null; 
		}

		public WorldTimeZone(
			short worldtimezoneid, 
			string countryid, 
			string worldtimezoneiananame, 
			string worldtimezonetitle, 
			string worldtimezonecomments)
			: this()
		{
			_worldtimezoneid = worldtimezoneid;
			_countryid = countryid;
			_worldtimezoneiananame = worldtimezoneiananame;
			_worldtimezonetitle = worldtimezonetitle;
			_worldtimezonecomments = worldtimezonecomments;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short WorldTimeZoneID
		{
			get
			{ 
				return _worldtimezoneid;
			}
			set
			{
				_worldtimezoneid = value;
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
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CountryID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryID", value, value.ToString());
				
				_countryid = value;
			}
		}
			
		public virtual string WorldTimeZoneIANAName
		{
			get
			{ 
				return _worldtimezoneiananame;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneIANAName", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneIANAName", value, value.ToString());
				
				_worldtimezoneiananame = value;
			}
		}
			
		public virtual string WorldTimeZoneTitle
		{
			get
			{ 
				return _worldtimezonetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneTitle", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneTitle", value, value.ToString());
				
				_worldtimezonetitle = value;
			}
		}
			
		public virtual string WorldTimeZoneComments
		{
			get
			{ 
				return _worldtimezonecomments;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneComments", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneComments", value, value.ToString());
				
				_worldtimezonecomments = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddUser(User obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.WorldTimeZoneID;
			
        }
		
		#endregion //Public Functions
	}
}
