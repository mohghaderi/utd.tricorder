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
    public class DoctorService : ServiceBase<Doctor, vDoctor>, IDoctorService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Gets list of doctors by its phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public IList<vDoctor> SearchByClinicPhoneNumber(DoctorSearchByClinicPhoneNumberSP p)
        {
            string searchablePhoneNumber = UTD.Tricorder.Common.PhoneNumberUtils.MakeSearchablePhoneNumber(p.PhoneNumber);
            if (string.IsNullOrEmpty(searchablePhoneNumber) == false)
            {
                FilterExpression filter = new FilterExpression();
                filter.AddFilter(vDoctor.ColumnNames.ClinicPhoneNumberSearchable, searchablePhoneNumber, FilterOperatorEnum.Contains);

                SortExpression sort = new SortExpression(vDoctor.ColumnNames.LastName);

                List<string> columns = new List<string>();
                columns.Add(vDoctor.ColumnNames.NamePrefix);
                columns.Add(vDoctor.ColumnNames.FirstName);
                columns.Add(vDoctor.ColumnNames.LastName);
                columns.Add(vDoctor.ColumnNames.ClinicPhoneNumber);
                columns.Add(vDoctor.ColumnNames.ClinicAddress);
                columns.Add(vDoctor.ColumnNames.DoctorID);

                return GetByFilterV(new GetByFilterParameters(filter, sort, 0, 10, columns, GetSourceTypeEnum.View));
            }
            else
            {
                return new List<vDoctor>();
            }
        }



        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            foreach (EntityObjectBase entityObj in list)
            {
                long doctorId = (long) entityObj.GetPrimaryKeyValue();
                var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)doctorId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "DoctorProfilePicUrl", entityObj, doctorProfileImageUrl);
            }
        }


        protected override void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {
            var doctorProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)typedKeyObject);
            FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "DoctorProfilePicUrl", entityObj, doctorProfileImageUrl);
        }

		#endregion

    }
}

