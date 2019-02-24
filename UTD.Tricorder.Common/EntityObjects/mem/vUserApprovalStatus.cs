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
	public partial class vUserApprovalStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "UserApprovalStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string UserApprovalStatusID = "UserApprovalStatusID";
			public const string UserApprovalStatusTitle = "UserApprovalStatusTitle";
			public const string UserApprovalStatusCode = "UserApprovalStatusCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("UserApprovalStatusID");
			_ColumnsList.Add("UserApprovalStatusTitle");
			_ColumnsList.Add("UserApprovalStatusCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _userapprovalstatusid; 
		private string _userapprovalstatustitle; 
		private string _userapprovalstatuscode; 		
		#endregion

		#region Constructor

		public vUserApprovalStatus()
		 //: base()
		{
			_userapprovalstatusid = -1; 
			_userapprovalstatustitle = null; 
			_userapprovalstatuscode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int UserApprovalStatusID
		{
			get
			{ 
				return _userapprovalstatusid;
			}
			set
			{
				_userapprovalstatusid = value;
			}

		}
			
		public virtual string UserApprovalStatusTitle
		{
			get
			{ 
				return _userapprovalstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserApprovalStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserApprovalStatusTitle", value, value.ToString());
				
				_userapprovalstatustitle = value;
			}
		}
			
		public virtual string UserApprovalStatusCode
		{
			get
			{ 
				return _userapprovalstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserApprovalStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserApprovalStatusCode", value, value.ToString());
				
				_userapprovalstatuscode = value;
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
            return this.UserApprovalStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
