using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class FoodGroupSumEN : EntityInfoBase
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


		#endregion //Generator-Safe Area
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vFoodGroupSum.ColumnNames.FoodGroupID,
                new ColumnInfo() { 
								Name= vFoodGroupSum.ColumnNames.FoodGroupID,
								Caption=new i18nText("Common.ENInfo.FoodGroupSum.FoodGroupID.Caption", "Food Group"),
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
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=false,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vFoodGroupSum.ColumnNames.CalorieSum,
                new ColumnInfo() { 
								Name= vFoodGroupSum.ColumnNames.CalorieSum,
								Caption=new i18nText("Common.ENInfo.FoodGroupSum.CalorieSum.Caption", "Calorie Sum"),
								DataTypeDotNet=typeof(double?), 
								ValidationMaxLength= 0,
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
			
				this.EntityColumns.Add(vFoodGroupSum.ColumnNames.FatSum,
                new ColumnInfo() { 
								Name= vFoodGroupSum.ColumnNames.FatSum,
								Caption=new i18nText("Common.ENInfo.FoodGroupSum.FatSum.Caption", "Fat Sum"),
								DataTypeDotNet=typeof(double?), 
								ValidationMaxLength= 0,
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
			
				this.EntityColumns.Add(vFoodGroupSum.ColumnNames.CarbSum,
                new ColumnInfo() { 
								Name= vFoodGroupSum.ColumnNames.CarbSum,
								Caption=new i18nText("Common.ENInfo.FoodGroupSum.CarbSum.Caption", "Carb Sum"),
								DataTypeDotNet=typeof(double?), 
								ValidationMaxLength= 0,
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
			
				this.EntityColumns.Add(vFoodGroupSum.ColumnNames.ProteinSum,
                new ColumnInfo() { 
								Name= vFoodGroupSum.ColumnNames.ProteinSum,
								Caption=new i18nText("Common.ENInfo.FoodGroupSum.ProteinSum.Caption", "Protein Sum"),
								DataTypeDotNet=typeof(double?), 
								ValidationMaxLength= 0,
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
			

            this.EntityTitle = "Food Group Sum";
            this.IDFieldName = "";
            this.CodeFieldName = "";
            this.TitleFieldName = "";

            this.Schema = "app";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }
		
		
        /////////////////////////// Static access methods ////////////////////////

        /// <summary>
        /// Gets entity service from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <param name="additionalDataKey">additional data key. it can be empty</param>
        /// <returns>Entity service</returns>
		public static IFoodGroupSumService GetService(string additionalDataKey = "")
		{
			return (IFoodGroupSumService) EntityFactory.GetEntityServiceByName(vFoodGroupSum.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vFoodGroupSum GetEntityObjectT()
		{
			return (vFoodGroupSum)EntityFactory.GetEntityObject(vFoodGroupSum.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vFoodGroupSum GetEntityObjectV()
		{
			return (vFoodGroupSum)EntityFactory.GetEntityObject(vFoodGroupSum.EntityName, GetSourceTypeEnum.View);
		}


	}
}

