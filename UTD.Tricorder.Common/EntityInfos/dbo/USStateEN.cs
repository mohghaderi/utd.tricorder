using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class USStateEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
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
            //this.DetailEntityTabs.Add("", "");
            this.TitleFieldName = vUSState.ColumnNames.StateName;
            this.CodeFieldName = vUSState.ColumnNames.StateNameAbbrev;
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vUSState.ColumnNames.USStateID,
                new ColumnInfo() { 
								Name= vUSState.ColumnNames.USStateID,
								Caption=new i18nText("Common.ENInfo.USState.USStateID.Caption", "U S State"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2,
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
			
				this.EntityColumns.Add(vUSState.ColumnNames.StateName,
                new ColumnInfo() { 
								Name= vUSState.ColumnNames.StateName,
								Caption=new i18nText("Common.ENInfo.USState.StateName.Caption", "State Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 250,
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
			
				this.EntityColumns.Add(vUSState.ColumnNames.StateNameAbbrev,
                new ColumnInfo() { 
								Name= vUSState.ColumnNames.StateNameAbbrev,
								Caption=new i18nText("Common.ENInfo.USState.StateNameAbbrev.Caption", "State Name Abbrev"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 10,
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
			

            this.EntityTitle = "U S State";
            this.IDFieldName = "USStateID";
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
		public static IUSStateService GetService(string additionalDataKey = "")
		{
			return (IUSStateService) EntityFactory.GetEntityServiceByName(vUSState.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static USState GetEntityObjectT()
		{
			return (USState)EntityFactory.GetEntityObject(vUSState.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vUSState GetEntityObjectV()
		{
			return (vUSState)EntityFactory.GetEntityObject(vUSState.EntityName, GetSourceTypeEnum.View);
		}


	}
}

