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
	public partial class SiteDomain : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _sitedomainid; 
		private int _siteid; 
		private string _sitedomainname; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private bool _isactive; 
		private short _defaultlanguageid; 		
		#endregion

		#region Constructor

		public SiteDomain()
		 //: base()
		{
			_sitedomainid = -1; 
			_siteid = -1; 
			_sitedomainname = null; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_isactive = false; 
			_defaultlanguageid = -1; 
		}

		public SiteDomain(
			long sitedomainid, 
			int siteid, 
			string sitedomainname, 
			long insertuserid, 
			DateTime insertdate, 
			bool isactive, 
			short defaultlanguageid)
			: this()
		{
			_sitedomainid = sitedomainid;
			_siteid = siteid;
			_sitedomainname = sitedomainname;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_isactive = isactive;
			_defaultlanguageid = defaultlanguageid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long SiteDomainID
		{
			get
			{ 
				return _sitedomainid;
			}
			set
			{
				_sitedomainid = value;
			}

		}
			
		public virtual int SiteID
		{
			get
			{ 
				return _siteid;
			}
			set
			{
				_siteid = value;
			}

		}
			
		public virtual string SiteDomainName
		{
			get
			{ 
				return _sitedomainname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SiteDomainName", value, "null");
				
				//if(  value.Length > 255)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteDomainName", value, value.ToString());
				
				_sitedomainname = value;
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
			
		public virtual bool IsActive
		{
			get
			{ 
				return _isactive;
			}
			set
			{
				_isactive = value;
			}

		}
			
		public virtual short DefaultLanguageID
		{
			get
			{ 
				return _defaultlanguageid;
			}
			set
			{
				_defaultlanguageid = value;
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
            return this.SiteDomainID;
			
        }
		
		#endregion //Public Functions
	}
}
