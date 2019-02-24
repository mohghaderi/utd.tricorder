using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct DoctorScheduleAddBatchSP
    {
        public long DoctorID;
        public string[] SelectedTimes;
        public int SelectedDateUnixEpoch;
        public byte NumberOfAllowedPatients;
        public byte NumberOfRegisteredPatients;
        public byte DoctorScheduleVisitPlaceID;
    }


    public struct DoctorScheduleIsTimeAvailableSP
    {
        public long DoctorID;
        public int SelectedDateTimeUnixEpoch;
    }

    public struct DoctorScheduleGetTimeByDateSP
    {
        public long DoctorID;
        public int DateUnixEpoch;
    }

    public struct DoctorScheduleGetByRangeSP
    {
        public long DoctorID;
        public int StartUnixEpoch;
        public int EndUnixEpoch;
    }


    public struct DoctorScheduleCopyRangeSP
    {
        public long DoctorID;
        public int SourceUnixEpoch;
        public int NumberOfDays;
        public int DestinationUnixEpoch;
    }

    public struct DoctorScheduleDeleteRangeSP
    {
        public long DoctorID;
        public int StartUnixEpoch;
        public int EndUnixEpoch;
    }


}
