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
	public partial class User_Language : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _user_languageid; 
		private long _userid; 
		private short _languageid; 		
		#endregion

		#region Constructor

		public User_Language()
		 //: base()
		{
			_user_languageid = -1; 
			_userid = -1; 
			_languageid = -1; 
		}

		public User_Language(
			long user_languageid, 
			long userid, 
			short languageid)
			: this()
		{
			_user_languageid = user_languageid;
			_userid = userid;
			_languageid = languageid;
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
