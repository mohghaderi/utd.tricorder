using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IMedicalHistoryService : IServiceBaseT<MedicalHistory, vMedicalHistory>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Saves a section by its parameters
        /// </summary>
        /// <param name="p">parameters</param>
        void SaveSection(MedicalHistorySaveSectionSP p);
        
        /// <summary>
        /// Gets values of a section
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>s
        string GetSectionValues(MedicalHistoryGetSectionSP p);
		

		#endregion
    }
}

