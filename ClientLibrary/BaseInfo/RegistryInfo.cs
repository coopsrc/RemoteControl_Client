using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.BaseInfo
{
    public class RegistryInfo
    {
        private List<Registries> keyValue = new List<Registries>();
        public RegistryInfo()
        {

        }
        public RegistryInfo(RegistryKey key)
        {

        }

        public RegistryInfo(IPAddress address, int port)
        {

        }

        private List<Registries> GetKeyValue(RegistryKey key)
        {
            List<Registries> list = new List<Registries>();



            return list;
        }

        public string[] GetRootKey()
        {
            return Registry.ClassesRoot.GetSubKeyNames();
        }

        public string[] GetUserKey()
        {
            return Registry.CurrentUser.GetSubKeyNames();
        }

        public string[] GetMachineKey()
        {
            return Registry.LocalMachine.GetSubKeyNames();
        }

        public string[] GetUsersKey()
        {
            return Registry.Users.GetSubKeyNames();
        }

        public string[] GetConfigKey()
        {
            return Registry.CurrentConfig.GetSubKeyNames();
        }

        public string[] GetRootKeyValueNames()
        {
            return Registry.ClassesRoot.GetValueNames();
        }
        public string[] GetRootKeyValueNames(string key)
        {
            return Registry.ClassesRoot.GetValueNames();
        }

    }
}
