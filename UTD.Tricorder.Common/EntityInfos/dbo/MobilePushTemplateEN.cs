using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class MobilePushTemplateEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		//protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
		//{
			//base.InitAdditionalDataKey(entityName, additionalDataKey);
			//this.ContextName = "default";
			//this.SecurityResourceCode = this.EntityName;
			//this.AuditLogEnabled = true;
			//this.DefaultPageSize = 10;
			//this.HasScriptFile = false;
			//this.AllowInsert = false;
			//this.AllowUpdate = false;
			//this.AllowDelete = false;
			//this.HasPopupEdit = false;
			//this.HasInPlaceEdit = true;
			//this.AllowBatchUpdate = false;
			//this.DetailEntityTabs.Add("","");
		//}


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.MobilePushTemplateID,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.MobilePushTemplateID,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.MobilePushTemplateID.Caption", "Mobile Push Template"),
								DataTypeDotNet=typeof(byte), 
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
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.MobileNotificationTypeName,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.MobileNotificationTypeName,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.MobileNotificationTypeName.Caption", "Mobile Notification Type Name"),
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
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.Title,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.Title,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.Title.Caption", "Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.AlertText,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.AlertText,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.AlertText.Caption", "Alert Text"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.IsOneSufficient,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.IsOneSufficient,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.IsOneSufficient.Caption", "Is One Sufficient"),
								DataTypeDotNet=typeof(bool), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.CheckBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.SoundFileName,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.SoundFileName,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.SoundFileName.Caption", "Sound File Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.DelayWhileIdle,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.DelayWhileIdle,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.DelayWhileIdle.Caption", "Delay While Idle"),
								DataTypeDotNet=typeof(bool?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.CheckBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.TimeToLiveSeconds,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.TimeToLiveSeconds,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.TimeToLiveSeconds.Caption", "Time To Live Seconds"),
								DataTypeDotNet=typeof(int?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vMobilePushTemplate.ColumnNames.MobilePushDeliveryTypeID,
                new ColumnInfo() { 
								Name= vMobilePushTemplate.ColumnNames.MobilePushDeliveryTypeID,
								Caption=new i18nText("Common.ENInfo.MobilePushTemplate.MobilePushDeliveryTypeID.Caption", "Mobile Push Delivery Type"),
								DataTypeDotNet=typeof(byte), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vMobilePushDeliveryType.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vMobilePushDeliveryType.ColumnNames.MobilePushDeliveryTypeID,
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
			

            this.EntityTitle = "Mobile Push Template";
            this.IDFieldName = "MobilePushTemplateID";
            this.CodeFieldName = "";
            this.TitleFieldName = "";

            this.Schema = "dbo";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }
		
		
        /////////////////////////// Static access methods ////////////////////////

        /// <summary>
        /// Gets entity service from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <param name="additionalDataKey">additional data key. it can be empty</param>
        /// <returns>Entity service</returns>
		public static IMobilePushTemplateService GetService(string additionalDataKey = "")
		{
			return (IMobilePushTemplateService) EntityFactory.GetEntityServiceByName(vMobilePushTemplate.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static MobilePushTemplate GetEntityObjectT()
		{
			return (MobilePushTemplate)EntityFactory.GetEntityObject(vMobilePushTemplate.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vMobilePushTemplate GetEntityObjectV()
		{
			return (vMobilePushTemplate)EntityFactory.GetEntityObject(vMobilePushTemplate.EntityName, GetSourceTypeEnum.View);
		}


	}
}

