using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class MembershipAreaEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vMembershipArea.ColumnNames.MembershipAreaID,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.MembershipAreaID,
								Caption=new i18nText("Common.ENInfo.MembershipArea.MembershipAreaID.Caption", "Membership Area"),
								DataTypeDotNet=typeof(long), 
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
			
				this.EntityColumns.Add(vMembershipArea.ColumnNames.ParentID,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.ParentID,
								Caption=new i18nText("Common.ENInfo.MembershipArea.ParentID.Caption", "Parent"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vMembershipArea.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vMembershipArea.ColumnNames.MembershipAreaID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMembershipArea.ColumnNames.MembershipAreaCode,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.MembershipAreaCode,
								Caption=new i18nText("Common.ENInfo.MembershipArea.MembershipAreaCode.Caption", "Membership Area Code"),
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
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMembershipArea.ColumnNames.MembershipAreaName,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.MembershipAreaName,
								Caption=new i18nText("Common.ENInfo.MembershipArea.MembershipAreaName.Caption", "Membership Area Name"),
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
			
				this.EntityColumns.Add(vMembershipArea.ColumnNames.ParentMembershipAreaName,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.ParentMembershipAreaName,
								Caption=new i18nText("Common.ENInfo.MembershipArea.ParentMembershipAreaName.Caption", "Parent Membership Area Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMembershipArea.ColumnNames.ParentMembershipAreaCode,
                new ColumnInfo() { 
								Name= vMembershipArea.ColumnNames.ParentMembershipAreaCode,
								Caption=new i18nText("Common.ENInfo.MembershipArea.ParentMembershipAreaCode.Caption", "Parent Membership Area Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			

            this.EntityTitle = "Membership Area";
            this.IDFieldName = "MembershipAreaID";
            this.CodeFieldName = "MembershipAreaCode";
            this.TitleFieldName = "MembershipAreaName";

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
		public static IMembershipAreaService GetService(string additionalDataKey = "")
		{
			return (IMembershipAreaService) EntityFactory.GetEntityServiceByName(vMembershipArea.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static MembershipArea GetEntityObjectT()
		{
			return (MembershipArea)EntityFactory.GetEntityObject(vMembershipArea.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vMembershipArea GetEntityObjectV()
		{
			return (vMembershipArea)EntityFactory.GetEntityObject(vMembershipArea.EntityName, GetSourceTypeEnum.View);
		}


	}
}

