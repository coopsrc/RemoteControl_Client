using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public struct HostList
    {
        private IPAddress hostAddress;

        public IPAddress HostAddress
        {
            get { return hostAddress; }
            set { hostAddress = value; }
        }
        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        private string hostName;

        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string osName;

        public string OsName
        {
            get { return osName; }
            set { osName = value; }
        }
        private string cpuType;

        public string CpuType
        {
            get { return cpuType; }
            set { cpuType = value; }
        }
        private string memorySize;

        public string MemorySize
        {
            get { return memorySize; }
            set { memorySize = value; }
        }
        private string hardDiskSize;

        public string HardDiskSize
        {
            get { return hardDiskSize; }
            set { hardDiskSize = value; }
        }
        private string screenSize;

        public string ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }
        private string videoStatus;

        public string VideoStatus
        {
            get { return videoStatus; }
            set { videoStatus = value; }
        }

        public HostList(IPAddress hostAddress, string location, string hostName, string userName, string osName, string cpuType, string memorySize, string hardDiskSize, string screenSize, string videoStatus)
        {
            this.hostAddress = hostAddress;
            this.location = location;
            this.hostName = hostName;
            this.userName = userName;
            this.osName = osName;
            this.cpuType = cpuType;
            this.memorySize = memorySize;
            this.hardDiskSize = hardDiskSize;
            this.screenSize = screenSize;
            this.videoStatus = videoStatus;
        }

    }
}
