using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.BaseInfo
{
    public class SystemInfo
    {

        private string hostName = "";

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private string screenSize = "";

        public string ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }
        private string cpuType = "";

        public string CpuType
        {
            get { return cpuType; }
            set { cpuType = value; }
        }
        private string memorySize = "";

        public string MemorySize
        {
            get { return memorySize; }
            set { memorySize = value; }
        }
        private string diskSize = "";

        public string DiskSize
        {
            get { return diskSize; }
            set { diskSize = value; }
        }
        private string systemVersion = "";

        public string SystemVersion
        {
            get { return systemVersion; }
            set { systemVersion = value; }
        }
        private string userName = "";

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string path = "";

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public SystemInfo()
        {
            this.hostName = LocalHostInfo.HostName();
            this.screenSize = LocalHostInfo.ScreenSize();
            this.cpuType = LocalHostInfo.CPUType();
            this.memorySize = LocalHostInfo.MemorySize();
            this.diskSize = LocalHostInfo.HardDiskSize();
            this.systemVersion = LocalHostInfo.OSName();
            this.userName = LocalHostInfo.UserName();
            this.path = LocalHostInfo.SystemPaths();
        }

        public SystemInfo(IPAddress address, int port)
        {

        }
    }
}
