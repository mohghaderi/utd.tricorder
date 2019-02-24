using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service
{
    public class Illness_SpecialtyService : ServiceBase<Illness_Specialty, vIllness_Specialty>, IIllness_SpecialtyService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets data by provided doctor's specialties
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
		public IList<vIllness_Specialty> GetByDoctorID(long DoctorID)
        {
            var service = Doctor_SpecialtyEN.GetService();
            var list = service.GetByDoctorID(DoctorID);
            FilterExpression filter = new FilterExpression();
            filter.LogicalOperator = FilterLogicalOperatorEnum.OR;
            foreach (var item in list)
            {
                filter.AddFilter(new Filter(vIllness_Specialty.ColumnNames.SpecialtyID, item.SpecialtyID));
            }

            SortExpression sort = new SortExpression(vIllness_Specialty.ColumnNames.IllnessTitle);

            return GetByFilterV(new GetByFilterParameters(filter, sort,0, int.MaxValue));
        }

		#endregion

    }
}

