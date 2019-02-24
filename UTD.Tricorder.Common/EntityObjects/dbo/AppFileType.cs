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
	public partial class AppFileType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _appfiletypeid;//3

		//private IList<AppFile> _AppFileList; 

		//private IList<AppFileType> _AppFileTypeList; 
private short _appentityid;//0
//private AppEntity _appentityid;//1

		private string _appfiletypetitle; private int? _parentfiletypeid;//0
//private AppFileType _parentfiletypeid;//1

		private int _maxnumberoffiles; 
		private bool _ismandatory; 
		private int _minfilesize; 
		private int _maxfilesize; 
		private string _acceptableformatscommaseparated; 
		private string _virtualpathtemplate; private short _appfilestoragetypeid;//0
//private AppFileStorageType _appfilestoragetypeid;//1

		private bool _hassecuritycheck; 		
		#endregion

		#region Constructor

		public AppFileType()
		 //: base()
		{
			_appfiletypeid = -1; 
			//_AppFileList = new List<AppFile>(); 
			//_AppFileTypeList = new List<AppFileType>(); 
			_appentityid = -1; 
			_appfiletypetitle = null; 
			_parentfiletypeid = null; 
			_maxnumberoffiles = -1; 
			_ismandatory = false; 
			_minfilesize = -1; 
			_maxfilesize = -1; 
			_acceptableformatscommaseparated = null; 
			_virtualpathtemplate = null; 
			_appfilestoragetypeid = -1; 
			_hassecuritycheck = false; 
		}

		public AppFileType(
			int appfiletypeid, 
			short appentityid, 
			string appfiletypetitle, 
			int maxnumberoffiles, 
			bool ismandatory, 
			int minfilesize, 
			int maxfilesize, 
			string acceptableformatscommaseparated, 
			string virtualpathtemplate, 
			short appfilestoragetypeid, 
			bool hassecuritycheck)
			: this()
		{
			_appfiletypeid = appfiletypeid;
			_appentityid = appentityid;
			_appfiletypetitle = appfiletypetitle;
			_parentfiletypeid = null;
			_maxnumberoffiles = maxnumberoffiles;
			_ismandatory = ismandatory;
			_minfilesize = minfilesize;
			_maxfilesize = maxfilesize;
			_acceptableformatscommaseparated = acceptableformatscommaseparated;
			_virtualpathtemplate = virtualpathtemplate;
			_appfilestoragetypeid = appfilestoragetypeid;
			_hassecuritycheck = hassecuritycheck;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddAppFile(AppFile obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_AppFileList.Add(obj);
		//}
		

		//public virtual void AddAppFileType(AppFileType obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_AppFileTypeList.Add(obj);
		//}
		


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
