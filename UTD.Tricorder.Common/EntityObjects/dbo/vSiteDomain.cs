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
	public partial class vSiteDomain : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "SiteDomain";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string SiteDomainID = "SiteDomainID";
			public const string SiteID = "SiteID";
			public const string SiteDomainName = "SiteDomainName";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string IsActive = "IsActive";
			public const string DefaultLanguageID = "DefaultLanguageID";
			public const string SiteCode = "SiteCode";
			public const string SiteTitle = "SiteTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("SiteDomainID");
			_ColumnsList.Add("SiteID");
			_ColumnsList.Add("SiteDomainName");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("IsActive");
			_ColumnsList.Add("DefaultLanguageID");
			_ColumnsList.Add("SiteCode");
			_ColumnsList.Add("SiteTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _sitedomainid; 
		private int _siteid; 
		private string _sitedomainname; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private bool _isactive; 
		private short _defaultlanguageid; 
		private string _sitecode; 
		private string _sitetitle; 		
		#endregion

		#region Constructor

		public vSiteDomain()
		 //: base()
		{
			_sitedomainid = -1; 
			_siteid = -1; 
			_sitedomainname = null; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_isactive = false; 
			_defaultlanguageid = -1; 
			_sitecode = null; 
			_sitetitle = null; 
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
			
		public virtual string SiteCode
		{
			get
			{ 
				return _sitecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SiteCode", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteCode", value, value.ToString());
				
				_sitecode = value;
			}
		}
			
		public virtual string SiteTitle
		{
			get
			{ 
				return _sitetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SiteTitle", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteTitle", value, value.ToString());
				
				_sitetitle = value;
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
