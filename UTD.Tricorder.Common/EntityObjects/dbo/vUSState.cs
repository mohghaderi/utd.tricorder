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
	public partial class vUSState : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "USState";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string USStateID = "USStateID";
			public const string StateName = "StateName";
			public const string StateNameAbbrev = "StateNameAbbrev";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("USStateID");
			_ColumnsList.Add("StateName");
			_ColumnsList.Add("StateNameAbbrev");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private string _usstateid; 
		private string _statename; 
		private string _statenameabbrev; 		
		#endregion

		#region Constructor

		public vUSState()
		 //: base()
		{
			_usstateid = null; 
			_statename = null; 
			_statenameabbrev = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual string USStateID
		{
			get
			{ 
				return _usstateid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for USStateID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStateID", value, value.ToString());
				
				_usstateid = value;
			}
		}
			
		public virtual string StateName
		{
			get
			{ 
				return _statename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for StateName", value, "null");
				
				//if(  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateName", value, value.ToString());
				
				_statename = value;
			}
		}
			
		public virtual string StateNameAbbrev
		{
			get
			{ 
				return _statenameabbrev;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for StateNameAbbrev", value, "null");
				
				//if(  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateNameAbbrev", value, value.ToString());
				
				_statenameabbrev = value;
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
            return this.USStateID;
			
        }
		
		#endregion //Public Functions
	}
}
