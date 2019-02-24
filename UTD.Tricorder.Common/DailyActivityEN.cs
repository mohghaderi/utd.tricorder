using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
    public class DailyActivityEN : EntityInfoBase
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


            this.EntityColumns.Add(vDailyActivity.ColumnNames.DailyActivityID,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.DailyActivityID,
                Caption = new i18nText("Common.ENInfo.DailyActivity.DailyActivityID.Caption", "Daily Activity"),
                DataTypeDotNet = typeof(Guid),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.None,
                IsPrimaryKey = true,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = true,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = false,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = false,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.UserID,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.UserID,
                Caption = new i18nText("Common.ENInfo.DailyActivity.UserID.Caption", "User"),
                DataTypeDotNet = typeof(long),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.ComboBox,
                IsPrimaryKey = false,
                IsForeignKey = true,
                ForeignEntityName = vUser.EntityName,
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = vUser.ColumnNames.UserID,
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = false,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.RecordDateTime,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.RecordDateTime,
                Caption = new i18nText("Common.ENInfo.DailyActivity.RecordDateTime.Caption", "Record Date Time"),
                DataTypeDotNet = typeof(int),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.NumericTextBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = true,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.DailyActivityTypeID,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.DailyActivityTypeID,
                Caption = new i18nText("Common.ENInfo.DailyActivity.DailyActivityTypeID.Caption", "Daily Activity Type"),
                DataTypeDotNet = typeof(int),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.ComboBox,
                IsPrimaryKey = false,
                IsForeignKey = true,
                ForeignEntityName = vDailyActivityType.EntityName,
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = vDailyActivityType.ColumnNames.DailyActivityTypeID,
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = false,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.IsManualEntry,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.IsManualEntry,
                Caption = new i18nText("Common.ENInfo.DailyActivity.IsManualEntry.Caption", "Is Manual Entry"),
                DataTypeDotNet = typeof(bool),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.CheckBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = true,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.AmountKCal,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.AmountKCal,
                Caption = new i18nText("Common.ENInfo.DailyActivity.AmountKCal.Caption", "Amount K Cal"),
                DataTypeDotNet = typeof(double),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.LargeNumberTextBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = true,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.DurationSeconds,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.DurationSeconds,
                Caption = new i18nText("Common.ENInfo.DailyActivity.DurationSeconds.Caption", "Duration Seconds"),
                DataTypeDotNet = typeof(int),
                ValidationMaxLength = 0,
                ValidationIsNullable = false,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.NumericTextBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = true,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.Comment,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.Comment,
                Caption = new i18nText("Common.ENInfo.DailyActivity.Comment.Caption", "Comment"),
                DataTypeDotNet = typeof(string),
                ValidationMaxLength = 1073741823,
                ValidationIsNullable = true,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.MultiLineTextBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = true,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });

            this.EntityColumns.Add(vDailyActivity.ColumnNames.ExternalEntityID,
            new ColumnInfo()
            {
                Name = vDailyActivity.ColumnNames.ExternalEntityID,
                Caption = new i18nText("Common.ENInfo.DailyActivity.ExternalEntityID.Caption", "External Entity"),
                DataTypeDotNet = typeof(long?),
                ValidationMaxLength = 0,
                ValidationIsNullable = true,
                ValidationMinValue = null,
                ValidationMaxValue = null,
                ValidationNoDuplicate = false,
                EditorControl = EditorControlTypes.LargeNumberTextBox,
                IsPrimaryKey = false,
                IsForeignKey = false,
                ForeignEntityName = "",
                ForeignEntityAdditionalDataKey = "",
                ForeignEntityMapColumnName = "",
                IsClientColumn = false,
                IsInsertable = true,
                IsUpdatable = true,
                PickListVisible = false,
                GridAllowFilter = true,
                GridColumnSize = 100,
                GridIsInplaceEditable = false,
                GridVisible = false,
                GridIsAutoExpand = false,
                GridTextAlign = TextAlignEnum.Default
            });


            this.EntityTitle = "Daily Activity";
            this.IDFieldName = "DailyActivityID";
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
        public static IDailyActivityService GetService(string additionalDataKey = "")
        {
            return (IDailyActivityService)EntityFactory.GetEntityServiceByName(vDailyActivity.EntityName, additionalDataKey);
        }

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
        public static DailyActivity GetEntityObjectT()
        {
            return (DailyActivity)EntityFactory.GetEntityObject(vDailyActivity.EntityName, GetSourceTypeEnum.Table);
        }

        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
        public static vDailyActivity GetEntityObjectV()
        {
            return (vDailyActivity)EntityFactory.GetEntityObject(vDailyActivity.EntityName, GetSourceTypeEnum.View);
        }


    }
}

