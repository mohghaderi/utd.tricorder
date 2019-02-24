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
	public partial class vUser_Language : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "User_Language";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string User_LanguageID = "User_LanguageID";
			public const string LanguageID = "LanguageID";
			public const string UserID = "UserID";
			public const string LanguageName = "LanguageName";
			public const string LanguageCode = "LanguageCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("User_LanguageID");
			_ColumnsList.Add("LanguageID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("LanguageName");
			_ColumnsList.Add("LanguageCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _user_languageid; 
		private short _languageid; 
		private long _userid; 
		private string _languagename; 
		private string _languagecode; 		
		#endregion

		#region Constructor

		public vUser_Language()
		 //: base()
		{
			_user_languageid = -1; 
			_languageid = -1; 
			_userid = -1; 
			_languagename = null; 
			_languagecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long User_LanguageID
		{
			get
			{ 
				return _user_languageid;
			}
			set
			{
				_user_languageid = value;
			}

		}
			
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
			
		public virtual long UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.User_LanguageID;
			
        }
		
		#endregion //Public Functions
	}
}
