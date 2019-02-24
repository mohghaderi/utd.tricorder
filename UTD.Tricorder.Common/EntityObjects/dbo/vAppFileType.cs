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
	public partial class vAppFileType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppFileType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppFileTypeID = "AppFileTypeID";
			public const string AppEntityID = "AppEntityID";
			public const string AppFileTypeTitle = "AppFileTypeTitle";
			public const string ParentFileTypeID = "ParentFileTypeID";
			public const string IsMandatory = "IsMandatory";
			public const string MaxFileSize = "MaxFileSize";
			public const string AcceptableFormatsCommaSeparated = "AcceptableFormatsCommaSeparated";
			public const string AppEntityName = "AppEntityName";
			public const string ParentAppEntityID = "ParentAppEntityID";
			public const string ParentAppFileTypeTitle = "ParentAppFileTypeTitle";
			public const string VirtualPathTemplate = "VirtualPathTemplate";
			public const string AppFileStorageTypeID = "AppFileStorageTypeID";
			public const string AppFileStorageTypeTitle = "AppFileStorageTypeTitle";
			public const string AppFileStorageSettings = "AppFileStorageSettings";
			public const string MaxNumberOfFiles = "MaxNumberOfFiles";
			public const string MinFileSize = "MinFileSize";
			public const string HasSecurityCheck = "HasSecurityCheck";
			public const string AppEntityADK = "AppEntityADK";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppFileTypeID");
			_ColumnsList.Add("AppEntityID");
			_ColumnsList.Add("AppFileTypeTitle");
			_ColumnsList.Add("ParentFileTypeID");
			_ColumnsList.Add("IsMandatory");
			_ColumnsList.Add("MaxFileSize");
			_ColumnsList.Add("AcceptableFormatsCommaSeparated");
			_ColumnsList.Add("AppEntityName");
			_ColumnsList.Add("ParentAppEntityID");
			_ColumnsList.Add("ParentAppFileTypeTitle");
			_ColumnsList.Add("VirtualPathTemplate");
			_ColumnsList.Add("AppFileStorageTypeID");
			_ColumnsList.Add("AppFileStorageTypeTitle");
			_ColumnsList.Add("AppFileStorageSettings");
			_ColumnsList.Add("MaxNumberOfFiles");
			_ColumnsList.Add("MinFileSize");
			_ColumnsList.Add("HasSecurityCheck");
			_ColumnsList.Add("AppEntityADK");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _appfiletypeid; 
		private short _appentityid; 
		private string _appfiletypetitle; 
		private int? _parentfiletypeid; 
		private bool _ismandatory; 
		private int _maxfilesize; 
		private string _acceptableformatscommaseparated; 
		private string _appentityname; 
		private short? _parentappentityid; 
		private string _parentappfiletypetitle; 
		private string _virtualpathtemplate; 
		private short _appfilestoragetypeid; 
		private string _appfilestoragetypetitle; 
		private string _appfilestoragesettings; 
		private int _maxnumberoffiles; 
		private int _minfilesize; 
		private bool _hassecuritycheck; 
		private string _appentityadk; 		
		#endregion

		#region Constructor

		public vAppFileType()
		 //: base()
		{
			_appfiletypeid = -1; 
			_appentityid = -1; 
			_appfiletypetitle = null; 
			_parentfiletypeid = null; 
			_ismandatory = false; 
			_maxfilesize = -1; 
			_acceptableformatscommaseparated = null; 
			_appentityname = null; 
			_parentappentityid = null; 
			_parentappfiletypetitle = null; 
			_virtualpathtemplate = null; 
			_appfilestoragetypeid = -1; 
			_appfilestoragetypetitle = null; 
			_appfilestoragesettings = null; 
			_maxnumberoffiles = -1; 
			_minfilesize = -1; 
			_hassecuritycheck = false; 
			_appentityadk = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int AppFileTypeID
		{
			get
			{ 
				return _appfiletypeid;
			}
			set
			{
				_appfiletypeid = value;
			}

		}
			
		public virtual short AppEntityID
		{
			get
			{ 
				return _appentityid;
			}
			set
			{
				_appentityid = value;
			}

		}
			
		public virtual string AppFileTypeTitle
		{
			get
			{ 
				return _appfiletypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppFileTypeTitle", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppFileTypeTitle", value, value.ToString());
				
				_appfiletypetitle = value;
			}
		}
			
		public virtual int? ParentFileTypeID
		{
			get
			{ 
				return _parentfiletypeid;
			}
			set
			{
				_parentfiletypeid = value;
			}

		}
			
		public virtual bool IsMandatory
		{
			get
			{ 
				return _ismandatory;
			}
			set
			{
				_ismandatory = value;
			}

		}
			
		public virtual int MaxFileSize
		{
			get
			{ 
				return _maxfilesize;
			}
			set
			{
				_maxfilesize = value;
			}

		}
			
		public virtual string AcceptableFormatsCommaSeparated
		{
			get
			{ 
				return _acceptableformatscommaseparated;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AcceptableFormatsCommaSeparated", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AcceptableFormatsCommaSeparated", value, value.ToString());
				
				_acceptableformatscommaseparated = value;
			}
		}
			
		public virtual string AppEntityName
		{
			get
			{ 
				return _appentityname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppEntityName", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityName", value, value.ToString());
				
				_appentityname = value;
			}
		}
			
		public virtual short? ParentAppEntityID
		{
			get
			{ 
				return _parentappentityid;
			}
			set
			{
				_parentappentityid = value;
			}

		}
			
		public virtual string ParentAppFileTypeTitle
		{
			get
			{ 
				return _parentappfiletypetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParentAppFileTypeTitle", value, value.ToString());
				
				_parentappfiletypetitle = value;
			}
		}
			
		public virtual string VirtualPathTemplate
		{
			get
			{ 
				return _virtualpathtemplate;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VirtualPathTemplate", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for VirtualPathTemplate", value, value.ToString());
				
				_virtualpathtemplate = value;
			}
		}
			
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
				//if(  value != null &&  value.Length > 200)
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
			
		public virtual int MaxNumberOfFiles
		{
			get
			{ 
				return _maxnumberoffiles;
			}
			set
			{
				_maxnumberoffiles = value;
			}

		}
			
		public virtual int MinFileSize
		{
			get
			{ 
				return _minfilesize;
			}
			set
			{
				_minfilesize = value;
			}

		}
			
		public virtual bool HasSecurityCheck
		{
			get
			{ 
				return _hassecuritycheck;
			}
			set
			{
				_hassecuritycheck = value;
			}

		}
			
		public virtual string AppEntityADK
		{
			get
			{ 
				return _appentityadk;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityADK", value, value.ToString());
				
				_appentityadk = value;
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
            return this.AppFileTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
