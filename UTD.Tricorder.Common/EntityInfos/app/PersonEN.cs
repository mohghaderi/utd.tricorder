using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class PersonEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            base.InitAdditionalDataKey(entityName, additionalDataKey);
            this.HasScriptFile = true;
            this.TitleFieldName = vPerson.ColumnNames.LastName;
            this.CodeFieldName = vPerson.ColumnNames.UserName;

            this.DetailEntities.Add(new EntityDetail(vVitalValue.EntityName, "", vVitalValue.ColumnNames.PersonID) { TabCustomUrl = "~/UC/app/VitalValueChartForm.aspx?UserID={MasterRecordID}", EditType = DetailEntityTabViewEnum.CustomUrlTemplate });

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

            this.EntityColumns[vPerson.ColumnNames.NonUSStateTitle].Caption = "State/Region";
            this.EntityColumns[vPerson.ColumnNames.USStateID].Caption = "State";
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vPerson.ColumnNames.PersonID,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.PersonID,
								Caption=new i18nText("Common.ENInfo.Person.PersonID.Caption", "Person"),
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.Birthday,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.Birthday,
								Caption=new i18nText("Common.ENInfo.Person.Birthday.Caption", "Birthday"),
								DataTypeDotNet=typeof(DateTime?), 
								ValidationMaxLength= 27,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.GenderTypeID,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.GenderTypeID,
								Caption=new i18nText("Common.ENInfo.Person.GenderTypeID.Caption", "Gender Type"),
								DataTypeDotNet=typeof(int?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vGenderType.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vGenderType.ColumnNames.GenderTypeID,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.UserName,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.UserName,
								Caption=new i18nText("Common.ENInfo.Person.UserName.Caption", "User Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.USStateID,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.USStateID,
								Caption=new i18nText("Common.ENInfo.Person.USStateID.Caption", "U S State"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUSState.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUSState.ColumnNames.USStateID,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.AddressLine1,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.AddressLine1,
								Caption=new i18nText("Common.ENInfo.Person.AddressLine1.Caption", "Address Line1"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 300,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.AddressLine2,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.AddressLine2,
								Caption=new i18nText("Common.ENInfo.Person.AddressLine2.Caption", "Address Line2"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 300,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.City,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.City,
								Caption=new i18nText("Common.ENInfo.Person.City.Caption", "City"),
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.ZipCode,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.ZipCode,
								Caption=new i18nText("Common.ENInfo.Person.ZipCode.Caption", "Zip Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 15,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.CountryID,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.CountryID,
								Caption=new i18nText("Common.ENInfo.Person.CountryID.Caption", "Country"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vCountry.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vCountry.ColumnNames.CountryID,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.StateTitle,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.StateTitle,
								Caption=new i18nText("Common.ENInfo.Person.StateTitle.Caption", "State Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 250,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.NonUSStateTitle,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.NonUSStateTitle,
								Caption=new i18nText("Common.ENInfo.Person.NonUSStateTitle.Caption", "Non U S State Title"),
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.StateName,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.StateName,
								Caption=new i18nText("Common.ENInfo.Person.StateName.Caption", "State Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 250,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.CountryName,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.CountryName,
								Caption=new i18nText("Common.ENInfo.Person.CountryName.Caption", "Country Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 200,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.FirstName,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.FirstName,
								Caption=new i18nText("Common.ENInfo.Person.FirstName.Caption", "First Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.LastName,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.LastName,
								Caption=new i18nText("Common.ENInfo.Person.LastName.Caption", "Last Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.NamePrefix,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.NamePrefix,
								Caption=new i18nText("Common.ENInfo.Person.NamePrefix.Caption", "Name Prefix"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 4,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.PhoneNumber,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.PhoneNumber,
								Caption=new i18nText("Common.ENInfo.Person.PhoneNumber.Caption", "Phone Number"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 18,
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
			
				this.EntityColumns.Add(vPerson.ColumnNames.Email,
                new ColumnInfo() { 
								Name= vPerson.ColumnNames.Email,
								Caption=new i18nText("Common.ENInfo.Person.Email.Caption", "Email"),
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
			

            this.EntityTitle = "Person";
            this.IDFieldName = "PersonID";
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
		public static IPersonService GetService(string additionalDataKey = "")
		{
			return (IPersonService) EntityFactory.GetEntityServiceByName(vPerson.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static Person GetEntityObjectT()
		{
			return (Person)EntityFactory.GetEntityObject(vPerson.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vPerson GetEntityObjectV()
		{
			return (vPerson)EntityFactory.GetEntityObject(vPerson.EntityName, GetSourceTypeEnum.View);
		}


	}
}

