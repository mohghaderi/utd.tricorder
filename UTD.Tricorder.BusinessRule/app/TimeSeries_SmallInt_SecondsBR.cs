//#DONT REGENERATE
using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class TimeSeries_SmallInt_SecondsBR : BusinessRuleBase<TimeSeries_SmallInt_Seconds, TimeSeries_SmallInt_Seconds>
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            TimeSeries_SmallInt_Seconds obj = (TimeSeries_SmallInt_Seconds)entitySet;
            if (fnName == RuleFunctionSEnum.Insert)
            {
                //TODO: Check related TimeSeriesStrip exists
                //TODO: Check date is greater than startdate in strip
                //TODO: Check strip is the lastest strip in database

                CheckUtils.CheckNotEqual(obj.TimeSeriesStripID, Guid.Empty,
                    TimeSeries_SmallInt_Seconds.ColumnNames.TimeSeriesStripID, errors);

                // typeid should be provided
                CheckUtils.CheckNotEqual(obj.TimeSeriesTypeID, 0,
                    TimeSeries_SmallInt_Seconds.ColumnNames.TimeSeriesTypeID, errors);

                // time should be in unix range
                int maxUtcEpoch = DateTimeEpoch.GetUtcNowEpoch();
                CheckUtils.CheckIntBetweenMinMax(TimeSeries_SmallInt_Seconds.ColumnNames.TSDateOffset, obj.TSDateOffset, errors, 
                    DateTimeEpoch.UnixMinDateSecondsEpoch, maxUtcEpoch);
            }
        }


        #endregion

    }
}

