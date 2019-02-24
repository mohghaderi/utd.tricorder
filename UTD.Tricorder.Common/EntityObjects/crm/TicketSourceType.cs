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
	public partial class TicketSourceType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private byte _ticketsourcetypeid; 
		private string _ticketsourcetypetitle; 
		private string _ticketsourcetypecode; 		
		#endregion

		#region Constructor

		public TicketSourceType()
		 //: base()
		{
			_ticketsourcetypeid = new byte(); 
			_ticketsourcetypetitle = null; 
			_ticketsourcetypecode = null; 
		}

		public TicketSourceType(
			byte ticketsourcetypeid, 
			string ticketsourcetypetitle, 
			string ticketsourcetypecode)
			: this()
		{
			_ticketsourcetypeid = ticketsourcetypeid;
			_ticketsourcetypetitle = ticketsourcetypetitle;
			_ticketsourcetypecode = ticketsourcetypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte TicketSourceTypeID
		{
			get
			{ 
				return _ticketsourcetypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeID", value, value.ToString());
				
				_ticketsourcetypeid = value;
			}

		}
			
		public virtual string TicketSourceTypeTitle
		{
			get
			{ 
				return _ticketsourcetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeTitle", value, value.ToString());
				
				_ticketsourcetypetitle = value;
			}
		}
			
		public virtual string TicketSourceTypeCode
		{
			get
			{ 
				return _ticketsourcetypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeCode", value, value.ToString());
				
				_ticketsourcetypecode = value;
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
            return this.TicketSourceTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
