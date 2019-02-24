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
	public partial class TicketGroup : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _ticketgroupid;//3

		//private IList<Feedback> _FeedbackList; 

		private string _ticketgroupname; 
		private Guid? _siteid; 		
		#endregion

		#region Constructor

		public TicketGroup()
		 //: base()
		{
			_ticketgroupid = -1; 
			//_FeedbackList = new List<Feedback>(); 
			_ticketgroupname = null; 
			_siteid = null; 
		}

		public TicketGroup(
			int ticketgroupid, 
			string ticketgroupname)
			: this()
		{
			_ticketgroupid = ticketgroupid;
			_ticketgroupname = ticketgroupname;
			_siteid = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int TicketGroupID
		{
			get
			{ 
				return _ticketgroupid;
			}
			set
			{
				_ticketgroupid = value;
			}

		}
			
		public virtual string TicketGroupName
		{
			get
			{ 
				return _ticketgroupname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketGroupName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketGroupName", value, value.ToString());
				
				_ticketgroupname = value;
			}
		}
			
		public virtual Guid? SiteID
		{
			get
			{ 
				return _siteid;
			}
			set
			{
				_siteid = value;
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
            return this.TicketGroupID;
			
        }
		
		#endregion //Public Functions
	}
}
