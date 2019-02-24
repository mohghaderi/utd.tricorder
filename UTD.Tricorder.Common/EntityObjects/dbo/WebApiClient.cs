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
	public partial class WebApiClient : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _webapiclientid;//3

		//private IList<WebApiToken> _WebApiTokenList; 

		private string _secretkey; 
		private string _clientcode; 
		private bool _isactive; 
		private int _refreshlifetimeminutes; 
		private string _allowedorigin; 
		private bool _checksecret; 
		private long _owneruserid; 
		private DateTime _insertdate; 
		private byte _userapprovalstatusid; 
		private int _siteid; 		
		#endregion

		#region Constructor

		public WebApiClient()
		 //: base()
		{
			_webapiclientid = -1; 
			//_WebApiTokenList = new List<WebApiToken>(); 
			_secretkey = null; 
			_clientcode = null; 
			_isactive = false; 
			_refreshlifetimeminutes = -1; 
			_allowedorigin = null; 
			_checksecret = false; 
			_owneruserid = -1; 
			_insertdate = DateTime.MinValue; 
			_userapprovalstatusid = new byte(); 
			_siteid = -1; 
		}

		public WebApiClient(
			int webapiclientid, 
			string secretkey, 
			string clientcode, 
			bool isactive, 
			int refreshlifetimeminutes, 
			string allowedorigin, 
			bool checksecret, 
			long owneruserid, 
			DateTime insertdate, 
			byte userapprovalstatusid, 
			int siteid)
			: this()
		{
			_webapiclientid = webapiclientid;
			_secretkey = secretkey;
			_clientcode = clientcode;
			_isactive = isactive;
			_refreshlifetimeminutes = refreshlifetimeminutes;
			_allowedorigin = allowedorigin;
			_checksecret = checksecret;
			_owneruserid = owneruserid;
			_insertdate = insertdate;
			_userapprovalstatusid = userapprovalstatusid;
			_siteid = siteid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int WebApiClientID
		{
			get
			{ 
				return _webapiclientid;
			}
			set
			{
				_webapiclientid = value;
			}

		}
			
		public virtual string SecretKey
		{
			get
			{ 
				return _secretkey;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SecretKey", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SecretKey", value, value.ToString());
				
				_secretkey = value;
			}
		}
			
		public virtual string ClientCode
		{
			get
			{ 
				return _clientcode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ClientCode", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for ClientCode", value, value.ToString());
				
				_clientcode = value;
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
			
		public virtual int RefreshLifeTimeMinutes
		{
			get
			{ 
				return _refreshlifetimeminutes;
			}
			set
			{
				_refreshlifetimeminutes = value;
			}

		}
			
		public virtual string AllowedOrigin
		{
			get
			{ 
				return _allowedorigin;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AllowedOrigin", value, "null");
				
				//if(  value.Length > 1024)
				//	throw new ArgumentOutOfRangeException("Invalid value for AllowedOrigin", value, value.ToString());
				
				_allowedorigin = value;
			}
		}
			
		public virtual bool CheckSecret
		{
			get
			{ 
				return _checksecret;
			}
			set
			{
				_checksecret = value;
			}

		}
			
		public virtual long OwnerUserID
		{
			get
			{ 
				return _owneruserid;
			}
			set
			{
				_owneruserid = value;
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
			
		public virtual byte UserApprovalStatusID
		{
			get
			{ 
				return _userapprovalstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserApprovalStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserApprovalStatusID", value, value.ToString());
				
				_userapprovalstatusid = value;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddWebApiToken(WebApiToken obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_WebApiTokenList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.WebApiClientID;
			
        }
		
		#endregion //Public Functions
	}
}
