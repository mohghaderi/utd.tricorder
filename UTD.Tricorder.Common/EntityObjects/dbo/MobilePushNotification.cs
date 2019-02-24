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
	public partial class MobilePushNotification : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _mobilepushnotificationid; private byte _mobilepushtemplateid;//0
//private MobilePushTemplate _mobilepushtemplateid;//1

		private string _paramsjson; 
		private string _templateparamsjson; private long? _receiveruserid;//0
//private User _receiveruserid;//1

		private string _receivergroupname; private byte _mobilepushnotificationstatusid;//0
//private NotificationStatus _mobilepushnotificationstatusid;//1

		private DateTime _insertdate; private long? _senderuserid;//0
//private User _senderuserid;//1
		
		#endregion

		#region Constructor

		public MobilePushNotification()
		 //: base()
		{
			_mobilepushnotificationid = -1; 
			_mobilepushtemplateid = new byte(); 
			_paramsjson = null; 
			_templateparamsjson = null; 
			_receiveruserid = null; 
			_receivergroupname = null; 
			_mobilepushnotificationstatusid = new byte(); 
			_insertdate = DateTime.MinValue; 
			_senderuserid = null; 
		}

		public MobilePushNotification(
			long mobilepushnotificationid, 
			byte mobilepushtemplateid, 
			byte mobilepushnotificationstatusid, 
			DateTime insertdate)
			: this()
		{
			_mobilepushnotificationid = mobilepushnotificationid;
			_mobilepushtemplateid = mobilepushtemplateid;
			_paramsjson = String.Empty;
			_templateparamsjson = String.Empty;
			_receiveruserid = null;
			_receivergroupname = String.Empty;
			_mobilepushnotificationstatusid = mobilepushnotificationstatusid;
			_insertdate = insertdate;
			_senderuserid = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long MobilePushNotificationID
		{
			get
			{ 
				return _mobilepushnotificationid;
			}
			set
			{
				_mobilepushnotificationid = value;
			}

		}
			
		public virtual byte MobilePushTemplateID
		{
			get
			{ 
				return _mobilepushtemplateid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushTemplateID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushTemplateID", value, value.ToString());
				
				_mobilepushtemplateid = value;
			}

		}
			
		public virtual string ParamsJSON
		{
			get
			{ 
				return _paramsjson;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 400)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParamsJSON", value, value.ToString());
				
				_paramsjson = value;
			}
		}
			
		public virtual string TemplateParamsJSON
		{
			get
			{ 
				return _templateparamsjson;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for TemplateParamsJSON", value, value.ToString());
				
				_templateparamsjson = value;
			}
		}
			
		public virtual long? ReceiverUserID
		{
			get
			{ 
				return _receiveruserid;
			}
			set
			{
				_receiveruserid = value;
			}

		}
			
		public virtual string ReceiverGroupName
		{
			get
			{ 
				return _receivergroupname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverGroupName", value, value.ToString());
				
				_receivergroupname = value;
			}
		}
			
		public virtual byte MobilePushNotificationStatusID
		{
			get
			{ 
				return _mobilepushnotificationstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushNotificationStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushNotificationStatusID", value, value.ToString());
				
				_mobilepushnotificationstatusid = value;
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
			
		public virtual long? SenderUserID
		{
			get
			{ 
				return _senderuserid;
			}
			set
			{
				_senderuserid = value;
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
            return this.MobilePushNotificationID;
			
        }
		
		#endregion //Public Functions
	}
}
