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
	public partial class vWebApiToken : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "WebApiToken";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string WebApiTokenID = "WebApiTokenID";
			public const string WebApiClientID = "WebApiClientID";
			public const string UserID = "UserID";
			public const string IssuedUtc = "IssuedUtc";
			public const string ProtectedTicket = "ProtectedTicket";
			public const string ExpiresUtc = "ExpiresUtc";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("WebApiTokenID");
			_ColumnsList.Add("WebApiClientID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("IssuedUtc");
			_ColumnsList.Add("ProtectedTicket");
			_ColumnsList.Add("ExpiresUtc");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private Guid _webapitokenid; 
		private int _webapiclientid; 
		private long _userid; 
		private DateTime _issuedutc; 
		private string _protectedticket; 
		private DateTime _expiresutc; 		
		#endregion

		#region Constructor

		public vWebApiToken()
		 //: base()
		{
			_webapitokenid = new Guid(); 
			_webapiclientid = -1; 
			_userid = -1; 
			_issuedutc = DateTime.MinValue; 
			_protectedticket = null; 
			_expiresutc = DateTime.MinValue; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual Guid WebApiTokenID
		{
			get
			{ 
				return _webapitokenid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for WebApiTokenID", value, "null");

				_webapitokenid = value;
			}

		}
			
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
			
		public virtual long UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
			}

		}
			
		public virtual DateTime IssuedUtc
		{
			get
			{ 
				return _issuedutc;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for IssuedUtc", value, value.ToString());

				_issuedutc = value;	
			}
					
		}
			
		public virtual string ProtectedTicket
		{
			get
			{ 
				return _protectedticket;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ProtectedTicket", value, "null");
				
				//if(  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for ProtectedTicket", value, value.ToString());
				
				_protectedticket = value;
			}
		}
			
		public virtual DateTime ExpiresUtc
		{
			get
			{ 
				return _expiresutc;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for ExpiresUtc", value, value.ToString());

				_expiresutc = value;	
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
            return this.WebApiTokenID;
			
        }
		
		#endregion //Public Functions
	}
}
