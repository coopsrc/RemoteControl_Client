using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.BaseInfo
{
    public class Registries
    {
        private string registryName;

        public string RegistryName
        {
            get { return registryName; }
            set { registryName = value; }
        }
        private string registryType;

        public string RegistryType
        {
            get { return registryType; }
            set { registryType = value; }
        }
        private string registryData;

        public string RegistryData
        {
            get { return registryData; }
            set { registryData = value; }
        }
    }
}
