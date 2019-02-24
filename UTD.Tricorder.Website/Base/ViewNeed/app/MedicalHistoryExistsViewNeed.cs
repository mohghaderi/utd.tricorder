using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Website.Base.ViewNeed
{
    public class MedicalHistoryExistsViewNeed
    {
        public ViewNeedClass CheckNeed(long userId)
        {
            string[] requiredSections = { "Allergy", "Condition", "CurrentMed", "FamilyHistory", "Immunization" , "PastMed", "Sign", "Social" };

            var filter = new FilterExpression(vMedicalHistory.ColumnNames.PatientUserID, userId);
            List<string> columns = new List<string>();
            columns.Add(vMedicalHistory.ColumnNames.MedicalHistoryID);
            columns.Add(vMedicalHistory.ColumnNames.PatientUserID);
            columns.Add(vMedicalHistory.ColumnNames.SectionName);

            var items = MedicalHistoryEN.GetService().GetByFilterV(new GetByFilterParameters(filter, null, 0, int.MaxValue, columns, GetSourceTypeEnum.View));

            if (items.Count == requiredSections.Length) // since we store one record per view, we don't need to compute all
                return null;

            // creating list of available sections in the database
            List<string> filledSections = new List<string>();
            foreach(var item in items)
            {
                if (filledSections.Contains(item.SectionName) == false)
                    filledSections.Add(item.SectionName);
            }

            // finding unfilled section and returning the related view
            foreach (string requiredSection in requiredSections)
            {
                if (filledSections.Contains(requiredSection) == false)
                {
                    // redirecting to the related view (instead of the general form
                    string viewUrl = "MedicalHistory-" + requiredSection;
                    return new ViewNeedClass("You need a complete your medical history to access this form.", viewUrl);
                }
            }

            return null;
        }

    }
}