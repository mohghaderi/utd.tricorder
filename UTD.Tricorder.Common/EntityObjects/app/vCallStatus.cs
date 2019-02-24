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
	public partial class vCallStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "CallStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string CallStatusID = "CallStatusID";
			public const string CallStatusName = "CallStatusName";
			public const string CallStatusTitle = "CallStatusTitle";
			public const string CallStatusIcon = "CallStatusIcon";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("CallStatusID");
			_ColumnsList.Add("CallStatusName");
			_ColumnsList.Add("CallStatusTitle");
			_ColumnsList.Add("CallStatusIcon");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _callstatusid; 
		private string _callstatusname; 
		private string _callstatustitle; 
		private string _callstatusicon; 		
		#endregion

		#region Constructor

		public vCallStatus()
		 //: base()
		{
			_callstatusid = new byte(); 
			_callstatusname = null; 
			_callstatustitle = null; 
			_callstatusicon = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string CallStatusName
		{
			get
			{ 
				return _callstatusname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CallStatusName", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for CallStatusName", value, value.ToString());
				
				_callstatusname = value;
			}
		}
			
		public virtual string CallStatusTitle
		{
			get
			{ 
				return _callstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CallStatusTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for CallStatusTitle", value, value.ToString());
				
				_callstatustitle = value;
			}
		}
			
		public virtual string CallStatusIcon
		{
			get
			{ 
				return _callstatusicon;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for CallStatusIcon", value, value.ToString());
				
				_callstatusicon = value;
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
            return this.CallStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
