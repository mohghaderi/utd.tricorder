using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class MobilePushNotificationEN : EntityInfoBase
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


				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.MobilePushNotificationID,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.MobilePushNotificationID,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.MobilePushNotificationID.Caption", "Mobile Push Notification"),
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.MobilePushTemplateID,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.MobilePushTemplateID,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.MobilePushTemplateID.Caption", "Mobile Push Template"),
								DataTypeDotNet=typeof(byte), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vMobilePushTemplate.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vMobilePushTemplate.ColumnNames.MobilePushTemplateID,
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.ParamsJSON,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.ParamsJSON,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.ParamsJSON.Caption", "Params J S O N"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 400,
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.TemplateParamsJSON,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.TemplateParamsJSON,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.TemplateParamsJSON.Caption", "Template Params J S O N"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 1073741823,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.MultiLineTextBox, 
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.ReceiverUserID,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.ReceiverUserID,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.ReceiverUserID.Caption", "Receiver User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.MobilePushNotificationStatusID,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.MobilePushNotificationStatusID,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.MobilePushNotificationStatusID.Caption", "Mobile Push Notification Status"),
								DataTypeDotNet=typeof(byte), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vNotificationStatus.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vNotificationStatus.ColumnNames.NotificationStatusID,
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.InsertDate,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.InsertDate,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.InsertDate.Caption", "Insert Date"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 27,
								ValidationIsNullable = false, 
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.ReceiverGroupName,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.ReceiverGroupName,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.ReceiverGroupName.Caption", "Receiver Group Name"),
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
			
				this.EntityColumns.Add(vMobilePushNotification.ColumnNames.SenderUserID,
                new ColumnInfo() { 
								Name= vMobilePushNotification.ColumnNames.SenderUserID,
								Caption=new i18nText("Common.ENInfo.MobilePushNotification.SenderUserID.Caption", "Sender User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
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
			

            this.EntityTitle = "Mobile Push Notification";
            this.IDFieldName = "MobilePushNotificationID";
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
		public static IMobilePushNotificationService GetService(string additionalDataKey = "")
		{
			return (IMobilePushNotificationService) EntityFactory.GetEntityServiceByName(vMobilePushNotification.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static MobilePushNotification GetEntityObjectT()
		{
			return (MobilePushNotification)EntityFactory.GetEntityObject(vMobilePushNotification.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vMobilePushNotification GetEntityObjectV()
		{
			return (vMobilePushNotification)EntityFactory.GetEntityObject(vMobilePushNotification.EntityName, GetSourceTypeEnum.View);
		}


	}
}

