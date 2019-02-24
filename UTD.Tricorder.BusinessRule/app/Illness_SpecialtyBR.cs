using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class BR : BusinessRuleBase<Illness_Specialty, vIllness_Specialty>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vIllness_Specialty.ColumnNames.SpecialtyID,
                vIllness_Specialty.ColumnNames.IllnessID,
                vIllness_Specialty.ColumnNames.Illness_SpecialtyID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }

		#endregion

    }
}

