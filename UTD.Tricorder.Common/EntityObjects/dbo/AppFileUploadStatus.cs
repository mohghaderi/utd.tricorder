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
	public partial class AppFileUploadStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _appfileuploadstatusid;//3

		//private IList<AppFile> _AppFileList; 

		private string _appfileuploadstatustitle; 		
		#endregion

		#region Constructor

		public AppFileUploadStatus()
		 //: base()
		{
			_appfileuploadstatusid = -1; 
			//_AppFileList = new List<AppFile>(); 
			_appfileuploadstatustitle = null; 
		}

		public AppFileUploadStatus(
			short appfileuploadstatusid, 
			string appfileuploadstatustitle)
			: this()
		{
			_appfileuploadstatusid = appfileuploadstatusid;
			_appfileuploadstatustitle = appfileuploadstatustitle;
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

		//public virtual void AddAppFile(AppFile obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_AppFileList.Add(obj);
		//}
		


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
