using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.BaseInfo
{
    public class Processes
    {
        private string processId;
        public string ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }

        private string processName;
        public string ProcessName
        {
            get { return processName; }
            set { processName = value; }
        }

        private string processUser;
        public string ProcessUser
        {
            get { return processUser; }
            set { processUser = value; }
        }


        private string processMemory;
        public string ProcessMemory
        {
            get { return processMemory; }
            set { processMemory = value; }
        }
    }
}
