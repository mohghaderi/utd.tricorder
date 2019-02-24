using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class AppExceptionLogEN : EntityInfoBase
	{
	
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            this.EntityColumns[vAppExceptionLog.ColumnNames.DataInformation].GridVisible = false;
            this.EntityColumns[vAppExceptionLog.ColumnNames.Source].GridVisible = false;
            this.EntityColumns[vAppExceptionLog.ColumnNames.Target].GridVisible = false;
            this.EntityColumns[vAppExceptionLog.ColumnNames.ClassType].GridVisible = false;
            this.EntityColumns[vAppExceptionLog.ColumnNames.StackTrace].GridVisible = false;
            this.EntityColumns[vAppExceptionLog.ColumnNames.IPAddress].Caption = "IP";
        }


        #endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.AppExceptionLogID,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.AppExceptionLogID,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.AppExceptionLogID.Caption", "App Exception Log"),
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.Message,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.Message,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.Message.Caption", "Message"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
								ValidationIsNullable = false, 
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.Source,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.Source,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.Source.Caption", "Source"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.UserID,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.UserID,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.UserID.Caption", "User"),
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.InsertDate,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.InsertDate,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.InsertDate.Caption", "Insert Date"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 0,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.ClassType,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.ClassType,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.ClassType.Caption", "Class Type"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.StackTrace,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.StackTrace,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.StackTrace.Caption", "Stack Trace"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.Target,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.Target,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.Target.Caption", "Target"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.IPAddress,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.IPAddress,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.IPAddress.Caption", "I P Address"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.Url,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.Url,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.Url.Caption", "Url"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2048,
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
			
				this.EntityColumns.Add(vAppExceptionLog.ColumnNames.DataInformation,
                new ColumnInfo() { 
								Name= vAppExceptionLog.ColumnNames.DataInformation,
								Caption=new i18nText("Common.ENInfo.AppExceptionLog.DataInformation.Caption", "Data Information"),
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
			

            this.EntityTitle = "App Exception Log";
            this.IDFieldName = "AppExceptionLogID";
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
		public static IAppExceptionLogService GetService(string additionalDataKey = "")
		{
			return (IAppExceptionLogService) EntityFactory.GetEntityServiceByName(vAppExceptionLog.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static AppExceptionLog GetEntityObjectT()
		{
			return (AppExceptionLog)EntityFactory.GetEntityObject(vAppExceptionLog.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vAppExceptionLog GetEntityObjectV()
		{
			return (vAppExceptionLog)EntityFactory.GetEntityObject(vAppExceptionLog.EntityName, GetSourceTypeEnum.View);
		}


	}
}

