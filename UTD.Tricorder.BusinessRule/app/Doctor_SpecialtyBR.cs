using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class Doctor_SpecialtyBR : BusinessRuleBase<Doctor_Specialty, vDoctor_Specialty>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vDoctor_Specialty.ColumnNames.SpecialtyID,
                vDoctor_Specialty.ColumnNames.DoctorID,
                vDoctor_Specialty.ColumnNames.Doctor_SpecialtyID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }
		

		#endregion

    }
}

