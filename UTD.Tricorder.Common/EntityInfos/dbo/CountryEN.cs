using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class CountryEN : EntityInfoBase
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
            this.TitleFieldName = vCountry.ColumnNames.CountryTitle;
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vCountry.ColumnNames.CountryID,
                new ColumnInfo() { 
								Name= vCountry.ColumnNames.CountryID,
								Caption=new i18nText("Common.ENInfo.Country.CountryID.Caption", "Country"),
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
			
				this.EntityColumns.Add(vCountry.ColumnNames.CountryName,
                new ColumnInfo() { 
								Name= vCountry.ColumnNames.CountryName,
								Caption=new i18nText("Common.ENInfo.Country.CountryName.Caption", "Country Name"),
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
			
				this.EntityColumns.Add(vCountry.ColumnNames.CountryTitle,
                new ColumnInfo() { 
								Name= vCountry.ColumnNames.CountryTitle,
								Caption=new i18nText("Common.ENInfo.Country.CountryTitle.Caption", "Country Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 200,
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
			

            this.EntityTitle = "Country";
            this.IDFieldName = "CountryID";
            this.CodeFieldName = "";
            this.TitleFieldName = "CountryTitle";

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
		public static ICountryService GetService(string additionalDataKey = "")
		{
			return (ICountryService) EntityFactory.GetEntityServiceByName(vCountry.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static Country GetEntityObjectT()
		{
			return (Country)EntityFactory.GetEntityObject(vCountry.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vCountry GetEntityObjectV()
		{
			return (vCountry)EntityFactory.GetEntityObject(vCountry.EntityName, GetSourceTypeEnum.View);
		}


	}
}

