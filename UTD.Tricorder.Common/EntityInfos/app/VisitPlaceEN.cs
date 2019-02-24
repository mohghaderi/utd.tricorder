using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class VisitPlaceEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        public const string AdditionalDataKey_NotBoth = "NotBoth";

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
            if (additionalDataKey == AdditionalDataKey_NotBoth)
                this.DefaultFilter.AddFilter(new Filter(vVisitPlace.ColumnNames.VisitPlaceID, (int)EntityEnums.VisitPlaceEnum.Both, FilterOperatorEnum.NotEqualTo));
        }


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vVisitPlace.ColumnNames.VisitPlaceID,
                new ColumnInfo() { 
								Name= vVisitPlace.ColumnNames.VisitPlaceID,
								Caption=new i18nText("Common.ENInfo.VisitPlace.VisitPlaceID.Caption", "Visit Place"),
								DataTypeDotNet=typeof(byte), 
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
			
				this.EntityColumns.Add(vVisitPlace.ColumnNames.VisitPlaceTitle,
                new ColumnInfo() { 
								Name= vVisitPlace.ColumnNames.VisitPlaceTitle,
								Caption=new i18nText("Common.ENInfo.VisitPlace.VisitPlaceTitle.Caption", "Visit Place Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
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
			
				this.EntityColumns.Add(vVisitPlace.ColumnNames.VisitPlaceIcon,
                new ColumnInfo() { 
								Name= vVisitPlace.ColumnNames.VisitPlaceIcon,
								Caption=new i18nText("Common.ENInfo.VisitPlace.VisitPlaceIcon.Caption", "Visit Place Icon"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
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
			

            this.EntityTitle = "Visit Place";
            this.IDFieldName = "VisitPlaceID";
            this.CodeFieldName = "";
            this.TitleFieldName = "VisitPlaceTitle";

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
		public static IVisitPlaceService GetService(string additionalDataKey = "")
		{
			return (IVisitPlaceService) EntityFactory.GetEntityServiceByName(vVisitPlace.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static VisitPlace GetEntityObjectT()
		{
			return (VisitPlace)EntityFactory.GetEntityObject(vVisitPlace.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vVisitPlace GetEntityObjectV()
		{
			return (vVisitPlace)EntityFactory.GetEntityObject(vVisitPlace.EntityName, GetSourceTypeEnum.View);
		}


	}
}

