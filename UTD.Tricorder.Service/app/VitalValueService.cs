using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class VitalValueService : ServiceBase<VitalValue, vVitalValue>, IVitalValueService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void OnAfterInitialize()
        {
            //if (this.AdditionalDataKey == VitalValueEN.AdditionalData_MyVital)
            if (!FWUtils.SecurityUtils.HasRole(EntityEnums.RoleSEnum.SystemAdmin)
                || this.AdditionalDataKey == VitalValueEN.AdditionalData_MyVital)
                this.SecurityCheckers.Add(new MyRowEntitySecurity(this, vVitalValue.ColumnNames.PersonID, FWUtils.SecurityUtils.GetCurrentUserIDLong()));
        }

        /// <summary>
        /// Gets the chart all data.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="vitalTypeID">The vital type identifier.</param>
        /// <returns></returns>
        public List<vVitalValue> GetAllChartData(GetAllChartDataSP p)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vVitalValue.ColumnNames.PersonID, p.UserID));
            filter.AddFilter(new Filter(vVitalValue.ColumnNames.VitalTypeID, p.VitalTypeID));
            
            SortExpression sort = new SortExpression(vVitalValue.ColumnNames.RecordDateTime);

            List<string> columnNames = new List<string>();
            columnNames.Add(vVitalValue.ColumnNames.RecordDateTimeUnix);
            columnNames.Add(vVitalValue.ColumnNames.DataValue);

            var getp = new GetByFilterParameters(filter, sort, 0, 10000, columnNames, GetSourceTypeEnum.View);
            return (List<vVitalValue>)this.GetByFilter(getp);
        }




        /// <summary>
        /// Gets all chart data in json format.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="vitalValueTypeID">The vital value type identifier.</param>
        /// <returns></returns>
        public string GetAllChartDataJson(GetAllChartDataSP p)
        {
            IVitalTypeService vTypeService = (IVitalTypeService)EntityFactory.GetEntityServiceByName(vVitalType.EntityName, "");
            vVitalType vitalType = vTypeService.GetByIDV(p.VitalTypeID, new GetByIDParameters());

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var list = this.GetAllChartData(p);
            sb.Append("[");
            vVitalValue prevItem = null;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                VitalValueToJsonString(sb, item, vitalType, prevItem);
                if (i != list.Count - 1)
                    sb.Append(",");

                prevItem = item;
            }
            sb.Append("]");
            return sb.ToString();
        }

        private void VitalValueToJsonString(System.Text.StringBuilder sb, vVitalValue item, vVitalType vitalType, vVitalValue previousItem)
        {
            int recordDateTime = item.RecordDateTimeUnix.Value;
            double dataValue = item.DataValue;

            // compress by difference
            if (previousItem != null)
                recordDateTime = item.RecordDateTimeUnix.Value - previousItem.RecordDateTimeUnix.Value;
            //if (previousItem != null)
            //    dataValue = item.DataValue - previousItem.DataValue;

            string formattedValue = dataValue.ToString("F" + vitalType.AfterDecimalPointDigits.ToString());

            sb.Append("[")
                .Append(FWUtils.EntityUtils.ConvertObjectToString(recordDateTime))
                .Append(",")
                .Append(formattedValue)
                .Append("]");
        }


        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            VitalValue obj = (VitalValue)entitySet;

            if (this.AdditionalDataKey == VitalValueEN.AdditionalData_MyVital)
                obj.PersonID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            obj.RecordDateTime = DateTime.UtcNow;

            return true;
        }

		#endregion

    }
}

