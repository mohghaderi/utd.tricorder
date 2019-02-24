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
	public partial class vWebApiClient : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "WebApiClient";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string WebApiClientID = "WebApiClientID";
			public const string SecretKey = "SecretKey";
			public const string ClientCode = "ClientCode";
			public const string IsActive = "IsActive";
			public const string RefreshLifeTimeMinutes = "RefreshLifeTimeMinutes";
			public const string AllowedOrigin = "AllowedOrigin";
			public const string CheckSecret = "CheckSecret";
			public const string OwnerUserID = "OwnerUserID";
			public const string InsertDate = "InsertDate";
			public const string UserApprovalStatusID = "UserApprovalStatusID";
			public const string SiteID = "SiteID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("WebApiClientID");
			_ColumnsList.Add("SecretKey");
			_ColumnsList.Add("ClientCode");
			_ColumnsList.Add("IsActive");
			_ColumnsList.Add("RefreshLifeTimeMinutes");
			_ColumnsList.Add("AllowedOrigin");
			_ColumnsList.Add("CheckSecret");
			_ColumnsList.Add("OwnerUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UserApprovalStatusID");
			_ColumnsList.Add("SiteID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _webapiclientid; 
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

		public vWebApiClient()
		 //: base()
		{
			_webapiclientid = -1; 
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
