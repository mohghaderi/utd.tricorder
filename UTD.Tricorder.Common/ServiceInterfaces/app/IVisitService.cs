using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IVisitService : IServiceBaseT<Visit, vVisit>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Gets the visits by date.
        /// </summary>
        /// <param name="doctorId">doctor identifier</param>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns></returns>
        List<vVisit> GetDoctorVisitsByDate(long doctorId, DateTime selectedDate);


        /// <summary>
        /// Cancels a visit
        /// </summary>
        /// <param name="visitId">The visit identifier.</param>
        void CancelVisit(long visitId);



        /// <summary>
        /// Reschedules the visit.
        /// </summary>
        /// <param name="p">parameters</param>
        void RescheduleVisit(VisitRescheduleVisitSP p);



        ///// <summary>
        ///// Updates the doctor report.
        ///// </summary>
        ///// <param name="visitID">The visit identifier.</param>
        ///// <param name="doctorReport">The doctor report.</param>
        //void UpdateDoctorReport(long visitID, string doctorReport);

        /// <summary>
        /// Gets value of a section for a visit
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        string GetSectionValues(VisitGetSectionSP p);


        /// <summary>
        /// Saves the section information for one visit
        /// </summary>
        /// <param name="p">parameters</param>
        void SaveSection(VisitSaveSectionSP p);

        /// <summary>
        /// Completes a visit (changes status to end successfully)
        /// </summary>
        /// <param name="visitId">visit identifier</param>
        void CompleteVisit(long visitId);


        /// <summary>
        /// reverse visit status to scheduled
        /// </summary>
        /// <param name="visitId">visit identifier</param>
        void UndoStatusToRescheduled(long visitId);

		#endregion
    }
}

