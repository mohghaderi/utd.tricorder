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
	public partial class vLanguage : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Language";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string LanguageID = "LanguageID";
			public const string LanguageCode = "LanguageCode";
			public const string LanguageName = "LanguageName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("LanguageID");
			_ColumnsList.Add("LanguageCode");
			_ColumnsList.Add("LanguageName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _languageid; 
		private string _languagecode; 
		private string _languagename; 		
		#endregion

		#region Constructor

		public vLanguage()
		 //: base()
		{
			_languageid = -1; 
			_languagecode = null; 
			_languagename = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short LanguageID
		{
			get
			{ 
				return _languageid;
			}
			set
			{
				_languageid = value;
			}

		}
			
		public virtual string LanguageCode
		{
			get
			{ 
				return _languagecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LanguageCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageCode", value, value.ToString());
				
				_languagecode = value;
			}
		}
			
		public virtual string LanguageName
		{
			get
			{ 
				return _languagename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LanguageName", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageName", value, value.ToString());
				
				_languagename = value;
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
            return this.LanguageID;
			
        }
		
		#endregion //Public Functions
	}
}
