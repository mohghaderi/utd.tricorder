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
	public partial class vNotificationTemplate : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "NotificationTemplate";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string NotificationTemplateID = "NotificationTemplateID";
			public const string NotificationTitle = "NotificationTitle";
			public const string SMSBody = "SMSBody";
			public const string EmailSubject = "EmailSubject";
			public const string EmailBodyHTML = "EmailBodyHTML";
			public const string ShortWebBody = "ShortWebBody";
			public const string EmailBodyText = "EmailBodyText";
			public const string Description = "Description";
			public const string MobilePushSound = "MobilePushSound";
			public const string MobilePushType = "MobilePushType";
			public const string MobilePushParamsJSON = "MobilePushParamsJSON";
			public const string MobilePushAlert = "MobilePushAlert";
			public const string MobilePushTitle = "MobilePushTitle";
			public const string TimeToLiveSeconds = "TimeToLiveSeconds";
			public const string TemplateDotNetFullClassName = "TemplateDotNetFullClassName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("NotificationTemplateID");
			_ColumnsList.Add("NotificationTitle");
			_ColumnsList.Add("SMSBody");
			_ColumnsList.Add("EmailSubject");
			_ColumnsList.Add("EmailBodyHTML");
			_ColumnsList.Add("ShortWebBody");
			_ColumnsList.Add("EmailBodyText");
			_ColumnsList.Add("Description");
			_ColumnsList.Add("MobilePushSound");
			_ColumnsList.Add("MobilePushType");
			_ColumnsList.Add("MobilePushParamsJSON");
			_ColumnsList.Add("MobilePushAlert");
			_ColumnsList.Add("MobilePushTitle");
			_ColumnsList.Add("TimeToLiveSeconds");
			_ColumnsList.Add("TemplateDotNetFullClassName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _notificationtemplateid; 
		private string _notificationtitle; 
		private string _smsbody; 
		private string _emailsubject; 
		private string _emailbodyhtml; 
		private string _shortwebbody; 
		private string _emailbodytext; 
		private string _description; 
		private string _mobilepushsound; 
		private string _mobilepushtype; 
		private string _mobilepushparamsjson; 
		private string _mobilepushalert; 
		private string _mobilepushtitle; 
		private int? _timetoliveseconds; 
		private string _templatedotnetfullclassname; 		
		#endregion

		#region Constructor

		public vNotificationTemplate()
		 //: base()
		{
			_notificationtemplateid = -1; 
			_notificationtitle = null; 
			_smsbody = null; 
			_emailsubject = null; 
			_emailbodyhtml = null; 
			_shortwebbody = null; 
			_emailbodytext = null; 
			_description = null; 
			_mobilepushsound = null; 
			_mobilepushtype = null; 
			_mobilepushparamsjson = null; 
			_mobilepushalert = null; 
			_mobilepushtitle = null; 
			_timetoliveseconds = null; 
			_templatedotnetfullclassname = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short NotificationTemplateID
		{
			get
			{ 
				return _notificationtemplateid;
			}
			set
			{
				_notificationtemplateid = value;
			}

		}
			
		public virtual string NotificationTitle
		{
			get
			{ 
				return _notificationtitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for NotificationTitle", value, value.ToString());
				
				_notificationtitle = value;
			}
		}
			
		public virtual string SMSBody
		{
			get
			{ 
				return _smsbody;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for SMSBody", value, value.ToString());
				
				_smsbody = value;
			}
		}
			
		public virtual string EmailSubject
		{
			get
			{ 
				return _emailsubject;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailSubject", value, value.ToString());
				
				_emailsubject = value;
			}
		}
			
		public virtual string EmailBodyHTML
		{
			get
			{ 
				return _emailbodyhtml;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailBodyHTML", value, value.ToString());
				
				_emailbodyhtml = value;
			}
		}
			
		public virtual string ShortWebBody
		{
			get
			{ 
				return _shortwebbody;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for ShortWebBody", value, value.ToString());
				
				_shortwebbody = value;
			}
		}
			
		public virtual string EmailBodyText
		{
			get
			{ 
				return _emailbodytext;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailBodyText", value, value.ToString());
				
				_emailbodytext = value;
			}
		}
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual string MobilePushSound
		{
			get
			{ 
				return _mobilepushsound;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushSound", value, value.ToString());
				
				_mobilepushsound = value;
			}
		}
			
		public virtual string MobilePushType
		{
			get
			{ 
				return _mobilepushtype;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushType", value, value.ToString());
				
				_mobilepushtype = value;
			}
		}
			
		public virtual string MobilePushParamsJSON
		{
			get
			{ 
				return _mobilepushparamsjson;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushParamsJSON", value, value.ToString());
				
				_mobilepushparamsjson = value;
			}
		}
			
		public virtual string MobilePushAlert
		{
			get
			{ 
				return _mobilepushalert;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushAlert", value, value.ToString());
				
				_mobilepushalert = value;
			}
		}
			
		public virtual string MobilePushTitle
		{
			get
			{ 
				return _mobilepushtitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushTitle", value, value.ToString());
				
				_mobilepushtitle = value;
			}
		}
			
		public virtual int? TimeToLiveSeconds
		{
			get
			{ 
				return _timetoliveseconds;
			}
			set
			{
				_timetoliveseconds = value;
			}

		}
			
		public virtual string TemplateDotNetFullClassName
		{
			get
			{ 
				return _templatedotnetfullclassname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for TemplateDotNetFullClassName", value, value.ToString());
				
				_templatedotnetfullclassname = value;
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
            return this.NotificationTemplateID;
			
        }
		
		#endregion //Public Functions
	}
}
