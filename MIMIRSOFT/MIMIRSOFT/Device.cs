using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMIRSOFT
{
    internal class Device
    {
        private string ipAddress;
        private string macAddress;
        private string domainName;
        private string adaptaterConstructor;
        private string info;
        private string firstDetection;
        private string lastDetection;
        
        public Device() { }

        public Device(string p_ipAddress, string p_macAddress, string p_domainName, string p_adaptaterConstructor, string p_info = "", string p_firstDetection = "", string p_lastDetection = "")
        {
            ipAddress = p_ipAddress;
            macAddress = p_macAddress;
            domainName = p_domainName;
            adaptaterConstructor = p_adaptaterConstructor;
            info = p_info;
            firstDetection = p_firstDetection;
            lastDetection = p_lastDetection;
            
        }

        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public string MacAddress
        {
            get { return macAddress; }
            set { macAddress = value; }
        }

        public string DomainName
        {
            get { return domainName; }
            set { domainName = value; }
        }

        public string AdaptatorConstructor
        {
            get { return adaptaterConstructor; }
            set { adaptaterConstructor = value; }
        } 
        
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        public string FirstDetection
        {
            get { return firstDetection; }
            set { firstDetection = value; }
        }

        public string LastDetection
        {
            get { return lastDetection; }
            set { lastDetection = value; }
        }

        /*public  bool Equals(Device anotherDevice)
        {
            if(this.IpAddress == anotherDevice.IpAddress)
            {
                if (this.MacAddress == anotherDevice.MacAddress)
                {
                    if (this.DomainName == anotherDevice.DomainName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }*/
    }
}
