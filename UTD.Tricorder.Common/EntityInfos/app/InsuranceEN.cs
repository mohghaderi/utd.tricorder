using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class InsuranceEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            base.InitAdditionalDataKey(entityName, additionalDataKey);
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
            this.DetailEntities.Add(new EntityDetail(vInsurancePlan.EntityName, "", vInsurancePlan.ColumnNames.InsuranceID));
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vInsurance.ColumnNames.InsuranceID,
                new ColumnInfo() { 
								Name= vInsurance.ColumnNames.InsuranceID,
								Caption=new i18nText("Common.ENInfo.Insurance.InsuranceID.Caption", "Insurance"),
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
			
				this.EntityColumns.Add(vInsurance.ColumnNames.InsuranceName,
                new ColumnInfo() { 
								Name= vInsurance.ColumnNames.InsuranceName,
								Caption=new i18nText("Common.ENInfo.Insurance.InsuranceName.Caption", "Insurance Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 150,
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
			
				this.EntityColumns.Add(vInsurance.ColumnNames.IsDental,
                new ColumnInfo() { 
								Name= vInsurance.ColumnNames.IsDental,
								Caption=new i18nText("Common.ENInfo.Insurance.IsDental.Caption", "Is Dental"),
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
			
				this.EntityColumns.Add(vInsurance.ColumnNames.HasKid,
                new ColumnInfo() { 
								Name= vInsurance.ColumnNames.HasKid,
								Caption=new i18nText("Common.ENInfo.Insurance.HasKid.Caption", "Has Kid"),
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
			

            this.EntityTitle = "Insurance";
            this.IDFieldName = "InsuranceID";
            this.CodeFieldName = "";
            this.TitleFieldName = "InsuranceName";

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
		public static IInsuranceService GetService(string additionalDataKey = "")
		{
			return (IInsuranceService) EntityFactory.GetEntityServiceByName(vInsurance.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static Insurance GetEntityObjectT()
		{
			return (Insurance)EntityFactory.GetEntityObject(vInsurance.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vInsurance GetEntityObjectV()
		{
			return (vInsurance)EntityFactory.GetEntityObject(vInsurance.EntityName, GetSourceTypeEnum.View);
		}


	}
}

