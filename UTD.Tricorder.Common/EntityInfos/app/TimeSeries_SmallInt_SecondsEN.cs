//#DONT REGENERATE
using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class TimeSeries_SmallInt_SecondsEN : EntityInfoBase
	{


        #region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        public const string AdditionalData_MyVital = "MyVital";


		#endregion

		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset,
                new ColumnInfo() { 
								Name= TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset,
								Caption="T S Date Offset",
								DataTypeDotNet=typeof(int), 
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
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=false,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValue,
                new ColumnInfo() { 
								Name= TimeSeries_SmallInt_Seconds.ColumnNames.TSValue,
								Caption="T S Value",
								DataTypeDotNet=typeof(short), 
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
			
				this.EntityColumns.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TimeSeriesTypeID,
                new ColumnInfo() { 
								Name= TimeSeries_SmallInt_Seconds.ColumnNames.TimeSeriesTypeID,
								Caption="Time Series Type",
								DataTypeDotNet=typeof(byte), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
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
			
				this.EntityColumns.Add(TimeSeries_SmallInt_Seconds.ColumnNames.UserID,
                new ColumnInfo() { 
								Name= TimeSeries_SmallInt_Seconds.ColumnNames.UserID,
								Caption="User",
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
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
			
				this.EntityColumns.Add(TimeSeries_SmallInt_Seconds.ColumnNames.TSValueBinary,
                new ColumnInfo() { 
								Name= TimeSeries_SmallInt_Seconds.ColumnNames.TSValueBinary,
								Caption="T S Value Binary",
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 2147483647,
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
			

            this.EntityTitle = "Time Series_ Small Int_ Seconds";
            this.IDFieldName = "";
            this.CodeFieldName = "";
            this.TitleFieldName = "";

            this.Schema = "app";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }



	}
}

