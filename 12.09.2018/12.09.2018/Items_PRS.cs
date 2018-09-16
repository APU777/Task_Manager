using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._09._2018
{
    class Items_PRS
    {
        public Items_PRS (string _ProcessName, string _ProId, string _BasePriority, string _PriorityClass)
        {
            ProcessName = _ProcessName;

            ProcessId = _ProId;

            BasePriority = _BasePriority;

            PriorityClass = _PriorityClass;

        }


        public string ProcessName { get; set; }

        public string ProcessId { get; set; }

        public string BasePriority { get; set; }

        public string PriorityClass { get; set; }

    }
}
