using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct MedicalHistorySaveSectionSP
    {
        /// <summary>
        /// name (or id) of the section
        /// </summary>
        public string SectionName;
        /// <summary>
        /// values of parameters in the section in Json format
        /// </summary>
        public string SectionValuesJson;

        /// <summary>
        /// Patient identifier
        /// </summary>
        public long PatientUserID;

    }


    /// <summary>
    /// Gets information of a section if available
    /// </summary>
    public struct MedicalHistoryGetSectionSP
    {
        public string SectionName;
        public long PatientUserID;
    }


}
