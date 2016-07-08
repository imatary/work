using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Lib.Core.Helper
{
    public static class StringHelper
    {
        public static string GetInfo()
        {
            //System.Environment.MachineName
            //HttpContext.Current.Server.MachineName
            //System.Net.Dns.GetHostName()
            String pcName = System.Net.Dns.GetHostName();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string info = $"{userName} - {pcName} - {GetComputerLanIp()} - {GetMacAddress()}";
            return info;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }


        private static string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        /// <summary>
        /// Get computer LAN address like 192.168.1.3
        /// </summary>
        /// <returns></returns>
        private static string GetComputerLanIp()
        {
            string strHostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return ipAddress.ToString();
                }
            }
            return "-";
        }

        public static string LengthStaffCode(string staffCode)
        {
            string prefix = null;
            if (staffCode.Length == 1)
            {
                prefix = "0000" + staffCode;
            }
            else if (staffCode.Length == 2)
            {
                prefix = "000" + staffCode;
            }
            else if (staffCode.Length == 3)
            {
                prefix = "00" + staffCode;
            }
            else if (staffCode.Length == 4)
            {
                prefix = "0" + staffCode;
            }
            else if (staffCode.Length == 5)
            {
                prefix = staffCode;
            }
            if (prefix != null)
                return prefix;

            return staffCode;
        }
    }
}
