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
	public partial class AppFileStorageType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _appfilestoragetypeid;//3

		//private IList<AppFileType> _AppFileTypeList; 

		private string _appfilestoragetypetitle; 
		private string _appfilestoragesettings; 		
		#endregion

		#region Constructor

		public AppFileStorageType()
		 //: base()
		{
			_appfilestoragetypeid = -1; 
			//_AppFileTypeList = new List<AppFileType>(); 
			_appfilestoragetypetitle = null; 
			_appfilestoragesettings = null; 
		}

		public AppFileStorageType(
			short appfilestoragetypeid, 
			string appfilestoragetypetitle)
			: this()
		{
			_appfilestoragetypeid = appfilestoragetypeid;
			_appfilestoragetypetitle = appfilestoragetypetitle;
			_appfilestoragesettings = String.Empty;
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
            return this.AppFileStorageTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
