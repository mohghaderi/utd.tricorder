using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class TimeSeriesStripEN : EntityInfoBase
	{
	
		#region Generator-Safe Area

        public const string AdditionalData_MyVital = "MyVital";

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
            //this.DetailEntityTabs.Add("", "");
            this.EntityColumns[vTimeSeriesStrip.ColumnNames.EndDateOffset].GridVisible = false;
            this.EntityColumns[vTimeSeriesStrip.ColumnNames.StartDateOffset].GridVisible = false;
            this.EntityColumns[vTimeSeriesStrip.ColumnNames.TimeSeriesTypeCode].GridVisible = false;
            this.EditFormUrl = "~/UC/app/TimeSeriesChartForm.aspx?TimeSeriesStripID={RecordID}&AdditionalDataKey={AdditionalDataKey}";
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.TimeSeriesStripID,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.TimeSeriesStripID,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.TimeSeriesStripID.Caption", "Time Series Strip"),
								DataTypeDotNet=typeof(Guid), 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.UserID,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.UserID,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.UserID.Caption", "User"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.StartDateOffset,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.StartDateOffset,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.StartDateOffset.Caption", "Start Date Offset"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.EndDateOffset,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.EndDateOffset,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.EndDateOffset.Caption", "End Date Offset"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.TimeSeriesTypeID,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.TimeSeriesTypeID,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.TimeSeriesTypeID.Caption", "Time Series Type"),
								DataTypeDotNet=typeof(byte), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vTimeSeriesType.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vTimeSeriesType.ColumnNames.TimeSeriesTypeID,
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.StartDateTime,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.StartDateTime,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.StartDateTime.Caption", "Start Date Time"),
								DataTypeDotNet=typeof(DateTime?), 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.EndDateTime,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.EndDateTime,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.EndDateTime.Caption", "End Date Time"),
								DataTypeDotNet=typeof(DateTime?), 
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.DurationSeconds,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.DurationSeconds,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.DurationSeconds.Caption", "Duration Seconds"),
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.TimeSeriesTypeName,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.TimeSeriesTypeName,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.TimeSeriesTypeName.Caption", "Time Series Type Name"),
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
			
				this.EntityColumns.Add(vTimeSeriesStrip.ColumnNames.TimeSeriesTypeCode,
                new ColumnInfo() { 
								Name= vTimeSeriesStrip.ColumnNames.TimeSeriesTypeCode,
								Caption=new i18nText("Common.ENInfo.TimeSeriesStrip.TimeSeriesTypeCode.Caption", "Time Series Type Code"),
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
			

            this.EntityTitle = "Time Series Strip";
            this.IDFieldName = "TimeSeriesStripID";
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
		public static ITimeSeriesStripService GetService(string additionalDataKey = "")
		{
			return (ITimeSeriesStripService) EntityFactory.GetEntityServiceByName(vTimeSeriesStrip.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static TimeSeriesStrip GetEntityObjectT()
		{
			return (TimeSeriesStrip)EntityFactory.GetEntityObject(vTimeSeriesStrip.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vTimeSeriesStrip GetEntityObjectV()
		{
			return (vTimeSeriesStrip)EntityFactory.GetEntityObject(vTimeSeriesStrip.EntityName, GetSourceTypeEnum.View);
		}


	}
}

