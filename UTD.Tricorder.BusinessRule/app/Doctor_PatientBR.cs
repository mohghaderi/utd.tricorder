using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class Doctor_PatientBR : BusinessRuleBase<Doctor_Patient, vDoctor_Patient>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vDoctor_Patient.ColumnNames.DoctorID,
                vDoctor_Patient.ColumnNames.PatientUserID,
                vDoctor_Patient.ColumnNames.Doctor_PatientID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }

		#endregion

    }
}

