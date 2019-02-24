using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class InsurancePlanEN : EntityInfoBase
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


				this.EntityColumns.Add(vInsurancePlan.ColumnNames.InsurancePlanID,
                new ColumnInfo() { 
								Name= vInsurancePlan.ColumnNames.InsurancePlanID,
								Caption=new i18nText("Common.ENInfo.InsurancePlan.InsurancePlanID.Caption", "Insurance Plan"),
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
			
				this.EntityColumns.Add(vInsurancePlan.ColumnNames.InsuranceID,
                new ColumnInfo() { 
								Name= vInsurancePlan.ColumnNames.InsuranceID,
								Caption=new i18nText("Common.ENInfo.InsurancePlan.InsuranceID.Caption", "Insurance"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vInsurance.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vInsurance.ColumnNames.InsuranceID,
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
			
				this.EntityColumns.Add(vInsurancePlan.ColumnNames.InsurancePlanTitle,
                new ColumnInfo() { 
								Name= vInsurancePlan.ColumnNames.InsurancePlanTitle,
								Caption=new i18nText("Common.ENInfo.InsurancePlan.InsurancePlanTitle.Caption", "Insurance Plan Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 350,
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
			
				this.EntityColumns.Add(vInsurancePlan.ColumnNames.IsDental,
                new ColumnInfo() { 
								Name= vInsurancePlan.ColumnNames.IsDental,
								Caption=new i18nText("Common.ENInfo.InsurancePlan.IsDental.Caption", "Is Dental"),
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
			

            this.EntityTitle = "Insurance Plan";
            this.IDFieldName = "InsurancePlanID";
            this.CodeFieldName = "";
            this.TitleFieldName = "InsurancePlanTitle";

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
		public static IInsurancePlanService GetService(string additionalDataKey = "")
		{
			return (IInsurancePlanService) EntityFactory.GetEntityServiceByName(vInsurancePlan.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static InsurancePlan GetEntityObjectT()
		{
			return (InsurancePlan)EntityFactory.GetEntityObject(vInsurancePlan.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vInsurancePlan GetEntityObjectV()
		{
			return (vInsurancePlan)EntityFactory.GetEntityObject(vInsurancePlan.EntityName, GetSourceTypeEnum.View);
		}


	}
}

