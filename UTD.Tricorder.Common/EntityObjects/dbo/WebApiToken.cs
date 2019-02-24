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
	public partial class WebApiToken : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private Guid _webapitokenid; private int _webapiclientid;//0
//private WebApiClient _webapiclientid;//1

		private long _userid; 
		private DateTime _issuedutc; 
		private DateTime _expiresutc; 
		private string _protectedticket; 		
		#endregion

		#region Constructor

		public WebApiToken()
		 //: base()
		{
			_webapitokenid = new Guid(); 
			_webapiclientid = -1; 
			_userid = -1; 
			_issuedutc = DateTime.MinValue; 
			_expiresutc = DateTime.MinValue; 
			_protectedticket = null; 
		}

		public WebApiToken(
			Guid webapitokenid, 
			int webapiclientid, 
			long userid, 
			DateTime issuedutc, 
			DateTime expiresutc, 
			string protectedticket)
			: this()
		{
			_webapitokenid = webapitokenid;
			_webapiclientid = webapiclientid;
			_userid = userid;
			_issuedutc = issuedutc;
			_expiresutc = expiresutc;
			_protectedticket = protectedticket;
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
