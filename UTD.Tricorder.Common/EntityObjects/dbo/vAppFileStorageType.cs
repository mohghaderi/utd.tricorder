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
	public partial class vAppFileStorageType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppFileStorageType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppFileStorageTypeID = "AppFileStorageTypeID";
			public const string AppFileStorageTypeTitle = "AppFileStorageTypeTitle";
			public const string AppFileStorageSettings = "AppFileStorageSettings";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppFileStorageTypeID");
			_ColumnsList.Add("AppFileStorageTypeTitle");
			_ColumnsList.Add("AppFileStorageSettings");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _appfilestoragetypeid; 
		private string _appfilestoragetypetitle; 
		private string _appfilestoragesettings; 		
		#endregion

		#region Constructor

		public vAppFileStorageType()
		 //: base()
		{
			_appfilestoragetypeid = -1; 
			_appfilestoragetypetitle = null; 
			_appfilestoragesettings = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short AppFileStorageTypeID
		{
			get
			{ 
				return _appfilestoragetypeid;
			}
			set
			{
				_appfilestoragetypeid = value;
			}

		}
			
		public virtual string AppFileStorageTypeTitle
		{
			get
			{ 
				return _appfilestoragetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppFileStorageTypeTitle", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppFileStorageTypeTitle", value, value.ToString());
				
				_appfilestoragetypetitle = value;
			}
		}
			
		public virtual string AppFileStorageSettings
		{
			get
			{ 
				return _appfilestoragesettings;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppFileStorageSettings", value, value.ToString());
				
				_appfilestoragesettings = value;
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
            return this.AppFileStorageTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
