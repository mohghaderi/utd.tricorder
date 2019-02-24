using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Business
{
    /// <summary>
    /// Common rules that should be checked in many entities are defined here
    /// it helps to keep business rules files shorter and with less bugs
    /// </summary>
    public class BusinessRulesCheckUtils
    {
        //TODO: "Check" should be removed from the function names
        //TODO: Error checking and adding should be easier and related to entity
        //TODO: Rename CheckUtils name to a simplier name
        //TODO: BusinessRuleErrorList errors should be removed totaly from method names

        private IBusinessRuleBase Business;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRulesCheckUtils"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public BusinessRulesCheckUtils(IBusinessRuleBase business)
        {
            Check.Require(business != null);
            Business = business;
        }


        /// <summary>
        /// Gets the field title.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        protected string GetFieldTitle(string fieldName)
        {
            if (Business.Entity.EntityColumns.ContainsKey(fieldName))
                return Business.Entity.EntityColumns[fieldName].Caption;
            else
                return fieldName;
        }

        /// <summary>
        /// Checks the string should not be null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldTitle">The field title.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckStringShouldNotBeNullOrEmpty(string fieldName, string value, BusinessRuleErrorList errors)
        {
            if (string.IsNullOrEmpty(value))
            {
                string fieldTitle = GetFieldTitle(fieldName);
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.StringNotNullOrEmpty, fieldTitle));
                return false;
            }
            return true;
        }


        /// <summary>
        /// Checks the string length between minimum and maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckStringLenBetweenMinAndMax(string fieldName, string value, BusinessRuleErrorList errors, int min, int max)
        {
            if (value != null)
            {
                if (!(value.Length >= min && value.Length <= max))
                {
                    errors.Add(fieldName,
                        string.Format(StringMsgs.BusinessErrors.StringLenBetweenMinMax, GetFieldTitle(fieldName), min, max)
                        );
                    return false;
                }
                return true;
            }

            return false;
        }


        /// <summary>
        /// Checks the int value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckIntBetweenMinMax(string fieldName, int value, BusinessRuleErrorList errors, int? minValue, int? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            int min = minValue.HasValue ? minValue.Value : int.MinValue;
            int max = minValue.HasValue ? maxValue.Value : int.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the long value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckLongBetweenMinMax(string fieldName, long value, BusinessRuleErrorList errors, long? minValue, long? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            long min = minValue.HasValue ? minValue.Value : long.MinValue;
            long max = minValue.HasValue ? maxValue.Value : long.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the double value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckDoubleBetweenMinMax(string fieldName, double value, BusinessRuleErrorList errors, double? minValue, double? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            double min = minValue.HasValue ? minValue.Value : double.MinValue;
            double max = minValue.HasValue ? maxValue.Value : double.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the float32 value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckFloatBetweenMinMax(string fieldName, float value, BusinessRuleErrorList errors, float? minValue, float? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            float min = minValue.HasValue ? minValue.Value : float.MinValue;
            float max = minValue.HasValue ? maxValue.Value : float.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the decimal value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckDecimalBetweenMinMax(string fieldName, decimal value, BusinessRuleErrorList errors, decimal? minValue, decimal? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            decimal min = minValue.HasValue ? minValue.Value : decimal.MinValue;
            decimal max = minValue.HasValue ? maxValue.Value : decimal.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the DateTime value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckDateTimeBetweenMinMax(string fieldName, DateTime value, BusinessRuleErrorList errors, DateTime? minValue, DateTime? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            DateTime min = minValue.HasValue ? minValue.Value : FWConsts.MinDateTime;
            DateTime max = minValue.HasValue ? maxValue.Value : FWConsts.MaxDateTime;

            // since date time can get a value more than .NET min and max,
            // we should check min and max all the time.

            //if (minValue.HasValue && maxValue.HasValue)
            //{
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            //}
            //if (minValue.HasValue && value < min)
            //{
            //    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
            //    return false;
            //}
            //if (maxValue.HasValue && value > max)
            //{
            //    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// Dates the time greater than now.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool DateTimeLessThanUtcNow(DateTime value, string fieldName, BusinessRuleErrorList errors)
        {
            return CheckDateTimeBetweenMinMax(fieldName, value, errors, null, DateTime.UtcNow);
        }

        /// <summary>
        /// Dates the time is in unix range.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool DateTimeIsInUnixRange(DateTime value, string fieldName, BusinessRuleErrorList errors)
        {
            return CheckDateTimeBetweenMinMax(fieldName, value, errors, DateTimeEpoch.UnixMinDate, DateTimeEpoch.UnixMaxDate);
        }

        /// <summary>
        /// Checks the short value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckShortBetweenMinMax(string fieldName, short value, BusinessRuleErrorList errors, short? minValue, short? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            short min = minValue.HasValue ? minValue.Value : short.MinValue;
            short max = minValue.HasValue ? maxValue.Value : short.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks the byte value between minimum maximum.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public bool CheckByteBetweenMinMax(string fieldName, byte value, BusinessRuleErrorList errors, byte? minValue, byte? maxValue)
        {
            if (minValue.HasValue == false && maxValue.HasValue == false)
                return true;

            byte min = minValue.HasValue ? minValue.Value : byte.MinValue;
            byte max = minValue.HasValue ? maxValue.Value : byte.MaxValue;

            if (minValue.HasValue && maxValue.HasValue)
            {
                if (!(value >= min && value <= max))
                {
                    errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueBetweenMinMax, GetFieldTitle(fieldName), min.ToString(), max.ToString()));
                    return false;
                }
            }
            if (minValue.HasValue && value < min)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMin, GetFieldTitle(fieldName), min.ToString()));
                return false;
            }
            if (maxValue.HasValue && value > max)
            {
                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueMax, GetFieldTitle(fieldName), max.ToString()));
                return false;
            }

            return true;
        }



        /// <summary>
        /// Checks the duplicate value not to be exists.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="idvalue">The idvalue.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="additionalFilter">The additional filter.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <param name="customErrorMessage">The custom error message.</param>
        /// <returns></returns>
        public bool CheckDuplicateValueNotToBeExists(string fieldName, object value, object idvalue, BusinessRuleErrorList errors, Filter additionalFilter, bool isInsert, string customErrorMessage)
        {
            if (value == null)
                return true;
            if (isInsert == false)
                Check.Require(idvalue != null, "idvalue can not be null when CheckDuplicateValueNotToBeExists is called in update mode.");

            if (string.IsNullOrEmpty(customErrorMessage))
                customErrorMessage = StringMsgs.BusinessErrors.DuplicateValueExists;

            FilterExpression filter = new FilterExpression(new Filter(fieldName, value));
            if (additionalFilter != null)
                filter.AddFilter(additionalFilter);

            if (isInsert == false) // in the case of update, we check against id
            {
                filter.AddFilter(new Filter(this.Business.Entity.IDFieldName, idvalue, FilterOperatorEnum.NotEqualTo));
                Check.Ensure(idvalue != null, "No value provided for id.");
            }

            var count = Business.GetCount(filter);
            if (count > 0)
            {
                errors.Add(fieldName, string.Format(customErrorMessage, GetFieldTitle(fieldName)));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the duplicate value not to be exists.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="idvalue">The idvalue.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="additionalFilter">The additional filter.</param>
        /// <param name="isInsert">if set to <c>true</c> [is insert].</param>
        /// <param name="customErrorMessage">The custom error message.</param>
        /// <returns></returns>
        public bool CheckDuplicateTwoKeyNotToBeExists(object entitySet, string fieldName1, string fieldName2, string idFieldName, BusinessRuleErrorList errors, Filter additionalFilter, bool isInsert, string customErrorMessage)
        {
            Check.Require(string.IsNullOrEmpty(fieldName1) == false, "CheckDuplicateTwoKeyNotToBeExists fieldName1 can't be empty");
            Check.Require(string.IsNullOrEmpty(fieldName2) == false, "CheckDuplicateTwoKeyNotToBeExists fieldName2 can't be empty");
            if (isInsert == false)
                Check.Require(string.IsNullOrEmpty(idFieldName) == false, "idvalue can not be null when CheckDuplicateTwoKeyNotToBeExists is called in update mode.");

            object f1Value = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, fieldName1);
            object f2Value = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, fieldName2);

            if (string.IsNullOrEmpty(customErrorMessage))
                customErrorMessage = StringMsgs.BusinessErrors.DuplicateTwoKeyValueExists;

            FilterExpression filter = new FilterExpression(new Filter(fieldName1, f1Value));
            filter.AddFilter(fieldName2, f2Value);
            if (additionalFilter != null)
                filter.AddFilter(additionalFilter);

            if (isInsert == false) // in the case of update, we check against id
            {
                object idvalue = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, idFieldName);
                filter.AddFilter(new Filter(this.Business.Entity.IDFieldName, idvalue, FilterOperatorEnum.NotEqualTo));
                Check.Ensure(idvalue != null, "No value provided for id.");
            }

            var count = Business.GetCount(filter);
            if (count > 0)
            {
                errors.Add(fieldName1, string.Format(customErrorMessage, GetFieldTitle(fieldName1)));
                //errors.Add(fieldName2, string.Format(customErrorMessage, GetFieldTitle(fieldName2)));
                return false;
            }
            return true;
        }



        public bool CheckNotEqual(object fieldValue, object value, string fieldName, BusinessRuleErrorList errors)
        {
            if (fieldValue.Equals(value))
            {
                string valueString = "null";
                if (value != null)
                    valueString = value.ToString();

                errors.Add(fieldName, string.Format(StringMsgs.BusinessErrors.ValueNotEqual, GetFieldTitle(fieldName), valueString));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks that a dependant entity doesn't exists
        /// </summary>
        /// <param name="entityName">dependant entity name</param>
        /// <param name="adk">additional data key</param>
        /// <param name="filter">filter to check existance</param>
        /// <param name="errors">errors</param>
        /// <param name="customErrorMessage">custom error message</param>
        /// <returns></returns>
        public bool CheckNoDependantRecordExists(string entityName, string adk, FilterExpression filter, BusinessRuleErrorList errors, string customErrorMessage)
        {
            var service = EntityFactory.GetEntityServiceByName(entityName, adk);
            if (service.GetCount(filter) > 0)
            {
                errors.Add(service.Entity.IDFieldName, customErrorMessage);
                return false;
            }
            return true;
        }


    }
}
