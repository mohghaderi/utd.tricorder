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
	public partial class vTicketPriority : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TicketPriority";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TicketPriorityID = "TicketPriorityID";
			public const string TicketPriorityTitle = "TicketPriorityTitle";
			public const string TicketPriorityCode = "TicketPriorityCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TicketPriorityID");
			_ColumnsList.Add("TicketPriorityTitle");
			_ColumnsList.Add("TicketPriorityCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _ticketpriorityid; 
		private string _ticketprioritytitle; 
		private string _ticketprioritycode; 		
		#endregion

		#region Constructor

		public vTicketPriority()
		 //: base()
		{
			_ticketpriorityid = new byte(); 
			_ticketprioritytitle = null; 
			_ticketprioritycode = null; 
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
