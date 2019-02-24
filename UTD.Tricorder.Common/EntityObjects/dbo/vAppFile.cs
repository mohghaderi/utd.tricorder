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
	public partial class vAppFile : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public virtual string DownloadUrl
        {
            get;
            set;
        }

        public virtual string FileSizeUserFriendly
        {
            get
            {
                if (this.FileSize.HasValue)
                    return FWUtils.MiscUtils.GetReadableFileSize(this.FileSize.Value);
                else
                    return FWUtils.MiscUtils.GetReadableFileSize(0);
            }
        }

		#endregion


		public const string EntityName = "AppFile";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppFileID = "AppFileID";
			public const string AppFileTypeID = "AppFileTypeID";
			public const string AppEntityRecordIDValue = "AppEntityRecordIDValue";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string FileDate = "FileDate";
			public const string FileName = "FileName";
			public const string FileType = "FileType";
			public const string FileBytes = "FileBytes";
			public const string FileSize = "FileSize";
			public const string Description = "Description";
			public const string VersionTimeStamp = "VersionTimeStamp";
			public const string ExtraString1 = "ExtraString1";
			public const string ExtraString2 = "ExtraString2";
			public const string ExtraInt = "ExtraInt";
			public const string ExtraDouble = "ExtraDouble";
			public const string ExtraBigInt = "ExtraBigInt";
			public const string ExtraGuid = "ExtraGuid";
			public const string AppFileUploadStatusID = "AppFileUploadStatusID";
			public const string VirtualPathTemplate = "VirtualPathTemplate";
			public const string AppFileStorageTypeID = "AppFileStorageTypeID";
			public const string ParentFileTypeID = "ParentFileTypeID";
			public const string FileUUID = "FileUUID";
			public const string FileTitle = "FileTitle";
			public const string AppEntityID = "AppEntityID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppFileID");
			_ColumnsList.Add("AppFileTypeID");
			_ColumnsList.Add("AppEntityRecordIDValue");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("FileDate");
			_ColumnsList.Add("FileName");
			_ColumnsList.Add("FileType");
			_ColumnsList.Add("FileBytes");
			_ColumnsList.Add("FileSize");
			_ColumnsList.Add("Description");
			_ColumnsList.Add("VersionTimeStamp");
			_ColumnsList.Add("ExtraString1");
			_ColumnsList.Add("ExtraString2");
			_ColumnsList.Add("ExtraInt");
			_ColumnsList.Add("ExtraDouble");
			_ColumnsList.Add("ExtraBigInt");
			_ColumnsList.Add("ExtraGuid");
			_ColumnsList.Add("AppFileUploadStatusID");
			_ColumnsList.Add("VirtualPathTemplate");
			_ColumnsList.Add("AppFileStorageTypeID");
			_ColumnsList.Add("ParentFileTypeID");
			_ColumnsList.Add("FileUUID");
			_ColumnsList.Add("FileTitle");
			_ColumnsList.Add("AppEntityID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _appfileid; 
		private int _appfiletypeid; 
		private long _appentityrecordidvalue; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private DateTime? _filedate; 
		private string _filename; 
		private string _filetype; 
		private byte[] _filebytes; 
		private int? _filesize; 
		private string _description; 
		private byte[] _versiontimestamp; 
		private string _extrastring1; 
		private string _extrastring2; 
		private int? _extraint; 
		private double? _extradouble; 
		private long? _extrabigint; 
		private Guid? _extraguid; 
		private short _appfileuploadstatusid; 
		private string _virtualpathtemplate; 
		private short? _appfilestoragetypeid; 
		private int? _parentfiletypeid; 
		private Guid _fileuuid; 
		private string _filetitle; 
		private short? _appentityid; 		
		#endregion

		#region Constructor

		public vAppFile()
		 //: base()
		{
			_appfileid = -1; 
			_appfiletypeid = -1; 
			_appentityrecordidvalue = -1; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_filedate = null; 
			_filename = null; 
			_filetype = null; 
			_filebytes = null; 
			_filesize = null; 
			_description = null; 
			_versiontimestamp = null; 
			_extrastring1 = null; 
			_extrastring2 = null; 
			_extraint = null; 
			_extradouble = null; 
			_extrabigint = null; 
			_extraguid = null; 
			_appfileuploadstatusid = -1; 
			_virtualpathtemplate = null; 
			_appfilestoragetypeid = null; 
			_parentfiletypeid = null; 
			_fileuuid = new Guid(); 
			_filetitle = null; 
			_appentityid = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long AppFileID
		{
			get
			{ 
				return _appfileid;
			}
			set
			{
				_appfileid = value;
			}

		}
			
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
			
		public virtual long AppEntityRecordIDValue
		{
			get
			{ 
				return _appentityrecordidvalue;
			}
			set
			{
				_appentityrecordidvalue = value;
			}

		}
			
		public virtual long InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
			}			
					
		}
			
		public virtual DateTime? FileDate
		{
			get
			{ 
				return _filedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for FileDate", value, value.ToString());
						
				_filedate = value;	
			}			
					
		}
			
		public virtual string FileName
		{
			get
			{ 
				return _filename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for FileName", value, value.ToString());
				
				_filename = value;
			}
		}
			
		public virtual string FileType
		{
			get
			{ 
				return _filetype;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 6)
				//	throw new ArgumentOutOfRangeException("Invalid value for FileType", value, value.ToString());
				
				_filetype = value;
			}
		}
			
		public virtual byte[] FileBytes
		{
			get
			{ 
				return _filebytes;
			}
			set
			{
				_filebytes = value;
			}

		}
			
		public virtual int? FileSize
		{
			get
			{ 
				return _filesize;
			}
			set
			{
				_filesize = value;
			}

		}
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual byte[] VersionTimeStamp
		{
			get
			{ 
				return _versiontimestamp;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for VersionTimeStamp", value, "null");

				_versiontimestamp = value;
			}

		}
			
		public virtual string ExtraString1
		{
			get
			{ 
				return _extrastring1;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for ExtraString1", value, value.ToString());
				
				_extrastring1 = value;
			}
		}
			
		public virtual string ExtraString2
		{
			get
			{ 
				return _extrastring2;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2147483647)
				//	throw new ArgumentOutOfRangeException("Invalid value for ExtraString2", value, value.ToString());
				
				_extrastring2 = value;
			}
		}
			
		public virtual int? ExtraInt
		{
			get
			{ 
				return _extraint;
			}
			set
			{
				_extraint = value;
			}

		}
			
		public virtual double? ExtraDouble
		{
			get
			{ 
				return _extradouble;
			}
			set
			{
				_extradouble = value;
			}

		}
			
		public virtual long? ExtraBigInt
		{
			get
			{ 
				return _extrabigint;
			}
			set
			{
				_extrabigint = value;
			}

		}
			
		public virtual Guid? ExtraGuid
		{
			get
			{ 
				return _extraguid;
			}
			set
			{
				_extraguid = value;
			}

		}
			
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
			
		public virtual string VirtualPathTemplate
		{
			get
			{ 
				return _virtualpathtemplate;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for VirtualPathTemplate", value, value.ToString());
				
				_virtualpathtemplate = value;
			}
		}
			
		public virtual short? AppFileStorageTypeID
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
			
		public virtual Guid FileUUID
		{
			get
			{ 
				return _fileuuid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for FileUUID", value, "null");

				_fileuuid = value;
			}

		}
			
		public virtual string FileTitle
		{
			get
			{ 
				return _filetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for FileTitle", value, value.ToString());
				
				_filetitle = value;
			}
		}
			
		public virtual short? AppEntityID
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.AppFileID;
			
        }
		
		#endregion //Public Functions
	}
}
