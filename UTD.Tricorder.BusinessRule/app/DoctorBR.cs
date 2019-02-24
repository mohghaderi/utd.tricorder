using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class DoctorBR : BusinessRuleBase<Doctor, vDoctor>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            if (entitySet is Doctor)
            {
                // setting ClinicPhoneSearchable phone
                Doctor obj = (Doctor)entitySet;
                if (fnName != RuleFunctionSEnum.Delete)
                    obj.ClinicPhoneNumberSearchable = UTD.Tricorder.Common.PhoneNumberUtils.MakeSearchablePhoneNumber(obj.ClinicPhoneNumber);
            }
            else
                throw new NotImplementedException();
        }


		#endregion

    }
}

