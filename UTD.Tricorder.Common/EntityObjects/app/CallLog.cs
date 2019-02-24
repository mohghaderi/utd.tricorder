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
	public partial class CallLog : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


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

		#region Private Members

		private long _calllogid; private long _senderuserid;//0
//private User _senderuserid;//1
private long _receiveruserid;//0
//private User _receiveruserid;//1

		private DateTime _startdate; 
		private DateTime? _enddate; 
		private int _durationseconds; 
		private long? _entityrecordid; private short _appentityid;//0
//private AppEntity _appentityid;//1
private byte _callstatusid;//0
//private CallStatus _callstatusid;//1
		
		#endregion

		#region Constructor

		public CallLog()
		 //: base()
		{
			_calllogid = -1; 
			_senderuserid = -1; 
			_receiveruserid = -1; 
			_startdate = DateTime.MinValue; 
			_enddate = null; 
			_durationseconds = -1; 
			_entityrecordid = null; 
			_appentityid = -1; 
			_callstatusid = new byte(); 
		}

		public CallLog(
			long calllogid, 
			long senderuserid, 
			long receiveruserid, 
			DateTime startdate, 
			int durationseconds, 
			short appentityid, 
			byte callstatusid)
			: this()
		{
			_calllogid = calllogid;
			_senderuserid = senderuserid;
			_receiveruserid = receiveruserid;
			_startdate = startdate;
			_enddate = null;
			_durationseconds = durationseconds;
			_entityrecordid = null;
			_appentityid = appentityid;
			_callstatusid = callstatusid;
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
