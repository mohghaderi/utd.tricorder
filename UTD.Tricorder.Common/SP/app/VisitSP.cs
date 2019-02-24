using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct VisitRescheduleVisitSP
    {
        /// <summary>
        /// The visit identifier.
        /// </summary>
        public long VisitID;
        /// <summary>
        /// The new doctor schedule identifier.
        /// </summary>
        public long NewDoctorScheduleID;
    }


    public struct VisitSaveSectionSP
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
        /// Visit identifier
        /// </summary>
        public long VisitID;

    }


    /// <summary>
    /// Gets information of a section if available
    /// </summary>
    public struct VisitGetSectionSP
    {
        /// <summary>
        /// section name
        /// </summary>
        public string SectionName;
        /// <summary>
        /// visit identifier
        /// </summary>
        public long VisitID;
    }




}
