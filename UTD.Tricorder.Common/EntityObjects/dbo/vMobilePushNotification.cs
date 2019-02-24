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
	public partial class vMobilePushNotification : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "MobilePushNotification";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string MobilePushNotificationID = "MobilePushNotificationID";
			public const string MobilePushTemplateID = "MobilePushTemplateID";
			public const string ParamsJSON = "ParamsJSON";
			public const string TemplateParamsJSON = "TemplateParamsJSON";
			public const string ReceiverUserID = "ReceiverUserID";
			public const string MobilePushNotificationStatusID = "MobilePushNotificationStatusID";
			public const string InsertDate = "InsertDate";
			public const string ReceiverGroupName = "ReceiverGroupName";
			public const string SenderUserID = "SenderUserID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("MobilePushNotificationID");
			_ColumnsList.Add("MobilePushTemplateID");
			_ColumnsList.Add("ParamsJSON");
			_ColumnsList.Add("TemplateParamsJSON");
			_ColumnsList.Add("ReceiverUserID");
			_ColumnsList.Add("MobilePushNotificationStatusID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("ReceiverGroupName");
			_ColumnsList.Add("SenderUserID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _mobilepushnotificationid; 
		private byte _mobilepushtemplateid; 
		private string _paramsjson; 
		private string _templateparamsjson; 
		private long? _receiveruserid; 
		private byte _mobilepushnotificationstatusid; 
		private DateTime _insertdate; 
		private string _receivergroupname; 
		private long? _senderuserid; 		
		#endregion

		#region Constructor

		public vMobilePushNotification()
		 //: base()
		{
			_mobilepushnotificationid = -1; 
			_mobilepushtemplateid = new byte(); 
			_paramsjson = null; 
			_templateparamsjson = null; 
			_receiveruserid = null; 
			_mobilepushnotificationstatusid = new byte(); 
			_insertdate = DateTime.MinValue; 
			_receivergroupname = null; 
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
