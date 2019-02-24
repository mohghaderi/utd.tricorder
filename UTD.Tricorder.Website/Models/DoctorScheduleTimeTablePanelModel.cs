using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Models
{
    public class DoctorScheduleTimeTablePanelModel
    {
        public string PanelTitle;
        public int StartHourIn24Format;
        public int EndHourIn24Format;
        public string AccordionID;
        public bool OpenByDefault;
    }
}