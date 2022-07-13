using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MIMIRSOFT
{
    internal class NetworkUtility
    {
        public static string getSubnetAddress(string ipaddress, string mask)
        {
            string[] Ipaddress = ipaddress.Split(".");
            string[] Mask = mask.Split(".");
            int[] subNetAddress = { Convert.ToInt32(Ipaddress[0]) & Convert.ToInt32(Mask[0]), Convert.ToInt32(Ipaddress[1]) & Convert.ToInt32(Mask[1]), Convert.ToInt32(Ipaddress[2]) & Convert.ToInt32(Mask[2]), Convert.ToInt32(Ipaddress[3]) & Convert.ToInt32(Mask[3]) };
            return Convert.ToString(subNetAddress[0]) + "." + Convert.ToString(subNetAddress[1]) + "." + Convert.ToString(subNetAddress[2]) + "." + Convert.ToString(subNetAddress[3]);

        }

        public static string getWildCardMask(string mask)
        {
            string[] Mask = mask.Split(".");
            int[] wildCard = { Convert.ToInt32(Mask[0]) ^ Convert.ToInt32("255"), Convert.ToInt32(Mask[1]) ^ Convert.ToInt32("255"), Convert.ToInt32(Mask[2]) ^ Convert.ToInt32("255"), Convert.ToInt32(Mask[3]) ^ Convert.ToInt32("255") };
            return Convert.ToString(wildCard[0]) + "." + Convert.ToString(wildCard[1]) + "." + Convert.ToString(wildCard[2]) + "." + Convert.ToString(wildCard[3]);
        }

        public static int getNumberOfAvailableAddresses(string WildCardMask)
        {
            string[] wildCardMask = WildCardMask.Split(".");
            string binaryWildCardMask = Convert.ToString(Convert.ToInt32(wildCardMask[0], 10), 2) + Convert.ToString(Convert.ToInt32(wildCardMask[1], 10), 2) + Convert.ToString(Convert.ToInt32(wildCardMask[2], 10), 2) + Convert.ToString(Convert.ToInt32(wildCardMask[3], 10), 2);
            return Convert.ToInt32(binaryWildCardMask, 2);
        }

        public static string generateIpAddress(string[] netWorkAddress, int hostNumber)
        {
            string hostBits = Convert.ToString(hostNumber, 2).PadLeft(32, '0');
            string[] hostPart = { hostBits.Substring(0, 8), hostBits.Substring(8, 8), hostBits.Substring(16, 8), hostBits.Substring(24, 8) };
            int[] IPaddress = { Convert.ToInt32(netWorkAddress[0]) | Convert.ToInt32(hostPart[0], 2), Convert.ToInt32(netWorkAddress[1]) | Convert.ToInt32(hostPart[1], 2), Convert.ToInt32(netWorkAddress[2]) | Convert.ToInt32(hostPart[2], 2), Convert.ToInt32(netWorkAddress[3]) | Convert.ToInt32(hostPart[3], 2) };
            return IPaddress[0] + "." + IPaddress[1] + "." + IPaddress[2] + "." + IPaddress[3] ;

        }

        public static string findNicConstructor(string macAddress)
        {

            string macPrefix = macAddress.Substring(0, 8).ToUpper();
            if (!macPrefix.Contains("-"))
            {
                macPrefix = macAddress.Substring(0, 6);
                foreach (string line in File.ReadLines(@"D:\PROJETS\MIMIRSOFT\macAdaptaterConstructor.txt"))
                {
                    if (line.Contains(macPrefix) & line.Contains("(base 16)"))
                    {
                        return line.Substring(22);
                    }
                }
            }
            else{
                foreach (string line in File.ReadLines(@"D:\PROJETS\MIMIRSOFT\macAdaptaterConstructor.txt"))
                {
                    if (line.Contains(macPrefix) & line.Contains("(hex)"))
                    {
                        return line.Substring(18);
                    }
                } 
            }
            return "";
        }

        public static string getDnsNameOfIpAddress(string IpAddress)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(IpAddress);
            return hostEntry.HostName;
        }

        public static string getMacAddress(string IpAddress)
        {
            string macAddress = string.Empty;
            Process ArpProcess = new Process();
            ArpProcess.StartInfo.FileName = "arp";
            ArpProcess.StartInfo.Arguments = "-a " + IpAddress;
            ArpProcess.StartInfo.UseShellExecute = false;
            ArpProcess.StartInfo.RedirectStandardOutput = true;
            ArpProcess.StartInfo.CreateNoWindow = true;
            ArpProcess.Start();
            string strOutput = ArpProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');

            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                         + "-" + substrings[7] + "-"
                         + substrings[8].Substring(0, 2);

            }
            return macAddress;
        }

        public static string getIPV4DefaultGatewayAdressOfAdaptater(NetworkInterface adapter)
        {
            string defaultGatewayIPAdress = "";
            GatewayIPAddressInformationCollection addresses = adapter.GetIPProperties().GatewayAddresses;
            if (addresses.Count > 0)
            {
                foreach (GatewayIPAddressInformation address in addresses)
                {
                    if(address.Address.AddressFamily == AddressFamily.InterNetwork){
                        defaultGatewayIPAdress = address.Address.ToString();
                    }
                    
                }
            }
            return defaultGatewayIPAdress;
        }

        public static string getIPV6DefaultGatewayAdressOfAdaptater(NetworkInterface adapter)
        {
            string defaultGatewayIPAdress = "";
            GatewayIPAddressInformationCollection addresses = adapter.GetIPProperties().GatewayAddresses;
            if (addresses.Count > 0)
            {
                foreach (GatewayIPAddressInformation address in addresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                       defaultGatewayIPAdress = address.Address.ToString();
                    }

                }
            }

            return defaultGatewayIPAdress;
        }

    }
}
