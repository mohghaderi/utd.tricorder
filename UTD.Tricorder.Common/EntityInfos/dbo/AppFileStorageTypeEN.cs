using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class AppFileStorageTypeEN : EntityInfoBase
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


				this.EntityColumns.Add(vAppFileStorageType.ColumnNames.AppFileStorageTypeID,
                new ColumnInfo() { 
								Name= vAppFileStorageType.ColumnNames.AppFileStorageTypeID,
								Caption=new i18nText("Common.ENInfo.AppFileStorageType.AppFileStorageTypeID.Caption", "App File Storage Type"),
								DataTypeDotNet=typeof(short), 
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
			
				this.EntityColumns.Add(vAppFileStorageType.ColumnNames.AppFileStorageTypeTitle,
                new ColumnInfo() { 
								Name= vAppFileStorageType.ColumnNames.AppFileStorageTypeTitle,
								Caption=new i18nText("Common.ENInfo.AppFileStorageType.AppFileStorageTypeTitle.Caption", "App File Storage Type Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 200,
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
			
				this.EntityColumns.Add(vAppFileStorageType.ColumnNames.AppFileStorageSettings,
                new ColumnInfo() { 
								Name= vAppFileStorageType.ColumnNames.AppFileStorageSettings,
								Caption=new i18nText("Common.ENInfo.AppFileStorageType.AppFileStorageSettings.Caption", "App File Storage Settings"),
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
			

            this.EntityTitle = "App File Storage Type";
            this.IDFieldName = "AppFileStorageTypeID";
            this.CodeFieldName = "";
            this.TitleFieldName = "AppFileStorageTypeTitle";

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
		public static IAppFileStorageTypeService GetService(string additionalDataKey = "")
		{
			return (IAppFileStorageTypeService) EntityFactory.GetEntityServiceByName(vAppFileStorageType.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static AppFileStorageType GetEntityObjectT()
		{
			return (AppFileStorageType)EntityFactory.GetEntityObject(vAppFileStorageType.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vAppFileStorageType GetEntityObjectV()
		{
			return (vAppFileStorageType)EntityFactory.GetEntityObject(vAppFileStorageType.EntityName, GetSourceTypeEnum.View);
		}


	}
}

