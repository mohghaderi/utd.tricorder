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
	public partial class vTicketSourceType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TicketSourceType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TicketSourceTypeID = "TicketSourceTypeID";
			public const string TicketSourceTypeTitle = "TicketSourceTypeTitle";
			public const string TicketSourceTypeCode = "TicketSourceTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TicketSourceTypeID");
			_ColumnsList.Add("TicketSourceTypeTitle");
			_ColumnsList.Add("TicketSourceTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _ticketsourcetypeid; 
		private string _ticketsourcetypetitle; 
		private string _ticketsourcetypecode; 		
		#endregion

		#region Constructor

		public vTicketSourceType()
		 //: base()
		{
			_ticketsourcetypeid = new byte(); 
			_ticketsourcetypetitle = null; 
			_ticketsourcetypecode = null; 
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
