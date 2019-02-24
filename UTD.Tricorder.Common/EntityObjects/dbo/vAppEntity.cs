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
	public partial class vAppEntity : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppEntity";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppEntityID = "AppEntityID";
			public const string AppEntityName = "AppEntityName";
			public const string AppEntityADK = "AppEntityADK";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppEntityID");
			_ColumnsList.Add("AppEntityName");
			_ColumnsList.Add("AppEntityADK");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _appentityid; 
		private string _appentityname; 
		private string _appentityadk; 		
		#endregion

		#region Constructor

		public vAppEntity()
		 //: base()
		{
			_appentityid = -1; 
			_appentityname = null; 
			_appentityadk = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
            return this.AppEntityID;
			
        }
		
		#endregion //Public Functions
	}
}
