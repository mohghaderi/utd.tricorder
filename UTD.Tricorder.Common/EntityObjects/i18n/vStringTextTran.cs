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
    public partial class vStringTextTran : EntityObjectBase, IFWStringTextTranObj
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public virtual string CultureName
        {
            get { return this.LanguageCode; }
        }

		#endregion


		public const string EntityName = "StringTextTran";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string StringTextTranID = "StringTextTranID";
			public const string StringTextID = "StringTextID";
			public const string TranValue = "TranValue";
			public const string LanguageID = "LanguageID";
			public const string IsAccepted = "IsAccepted";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string AcceptedUserID = "AcceptedUserID";
			public const string AcceptedDate = "AcceptedDate";
			public const string LanguageCode = "LanguageCode";
			public const string LanguageName = "LanguageName";
			public const string SuperLanguageID = "SuperLanguageID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("StringTextTranID");
			_ColumnsList.Add("StringTextID");
			_ColumnsList.Add("TranValue");
			_ColumnsList.Add("LanguageID");
			_ColumnsList.Add("IsAccepted");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("AcceptedUserID");
			_ColumnsList.Add("AcceptedDate");
			_ColumnsList.Add("LanguageCode");
			_ColumnsList.Add("LanguageName");
			_ColumnsList.Add("SuperLanguageID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _stringtexttranid; 
		private Guid _stringtextid; 
		private string _tranvalue; 
		private short _languageid; 
		private bool _isaccepted; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _accepteduserid; 
		private DateTime? _accepteddate; 
		private string _languagecode; 
		private string _languagename; 
		private short _superlanguageid; 		
		#endregion

		#region Constructor

		public vStringTextTran()
		 //: base()
		{
			_stringtexttranid = -1; 
			_stringtextid = new Guid(); 
			_tranvalue = null; 
			_languageid = -1; 
			_isaccepted = false; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_accepteduserid = null; 
			_accepteddate = null; 
			_languagecode = null; 
			_languagename = null; 
			_superlanguageid = -1; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long StringTextTranID
		{
			get
			{ 
				return _stringtexttranid;
			}
			set
			{
				_stringtexttranid = value;
			}

		}
			
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
			
		public virtual string TranValue
		{
			get
			{ 
				return _tranvalue;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TranValue", value, "null");
				
				//if(  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for TranValue", value, value.ToString());
				
				_tranvalue = value;
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
			
		public virtual bool IsAccepted
		{
			get
			{ 
				return _isaccepted;
			}
			set
			{
				_isaccepted = value;
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
			
		public virtual long? AcceptedUserID
		{
			get
			{ 
				return _accepteduserid;
			}
			set
			{
				_accepteduserid = value;
			}

		}
			
		public virtual DateTime? AcceptedDate
		{
			get
			{ 
				return _accepteddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for AcceptedDate", value, value.ToString());
						
				_accepteddate = value;	
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
			
		public virtual short SuperLanguageID
		{
			get
			{ 
				return _superlanguageid;
			}
			set
			{
				_superlanguageid = value;
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
            return this.StringTextTranID;
			
        }
		
		#endregion //Public Functions
	}
}
