using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class TestCaseTesterEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            base.InitAdditionalDataKey(entityName, additionalDataKey);

            this.HasScriptFile = true;
        }

		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vTestCaseTester.ColumnNames.TestCaseTesterID,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.TestCaseTesterID,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.TestCaseTesterID.Caption", "Test Case Tester"),
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.TestCaseTesterTitle,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.TestCaseTesterTitle,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.TestCaseTesterTitle.Caption", "Test Case Tester Title"),
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.TestCaseTesterCode,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.TestCaseTesterCode,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.TestCaseTesterCode.Caption", "Test Case Tester Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
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
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldGuid,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldGuid,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldGuid.Caption", "Field Guid"),
								DataTypeDotNet=typeof(Guid?), 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldByte,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldByte,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldByte.Caption", "Field Byte"),
								DataTypeDotNet=typeof(byte?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldInt16,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldInt16,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldInt16.Caption", "Field Int16"),
								DataTypeDotNet=typeof(short?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldInt32,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldInt32,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldInt32.Caption", "Field Int32"),
								DataTypeDotNet=typeof(int?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldInt64,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldInt64,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldInt64.Caption", "Field Int64"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldDouble,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldDouble,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldDouble.Caption", "Field Double"),
								DataTypeDotNet=typeof(double?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldFloat,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldFloat,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldFloat.Caption", "Field Float"),
								DataTypeDotNet=typeof(float?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldNtext,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldNtext,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldNtext.Caption", "Field Ntext"),
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldDateTime,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldDateTime,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldDateTime.Caption", "Field Date Time"),
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldByteArray50,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldByteArray50,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldByteArray50.Caption", "Field Byte Array50"),
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 50,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.FileUploader, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldVarByteArrayMax1024,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldVarByteArrayMax1024,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldVarByteArrayMax1024.Caption", "Field Var Byte Array Max1024"),
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 1024,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.FileUploader, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldDecimal,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldDecimal,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldDecimal.Caption", "Field Decimal"),
								DataTypeDotNet=typeof(decimal?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldString,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldString,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldString.Caption", "Field String"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 2147483647,
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.FieldTimeStamp,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.FieldTimeStamp,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.FieldTimeStamp.Caption", "Field Time Stamp"),
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 8,
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.InsertUser,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.InsertUser,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.InsertUser.Caption", "Insert User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.LargeNumberTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
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
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.InsertDate,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.InsertDate,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.InsertDate.Caption", "Insert Date"),
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
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.UpdateUser,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.UpdateUser,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.UpdateUser.Caption", "Update User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.LargeNumberTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
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
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vTestCaseTester.ColumnNames.UpdateDate,
                new ColumnInfo() { 
								Name= vTestCaseTester.ColumnNames.UpdateDate,
								Caption=new i18nText("Common.ENInfo.TestCaseTester.UpdateDate.Caption", "Update Date"),
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
			

            this.EntityTitle = "Test Case Tester";
            this.IDFieldName = "TestCaseTesterID";
            this.CodeFieldName = "TestCaseTesterCode";
            this.TitleFieldName = "TestCaseTesterTitle";

            this.Schema = "fwtest";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }
		
		
        /////////////////////////// Static access methods ////////////////////////

        /// <summary>
        /// Gets entity service from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <param name="additionalDataKey">additional data key. it can be empty</param>
        /// <returns>Entity service</returns>
		public static ITestCaseTesterService GetService(string additionalDataKey = "")
		{
			return (ITestCaseTesterService) EntityFactory.GetEntityServiceByName(vTestCaseTester.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static TestCaseTester GetEntityObjectT()
		{
			return (TestCaseTester)EntityFactory.GetEntityObject(vTestCaseTester.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vTestCaseTester GetEntityObjectV()
		{
			return (vTestCaseTester)EntityFactory.GetEntityObject(vTestCaseTester.EntityName, GetSourceTypeEnum.View);
		}


	}
}

