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
	public partial class vAppExceptionLog : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppExceptionLog";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppExceptionLogID = "AppExceptionLogID";
			public const string Message = "Message";
			public const string Source = "Source";
			public const string UserID = "UserID";
			public const string InsertDate = "InsertDate";
			public const string ClassType = "ClassType";
			public const string StackTrace = "StackTrace";
			public const string Target = "Target";
			public const string IPAddress = "IPAddress";
			public const string Url = "Url";
			public const string DataInformation = "DataInformation";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppExceptionLogID");
			_ColumnsList.Add("Message");
			_ColumnsList.Add("Source");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("ClassType");
			_ColumnsList.Add("StackTrace");
			_ColumnsList.Add("Target");
			_ColumnsList.Add("IPAddress");
			_ColumnsList.Add("Url");
			_ColumnsList.Add("DataInformation");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _appexceptionlogid; 
		private string _message; 
		private string _source; 
		private long? _userid; 
		private DateTime _insertdate; 
		private string _classtype; 
		private string _stacktrace; 
		private string _target; 
		private string _ipaddress; 
		private string _url; 
		private string _datainformation; 		
		#endregion

		#region Constructor

		public vAppExceptionLog()
		 //: base()
		{
			_appexceptionlogid = -1; 
			_message = null; 
			_source = null; 
			_userid = null; 
			_insertdate = DateTime.MinValue; 
			_classtype = null; 
			_stacktrace = null; 
			_target = null; 
			_ipaddress = null; 
			_url = null; 
			_datainformation = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long AppExceptionLogID
		{
			get
			{ 
				return _appexceptionlogid;
			}
			set
			{
				_appexceptionlogid = value;
			}

		}
			
		public virtual string Message
		{
			get
			{ 
				return _message;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for Message", value, "null");
				
				//if(  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for Message", value, value.ToString());
				
				_message = value;
			}
		}
			
		public virtual string Source
		{
			get
			{ 
				return _source;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for Source", value, value.ToString());
				
				_source = value;
			}
		}
			
		public virtual long? UserID
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
			
		public virtual string ClassType
		{
			get
			{ 
				return _classtype;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for ClassType", value, value.ToString());
				
				_classtype = value;
			}
		}
			
		public virtual string StackTrace
		{
			get
			{ 
				return _stacktrace;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for StackTrace", value, value.ToString());
				
				_stacktrace = value;
			}
		}
			
		public virtual string Target
		{
			get
			{ 
				return _target;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for Target", value, value.ToString());
				
				_target = value;
			}
		}
			
		public virtual string IPAddress
		{
			get
			{ 
				return _ipaddress;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for IPAddress", value, value.ToString());
				
				_ipaddress = value;
			}
		}
			
		public virtual string Url
		{
			get
			{ 
				return _url;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2048)
				//	throw new ArgumentOutOfRangeException("Invalid value for Url", value, value.ToString());
				
				_url = value;
			}
		}
			
		public virtual string DataInformation
		{
			get
			{ 
				return _datainformation;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for DataInformation", value, value.ToString());
				
				_datainformation = value;
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
            return this.AppExceptionLogID;
			
        }
		
		#endregion //Public Functions
	}
}
