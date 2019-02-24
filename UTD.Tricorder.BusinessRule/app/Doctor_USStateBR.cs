using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class Doctor_USStateBR : BusinessRuleBase<Doctor_USState, vDoctor_USState>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vDoctor_USState.ColumnNames.USStateID,
                vDoctor_USState.ColumnNames.DoctorID,
                vDoctor_USState.ColumnNames.Doctor_USStateID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }

		#endregion

    }
}

