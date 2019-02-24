using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class MedicalHistoryBR : BusinessRuleBase<MedicalHistory, vMedicalHistory>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            if (CheckUtils.CheckDuplicateTwoKeyNotToBeExists
                
                (entitySet
                , vMedicalHistory.ColumnNames.SectionName,
                vMedicalHistory.ColumnNames.PatientUserID,
                vMedicalHistory.ColumnNames.MedicalHistoryID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null) 
                
                == false)

                // the application shouldn't insert a medical history section when it is exists in the database
                throw new ImpossibleExecutionException("Medical history section is already saved by another user. Please re-save it.");


        }

		#endregion

    }
}

