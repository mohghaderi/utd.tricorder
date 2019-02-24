using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Framework.Common;
using Framework.Common.Entity;


namespace UTD.Tricorder.Common.EntityObjects

{
	[Serializable]
	public partial class vRegion : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Region";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string RegionID = "RegionID";
			public const string RegionName = "RegionName";
			public const string ParentID = "ParentID";
			public const string RegionTypeID = "RegionTypeID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("RegionID");
			_ColumnsList.Add("RegionName");
			_ColumnsList.Add("ParentID");
			_ColumnsList.Add("RegionTypeID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _regionid; 
		private string _regionname; 
		private long? _parentid; 
		private int _regiontypeid; 		
		#endregion

		#region Constructor

		public vRegion()
		{
			_regionid = -1; 
			_regionname = String.Empty; 
			_parentid = null; 
			_regiontypeid = -1; 
		}

		public vRegion(
			long regionid, 
			string regionname, 
			int regiontypeid)
			: this()
		{
			_regionid = regionid;
			_regionname = regionname;
			_parentid = null;
			_regiontypeid = regiontypeid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long RegionID
		{
			get
			{ 
				return _regionid;
			}
			set
			{
				_regionid = value;
			}

		}
			
		public virtual string RegionName
		{
			get
			{ 
				return _regionname;
			}

			set	
			{	
				if( value == null )
					throw new ArgumentOutOfRangeException("Null value not allowed for RegionName", value, "null");
				
				if(  value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for RegionName", value, value.ToString());
				
				_regionname = value;
			}
		}
			
		public virtual long? ParentID
		{
			get
			{ 
				return _parentid;
			}
			set
			{
				_parentid = value;
			}

		}
			
		public virtual int RegionTypeID
		{
			get
			{ 
				return _regiontypeid;
			}
			set
			{
				_regiontypeid = value;
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
            return this.RegionID;
			
        }

		#endregion //Public Functions
	}
}
