using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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

        public static string findDnsNameOfIpAddress(string IpAddress)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(IpAddress);
            return hostEntry.HostName;
        }
    }
}
