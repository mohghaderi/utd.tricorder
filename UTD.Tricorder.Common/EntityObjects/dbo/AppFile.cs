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
	public partial class AppFile : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public virtual string DownloadUrl
        {
            get;set;
        }

        public virtual string FileSizeUserFriendly
        {
            get {
                if (this.FileSize.HasValue)
                    return FWUtils.MiscUtils.GetReadableFileSize(this.FileSize.Value);
                else
                    return FWUtils.MiscUtils.GetReadableFileSize(0);
            }
        }

		#endregion

		#region Private Members

		private long _appfileid; private int _appfiletypeid;//0
//private AppFileType _appfiletypeid;//1

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
		private Guid? _extraguid; private short _appfileuploadstatusid;//0
//private AppFileUploadStatus _appfileuploadstatusid;//1

		private Guid _fileuuid; 
		private string _filetitle; 		
		#endregion

		#region Constructor

		public AppFile()
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
			_fileuuid = new Guid(); 
			_filetitle = null; 
		}

		public AppFile(
			long appfileid, 
			int appfiletypeid, 
			long appentityrecordidvalue, 
			long insertuserid, 
			DateTime insertdate, 
			byte[] versiontimestamp, 
			short appfileuploadstatusid, 
			Guid fileuuid)
			: this()
		{
			_appfileid = appfileid;
			_appfiletypeid = appfiletypeid;
			_appentityrecordidvalue = appentityrecordidvalue;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
			_filedate = null;
			_filename = String.Empty;
			_filetype = String.Empty;
			_filebytes = null;
			_filesize = null;
			_description = String.Empty;
			_versiontimestamp = versiontimestamp;
			_extrastring1 = String.Empty;
			_extrastring2 = String.Empty;
			_extraint = null;
			_extradouble = null;
			_extrabigint = null;
			_extraguid = null;
			_appfileuploadstatusid = appfileuploadstatusid;
			_fileuuid = fileuuid;
			_filetitle = String.Empty;
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
