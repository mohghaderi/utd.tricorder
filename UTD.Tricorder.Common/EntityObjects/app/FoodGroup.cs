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
	public partial class FoodGroup : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _foodgroupid;//3

		//private IList<FoodGroupItem> _FoodGroupItemList; 

		private long _userid; 
		private string _foodgrouptitle; 
		private byte _foodservingtimetypeid; 
		private bool _isgroupsaved; 
		private DateTime _recorddatetimeuserlocal; 		
		#endregion

		#region Constructor

		public FoodGroup()
		 //: base()
		{
			_foodgroupid = -1; 
			//_FoodGroupItemList = new List<FoodGroupItem>(); 
			_userid = -1; 
			_foodgrouptitle = null; 
			_foodservingtimetypeid = new byte(); 
			_isgroupsaved = false; 
			_recorddatetimeuserlocal = DateTime.MinValue; 
		}

		public FoodGroup(
			long foodgroupid, 
			long userid, 
			byte foodservingtimetypeid, 
			bool isgroupsaved, 
			DateTime recorddatetimeuserlocal)
			: this()
		{
			_foodgroupid = foodgroupid;
			_userid = userid;
			_foodgrouptitle = String.Empty;
			_foodservingtimetypeid = foodservingtimetypeid;
			_isgroupsaved = isgroupsaved;
			_recorddatetimeuserlocal = recorddatetimeuserlocal;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FoodGroupID
		{
			get
			{ 
				return _foodgroupid;
			}
			set
			{
				_foodgroupid = value;
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
			
		public virtual string FoodGroupTitle
		{
			get
			{ 
				return _foodgrouptitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodGroupTitle", value, value.ToString());
				
				_foodgrouptitle = value;
			}
		}
			
		public virtual byte FoodServingTimeTypeID
		{
			get
			{ 
				return _foodservingtimetypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodServingTimeTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodServingTimeTypeID", value, value.ToString());
				
				_foodservingtimetypeid = value;
			}

		}
			
		public virtual bool IsGroupSaved
		{
			get
			{ 
				return _isgroupsaved;
			}
			set
			{
				_isgroupsaved = value;
			}

		}
			
		public virtual DateTime RecordDateTimeUserLocal
		{
			get
			{ 
				return _recorddatetimeuserlocal;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecordDateTimeUserLocal", value, value.ToString());

				_recorddatetimeuserlocal = value;	
			}
					
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddFoodGroupItem(FoodGroupItem obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_FoodGroupItemList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.FoodGroupID;
			
        }
		
		#endregion //Public Functions
	}
}
