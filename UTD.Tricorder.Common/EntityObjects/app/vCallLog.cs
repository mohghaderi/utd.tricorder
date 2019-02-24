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
	public partial class vCallLog : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Sender complate name
        /// </summary>
        public virtual string SenderFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.SenderNamePrefix, this.SenderFirstName, this.SenderLastName);
            }
        }

        /// <summary>
        /// Receiver full name
        /// </summary>
        public virtual string ReceiverFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.ReceiverNamePrefix, this.ReceiverFirstName, this.ReceiverLastName);
            }
        }


        private string _ReceiverProfilePicUrl;

        public virtual string ReceiverProfilePicUrl
        {
            get
            {
                return _ReceiverProfilePicUrl;
            }
            set
            {
                _ReceiverProfilePicUrl = value;
            }
        }

        private string _SenderProfilePicUrl;

        public virtual string SenderProfilePicUrl
        {
            get
            {
                return _SenderProfilePicUrl;
            }
            set
            {
                _SenderProfilePicUrl = value;
            }
        }

		#endregion


		public const string EntityName = "CallLog";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string CallLogID = "CallLogID";
			public const string StartDate = "StartDate";
			public const string SenderUserID = "SenderUserID";
			public const string ReceiverUserID = "ReceiverUserID";
			public const string EndDate = "EndDate";
			public const string DurationSeconds = "DurationSeconds";
			public const string EntityRecordID = "EntityRecordID";
			public const string AppEntityID = "AppEntityID";
			public const string CallStatusID = "CallStatusID";
			public const string SenderNamePrefix = "SenderNamePrefix";
			public const string SenderFirstName = "SenderFirstName";
			public const string SenderLastName = "SenderLastName";
			public const string ReceiverFirstName = "ReceiverFirstName";
			public const string ReceiverLastName = "ReceiverLastName";
			public const string ReceiverNamePrefix = "ReceiverNamePrefix";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("CallLogID");
			_ColumnsList.Add("StartDate");
			_ColumnsList.Add("SenderUserID");
			_ColumnsList.Add("ReceiverUserID");
			_ColumnsList.Add("EndDate");
			_ColumnsList.Add("DurationSeconds");
			_ColumnsList.Add("EntityRecordID");
			_ColumnsList.Add("AppEntityID");
			_ColumnsList.Add("CallStatusID");
			_ColumnsList.Add("SenderNamePrefix");
			_ColumnsList.Add("SenderFirstName");
			_ColumnsList.Add("SenderLastName");
			_ColumnsList.Add("ReceiverFirstName");
			_ColumnsList.Add("ReceiverLastName");
			_ColumnsList.Add("ReceiverNamePrefix");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _calllogid; 
		private DateTime _startdate; 
		private long _senderuserid; 
		private long _receiveruserid; 
		private DateTime? _enddate; 
		private int _durationseconds; 
		private long? _entityrecordid; 
		private short _appentityid; 
		private byte _callstatusid; 
		private string _sendernameprefix; 
		private string _senderfirstname; 
		private string _senderlastname; 
		private string _receiverfirstname; 
		private string _receiverlastname; 
		private string _receivernameprefix; 		
		#endregion

		#region Constructor

		public vCallLog()
		 //: base()
		{
			_calllogid = -1; 
			_startdate = DateTime.MinValue; 
			_senderuserid = -1; 
			_receiveruserid = -1; 
			_enddate = null; 
			_durationseconds = -1; 
			_entityrecordid = null; 
			_appentityid = -1; 
			_callstatusid = new byte(); 
			_sendernameprefix = null; 
			_senderfirstname = null; 
			_senderlastname = null; 
			_receiverfirstname = null; 
			_receiverlastname = null; 
			_receivernameprefix = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long CallLogID
		{
			get
			{ 
				return _calllogid;
			}
			set
			{
				_calllogid = value;
			}

		}
			
		public virtual DateTime StartDate
		{
			get
			{ 
				return _startdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for StartDate", value, value.ToString());

				_startdate = value;	
			}
					
		}
			
		public virtual long SenderUserID
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
			
		public virtual long ReceiverUserID
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
			
		public virtual DateTime? EndDate
		{
			get
			{ 
				return _enddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for EndDate", value, value.ToString());
						
				_enddate = value;	
			}			
					
		}
			
		public virtual int DurationSeconds
		{
			get
			{ 
				return _durationseconds;
			}
			set
			{
				_durationseconds = value;
			}

		}
			
		public virtual long? EntityRecordID
		{
			get
			{ 
				return _entityrecordid;
			}
			set
			{
				_entityrecordid = value;
			}

		}
			
		public virtual short AppEntityID
		{
			get
			{ 
				return _appentityid;
			}
			set
			{
				_appentityid = value;
			}

		}
			
		public virtual byte CallStatusID
		{
			get
			{ 
				return _callstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CallStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for CallStatusID", value, value.ToString());
				
				_callstatusid = value;
			}

		}
			
		public virtual string SenderNamePrefix
		{
			get
			{ 
				return _sendernameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderNamePrefix", value, value.ToString());
				
				_sendernameprefix = value;
			}
		}
			
		public virtual string SenderFirstName
		{
			get
			{ 
				return _senderfirstname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderFirstName", value, value.ToString());
				
				_senderfirstname = value;
			}
		}
			
		public virtual string SenderLastName
		{
			get
			{ 
				return _senderlastname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderLastName", value, value.ToString());
				
				_senderlastname = value;
			}
		}
			
		public virtual string ReceiverFirstName
		{
			get
			{ 
				return _receiverfirstname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverFirstName", value, value.ToString());
				
				_receiverfirstname = value;
			}
		}
			
		public virtual string ReceiverLastName
		{
			get
			{ 
				return _receiverlastname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverLastName", value, value.ToString());
				
				_receiverlastname = value;
			}
		}
			
		public virtual string ReceiverNamePrefix
		{
			get
			{ 
				return _receivernameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverNamePrefix", value, value.ToString());
				
				_receivernameprefix = value;
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
            return this.CallLogID;
			
        }
		
		#endregion //Public Functions
	}
}
