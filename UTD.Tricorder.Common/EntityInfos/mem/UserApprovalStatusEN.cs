using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class UserApprovalStatusEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vUserApprovalStatus.ColumnNames.UserApprovalStatusID,
                new ColumnInfo() { 
								Name= vUserApprovalStatus.ColumnNames.UserApprovalStatusID,
								Caption=new i18nText("Common.ENInfo.UserApprovalStatus.UserApprovalStatusID.Caption", "User Approval Status"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=true, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=true,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=false,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUserApprovalStatus.ColumnNames.UserApprovalStatusTitle,
                new ColumnInfo() { 
								Name= vUserApprovalStatus.ColumnNames.UserApprovalStatusTitle,
								Caption=new i18nText("Common.ENInfo.UserApprovalStatus.UserApprovalStatusTitle.Caption", "User Approval Status Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=true,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=true,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=true,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUserApprovalStatus.ColumnNames.UserApprovalStatusCode,
                new ColumnInfo() { 
								Name= vUserApprovalStatus.ColumnNames.UserApprovalStatusCode,
								Caption=new i18nText("Common.ENInfo.UserApprovalStatus.UserApprovalStatusCode.Caption", "User Approval Status Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=true,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=true,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			

            this.EntityTitle = "User Approval Status";
            this.IDFieldName = "UserApprovalStatusID";
            this.CodeFieldName = "UserApprovalStatusCode";
            this.TitleFieldName = "UserApprovalStatusTitle";

            this.Schema = "mem";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }
		
		
        /////////////////////////// Static access methods ////////////////////////

        /// <summary>
        /// Gets entity service from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <param name="additionalDataKey">additional data key. it can be empty</param>
        /// <returns>Entity service</returns>
		public static IUserApprovalStatusService GetService(string additionalDataKey = "")
		{
			return (IUserApprovalStatusService) EntityFactory.GetEntityServiceByName(vUserApprovalStatus.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static UserApprovalStatus GetEntityObjectT()
		{
			return (UserApprovalStatus)EntityFactory.GetEntityObject(vUserApprovalStatus.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vUserApprovalStatus GetEntityObjectV()
		{
			return (vUserApprovalStatus)EntityFactory.GetEntityObject(vUserApprovalStatus.EntityName, GetSourceTypeEnum.View);
		}


	}
}

