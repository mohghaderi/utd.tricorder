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
	public partial class vAppFileUploadStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppFileUploadStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppFileUploadStatusID = "AppFileUploadStatusID";
			public const string AppFileUploadStatusTitle = "AppFileUploadStatusTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppFileUploadStatusID");
			_ColumnsList.Add("AppFileUploadStatusTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _appfileuploadstatusid; 
		private string _appfileuploadstatustitle; 		
		#endregion

		#region Constructor

		public vAppFileUploadStatus()
		 //: base()
		{
			_appfileuploadstatusid = -1; 
			_appfileuploadstatustitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short AppFileUploadStatusID
		{
			get
			{ 
				return _appfileuploadstatusid;
			}
			set
			{
				_appfileuploadstatusid = value;
			}

		}
			
		public virtual string AppFileUploadStatusTitle
		{
			get
			{ 
				return _appfileuploadstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppFileUploadStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppFileUploadStatusTitle", value, value.ToString());
				
				_appfileuploadstatustitle = value;
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
            return this.AppFileUploadStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
