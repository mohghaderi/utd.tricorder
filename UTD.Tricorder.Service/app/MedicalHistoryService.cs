using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class MedicalHistoryService : ServiceBase<MedicalHistory, vMedicalHistory>, IMedicalHistoryService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Saves a section by its parameters
        /// </summary>
        /// <param name="p">parameters</param>
        public void SaveSection(MedicalHistorySaveSectionSP p)
        {
            MedicalHistory obj = GetMedicalHistoryFromDB(p.PatientUserID, p.SectionName);
            if (p.SectionValuesJson == null)
                p.SectionValuesJson = "{}"; // put empty json object to prevent business rule exception

            if (obj == null)
            {
                obj = new MedicalHistory();
                obj.PatientUserID = p.PatientUserID;
                obj.SectionName = p.SectionName;
                obj.SectionValuesJson = p.SectionValuesJson;

                Insert(obj);
            }
            else
            {
                obj.SectionValuesJson = p.SectionValuesJson;
                Update(obj);
            }
        }


        /// <summary>
        /// Gets values of a section
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>s
        public string GetSectionValues(MedicalHistoryGetSectionSP p)
        {
            MedicalHistory obj = GetMedicalHistoryFromDB(p.PatientUserID, p.SectionName);
            if (obj == null)
                return null;
            else
            {
                return obj.SectionValuesJson;
            }
        }

        /// <summary>
        /// Gets medical history records from the database
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private MedicalHistory GetMedicalHistoryFromDB(long patientId, string sectionName)
        {
            FilterExpression filter = new FilterExpression(vMedicalHistory.ColumnNames.PatientUserID, patientId);
            filter.AddFilter(vMedicalHistory.ColumnNames.SectionName, sectionName);

            IList<MedicalHistory> list = GetByFilterT(new GetByFilterParameters(filter));
            if (list.Count == 0) // no data found so insert
            {
                return null;
            }
            else
                return list[0];
        }


		#endregion

    }
}

