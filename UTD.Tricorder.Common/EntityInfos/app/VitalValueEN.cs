using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class VitalValueEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        public const string AdditionalData_MyVital = "MyVital";
        private const string Action_ShowCharts = "ShowCharts";

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            if (additionalDataKey == AdditionalData_MyVital)
            {
                this.EntityColumns[vVitalValue.ColumnNames.PersonID].GridVisible = false;
                this.EntityColumns[vVitalValue.ColumnNames.PersonID].PickListVisible = false;
            }

            this.EntityColumns[vVitalValue.ColumnNames.VitalTypeCode].GridVisible = false;
            this.EntityColumns[vVitalValue.ColumnNames.VitalTypeCode].PickListVisible = false;
            this.EntityColumns[vVitalValue.ColumnNames.AfterDecimalPointDigits].GridVisible = false;
            this.EntityColumns[vVitalValue.ColumnNames.AfterDecimalPointDigits].PickListVisible = false;
            this.EntityColumns[vVitalValue.ColumnNames.RecordDateTimeUnix].GridVisible = false;
            this.EntityColumns[vVitalValue.ColumnNames.RecordDateTimeUnix].PickListVisible = false;

            this.EditFormHeight = 280;
            this.EditFormWidth = 450;
            this.EntityTitle = "Vital Signs";
            this.EditFormTitle = "Vital Signs";

            //this.ActionsList.Add(new EntityAction() { Name = Action_ShowCharts, Caption = "Show Charts", Icon = FIcon.ChartLine });
        }



		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vVitalValue.ColumnNames.VitalValueID,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.VitalValueID,
								Caption=new i18nText("Common.ENInfo.VitalValue.VitalValueID.Caption", "Vital Value"),
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.PersonID,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.PersonID,
								Caption=new i18nText("Common.ENInfo.VitalValue.PersonID.Caption", "Person"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vPerson.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vPerson.ColumnNames.PersonID,
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.DataValue,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.DataValue,
								Caption=new i18nText("Common.ENInfo.VitalValue.DataValue.Caption", "Data Value"),
								DataTypeDotNet=typeof(double), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.LargeNumberTextBox, 
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.RecordDateTime,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.RecordDateTime,
								Caption=new i18nText("Common.ENInfo.VitalValue.RecordDateTime.Caption", "Record Date Time"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 27,
								ValidationIsNullable = false, 
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.VitalTypeID,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.VitalTypeID,
								Caption=new i18nText("Common.ENInfo.VitalValue.VitalTypeID.Caption", "Vital Type"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vVitalType.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vVitalType.ColumnNames.VitalTypeID,
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.IsManualEntry,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.IsManualEntry,
								Caption=new i18nText("Common.ENInfo.VitalValue.IsManualEntry.Caption", "Is Manual Entry"),
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.VitalTypeTitle,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.VitalTypeTitle,
								Caption=new i18nText("Common.ENInfo.VitalValue.VitalTypeTitle.Caption", "Vital Type Title"),
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.VitalTypeCode,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.VitalTypeCode,
								Caption=new i18nText("Common.ENInfo.VitalValue.VitalTypeCode.Caption", "Vital Type Code"),
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.AfterDecimalPointDigits,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.AfterDecimalPointDigits,
								Caption=new i18nText("Common.ENInfo.VitalValue.AfterDecimalPointDigits.Caption", "After Decimal Point Digits"),
								DataTypeDotNet=typeof(byte), 
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.RecordDateTimeUnix,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.RecordDateTimeUnix,
								Caption=new i18nText("Common.ENInfo.VitalValue.RecordDateTimeUnix.Caption", "Record Date Time Unix"),
								DataTypeDotNet=typeof(int?), 
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
			
				this.EntityColumns.Add(vVitalValue.ColumnNames.Comment,
                new ColumnInfo() { 
								Name= vVitalValue.ColumnNames.Comment,
								Caption=new i18nText("Common.ENInfo.VitalValue.Comment.Caption", "Comment"),
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
			

            this.EntityTitle = "Vital Value";
            this.IDFieldName = "VitalValueID";
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
		public static IVitalValueService GetService(string additionalDataKey = "")
		{
			return (IVitalValueService) EntityFactory.GetEntityServiceByName(vVitalValue.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static VitalValue GetEntityObjectT()
		{
			return (VitalValue)EntityFactory.GetEntityObject(vVitalValue.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vVitalValue GetEntityObjectV()
		{
			return (vVitalValue)EntityFactory.GetEntityObject(vVitalValue.EntityName, GetSourceTypeEnum.View);
		}


	}
}

