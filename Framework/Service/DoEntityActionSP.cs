using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public struct DoEntityActionSP
    {
        public string recordId;
        public string actionName;
        public string parameters;
    }

    public struct DoBatchActionSP
    {
        public List<string> recordIds;
        public string actionName;
        public string parameters;
    }



}
