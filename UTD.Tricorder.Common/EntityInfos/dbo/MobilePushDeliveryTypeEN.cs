using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class MobilePushDeliveryTypeEN : EntityInfoBase
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


		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vMobilePushDeliveryType.ColumnNames.MobilePushDeliveryTypeID,
                new ColumnInfo() { 
								Name= vMobilePushDeliveryType.ColumnNames.MobilePushDeliveryTypeID,
								Caption=new i18nText("Common.ENInfo.MobilePushDeliveryType.MobilePushDeliveryTypeID.Caption", "Mobile Push Delivery Type"),
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
			
				this.EntityColumns.Add(vMobilePushDeliveryType.ColumnNames.MobilePushDeliveryTypeName,
                new ColumnInfo() { 
								Name= vMobilePushDeliveryType.ColumnNames.MobilePushDeliveryTypeName,
								Caption=new i18nText("Common.ENInfo.MobilePushDeliveryType.MobilePushDeliveryTypeName.Caption", "Mobile Push Delivery Type Name"),
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
			

            this.EntityTitle = "Mobile Push Delivery Type";
            this.IDFieldName = "MobilePushDeliveryTypeID";
            this.CodeFieldName = "";
            this.TitleFieldName = "MobilePushDeliveryTypeName";

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
		public static IMobilePushDeliveryTypeService GetService(string additionalDataKey = "")
		{
			return (IMobilePushDeliveryTypeService) EntityFactory.GetEntityServiceByName(vMobilePushDeliveryType.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static MobilePushDeliveryType GetEntityObjectT()
		{
			return (MobilePushDeliveryType)EntityFactory.GetEntityObject(vMobilePushDeliveryType.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vMobilePushDeliveryType GetEntityObjectV()
		{
			return (vMobilePushDeliveryType)EntityFactory.GetEntityObject(vMobilePushDeliveryType.EntityName, GetSourceTypeEnum.View);
		}


	}
}

