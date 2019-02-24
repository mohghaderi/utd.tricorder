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
	public partial class TicketPriority : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _ticketpriorityid;//3

		//private IList<Feedback> _FeedbackList; 

		private string _ticketprioritytitle; 
		private string _ticketprioritycode; 		
		#endregion

		#region Constructor

		public TicketPriority()
		 //: base()
		{
			_ticketpriorityid = new byte(); 
			//_FeedbackList = new List<Feedback>(); 
			_ticketprioritytitle = null; 
			_ticketprioritycode = null; 
		}

		public TicketPriority(
			byte ticketpriorityid, 
			string ticketprioritytitle, 
			string ticketprioritycode)
			: this()
		{
			_ticketpriorityid = ticketpriorityid;
			_ticketprioritytitle = ticketprioritytitle;
			_ticketprioritycode = ticketprioritycode;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte TicketPriorityID
		{
			get
			{ 
				return _ticketpriorityid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityID", value, value.ToString());
				
				_ticketpriorityid = value;
			}

		}
			
		public virtual string TicketPriorityTitle
		{
			get
			{ 
				return _ticketprioritytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityTitle", value, value.ToString());
				
				_ticketprioritytitle = value;
			}
		}
			
		public virtual string TicketPriorityCode
		{
			get
			{ 
				return _ticketprioritycode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityCode", value, value.ToString());
				
				_ticketprioritycode = value;
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
            return this.TicketPriorityID;
			
        }
		
		#endregion //Public Functions
	}
}
