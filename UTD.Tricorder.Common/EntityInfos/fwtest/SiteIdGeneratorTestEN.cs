using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class SiteIdGeneratorTestEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vSiteIdGeneratorTest.ColumnNames.SiteIdGeneratorTestID,
                new ColumnInfo() { 
								Name= vSiteIdGeneratorTest.ColumnNames.SiteIdGeneratorTestID,
								Caption=new i18nText("Common.ENInfo.SiteIdGeneratorTest.SiteIdGeneratorTestID.Caption", "Site Id Generator Test"),
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
			
				this.EntityColumns.Add(vSiteIdGeneratorTest.ColumnNames.SiteIdGeneratorTestTitle,
                new ColumnInfo() { 
								Name= vSiteIdGeneratorTest.ColumnNames.SiteIdGeneratorTestTitle,
								Caption=new i18nText("Common.ENInfo.SiteIdGeneratorTest.SiteIdGeneratorTestTitle.Caption", "Site Id Generator Test Title"),
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
			

            this.EntityTitle = "Site Id Generator Test";
            this.IDFieldName = "SiteIdGeneratorTestID";
            this.CodeFieldName = "";
            this.TitleFieldName = "SiteIdGeneratorTestTitle";

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
		public static ISiteIdGeneratorTestService GetService(string additionalDataKey = "")
		{
			return (ISiteIdGeneratorTestService) EntityFactory.GetEntityServiceByName(vSiteIdGeneratorTest.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static SiteIdGeneratorTest GetEntityObjectT()
		{
			return (SiteIdGeneratorTest)EntityFactory.GetEntityObject(vSiteIdGeneratorTest.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vSiteIdGeneratorTest GetEntityObjectV()
		{
			return (vSiteIdGeneratorTest)EntityFactory.GetEntityObject(vSiteIdGeneratorTest.EntityName, GetSourceTypeEnum.View);
		}


	}
}

