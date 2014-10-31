using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.BaseInfo
{
    public class ProcessInfo
    {
        private List<Processes> processList = new List<Processes>();

        public List<Processes> ProcessList
        {
            get { return processList; }
            set { processList = value; }
        }

        public ProcessInfo()
        {
            this.processList = GetProcesses();
        }

        public ProcessInfo(IPAddress address, int port)
        {

        }

        private List<Processes> GetProcesses()
        {
            List<Processes> list = new List<Processes>();

            Process[] processCollection = Process.GetProcesses();


            foreach (Process item in processCollection)
            {
                Processes processes = new Processes();

                processes.ProcessId = item.Id.ToString();
                processes.ProcessName = item.ProcessName;
                processes.ProcessUser = GetUserName(item.Id.ToString());
                processes.ProcessMemory = item.PrivateMemorySize64 / 1024 + "K";
                list.Add(processes);
            }

            return list;
        }

        public string GetUserName(string pId)
        {
            SelectQuery q = new SelectQuery("Select * from Win32_Process WHERE processID=" + pId);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(q);
            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;

                    inPar = disk.GetMethodParameters("GetOwner");
                    outPar = disk.InvokeMethod("GetOwner", inPar, null);
                    return outPar["User"].ToString();
                    break;
                }
            }
            catch
            {
                return "system";
            }
            return "system";
        }
    }
}
