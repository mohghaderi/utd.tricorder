using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class Doctor_InsuranceBR : BusinessRuleBase<Doctor_Insurance, vDoctor_Insurance>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vDoctor_Insurance.ColumnNames.InsurancePlanID,
                vDoctor_Insurance.ColumnNames.DoctorID,
                vDoctor_Insurance.ColumnNames.Doctor_InsuranceID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }

		#endregion

    }
}

