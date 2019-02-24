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
	public partial class vStringText : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "StringText";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string StringTextID = "StringTextID";
			public const string KeyFullName = "KeyFullName";
			public const string ValueEn = "ValueEn";
			public const string SystemID = "SystemID";
			public const string NumberOfArguments = "NumberOfArguments";
			public const string InsertDate = "InsertDate";
			public const string LastUsedDate = "LastUsedDate";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("StringTextID");
			_ColumnsList.Add("KeyFullName");
			_ColumnsList.Add("ValueEn");
			_ColumnsList.Add("SystemID");
			_ColumnsList.Add("NumberOfArguments");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("LastUsedDate");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private Guid _stringtextid; 
		private string _keyfullname; 
		private string _valueen; 
		private int _systemid; 
		private byte _numberofarguments; 
		private DateTime _insertdate; 
		private DateTime _lastuseddate; 		
		#endregion

		#region Constructor

		public vStringText()
		 //: base()
		{
			_stringtextid = new Guid(); 
			_keyfullname = null; 
			_valueen = null; 
			_systemid = -1; 
			_numberofarguments = new byte(); 
			_insertdate = DateTime.MinValue; 
			_lastuseddate = DateTime.MinValue; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual Guid StringTextID
		{
			get
			{ 
				return _stringtextid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for StringTextID", value, "null");

				_stringtextid = value;
			}

		}
			
		public virtual string KeyFullName
		{
			get
			{ 
				return _keyfullname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for KeyFullName", value, "null");
				
				//if(  value.Length > 512)
				//	throw new ArgumentOutOfRangeException("Invalid value for KeyFullName", value, value.ToString());
				
				_keyfullname = value;
			}
		}
			
		public virtual string ValueEn
		{
			get
			{ 
				return _valueen;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ValueEn", value, "null");
				
				//if(  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for ValueEn", value, value.ToString());
				
				_valueen = value;
			}
		}
			
		public virtual int SystemID
		{
			get
			{ 
				return _systemid;
			}
			set
			{
				_systemid = value;
			}

		}
			
		public virtual byte NumberOfArguments
		{
			get
			{ 
				return _numberofarguments;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for NumberOfArguments", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for NumberOfArguments", value, value.ToString());
				
				_numberofarguments = value;
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
			
		public virtual DateTime LastUsedDate
		{
			get
			{ 
				return _lastuseddate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for LastUsedDate", value, value.ToString());

				_lastuseddate = value;	
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
            return this.StringTextID;
			
        }
		
		#endregion //Public Functions
	}
}
