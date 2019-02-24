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
	public partial class TicketStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _ticketstatusid;//3

		//private IList<Feedback> _FeedbackList; 

		private string _ticketstatustitle; 
		private string _ticketstatuscode; 		
		#endregion

		#region Constructor

		public TicketStatus()
		 //: base()
		{
			_ticketstatusid = new byte(); 
			//_FeedbackList = new List<Feedback>(); 
			_ticketstatustitle = null; 
			_ticketstatuscode = null; 
		}

		public TicketStatus(
			byte ticketstatusid, 
			string ticketstatustitle, 
			string ticketstatuscode)
			: this()
		{
			_ticketstatusid = ticketstatusid;
			_ticketstatustitle = ticketstatustitle;
			_ticketstatuscode = ticketstatuscode;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte TicketStatusID
		{
			get
			{ 
				return _ticketstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusID", value, value.ToString());
				
				_ticketstatusid = value;
			}

		}
			
		public virtual string TicketStatusTitle
		{
			get
			{ 
				return _ticketstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusTitle", value, value.ToString());
				
				_ticketstatustitle = value;
			}
		}
			
		public virtual string TicketStatusCode
		{
			get
			{ 
				return _ticketstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusCode", value, value.ToString());
				
				_ticketstatuscode = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddFeedback(Feedback obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_FeedbackList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.TicketStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
