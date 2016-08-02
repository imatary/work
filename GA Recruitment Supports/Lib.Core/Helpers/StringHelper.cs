using System.Diagnostics;
using System.Reflection;
using System.Deployment.Application;
using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace Lib.Core.Helpers
{
    public static class StringHelper
    {
        public static string GetCurentAssemblyVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return fvi.FileVersion;
        }

        public static string GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private static Version GetRunningCurentVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

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
    }
}
