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
	public partial class vTicketStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TicketStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TicketStatusID = "TicketStatusID";
			public const string TicketStatusCode = "TicketStatusCode";
			public const string TicketStatusTitle = "TicketStatusTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TicketStatusID");
			_ColumnsList.Add("TicketStatusCode");
			_ColumnsList.Add("TicketStatusTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _ticketstatusid; 
		private string _ticketstatuscode; 
		private string _ticketstatustitle; 		
		#endregion

		#region Constructor

		public vTicketStatus()
		 //: base()
		{
			_ticketstatusid = new byte(); 
			_ticketstatuscode = null; 
			_ticketstatustitle = null; 
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
			
				
		#endregion 

		#region Public Functions


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
