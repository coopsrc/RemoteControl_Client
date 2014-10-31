using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLibrary.BaseInfo
{
    public static class LocalHostInfo
    {
        #region SystemInfo
        public static string HostName()
        {
            string hostName = Dns.GetHostName();
            return hostName;
        }
        public static string UserName()
        {
            string userName = Environment.GetEnvironmentVariable("UserName");
            return userName;
        }

        public static string OSName()
        {
            string osName = Environment.OSVersion.ToString();
            return osName;
        }
        public static string CPUType()
        {
            string cpuInfo = "";

            try
            {

                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");

                cpuInfo = rk.GetValue("ProcessorNameString").ToString();
            }
            catch
            {
                cpuInfo = "Unknow";
            }
            return cpuInfo;
        }

        public static string MemorySize()
        {
            ulong totalSize = 0;
            ulong freeSize = 0;

            ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject obj in mc.GetInstances())
            {
                if (obj["TotalVirtualMemorySize"] != null)
                    totalSize = (ulong)obj["TotalVirtualMemorySize"];

                if (obj["FreePhysicalMemory"] != null)
                    freeSize = (ulong)obj["FreePhysicalMemory"];
                break;
            }



            if (totalSize > 0)
            {
                return freeSize / 1024 + "M/" + totalSize / 1024 + "M";
            }
            else
            {
                return "Unknown";
            }
        }

        public static string HardDiskSize()
        {
            string hardDisk = null;
            string[] MyDrive = Environment.GetLogicalDrives();
            long s0 = 0, s1 = 0;
            foreach (string MyDriveLetter in MyDrive)
            {
                try
                {
                    DriveInfo MyDriveInfo = new DriveInfo(MyDriveLetter);
                    if (MyDriveInfo.DriveType == DriveType.CDRom || MyDriveInfo.DriveType == DriveType.Removable)
                        continue;
                    s0 += MyDriveInfo.TotalSize;
                    s1 += MyDriveInfo.TotalFreeSpace;
                }
                catch { }
            }
            hardDisk = (s1 / 1073741824).ToString() + "G/" + (s0 / 1073741824).ToString() + "G";
            return hardDisk;
        }

        public static string ScreenSize()
        {
            string screen = "";

            Rectangle rect = Screen.PrimaryScreen.Bounds;
            screen = rect.Width + " * " + rect.Height;

            return screen;
        }

        public static string SystemPaths()
        {
            string MyPaths = Environment.GetEnvironmentVariable("Path");
            return MyPaths;
        }
        #endregion

        #region ProcessInfo
        #endregion

        #region RegistryInfo
        #endregion
    }
}
