using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class VitalValueBR : BusinessRuleBase<VitalValue, vVitalValue>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);
            VitalValue o = (VitalValue) entitySet;

            if (CheckUtils.DateTimeLessThanUtcNow(o.RecordDateTime, vVitalValue.ColumnNames.RecordDateTime, errors))
                CheckUtils.DateTimeIsInUnixRange(o.RecordDateTime, vVitalValue.ColumnNames.RecordDateTime, errors);
        }

		#endregion

    }
}

