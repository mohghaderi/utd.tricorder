using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class TimeSeriesStripBR : BusinessRuleBase<TimeSeriesStrip, vTimeSeriesStrip>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            TimeSeriesStrip obj = (TimeSeriesStrip)entitySet;
            if (fnName == RuleFunctionSEnum.Insert)
            {
                obj.EndDateOffset = obj.StartDateOffset;
                
                CheckUtils.CheckNotEqual(obj.TimeSeriesStripID, Guid.Empty, 
                    vTimeSeriesStrip.ColumnNames.TimeSeriesStripID, errors);

                CheckUtils.CheckNotEqual(obj.TimeSeriesTypeID, 0, 
                    vTimeSeriesStrip.ColumnNames.TimeSeriesTypeID, errors);
            }
        }
		

		#endregion

    }
}

